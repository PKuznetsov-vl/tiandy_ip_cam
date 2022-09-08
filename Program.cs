using FaceDemo;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace tiandy_ip_cam
{

    class Program
    {
        static void Main(string[] args)
        {
            var MC = new Program();
            MC.StartUp();
            MC.CamLogin();
            MC.GetFacePhotos();
        }

        public int m_iLogonId = -1;
        int iLocalListenPort = 8000;
        string CamIpAddr = "10.16.7.30";
        string Login = "admin";
        string Pass = "v1sionlabs";
        public int m_iLogonMode = NVSSDK.SERVER_NORMAL;
        private MAIN_NOTIFY_V4 MainNotify_V40 = null;
        private void StartUp()
        {
            //设置客户端和主控端所用的默认网络端口

            NVSSDK.NetClient_SetPort(3000, 6000);

            //设置消息通知ID
            //NVSSDK.NetClient_SetMSGHandle(SDKConstMsg.WM_MAIN_MESSAGE, this.Handle, SDKConstMsg.MSG_PARACHG, SDKConstMsg.MSG_ALARM);

            //设置SDK工作模式
            NVSSDK.NetClient_SetSDKWorkMode(NVSSDK.EASYX_LIGHT_MODE);

            //启动SDK
            NVSSDK.NetClient_Startup_V4(0, 0, 0);

            //设置主回调
           // MainNotify_V40 = MyMAIN_NOTIFY_V4;
            //NVSSDK.NetClient_SetNotifyFunction_V4(MainNotify_V40, null, null, null, null);


        }
        private void MyMAIN_NOTIFY_V4(UInt32 _ulLogonID, IntPtr _iWparam, IntPtr _iLParam, IntPtr _iUser)
        {
            switch (_iWparam.ToInt32())
            {
                //登陆状态消息 
                //param1 登陆IP
                //param2 登陆ID
                //param3 登陆状态
                case SDKConstMsg.WCM_LOGON_NOTIFY:
                    {
                        switch (_iLParam.ToInt32())
                        {
                            case SDKConstMsg.LOGON_SUCCESS:
                                //MessageBox.Show("Login successfully！notify_v4");
                                break;
                            case SDKConstMsg.LOGON_TIMEOUT:
                             Console.WriteLine("Login timeout！notify_v4");
                                break;
                            case SDKConstMsg.LOGON_FAILED:
                                Console.WriteLine("Login failed！notify_v4");
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case SDKConstMsg.WCM_FACE_MODEING:
                    {
                        FaceModeResult tRet = new FaceModeResult();
                        tRet = (FaceModeResult)Marshal.PtrToStructure(_iLParam, typeof(FaceModeResult));

                        if (tRet.iTotal > 0)
                        {
                            Win32API.PostMessage(_iUser, ClientControlMsg.WM_CLIENT_MODEING, tRet.iIndex, tRet.iTotal);
                        }
                        break;
                    }
                case SDKConstMsg.WCM_VCA_SUSPEND:
                    {
                        Win32API.PostMessage(_iUser, ClientControlMsg.WM_CLIENT_SUSPEND, 0, 0);
                        break;
                    }
               
                default:
                    break;
            }
        }
        private void CamLogin()
        {
            int iRet = -1;

            LogonPara tNormal = new LogonPara();
            tNormal.cNvsIP = new char[32];
            tNormal.cUserName = new char[16];
            tNormal.cUserPwd = new char[16];
            tNormal.iSize = Marshal.SizeOf(tNormal);
            CommonFunction.CharsCopy(CamIpAddr.ToCharArray(), tNormal.cNvsIP);
            CommonFunction.CharsCopy(Login.ToCharArray(), tNormal.cUserName);
            CommonFunction.CharsCopy(Pass.ToCharArray(), tNormal.cUserPwd);
            tNormal.iNvsPort = iLocalListenPort;
            IntPtr ptrNormal = Marshal.AllocHGlobal(Marshal.SizeOf(tNormal));
            Marshal.StructureToPtr(tNormal, ptrNormal, true);
            m_iLogonId = NVSSDK.NetClient_Logon_V4(NVSSDK.SERVER_NORMAL, ptrNormal, Marshal.SizeOf(tNormal));


            if (m_iLogonId < 0)
            {
                m_iLogonId = -1;
                Console.WriteLine("Logon failed!");
                return;
            }
            else
            { Console.WriteLine("Login success!"); }
            //NVSSDK.NetClient_SetNotifyUserData_V4(m_iLogonId, this.Handle);

            int iTimes = 0;
            while (0 != NVSSDK.NetClient_GetLogonStatus(m_iLogonId))
            {
                if (iTimes++ > 250)
                {
                    return;
                }
                Thread.Sleep(20);
            }

            int iChanNum = 0;
            NVSSDK.NetClient_GetChannelNum(m_iLogonId, ref iChanNum);
            string[] Channels = new string[iChanNum];

            for (int i = 0; i < iChanNum; ++i)
            {
                //Channels.Items.Insert(i, (i + 1).ToString());
                Channels[i] = (i + 1).ToString();
                Console.WriteLine("Ch{0}", Channels[i]);
            }
        }
        private static NetPicPara g_tNetPicPara = new NetPicPara();
        private static int g_iCount = 0;//接收的图片总张数
        const uint CONST_INVALID_RECV_ID = 0xffffffff;
        private static uint g_uiRecvID = CONST_INVALID_RECV_ID;//接收图片流的连接ID

        public IntPtr Handle { get; private set; }

        //private IntPtr Handle;

        private static int MyNetPicStreamNotify(UInt32 _uiRecvID, int _lCommand, IntPtr _pvCallBackInfo, Int32 _BufLen, IntPtr _iUser)
        {
            if (null == _pvCallBackInfo)
            {
                return -1;
            }

            if (_uiRecvID != g_uiRecvID)
            {
                return -1;
            }

            if (NVSSDK.NET_PICSTREAM_CMD_FACE == _lCommand)
            {
                IntPtr ptVca = _pvCallBackInfo;
                FacePicStream tFacePicStream = (FacePicStream)Marshal.PtrToStructure(ptVca, typeof(FacePicStream));
                FileStream pfFullPic = null;
                PicData tFullPicData = (PicData)Marshal.PtrToStructure(tFacePicStream.tFullData, typeof(PicData));
                PicTime tTime = tFullPicData.tPicTime;
                DateTime tDataTime = DateTime.Now;//先初始化为现在的时间以免当时间不合理的时候出现崩溃
                if (tFullPicData.iDataLen > 0)
                {
                    tDataTime = new DateTime((int)tTime.uiYear, (int)tTime.uiMonth, (int)tTime.uiDay,
    (int)tTime.uiHour, (int)tTime.uiMinute, (int)tTime.uiSecondsr, (int)tTime.uiMilliseconds);
                }

                //全景图
                try
                {
                    if (tFullPicData.iDataLen > 0)
                    {
                        string strFullPicName = ".\\FacePicStream\\FullPic-No" + (g_iCount++) + "-Time" + tDataTime.ToString("20yyMMddhhmmss") + ".jpg";
                        Console.WriteLine(strFullPicName);
                        pfFullPic = new FileStream(strFullPicName, FileMode.Create);
                        if (null != pfFullPic)
                        {
                            byte[] btFullPicData = new byte[tFullPicData.iDataLen];
                            Marshal.Copy(tFullPicData.piPicData, btFullPicData, 0, tFullPicData.iDataLen);//将非托管内存拷贝成托管内存，才能在c#里面使用    
                            pfFullPic.Write(btFullPicData, 0, tFullPicData.iDataLen);
                        };
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (null != pfFullPic)
                    {
                        pfFullPic.Close();
                    }
                }

                //人脸小图和人脸底图
                for (int i = 0; i < tFacePicStream.iFaceCount; ++i)
                {
                    FacePicData tFacePicData = (FacePicData)Marshal.PtrToStructure(tFacePicStream.tFaceData[i], typeof(FacePicData));

                    FileStream pfFaceFile = null;
                    try
                    {
                        if (tFacePicData.iDataLen > 0)
                        {
                            //人脸小图
                            string strFacePicName = ".\\FacePicStream\\FacePic-No" + (g_iCount++) + "-Time" + tDataTime.ToString("20yyMMddhhmmss") + ".jpg";
                            pfFaceFile = new FileStream(strFacePicName, FileMode.Create);
                            if (null != pfFaceFile)
                            {
                                byte[] btFacePicData = new byte[tFacePicData.iDataLen];
                                Marshal.Copy(tFacePicData.pPicData, btFacePicData, 0, tFacePicData.iDataLen);//将非托管内存拷贝成托管内存，才能在c#里面使用 
                                pfFaceFile.Write(btFacePicData, 0, tFacePicData.iDataLen);
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        if (null != pfFaceFile)
                        {
                            pfFaceFile.Close();
                        }
                    }

                    //人脸底图
                    if (1 == tFacePicData.iAlramType)	//有人脸底图
                    {
                        FileStream pfNegFile = null;
                        try
                        {
                            if (tFacePicData.iNegPicLen > 0)
                            {
                                string strNegPicName = ".\\FacePicStream\\NegPic-No" + (g_iCount++) + "-Time" + tDataTime.ToString("20yyMMddhhmmss") + "相似度-" + (tFacePicData.iSimilatity).ToString() + ".jpg";
                                pfNegFile = new FileStream(strNegPicName, FileMode.Create);
                                if (null != pfNegFile)
                                {
                                    byte[] btNegPicData = new byte[tFacePicData.iNegPicLen];
                                    Marshal.Copy(tFacePicData.pcNegPicData, btNegPicData, 0, tFacePicData.iNegPicLen);//将非托管内存拷贝成托管内存，才能在c#里面使用 
                                    pfNegFile.Write(btNegPicData, 0, tFacePicData.iNegPicLen);
                                }

                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            if (null != pfNegFile)
                            {
                                pfNegFile.Close();
                            }
                        }
                    }
                }

                Win32API.PostMessage(_iUser, ClientControlMsg.WM_CLIENT_RECVPICNUM, 0, 0);
            }

            return 1;
        }
        private void GetFacePhotos()
        {

            


            if (!Directory.Exists("./tst"))
            {
                Console.WriteLine("Create Dir");
                Directory.CreateDirectory("./tst");
            }
            else { Console.WriteLine("Created"); }
            IntPtr ptNetPicPara = IntPtr.Zero;
            try
            {
                //开启图片流
                g_tNetPicPara.iStructLen = Marshal.SizeOf(g_tNetPicPara);
                g_tNetPicPara.iChannelNo = 0;
                g_tNetPicPara.cbkPicStreamNotify = MyNetPicStreamNotify;
                // g_tNetPicPara.pvUser = this.Handle;
                g_tNetPicPara.iPicType = 0;

                ptNetPicPara = Marshal.AllocHGlobal(Marshal.SizeOf(g_tNetPicPara));
                Marshal.StructureToPtr(g_tNetPicPara, ptNetPicPara, true);

                int iRet = NVSSDK.NetClient_StartRecvNetPicStream(m_iLogonId, ptNetPicPara, Marshal.SizeOf(g_tNetPicPara), ref g_uiRecvID);
                Console.WriteLine(iRet.ToString());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(ptNetPicPara);
            }
        }
    }
}