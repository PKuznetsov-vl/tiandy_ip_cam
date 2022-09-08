using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FaceDemo
{
    class NVSSDK
    {  
        public const int SERVER_NORMAL = 0;
        public const int SERVER_ACTIVE = 1;

        public const int DSM_CMD_SET_NET_WAN_INFO = 0;	    //[ActiveNetWanInfo]local public network ip and port
        public const int DSM_CMD_SET_DIRECTORY_INFO	= 1;	//[ActiveDirectoryInfo]directory public network ip, port,account,password....
        public const int DSM_CMD_SET_NVSREG_CALLBACK = 2;

        public const int DSM_CMD_GET_ONLINE_STATE = 0;      // DsmOnline
        public const int DSM_CMD_GET_DEVICE_INFO = 0;       // DsmOnline
        public const int DSM_CMD_GET_REGISTER_COUNT = 1;
        public const int DSM_CMD_GET_REGISTER_DEVLIST = 2;

        public const int DSM_STATE_OFFLINE = 0;
        public const int DSM_STATE_ONLINE = 1;

        public const int MAX_PAGESIZE    =20;
        
        public const int TYPE_NVS        = 0;       //nvs
        public const int TYPE_PROXY      = 1;       //代理服务器
        public const int TYPE_CLIENT     = 2;       //待连接的客户端
        public const int TYPE_TRANSFER   = 3;       //视频转发关系
        public const int TYPE_ASSIGN     = 4;       //代理分配
        public const int TYPE_DNS        = 5;       //域名解析
        public const int TYPE_DS         = 6;       //二级注册中心
        public const int TYPE_P2P_NVS    = 7;       //p2p nvs
        public const int TPYE_P2P_CLIENT = 8;       //使用P2P连接方式的客户端


        public const int FACE_MAX_PAGE_COUNT        = 20;  
        public const int FACE_MAX_KEY_COUNT		    = 33;
        public const int FACE_MAX_FEATURE_COUNT	    = 10;
        public const int FACE_MAX_RECT_POINT_COUNT  = 10;
        public const int MAX_QUERY_LIST_COUNT = 32;
        public const int MAX_VCA_FILE_COUNT = 5;
        public const int MAX_VCA_ATTR_COunt = 32;

        //faceParam
        public const int FACE_CMD_MIN								= 0;	
        public const int FACE_CMD_EDIT								= (FACE_CMD_MIN + 0x00);
        public const int FACE_CMD_DELETE						    = (FACE_CMD_MIN + 0x01);
        public const int FACE_CMD_QUERY								= (FACE_CMD_MIN + 0x02);
        public const int FACE_CMD_MODEL								= (FACE_CMD_MIN + 0x03);
        public const int FACE_CMD_LIB_EDIT							= (FACE_CMD_MIN + 0x04);
        public const int FACE_CMD_LIB_DELETE						= (FACE_CMD_MIN + 0x05);
        public const int FACE_CMD_LIB_QUERY							= (FACE_CMD_MIN + 0x06);
        public const int FACE_CMD_FEATURE_QUERY						= (FACE_CMD_MIN + 0x07);
        public const int FACE_CMD_FEATURE_CALC						= (FACE_CMD_MIN + 0x08);
        public const int FACE_CMD_CUT								= (FACE_CMD_MIN + 0x09);
        public const int FACE_CMD_CUT_QUERY							= (FACE_CMD_MIN + 0x0A);
        public const int FACE_CMD_TASK_CREATE						= (FACE_CMD_MIN + 0x0B);
        public const int FACE_CMD_TASK_FREE							= (FACE_CMD_MIN + 0x0C);
        public const int FACE_CMD_LIB_IMPORT						= (FACE_CMD_MIN + 0x0D);
        public const int FACE_CMD_SEARCH							= (FACE_CMD_MIN + 0x0E);
        public const int FACE_CMD_LIB_SYNC_START				    = (FACE_CMD_MIN + 0x0F);
        public const int FACE_CMD_LIB_SYNC_STATUS					= (FACE_CMD_MIN + 0x10);
        public const int FACE_CMD_CUT_EX						    = (FACE_CMD_MIN + 0x11);
        public const int FACE_CMD_SEARCH_SNAP						= (FACE_CMD_MIN + 0x12);
        public const int FACE_CMD_SEARCH_SNAP_PROCESS				= (FACE_CMD_MIN + 0x13);
        public const int FACE_CMD_SEARCH_SNAP_RESULT 				= (FACE_CMD_MIN + 0x14);
        public const int FACE_CMD_ALARM_PARAM						= (FACE_CMD_MIN + 0x15);
        public const int FACE_CMD_MAX                               = (FACE_CMD_MIN + 0x16);

        //from now on, after code 10  alarm use the style sending directly,not switch code in SDK。chenbin@140719
        public const int  ALARM_TYPE_MIN                          = 0;
        public const int  ALARM_TYPE_VIDEO_LOST					  = (ALARM_TYPE_MIN + 0);   //Video loss
        public const int  ALARM_TYPE_PORT_ALARM                   = (ALARM_TYPE_MIN + 1);   //Port alarm            
        public const int  ALARM_TYPE_MOTION_DETECTION			  = (ALARM_TYPE_MIN + 2);   //Motion detection
        public const int  ALARM_TYPE_VIDEO_COVER                  = (ALARM_TYPE_MIN + 3);   //Video occlusion
        public const int  ALARM_TYPE_VCA						  = (ALARM_TYPE_MIN + 4);	//Intelligent analysis
        public const int  ALARM_TYPE_AUDIOLOST					  = (ALARM_TYPE_MIN + 5);	//Audio missing
        public const int  ALARM_TYPE_TEMPERATURE                  = (ALARM_TYPE_MIN + 6);	//Temperature and humidity
        public const int  ALARM_TYPE_ILLEGAL_DETECT               = (ALARM_TYPE_MIN + 7);	//Violation detection
        public const int  ALARM_TYPE_TEMPERATURE_UPPER_LIMIT	  = (ALARM_TYPE_MIN + 12);
        public const int  ALARM_TYPE_TEMPERATURE_LOWER_LIMIT	  = (ALARM_TYPE_MIN + 13);
        public const int  ALARM_TYPE_HUMIDITY_UPPER_LIMIT		  = (ALARM_TYPE_MIN + 14);
        public const int  ALARM_TYPE_HUMIDITY_LOWER_LIMIT		  = (ALARM_TYPE_MIN + 15);
        public const int  ALARM_TYPE_PRESSURE_UPPER_LIMIT		  = (ALARM_TYPE_MIN + 16);
        public const int  ALARM_TYPE_PRESSURE_LOWER_LIMIT		  = (ALARM_TYPE_MIN + 17);
        public const int  ALARM_TYPE_TEMPERATURE_HUMIDITY_FAULT   = (ALARM_TYPE_MIN + 19);	//Temperature and humidity fault alarm
        public const int  ALARM_TYPE_FACE_IDENT					  = (ALARM_TYPE_MIN + 20);
        public const int  ALARM_TYPE_NVR_VCA                      = (ALARM_TYPE_MIN + 21);
        public const int  ALARM_TYPE_MOLP						  = (ALARM_TYPE_MIN + 22);		//malicious occlusion license plate
        public const int  ALARM_TYPE_RAINFALL					  = (ALARM_TYPE_MIN + 23);		//rainfall alarm		
        public const int  ALARM_TYPE_ALERT_WATER_LEVEL			  = (ALARM_TYPE_MIN + 24);		//alert water level alarm
        public const int  ALARM_TYPE_SENSOR_ABNORMAL		      = (ALARM_TYPE_MIN + 25);		//Sensor abnormal alarm
        public const int  ALARM_TYPE_EXTERN_BUTTON				  = (ALARM_TYPE_MIN + 10000);	//external button alarm
        public const int  ALARM_TYPE_EXCPETION				      = (ALARM_TYPE_MIN + 100); //Abnormal alarm
        public const int  ALARM_TYPE_ALL						  = (ALARM_TYPE_MIN + 255); //All
        public const int  ALARM_TYPE_MAX                          = (ALARM_TYPE_ALL + 1);
        public const int  ALARM_TYPE_PORT_ALARM_OFF				  = (ALARM_TYPE_MIN + 1 + 256);//Port stop alarm

        public const int CMD_SET_ALARMSCHEDULE	            = 0;
        public const int CMD_SET_ALARMLINK		            = 1;
        public const int CMD_SET_ALARMSCH_ENABLE            = 2;
        public const int CMD_SET_ALARMTRIGGER	            = 3;
        public const int CMD_SET_ALARMLINK_V1	            = 4; 
        public const int CMD_SET_ALARMLINK_V2	            = 5;
        public const int CMD_SET_ALARMLINK_V3               = 6;	
        //Dynamic environment alarm configuration NetClient_SetAlarmConfig/ NetClient_GetAlarmConfig
        public const int CMD_DH_ALARM_MIN					= (100);//Minimum value of the interface of the Dynamic environment alarm type
        public const int CMD_ALARM_IN_CONFIG                 = (CMD_DH_ALARM_MIN + 0);//Dynamic environment alarm configuration
        public const int CMD_ALARM_IN_LINK                   = (CMD_DH_ALARM_MIN + 1);//Dynamic environment alarm linkage
        public const int CMD_ALARM_IN_SCHEDULE				= (CMD_DH_ALARM_MIN + 2);//Dynamic environment configuration of the arming template
        public const int CMD_ALARM_IN_SCHEDULE_ENABLE        = (CMD_DH_ALARM_MIN + 3);//Dynamic environment configuration of the arming enable
        public const int CMD_ALARM_IN_OSD                    = (CMD_DH_ALARM_MIN + 4);//Dynamic environment characters overlay configuration 
        public const int CMD_ALARM_IN_DEBUG                  = (CMD_DH_ALARM_MIN + 5);//Dynamic environment debug
        public const int CMD_ALARM_IN_OFFLINE_TIME_INTERVEL  = (CMD_DH_ALARM_MIN + 6);//Offline interval
        public const int CMD_DH_ALARM_HOST  					= (CMD_DH_ALARM_MIN + 7);//Alarm server parameter setting
        public const int CMD_DH_ADD_ALARM_HOST				= (CMD_DH_ALARM_MIN + 8);//Add the alarm host
        public const int CMD_DH_DEVICE_ENABLE				= (CMD_DH_ALARM_MIN + 9);//Set up the moving ring device enalbe
        public const int CMD_ALARMSCH_ENABLE_EX				= (CMD_DH_ALARM_MIN + 10);
        public const int CMD_ALARM_EXTRA_SCHEDULE			= (CMD_DH_ALARM_MIN + 11);
        public const int CMD_ALARM_FACE_PARAM				= (CMD_DH_ALARM_MIN + 12);
        public const int CMD_ALARM_IN_PORT_PARA				= (CMD_DH_ALARM_MIN + 13);//alarm in port para, mode,type......
        public const int CMD_ALARM_IN_RAINFALL_PARA          = (CMD_DH_ALARM_MIN + 14);
        public const int CMD_ALARM_IN_ALERTWATER_PARA        = (CMD_DH_ALARM_MIN + 15);
        public const int CMD_DH_ALARM_MAX					= (CMD_DH_ALARM_MIN + 16);//MAX

        //Network picture stream callback command, different orders corresponding to different structures
        public const int NET_PICSTREAM_CMD_VCA = 1;
        public const int NET_PICSTREAM_CMD_ITS = 2;
        public const int NET_PICSTREAM_CMD_FACE = 3;

        public const int NET_CLIENT_MIN = 0;
        public const int NET_CLIENT_ANYSCENE = (NET_CLIENT_MIN + 21); // Analyze the scene
        public const int NET_CLIENT_FACE_DETECT_ARITHMETIC = (NET_CLIENT_MIN + 26); // Face Detection Algorithm
        public const int NET_CLIENT_VCA_SUSPEND = (NET_CLIENT_MIN + 32); // Suspend intelligence Analysis

        public const int VCA_CMD_MIN = 100;
        public const int VCA_CMD_PICSTREAM_UPLOADPARAM = (VCA_CMD_MIN + 47);

        public const int CMD_NETFILE_QUERY_VCA = 7;

        public const int VCA_SUSPEND_STATUS_PAUSE  = 0;//暂停人脸检测算法
        public const int VCA_SUSPEND_STATUS_RESUME = 1;//重新开启人脸检测算法

        public const int VCA_SUSPEND_RESULT_SUCCESS = 1;
        public const int VCA_SUSPEND_RESULT_CONFIGING = 2;

        public const int DOWNLOAD_CMD_MIN = 0;
        public const int DOWNLOAD_CMD_FILE = 0;			
        public const int DOWNLOAD_CMD_TIMESPAN = 1;			
        public const int DOWNLOAD_CMD_CONTROL = 2;			
        public const int DOWNLOAD_CMD_FILE_CONTINUE = 3;	
        public const int DOWNLOAD_CMD_GET_FILE_COUNT = 4;	
        public const int DOWNLOAD_CMD_GET_FILE_INFO = 5;
        public const int DOWNLOAD_CMD_SET_FILE_INFO = 6;
        public const int DOWNLOAD_CMD_CLEAR_ALLFILECHAN = 7;	
        public const int DOWNLOAD_CMD_MAX = 8;

        public const int HEAVY_MODE = 0;
        public const int LIGHT_MODE = 1;
        public const int EASYX_LIGHT_MODE = 2;
        public const int MOBILE_LIGHT_MODE = 3;


        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileQuery(Int32 _iServerPort, ref NVS_FILE_QUERY _FileQueryt);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileGetFileCount(Int32 _iLogonID, ref Int32 iTotalCount,ref Int32 _iCurrentCount);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileGetQueryfile(Int32 _iLogonID,Int32 _Index, ref NVS_FILE_DATA _filedata);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileDownloadFile(ref UInt32 _uiConID, Int32 _iLogonID, 
                                                    string _cRemoteFilename, 
                                                    string _cLocalFilename,
                                                    Int32 _iFlag,
                                                    Int32 _iPosition,
                                                    Int32 _iSpeed);
        //delete by yyb
        //[DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        //public static extern Int32 NetClient_SetNetFileDownloadFileCallBack(UInt32 _uiConID,ReplayCallBackDelegate _CallBack,IntPtr _UserDate);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileStopDownloadFile(UInt32 _uiConID);

        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileGetDownloadPos(UInt32 _uiConID, ref Int32 _iPos,ref Int32 _dlSize);

        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileDownload(ref UInt32 uiConID, Int32 _iLogonID, Int32 _iCmd, [MarshalAs(UnmanagedType.LPArray)]byte[] _lpBuf, Int32 _iBufSize);

        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetAlarmPortNum(Int32 _iLogonID, ref Int32 _iAlarmChannelNo, ref Int32 _iAlarmOutPortNum);

        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_NetFileDownloadByTimeSpanEx(ref UInt32 _uiConID, 
                                                                         Int32 _iLogonID,
                                                                         string _cLocalFilename,
                                                                         Int32 _iChannelNO,
                                                                         ref NVS_FILE_TIME _uiFromSecond,
                                                                         ref NVS_FILE_TIME _uiToSecond,
                                                                         Int32 _iFlag,
                                                                         Int32 _iPosition,
                                                                         Int32 _iSpeed);


        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_SetPort(Int32 _iServerPort, Int32 _iClientPort);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetMSGHandle(UInt32 _uiMessage, IntPtr _hWnd, UInt32 _uiParaMsg, UInt32 _uiAlarmMsg);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_Startup();
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_Cleanup();
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_SetNotifyFunction_V4(MAIN_NOTIFY_V4 _MainNotify,
                                          ALARM_NOTIFY_V4 _AlarmNotify,
                                          PARACHANGE_NOTIFY_V4 _ParaNotify,
                                          COMRECV_NOTIFY_V4 _ComNotify,
                                          PROXY_NOTIFY _ProxyNotify);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_Logon(String _cProxy, String _cIP, String _cUserName, String _cPassword, String _pcProID, Int32 _iPort);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_Logoff(Int32 _iLogonID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StartRecv(ref UInt32 _uiConID, ref CLIENTINFO _cltInfo, RECVDATA_NOTIFY _cbkDataArrive);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StopRecv(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StartCaptureData(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", EntryPoint = "NetClient_StopCaptureDate")]
        public static extern Int32 NetClient_StopCaptureData(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StartPlay(UInt32 _uiConID, IntPtr _hWnd, RECT _rcShow, UInt32 _iDecflag);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StopPlay(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetPlayingStatus(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StartCaptureFile(UInt32 _uiConID, string _strFileName, Int32 _iRecFileType);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StopCaptureFile(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_CaptureBmpPic(UInt32 _uiConID, string _strFileName);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetOsdText(Int32 _iLogonID, Int32 _iChannelNum,byte[] _btOSDText, ref UInt32 _ulTextColor);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_SetOsdText(Int32 _iLogonID, Int32 _iChannelNum, byte[] _btOSDText,UInt32 _ulTextColor);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetOsdType(Int32 _iLogonID, Int32 _iChannelNum, Int32 _iPositionX,ref Int32 _iPositionY,ref Int32 _iOSDType,ref Int32 _iEnabled);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll",SetLastError = true)]
        public static extern Int32 NetClient_SetOsdType(Int32 _iLogonID, Int32 _iChannelNum, Int32 _iPositionX, Int32 _iPositionY, Int32 _iOSDType, Int32 _iEnabled);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetComPortCounts(Int32 _iLogonID, ref Int32 _iComPortCounts, ref Int32 _iComPortEnabledStatus);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetDeviceType(Int32 _iLogonID, Int32 _iChannelNum, ref Int32 _iComNo, ref Int32 _iDevAddress, StringBuilder _strDevType);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetDeviceType(Int32 _iLogonID, Int32 _iChannelNum, Int32 _iComNo, Int32 _iDevAddress, byte[] _btDevType);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_GetComFormat(Int32 _iLogonID, Int32 _iComNo, StringBuilder _strComFormat, ref Int32 _iWorkMode);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_SetComFormat(Int32 _iLogonID, Int32 _iComNo,byte[] _btDeviceType,byte[] _btComFormat, Int32 _iWorkMode);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", EntryPoint = "NetClient_GetVideoPara")]
        public static extern Int32 NetClient_GetVideoParam(Int32 _iLogonID, Int32 _iChannelNum, ref STR_VideoParam _structVideoParam);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", EntryPoint = "NetClient_SetVideoPara", SetLastError = true)]
        public static extern Int32 NetClient_SetVideoParam(Int32 _iLogonID, Int32 _iChannelNum, ref STR_VideoParam _structVideoParam);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_ResetPlayerWnd(UInt32 _uiConID, IntPtr _hwnd);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetChannelNum(Int32 _iLogonID,ref Int32 _iChannelNum);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetCaptureStatus(UInt32 _uiConID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_DeviceCtrlEx(Int32 _iLogonID, Int32 _iChannelNum, Int32 _iActionType, Int32 _iParam1, Int32 _iParam2, Int32 _iControlType);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_TalkStart(Int32 _iLogonID, Int32 _iUser);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_TalkEnd(Int32 _iLogonID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_InputTalkingdata(byte[] _btTalkData, Int32 _iLen);

        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_Startup_V4(Int32 _iServerPort, Int32 _iClientPort, Int32 _iWnd);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_Logon_V4(Int32 _iLogonType, IntPtr _pvInBuffer, Int32 _iInBufferSize);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_GetLogonStatus(Int32 _iLogonID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_FaceConfig(Int32 _iLogonId, Int32 _iCmdId, Int32 _iChanNo, IntPtr _lpIn, Int32 _iInLen, IntPtr _lpOut, Int32 _iOutLen);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll", SetLastError = true)]
        public static extern Int32 NetClient_SetAlarmConfig(Int32 _iLogonID, Int32 _iChannel, Int32 _iAlarmType, Int32 _iCmd, IntPtr _pvCmdBuf);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StartRecvNetPicStream(Int32 _iLogonID, IntPtr _ptPara, Int32 _iBufLen, ref UInt32 _puiRecvID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_StopRecvNetPicStream(UInt32 _uiRecvID);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetDevConfig(Int32 _iLogonID, Int32 _iCommand, Int32 _iChannel, IntPtr _lpInBuffer, Int32 _iInBufferSize);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetDevConfig(Int32 _iLogonID, Int32 _iCommand, Int32 _iChannel, IntPtr _lpOutBuffer, Int32 _iOutBufferSize, IntPtr _lpBytesReturned);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetNotifyUserData_V4(Int32 _iLogonID, IntPtr _iUserData);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_Query_V5(Int32 _iLogonId, Int32 _iCmdId, Int32 _iChanNo, IntPtr _lpIn, int _iInLen, IntPtr _lpOutBuffer, int _iOutLen);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_VCASetConfig(Int32 _iLogonID, Int32 _iVCACmdID, Int32 _iChannel, IntPtr _lpCmdBuf, Int32 _iCmdBufLen);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_VCAGetConfig(Int32 _iLogonID, Int32 _iVCACmdID, Int32 _iChannel, IntPtr _lpCmdBuf, Int32 _iCmdBufLen);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetSDKWorkMode(Int32 _iWorkMode);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_SetDsmConfig(Int32 _iCommand, IntPtr _pvBuf, Int32 _iBufSize);
        [DllImport("C:/Users/Павел/Downloads/EN-NetSDK(Windows64)V5.1.0.0_build20211015/EN-NetSDK(Windows64)V5.1.0.0_build20211015/Lib&Dll/NVSSDK.dll")]
        public static extern Int32 NetClient_GetDsmRegstierInfo(Int32 _iCommand, IntPtr _pvBuf, Int32 _iBufSize);
    
    }

    class Win32API
    {
        //消息发送API
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(
            IntPtr hWnd,        // 信息发往的窗口的句柄
            int Msg,            // 消息ID
            int wParam,         // 参数1
            int lParam          // 参数2
        );
    }
}
