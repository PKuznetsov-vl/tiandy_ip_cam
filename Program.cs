using FaceDemo;
using RestSharp;
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


        private static NetPicPara g_tNetPicPara = new NetPicPara();
        private static int g_iCount = 0;//Общее количество полученных снимков
        const uint CONST_INVALID_RECV_ID = 0xffffffff;
        private static uint g_uiRecvID = CONST_INVALID_RECV_ID;//Идентификатор соединения принимающего поток изображений
        public int m_iLogonId = -1;
        int iLocalListenPort = 8000;
        string CamIpAddr = "10.16.7.30";
        string Login = "admin";
        string Pass = "v1sionlabs";
        public int m_iLogonMode = NVSSDK.SERVER_NORMAL;
        private MAIN_NOTIFY_V4 MainNotify_V40 = null;
        private void StartUp()
        {
            //设置客户端和主控端所用的默认网络端口 Установите сетевой порт по умолчанию, используемый клиентом и ведущим

            NVSSDK.NetClient_SetPort(3000, 6000);

            NVSSDK.NetClient_SetSDKWorkMode(NVSSDK.EASYX_LIGHT_MODE);

            NVSSDK.NetClient_Startup_V4(0, 0, 0);

            MainNotify_V40 = MyMAIN_NOTIFY_V4;
            NVSSDK.NetClient_SetNotifyFunction_V4(MainNotify_V40, null, null, null, null);


        }
        private void MyMAIN_NOTIFY_V4(UInt32 _ulLogonID, IntPtr _iWparam, IntPtr _iLParam, IntPtr _iUser)
        {
            switch (_iWparam.ToInt32())
            {
                case SDKConstMsg.WCM_LOGON_NOTIFY:
                    {
                        switch (_iLParam.ToInt32())
                        {
                            case SDKConstMsg.LOGON_SUCCESS:
                                Console.WriteLine("Login successfully!");
                                break;
                            case SDKConstMsg.LOGON_TIMEOUT:
                                Console.WriteLine("Error Login timeout!");
                                throw new Exception("Login timeout! Check camera ip");
                             
                            case SDKConstMsg.LOGON_FAILED:
                                Console.WriteLine("Error Login failed");
                                throw new Exception("Error Login failed! Check you credentials");
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
        static void LunaRequest(byte[] fl)
        { 

            var client = new RestClient("http://10.16.30.20:5000");
           
            var request = new RestRequest("/6/handlers/2e457656-5071-4a56-9eed-339b36d73223/events", Method.Post);
            request.AddQueryParameter("user_data", "Hello");
            request.AddHeader("Luna-Account-Id", "6d071cca-fda5-4a03-84d5-5bea65904480");
         
            request.AddBody(fl, contentType: "image/jpeg");

            var response = client.Execute(request);
            var content = response.ThrowIfError();
            Console.WriteLine("st" + content);
           
        }

        private void CamLogin()
        {
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

                throw new Exception("Login failed!");
            }

        }


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
                Console.WriteLine("tst1" + tFacePicStream.iFaceCount.ToString());


                for (int i = 0; i < tFacePicStream.iFaceCount; ++i)
                {
                    FacePicData tFacePicData = (FacePicData)Marshal.PtrToStructure(tFacePicStream.tFaceData[i], typeof(FacePicData));

              
                    try
                    {
                        Console.WriteLine("tst" + tFacePicData.iDataLen.ToString());
                        if (tFacePicData.iDataLen > 0)
                        {
                            //人脸小图
                            string strFacePicName = ".\\FacePicStream\\FacePic-No" + (g_iCount++) + ".jpg";
                            //pfFaceFile = new FileStream(strFacePicName, FileMode.Create);
                            //мб это 
                            // Marshal.FreeHGlobal(ptNetPicPara);
                            byte[] btFacePicData = new byte[tFacePicData.iDataLen];

                            Marshal.Copy(tFacePicData.pPicData, btFacePicData, 0, tFacePicData.iDataLen);//управляемая память
                            LunaRequest(btFacePicData);
                           
                            // pfFaceFile.Write(btFacePicData, 0, tFacePicData.iDataLen);
                            /* if (null != pfFaceFile)
                             {
                                 byte[] btFacePicData = new byte[tFacePicData.iDataLen];

                                 Marshal.Copy(tFacePicData.pPicData, btFacePicData, 0, tFacePicData.iDataLen);//управляемая память
                                 LunaRequest(btFacePicData);
                                 pfFaceFile.Write(btFacePicData, 0, tFacePicData.iDataLen);
                             }*/
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                              
                }

                Win32API.PostMessage(_iUser, ClientControlMsg.WM_CLIENT_RECVPICNUM, 0, 0);
                //Console.WriteLine("api" + Win32API.PostMessage(_iUser, ClientControlMsg.WM_CLIENT_RECVPICNUM, 0, 0).ToString());
            }

            return 1;
        }
        private void GetFacePhotos()
        {
            IntPtr ptNetPicPara = IntPtr.Zero;
            try
            {
                //开启图片流
                g_tNetPicPara.iStructLen = Marshal.SizeOf(g_tNetPicPara);
                g_tNetPicPara.iChannelNo = 0;
                g_tNetPicPara.cbkPicStreamNotify = MyNetPicStreamNotify;
              // if( g_tNetPicPara.cbkPicStreamNotify)
                // g_tNetPicPara.pvUser = this.Handle;
                g_tNetPicPara.iPicType = 0;

                ptNetPicPara = Marshal.AllocHGlobal(Marshal.SizeOf(g_tNetPicPara));
                Marshal.StructureToPtr(g_tNetPicPara, ptNetPicPara, true);
                int iRet = 0;
                //todo rewrite
                while (iRet <= 1)
                {
                    iRet = NVSSDK.NetClient_StartRecvNetPicStream(m_iLogonId, ptNetPicPara, Marshal.SizeOf(g_tNetPicPara), ref g_uiRecvID);

                    if (iRet != -1)
                    { Console.WriteLine("Logging"); }
                }
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