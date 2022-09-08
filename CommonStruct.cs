using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FaceDemo
{
    public class CommonLen
    {
        public const int LEN_16     = 16;
        public const int LEN_32     = 32;
        public const int LEN_36     = 36; 
        public const int LEN_64     = 64;
        public const int LEN_256    = 256;
              
        public const int LEN_UUID   = 64;

        public const int MAX_TIMESEGMENT = 4;
        public const int MAX_DAYS = 7;
        public const int MAX_EXTRA_SCHEDULE_TIME_SEGMENT = 16;

        public const int MAX_FACE_PICTURE_COUNT = 32;

        public const int FACE_MAX_PAGE_COUNT = 20;

        public const int MAX_FACE_DETECT_AREA_COUNT = 32;

    }

    
    [StructLayout(LayoutKind.Sequential)]
    struct DOWNLOAD_FILE
    {
        public Int32 m_iSize;			//结构体大小
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[] m_cRemoteFilename;   //前端录像文件名
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[] m_cLocalFilename;	  //本地录像文件名
        public Int32 m_iPosition;		//文件定位时,按百分比0～100;断点续传时，请求的文件指针偏移量
        public Int32 m_iSpeed;			//1，2，4，8，控制文件播放速度, 0-暂停
        public Int32 m_iIFrame;			//只发I帧 1,只播放I帧;0,全部播放					
        public Int32 m_iReqMode;			//需求数据的模式 1,帧模式;0,流模式					
        public Int32 m_iRemoteFileLen;	//	如果本地文件名不为空，此参数置为空
    };
    [StructLayout(LayoutKind.Sequential)]
    struct _MAIN_NOTIFY_DATA
    {
        public Int32 m_iLogonID;
        public Int32 m_wParam;
        public Int32 m_lParam;
        public Int32 m_iUserData;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct DOWNLOAD_CONTROL
    {
        public Int32 m_iSize;			//结构体大小
        public Int32 m_iPosition;		//0～100，定位文件播放位置；-1，不进行定位
        public Int32 m_iSpeed;			//1，2，4，8，控制文件播放速度, 0-暂停
        public Int32 m_iIFrame;			//只发I帧 1,只播放I帧;0,全部播放
        public Int32 m_iReqMode;			//需求数据的模式 1,帧模式;0,流模式
    };

    [StructLayout(LayoutKind.Sequential)]
    struct S_header
    {
        public UInt16 FrameRate;
        public UInt16 Width;
        public UInt16 Height;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct NVS_FILE_QUERY
    {
        public int m_iType;          /* Record type 1-Manual record, 2-Schedule record, 3-Alarm record*/
        public int m_iChannel;       /* Record channel 0~channel defined channel number*/
        public NVS_FILE_TIME m_struStartTime;  /* File start time */
        public NVS_FILE_TIME m_struStoptime;   /* File end time */
        public int m_iPageSize;      /* Record number returned by each research*/
        public int m_iPageNo;        /* From which page to research */
        public int m_iFiletype;      /* File type, 0-All, 1-AVstream, 2-picture*/
        public int m_iDevType;       /* 设备类型，0-摄像 1-网络视频服务器 2-网络摄像机 0xff-全部*/
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct NVS_FILE_TIME
    {
        public UInt16 m_iYear;   /* Year */
        public UInt16 m_iMonth;  /* Month */
        public UInt16 m_iDay;    /* Day */
        public UInt16 m_iHour;   /* Hour */
        public UInt16 m_iMinute; /* Minute */
        public UInt16 m_iSecond; /* Second */
    }
    [StructLayout(LayoutKind.Sequential)]
    struct NVS_FILE_DATA
    {
        public int m_iType;          /* Record type 1-Manual record, 2-Schedule record, 3-Alarm record*/
        public int m_iChannel;       /* Record channel 0~channel defined channel number*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public Char[] m_cFileName; /* File name */
        public NVS_FILE_TIME m_struStartTime;  /* File start time */
        public NVS_FILE_TIME m_struStoptime;   /* File end time */
        public int m_iFileSize;      /* File size */
    }

    /// <summary>
    /// /////////////////////////////
    /// </summary>

    [StructLayout(LayoutKind.Sequential)]
    struct CONNECT_STATE
    {
        public int m_iLogonID;
        public int m_iChannelNO;
        public int m_iStreamNO;
        public UInt32 m_uiConID;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct CLIENTINFO
    {
        public int m_iServerID;        //NVS ID,NetClient_Logon 返回值
        public int m_iChannelNo;	    //Remote host to be connected video channel number (Begin from 0)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public Char[] m_cNetFile;    //Play the file on net, not used temporarily
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public Char[] m_cRemoteIP;	//IP address of remote host
        public int m_iNetMode;		    //Select net mode 1--TCP  2--UDP  3--Multicast
        public int m_iTimeout;		    //Timeout length for data receipt
        public int m_iTTL;			    //TTL value when Multicast
        public int m_iBufferCount;     //Buffer number
        public int m_iDelayNum;        //Start to call play progress after which buffer is filled
        public int m_iDelayTime;       //Delay time(second), reserve
        public int m_iStreamNO;        //Stream type
        public int m_iFlag;			//0，首次请求该录像文件；1，操作录像文件
        public int m_iPosition;		//0～100，定位文件播放位置；-1，不进行定位
        public int m_iSpeed;			//1，2，4，8，控制文件播放速度        
    };

    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct NVS_IPAndID
    {
        public string m_pIP;
        public string m_pID;
        public UInt32 m_puiLogonID;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct NVS_SCHEDTIME
    {
        public UInt16 m_ustStartHour;
        public UInt16 m_usStartMin;
        public UInt16 m_ustStopHour;
        public UInt16 m_ustStopMin;
        public UInt16 m_ustRecordMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct STR_VideoParam
    {
        public UInt16 m_ustBrightness;             //亮度
        public UInt16 m_usHue;                     //色度
        public UInt16 m_ustContrast;               //对比度
        public UInt16 m_ustSaturation;             //饱和度
        [MarshalAs(UnmanagedType.Struct)]
        public NVS_SCHEDTIME m_strctTempletTime;   //时间模板        
    }

    //Ctrl param
    [StructLayout(LayoutKind.Sequential)]
    struct CONTROL_PARAM
    {
        public Int32 m_iAddress;   //device address
        public Int32 m_iPreset;	   //preset pos
        [MarshalAs(UnmanagedType.Struct)]
        public POINT m_ptMove;     //move pos
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] m_btBuf;     //Ctrl-Code(OUT)
        public Int32 m_iCount;     //Ctrl-Code count(OUT)
    };

    [StructLayout(LayoutKind.Sequential)]
    struct POINT
    {
        public Int32 x;
        public Int32 y;
    };

    [StructLayout(LayoutKind.Sequential)]
    class Reserve
    {
        public Int32 m_iReserved1;
        public UInt32 m_ustReserved2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btReserved1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] m_btReserved2;
        public Reserve()
        {
            m_iReserved1 = new Int32();
            m_ustReserved2 = new UInt32();
            m_btReserved1 = new byte[32];
            m_btReserved2 = new byte[64];
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    class NvsSingle
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btNvsIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btNvsName;
        public Int32 m_iNvsType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btFactoryID;
        [MarshalAs(UnmanagedType.Struct)]
        public Reserve m_stReserve;
        public NvsSingle()
        {
            m_btNvsIP = new byte[32];
            m_btNvsName = new byte[32];
            m_btFactoryID = new byte[32];
            m_stReserve = new Reserve();
        }

    };

    [StructLayout(LayoutKind.Sequential)]
    class DNSRegInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btUserName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btPwd;
        [MarshalAs(UnmanagedType.Struct)]
        public NvsSingle m_stNvs;
        public Int32 m_iPort;
        public Int32 m_iChannel;
        [MarshalAs(UnmanagedType.Struct)]
        public Reserve m_stReserve;
        public DNSRegInfo()
        {
            m_btUserName = new byte[32];
            m_btPwd = new byte[32];
            m_stNvs = new NvsSingle();
            m_stReserve = new Reserve();
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    class REG_DNS
    {
        [MarshalAs(UnmanagedType.Struct)]
        public DNSRegInfo m_stDNSInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btRegTime;
        [MarshalAs(UnmanagedType.Struct)]
        public Reserve m_stReserve;
        public REG_DNS()
        {
            m_stDNSInfo = new DNSRegInfo();
            m_btRegTime = new byte[32];
            m_stReserve = new Reserve();
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    class REG_NVS
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btPrimaryDS;
        [MarshalAs(UnmanagedType.Struct)]
        public NvsSingle m_stNvs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] m_btRegTime;
        public UInt32 m_uiClientConnNum;
        public Boolean m_blRegister;
        [MarshalAs(UnmanagedType.Struct)]
        public Reserve m_stReserve;
        public REG_NVS()
        {
            m_btPrimaryDS = new byte[32];
            m_stNvs = new NvsSingle();
            m_btRegTime = new byte[32];
            m_stReserve = new Reserve();
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FTP_SNAPSHOT
    {
        public Int32 iChannel;			//	通道 
        public Int32 iEnable;			//	模式 0:不使能,1:使能(定时),2:(报警联动抓拍),3:报警联动多次抓拍注释,默认为2
        public Int32 iQValue;			//	图片质量 取值范围0-100
        public Int32 iInterval;			//	抓拍时间间隔 取值范围1-3600(秒)
        public Int32 iPictureSize;		//  抓拍图片大小	0x7fff：代表自动，其余对应分辨率大小
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FTP_LINKSEND
    {
        public Int32 iChannel;			//	通道
        public Int32 iEnable;			//	使能
        public Int32 iMethod;			//	方式
    };

    [StructLayout(LayoutKind.Sequential)]
    struct STR_Para
    {

    };

    delegate void RECVDATA_NOTIFY(uint _ulID, string _strData, int _iLen);
    delegate void DNSList_NOTIFY(Int32 _iCount, IntPtr _pDns);
    delegate void NVSList_NOTIFY(Int32 _iCount, IntPtr _pNvs);
    delegate void COMRECV_NOTIFY(Int32 _iLogonID, IntPtr _pBuf, Int32 _iLen, Int32 _iComNO);

    //  SDK4.0回调接口委托V4接口为—__CDECL调用
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void MAIN_NOTIFY_V4(UInt32 _ulLogonID, IntPtr _iWparam, IntPtr _iLParam, IntPtr _iUser);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ALARM_NOTIFY_V4(Int32 _ulLogonID, Int32 _iChan, Int32 _iAlarmState, Int32 _iAlarmType, Int32 _iUser);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void PARACHANGE_NOTIFY_V4(Int32 _ulLogonID, Int32 _iChan, Int32 _iParaType, ref STR_Para _strPara, Int32 _iUser);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void COMRECV_NOTIFY_V4(Int32 _ulLogonID, IntPtr _cData, Int32 _iLen, Int32 _iComNo, Int32 _iUser);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void PROXY_NOTIFY(Int32 _ulLogonID, Int32 _iCmdKey, IntPtr _cData, Int32 _iLen, Int32 _iUser);


    public class SDKConstMsg
    {
        public const int WM_USER = 0x0400; //
        public const int WM_MAIN_MESSAGE = WM_USER + 1001;
        public const int MSG_PARACHG = WM_USER + 90910;
        public const int MSG_ALARM = WM_USER + 90911;
        public const int WCM_ERR_ORDER = 2;
        public const int WCM_ERR_DATANET = 3;
        public const int WCM_LOGON_NOTIFY = 7;
        public const int WCM_VIDEO_HEAD = 8;
        public const int WCM_VIDEO_DISCONNECT = 9;
        public const int WCM_RECORD_ERR = 13;

        public const int LOGON_SUCCESS = 0;
        public const int LOGON_ING = 1;
        public const int LOGON_RETRY = 2;
        public const int LOGON_DSMING = 3;
        public const int LOGON_FAILED = 4;
        public const int LOGON_TIMEOUT = 5;
        public const int NOT_LOGON = 6;
        public const int LOGON_DSMFAILED = 7;
        public const int LOGON_DSMTIMEOUT = 8;
        public const int PLAYER_PLAYING = 0x02;
        public const int USER_ERROR = 0x10000000;

        public const int WCM_QUERYFILE_FINISHED = 18;  
        public const int WCM_DWONLOAD_FINISHED = 19;
        public const int WCM_DWONLOAD_FAULT = 20;
        public const int WCM_DOWNLOAD_INTERRUPT = 29;

        // 对讲消息
        public const int WCM_TALK = 23;

        public const int WCM_VCA_SUSPEND = 103; // Suspends the intelligent analysis notification message
        public const int WCM_FACE_MODEING = 198;//人脸建模进度

    }

    public class AlarmConstMsgType
    {
        public const int ALARM_VDO_MOTION	=	0;  //移动侦测
        public const int ALARM_VDO_REC		=	1;
        public const int ALARM_VDO_LOST		=	2;    
        public const int ALARM_VDO_INPORT	=	3;  //报警输入
        public const int ALARM_VDO_OUTPORT	=	4;  //报警输出
        public const int ALARM_VDO_COVER 	=	5;  //视频遮挡
        public const int ALARM_VCA_INFO		=	6;  //智能分析报警
        public const int ALARM_AUDIO_LOST	=	7;  //音频丢失
        public const int ALARM_EXCEPTION    =   8;  
                                           
    }


    public class ActionControlMsg
    {
        public const int MOVE = 60;
        public const int MOVE_STOP = 61;
        public const int MOVE_UP = 1;
        public const int MOVE_DOWN = 2;
        public const int MOVE_LEFT = 3;
        public const int MOVE_RIGHT = 4;
        public const int MOVE_UP_LEFT = 6;
        public const int MOVE_UP_RIGHT = 5;
        public const int MOVE_DOWN_LEFT = 8;
        public const int MOVE_DOWN_RIGHT = 7;
        public const int ZOOM_BIG = 10;
        public const int ZOOM_SMALL = 11;
        public const int FOCUS_NEAR = 13;
        public const int FOCUS_FAR = 14;
        public const int IRIS_OPEN = 17;
        public const int IRIS_CLOSE = 18;
        public const int RAIN_ON = 19;
        public const int RAIN_OFF = 20;
        public const int LIGHT_ON = 21;
        public const int LIGHT_OFF = 22;
        public const int HOR_AUTO = 23;
        public const int HOR_AUTO_STOP = 24;
        public const int CALL_VIEW = 25;
        public const int SET_VIEW = 28;
        public const int POWER_ON = 29;
        public const int POWER_OFF = 30;
        public const int ZOOM_BIG_STOP = 32;
        public const int ZOOM_SMALL_STOP = 34;
        public const int FOCUS_FAR_STOP = 36;
        public const int FOCUS_NEAR_STOP = 38;
        public const int IRIS_OPEN_STOP = 40;
        public const int IRIS_CLOSE_STOP = 42;
    }

    public class ClientControlMsg
    {
        public const int WM_USER = 0x0400;
        public const int WM_CLIENT_MODEING = WM_USER + 8000;//自定义消息，处理建模进度
        public const int WM_CLIENT_SUSPEND = WM_USER + 8001;//自定义消息，获取人脸检测算法的状态，对界面进行处理  
        public const int WM_CLIENT_RECVPICNUM = WM_USER + 8002;//自定义消息，处理显示接收的总图片张数
        public const int WM_CLIENT_IMPORT = WM_USER + 8003; //自定义消息，处理批量导入图片
    }
    public class PicType
    {
        public const int IMAGE_EXT_TYPE_UNKNOWN = -1;
        public const int IMAGE_EXT_TYPE_JPG = 0;
        public const int IMAGE_EXT_TYPE_PNG = 1;
    }


    [StructLayout(LayoutKind.Sequential)]
    struct LogonPara
    {
        public int iSize;                                   //Structure size			
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cProxy;                                 //The ip address of the upper-level proxy to which the video is connected,not more than 32 characters, including '\0'   
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cNvsIP;                                 //IP address，not more than 32 characters, including '\0'
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cNvsName;                               //Nvs name. Used for domain name resolution   
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public char[] cUserName;                              //Login Nvs username，not more than 16 characters, including '\0'	  
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public char[] cUserPwd;                               //Login Nvs password，not more than 16 characters, including '\0'  
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cProductID;                             //Product ID，not more than 32 characters, including '\0'	  
        
        public int iNvsPort;                                //The communication port used by the Nvs server, if not specificed,Use the system default port(3000)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cCharSet;                               //Character set  
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public char[] cAccontName;                            //The username that connects to the contents server
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public char[] cAccontPasswd;                          //The password that connects to the contents server   
    };

    [StructLayout(LayoutKind.Sequential)]
    struct ActiveNetWanInfo
    {
        public int iSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
	    public char[] cWanIP;		//Local public network ip
        public int iWanPort;			//Local public network port
    };

    [StructLayout(LayoutKind.Sequential)]
    struct DsmOnline
    {
	    public int          iSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
	    public char[]	    cProductID;	//product id	
	    public int		    iOnline;			//0--Offline 1--Online
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
	    public char[]       cWanIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
	    public char[]       cLanIP;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct LogonActiveServer
    {
	    public int		iSize;	
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]		
	    public char[]	cUserName;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
	    public char[]	cUserPwd;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
	    public char[]	cProductID;	//product id	
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceLibQuery
    {
        public int iSize;
        public int iChanNo;
        public int iPageNo;
        public int iPageCount;
    };

    //[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    struct FaceLibInfo
    {
        public int iSize;
        public int iLibKey; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cName;
        public int iThreshold;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cExtrInfo;
        public int iAlarmType;
        public int iOptType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cLibVersion;                               
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceLibEdit
    {
        public int iSize;
        public int iChanNo;
        public FaceLibInfo tFaceLib;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceLibQueryResult
    {
        public int iSize;
        public int iChanNo;
        public int iTotal;
        public int iPageNo;
        public int iIndex;
        public int iPageCount;
        public FaceLibInfo tFaceLib;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceReply
    {
        public int iSize;
        public int iLibKey;
        public int iFaceKey;
        public int iOptType;
        public int iResult;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cFaceUUID;
        public int iDelLibProgress;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceSearchSnapQuery
    {
        public	int    iSize;
	    public  int    iTaskId;
	    public  int    iPageSize;
	    public  int    iPageNo;
    };

    struct FaceSearchSnapResult
    {
	    public int	    iSize;
	    public int	    iChanNo;
	    public int		iTotal;
	    public int		iCurPageCount;
	    public int		iItemIndex;
	    public NVS_FILE_TIME		tBegTime;
	    public NVS_FILE_TIME		tEndTime;
	    public int  	iAge;
        public int      iSex;
        public int      iNation;
        public int      iWearGlasses;
        public int      iWearMask;
        public int      iSimilarity;
	    public VcaFileAttr	    tPicSnap;
	    public VcaFileAttr	    tPicNeg;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct VcaFileAttr
    {
		public int	    iFileIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
	    public byte[]	cFileName;
	    public int 		iFileSize;
		public int		iFileType;
	    public int	    iReserve;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
	    public byte[]	cReserve;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceSearchSnapProcess
    {
        public int iSize;
        public int iTaskId;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct FaceLibDelete
    {
        public int iSize;
        public int iChanNo;
        public int iLibKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;                     
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceQuery
    {
        public int iSize;
        public int iChanNo;
        public int iPageNo;
        public int iPageCount;
        public int iLibKey;
        public int iModeling;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cName;
        public int iSex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public byte[] cBirthStart;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public byte[] cBirthEnd;
        public int iNation;
        public int iPlace;
        public int iCertType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cCertNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;       
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct FaceInfo
    {
	    public int iSize;
	    public int iLibKey;	  
	    public int iFaceKey;  
	    public int iCheckCode;
	    public int iFileType;   
	    public int iModeling;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cName;
        public int iSex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public byte[] cBirthTime;
        public int iNation;
        public int iPlace;
        public int iCertType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cCertNum;
        public int iOptType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cFaceUUID; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cLibVersion; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cVerifyCode; 
        public int iTaskId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
        public byte[] cFileName; 
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceEdit
    {
        public int iSize;
        public int iChanNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
        public byte[] cFacePic;
        public FaceInfo tFace;             
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceDelete
    {
        public int iSize;
        public int iChanNo;
        public int iLibKey;
        public int iFaceKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cFaceUUID;
                
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceQueryResult
    {
	    public int iSize;
	    public int iChanNo;	  
	    public int iTotal;  
	    public int iPageNo;
	    public int iPageCount;   
	    public int iIndex;
        public FaceInfo tFace;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceCutEx
    {	
        public int	    iSize;
	    public int	    iChanNo;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[]   cCheckCode;
	    public int		iPicType;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
	    public byte[]   cPicPath;
        public int      iPageNo;
	    public int		iPageCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceCutQueryResult
    {
        public int		    iSize;
        public int			iChanNo;
        public int			iTaskId;
        public int			iTotal;
        public int			iPageNo;
        public int			iIndex;
        public int			iPageCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
        public byte[]		cFileName;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceSearchSnap
    {
          public   int  	            iSize;
          public   int                  iChanCount;
          public   int                  iChanSize;
	      public   IntPtr		        pChanList;
	      public   NVS_FILE_TIME	    tBegTime;
	      public   NVS_FILE_TIME	    tEndTime;
          [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
          public   byte[]		         cPicturePath;
	      public   int 				     iSimilarity;
	      public   int 			         iSortMode; //0-sort by time 1-sort by similarity
	      public   int                   iTaskId;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct FaceSearch
    {
          public int 	iSize;
		  public int	iChanNo;
		  public int	iTaskId;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
		  public byte[] cLibKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_256)]
	 	  public byte[] cPicName;
	 	  public int    iSimilar;
		  public int	iPageNo;
	      public int	iPageCount;
	      public int	iLibKey;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct QueryChanNo
    {
	       public int iChanNo;
	       public int iStream;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct NetFileQueryVca
    {
        public int		iSize;
	
		public int		iChanCount;
	    public int		iChanSize;
	    public IntPtr	pChanList;

	    public int		iVcaCount;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = NVSSDK.MAX_QUERY_LIST_COUNT)]
	    public int[]	iVcaList;

	    public NVS_FILE_TIME		tBegTime;
	    public NVS_FILE_TIME		tEndTime;
	    public int					iPageCount;
	    public int					iPageNo;
	    public int					iFileType;

	    public int					iConditionCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NVSSDK.MAX_QUERY_LIST_COUNT * CommonLen.LEN_256)]
	    public char[,]				cQueryCondition;
    };

[StructLayout(LayoutKind.Sequential)]
struct NetFileQueryVcaResult
{
	public    int		iSize;
	public    int		iChanNo;
	public    int		iFileAttrCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NVSSDK.MAX_VCA_FILE_COUNT)]
	public VcaFileAttr[]	 tFileAttr;

	public    int	    iTotal;
	public    int		iCurPageCount;
	public 	  int	    iItemIndex;
	public    int	    iFileType;
	public    int		iVcaType;
	public NVS_FILE_TIME		tBegTime;
	public NVS_FILE_TIME		tEndTime;
	
	public    int		iExAttrCount;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NVSSDK.MAX_VCA_ATTR_COunt*CommonLen.LEN_256)]
	public    byte[]		cExAttr;
};

    [StructLayout(LayoutKind.Sequential)]
    public class FaceModeling
    {
        public int iSize;
        public int iChanNo;
        public int iType;
        public int iLibKey;
        public int iFaceNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NVSSDK.FACE_MAX_PAGE_COUNT)]
        public int[] iFaceKey;
        public FaceModeling()
        {
            iSize = 0;
            iChanNo = 0;
            iType = 0;
            iLibKey = 0;
            iFaceNum = 0;
            iFaceKey = new int[NVSSDK.FACE_MAX_PAGE_COUNT];
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceModeResult
    {
        public int iSize;
        public int iChanNo;
        public int iType;
        public int iLibKey;
        public int iFaceKey;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public char[] cName;
        public int iRetsult;
        public int iTotal;
        public int iIndex;               
    };

    [StructLayout(LayoutKind.Sequential)]
    struct VCASuspendResult
    {
        public int iBufSize;//structure size
        public int iStatus;//Status(0:Suspend intelligent analysis 1:Open intelligent analysis)
        public int iResult; //Result(1:success[indicate that parameters can be set] 2:fail[indicate that parameter is being set and can not set])           
    };


    [StructLayout(LayoutKind.Sequential)]
    struct TAlarmScheEnableParam
    {
        public int iBuffSize;
        public int iEnable;
        public int iParam1;
        public int iParam2;
        public int iParam3;
        public IntPtr pvReserved;
        public int iSceneID;   
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;                     
    };

    [StructLayout(LayoutKind.Sequential)]
    struct TAlarmScheduleParam
    {
        public int iBuffSize;
        public int iWeekday;
        public int iParam1;
        public int iParam2;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.MAX_DAYS * CommonLen.MAX_TIMESEGMENT)]
        public NVS_SCHEDTIME[,] timeSeg;//timeSeg[MAX_DAYS][MAX_TIMESEGMENT]

        public IntPtr pvReserved;
        public int iSceneID;   
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_UUID)]
        public byte[] cLibUUID;                     
    };




    //Register a network picture stream callback
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate int NET_PICSTREAM_NOTIFY(UInt32 _uiRecvID, int _lCommand, IntPtr _pvBuf, Int32 _iBufLen, IntPtr _pvUser);

    [StructLayout(LayoutKind.Sequential)]
    struct NetPicPara
    {
        public int iStructLen;
        public int iChannelNo;
        public NET_PICSTREAM_NOTIFY cbkPicStreamNotify;
        public IntPtr pvUser;
        public int iPicType;             
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct PicTime
    {
        public UInt32 uiYear;
        public UInt32 uiMonth;
        public UInt32 uiDay;
        public UInt32 uiWeek;
        public UInt32 uiHour;
        public UInt32 uiMinute;
        public UInt32 uiSecondsr;
        public UInt32 uiMilliseconds;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct PicData
    {
        [MarshalAs(UnmanagedType.Struct)]
        public PicTime tPicTime;
        public Int32 iDataLen;		    //Image length
        public IntPtr piPicData;		    //Picture raw data, the upper can be directly saved as a picture
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct FaceAttribute
    {
        public Int32 iType;				//Face attr type
        public Int32 iValue;			//face attr value
    }; 

    [StructLayout(LayoutKind.Sequential)]
    public struct FacePicData
    {
        public Int32 iFaceId;				//Face track Id
        public Int32 iDrop;					//The face track ends, 0 is not over, 1 ends
        public Int32 iFaceLevel;				//Face quality,0-100
        [MarshalAs(UnmanagedType.Struct)]
        RECT tFaceRect;				//Face coordinates
        public Int32 iWidth;					//Face wide picture of the wide
        public Int32 iHeight;				//Face small picture of the high
        public Int32 iFaceAttrCount;			//Number of face attributes
        public Int32 iFaceAttrStructSize;	//The size of strcut FaceAttribute
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public IntPtr[] ptFaceAttr;		        //Face attributes,supports up to 256 attribute types,the subscript is the face attribute type:
        //0-age,1-gender,2-masks,3-beard,4-eye open,5-mouth,6-glasses,7-race,8-emotion,9-smile,10-value......
        public Int32 iDataLen;				//Face picture length
        public IntPtr pPicData;				//Small figure bare data, the upper can be directly saved as a picture
        public UInt64 ullPts;                 //Timestamp of small picture

        public Int32 iAlramType;				//
	    public Int32 iSimilatity;			//0~100
	    public Int32 iLibKey;				//library key id
	    public Int32 iFaceKey;				//face key id
	    public Int32 iNegPicLen;				//negative picture len
	    public IntPtr pcNegPicData;			//negative picture data
	    public Int32 iNegPicType;			//negative picture type
	    public Int32 iSex;
	    public Int32 iNation;
	    public Int32 iPlace;					//negative place
	    public Int32 iCertType;				//credentials type
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public char[] cCertNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_16)]
        public char[] cBirthTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public byte[] cLibName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public char[] cLibUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_64)]
        public char[] cFaceUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_36)]
        public char[] cVerifyCode;
        public Int32 iFeatureLen;
        public IntPtr pcFeatureData;
    }; //Face map information

    [StructLayout(LayoutKind.Sequential)]
    struct FacePicStream
    {
        public Int32 iStructLen;			//Structure length
        public Int32 iSizeOfFull;
        public IntPtr tFullData;
        public Int32 iFaceCount;			//The current frame detects the number of face
        public Int32 iSizeOfFace;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.MAX_FACE_PICTURE_COUNT)]
        public IntPtr[] tFaceData;
        public Int32 iFaceFrameId;       //The face jpeg frame no       
    };

    [StructLayout(LayoutKind.Sequential)]
    struct AnyScene
    {
        public int				iBufSize;			//Scene application timed cruise template structure size
	    public int				iSceneID;			//Scene number(0~15)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.LEN_32)]
        public char[] cSceneName;//Scene name
        public int				iArithmetic;		//enable the algorithm type( bit0: 1-action analysis algorithm enable；0-not enable
										            //bit1：1-track algorithm enable；0-not enable
										            //bit2：1-face detection algorithm enable；0-not enable
										            //bit3：1-people amount statistics algorithm enable；0-not enable
										            //bit4：1-video diagnose algorithm enable；0-not enable
	                                                //bit5：1-license plate recognition algorithm enable；0-not enable
	                                                //bit6：1-audio and video exception algorithm enable；0-not enable 
										            //bit7：1-off post algorithm enable；0-not enable      
										            //bit8：1-people gathering algorithm enable；0-not enable
										            //bit11:1-witness protection algorithm enable；0-not enable
										            //bit20:1-Structured algorithm enable；0-not enable
										            //bit21: 1-procutrate duty   0-not enable
										            //bit22: 1-height limit; 0-not enable
										            //bit23: 1-new duty   0-not enable
										            //bit24: 1-abnormal number   0-not enable
										            //bit25: 1-get up   0-not enable
										            //bit26: 1-leave bed   0-not enable
										            //bit27: 1-hold still  0-not enable
										            //bit28: 1-sleep    0-not enable
										            //bit29: 1-slip up   0-not enable
										            //bit30: 1-new fight  0-not enable
										            //bit31: 1-arm touch   0-not enable
	    public int             iDevType;
	    public int			   iArithmeticEx;		//enable the algorithm type
										            //bit0：1-human detection algorithm enable 0-not enable
										            //bit1 1-pept enable 0-not enable       
    };

    [StructLayout(LayoutKind.Sequential)]
    struct FaceDetectArithmetic
    {
	    public int				iBufSize;			//Face detection algorithm structure size
	    public int				iSceneID;			//Scene id(0~15)
	    public int				iMaxSize;			//maximum face size(0~100 percentage of image width,100 indicates the width of entire screen)
	    public int				iMinSize;			//minimum face size(0~100 percentage of image width，100 indicates the width of entire screen)
	    public int				iLevel;				//Algorithm run level(0~5)
	    public int				iSensitiv;			//Sensitivity(0~5)
	    public int				iPicScale;			//Picture scale(1~10)
	    public int				iSnapEnable;		//Face snap enable(1-enable，0-not enable)
	    public int				iSnapSpace;			//Snap space(space frame count)
	    public int				iSnapTimes;			//Snap times(1~10)
	    public int				iPointNum;			//polygon area vertex number(3～32)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CommonLen.MAX_FACE_DETECT_AREA_COUNT)]
        public POINT[]          ptArea;//polygon area vertex point
        public int				iDisplayTarget;		//display target box, 0-not dispaly, 1-dispaly
	    public int				iExposureBright;	//exposure light strength
	    public int				iDisplayRule;		//0-not display 1-display
	    public int				iMinSizeEx;			//minimum face size(0~10000 percentage of image width，10000 indicates the width of entire screen)
	    public int				iMaxSizeEx;			//maximum face size(0~10000 percentage of image width,10000 indicates the width of entire screen)
	    public int				iPushMode;			//push mode 0:reserved 1:Speed first 2:Quality first  3:custom	4:timing
	    public int				iPushLevel;			//push level effect when push_mode == 3;(0:reserved,1:fast 2:normal 3:slow) effect when push_mode == 4;(value is timing time)
	    public int				iSnapMode;			//snap mode (0:reserved 1:snap all 2:snap high quality 3:custom)
	    public int				iSnapLevel;			//Snap level effect when Snap_mode == 3;(0~100)
	    public int				iDentification;		//Face recognition algorithm switch: 0-not supported, 1-off, 2-on
	    public int              iDevType;			//DevType:0-IPC，1-NVR
	    public int              iQpvalueBig;		//ST Customized, background image quality, range 1~100, 0 means not using this setting.			
	    public int              iQpvalueSmall;		//ST Customized, face thumbnail quality, range 1~100, 0 means not using this setting.						
	    public int          	iAlgSnapMode;		//ST Customized, algorithmic capture mode, 0-face, 1-vehicle, 2-mix.
	    public int              iPlateMinSize;		//ST Customized, the image width is very divided, the range is 1~10000, 10000 means the width of the whole screen. When this field is 0, it means no processing.	
    };

     [StructLayout(LayoutKind.Sequential)]
    struct PicStreamUploadParam
    {
	    public int         iSize;			
	    public int         iSceneId;		//range:0~15
	    public int         iRuleNo;		//range:0～7
	    public int         iPicType;		//Picture type: 0-Background big picture, 1-Small picture
	    public int         iSnapEnable;	//Send enable:0-not upload, 1-upload
	    public int         iIsOsd;			//Overlay information: 0-not stack, 1-stack.When iPicType=1,this parameter is invalid.
	    public int         iQpvalue;		//Snap picture quality range:1-100
	    public int		   iFaceFrameEnable;//Overlay face frame: 0-not stack, 1-stack.When iPicType=1,this parameter is invalid.
    };

}
