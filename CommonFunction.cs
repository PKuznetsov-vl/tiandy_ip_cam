using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FaceDemo
{
    class CommonFunction
    {
        public static double ConvertDateTimeToInt(DateTime time)
        {
            double intResult = 0;
            
            DateTime starttime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970,1,1));
            //time.AddHours(+8);
            double dSpace = (DateTime.Now - DateTime.UtcNow).TotalSeconds;
            intResult = (time - starttime).TotalSeconds + dSpace;
            return intResult;
        }
        public static  DateTime ConvertIntToDateTime(double utc)
        {
            DateTime starttime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            double dSpace = (DateTime.Now - DateTime.UtcNow).TotalSeconds;
            starttime = starttime.AddSeconds(utc - dSpace);

            return starttime;
        
        }
        public static long NvsFileTimeToAbsSeconds(NVS_FILE_TIME nvstime)
        {
            long iTime = 0;
            DateTime dtTime = new DateTime(nvstime.m_iYear,
                                           nvstime.m_iMonth,
                                           nvstime.m_iDay,
                                           nvstime.m_iHour,
                                           nvstime.m_iSecond,
                                           nvstime.m_iMinute);
            double dTime = ConvertDateTimeToInt(dtTime);
            iTime = Convert.ToInt64(dTime);
            return iTime;
        }

        public static string AddString(byte[] data)
        {
            int iLen = 0;
            string str = CommonFunction.ByteToStr(data);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '\0')
                    iLen++;
                else
                    break;
            }
            str = str.Substring(0, iLen);
            return str;
        }

        public static void CharsCopy(char[] source, char[] des)
        {
            for (int i = 0; i < source.Length & i < des.Length; i++)
            {
                des[i] = source[i];
            }
        }

        public static void BytesCopy(string source, byte[] des)
        {
            byte[] src = System.Text.Encoding.Default.GetBytes(source);
            for (int i = 0; i < src.Length & i < des.Length; i++)
            {
                des[i] = src[i];
            }
        }

        public static string CharToString(char[] source)
        {
            string strName = new string(source, 0, source.Length);
            strName = strName.Trim("\0".ToCharArray());
            return strName;
        }

        public static string ByteToStr(byte[] source)
        {
            string str = System.Text.Encoding.Default.GetString(source);
            return str;
        }
        public static string GetCurTimeStr()
        {
            return DateTime.Now.ToLocalTime().ToString();
        }
        public static int GetFaceFileType(string str)
        {
            int iType = PicType.IMAGE_EXT_TYPE_UNKNOWN;
            string cstrExt = System.IO.Path.GetExtension(str);
            if (cstrExt.Equals(".PNG", StringComparison.OrdinalIgnoreCase))
            {
                iType = PicType.IMAGE_EXT_TYPE_PNG;
            }
            else if (cstrExt.Equals(".JPG", StringComparison.OrdinalIgnoreCase) || cstrExt.Equals(".JPEG", StringComparison.OrdinalIgnoreCase))
            {
                iType = PicType.IMAGE_EXT_TYPE_JPG;
            }
            return iType;
        }
    }


}
