using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace learningForms
{
    internal class ChannelManagement
    {
        public static int GetChannelId(string s)
        {
            if (s == null) return -1;

            if (s == "D0") return 0;
            
            if (s == "D1") return 1;
            
            if (s == "D2") return 2;
            
            if (s == "D3") return 3;
            
            if (s == "D4") return 4;
            
            if (s == "D5") return 5;
            
            if (s == "D6") return 6;
            
            if (s == "D7") return 7;
            
            if (s == "D8") return 8;    
            
            if (s == "D9") return 9;
            
            if (s == "M") return 10;                // 10 is my mathematical buffer
            
            if (s == "T") return 11;                // 11 is my task buffer

            return -1;  // invalid call;

        }
        public static string GetPath(int ChannelId)
        {
            if (ChannelId >= 0 && ChannelId <= 11)
            {
                return "MyBuffer_" + ChannelId.ToString() + ".json";
            }
            return "DEFAULT_NOT_FOUND.txt";
        }
        public static bool CheckChannelIdAndRead(string theKey)
        {

            int ChannelId = ChannelManagement.GetChannelId(theKey);
            if (ChannelId != -1)
            {
                Debug.WriteLine("copy the text to ChannelId : " + ChannelId);                  // users wants to copy the text to ChannelId 1
                FileHandling.WriteData(ChannelId, Clipboard.GetText());
                Debug.WriteLine("and the text is : " + Clipboard.GetText());
                Thread.Sleep(300);
                
                return true;
            }
            return false;
        }

        public static bool CheckChannelIdAndWrite(string theKey)
        {
            int ChannelId = ChannelManagement.GetChannelId(theKey);

            Debug.WriteLine("-------------In Channel Management: " + ChannelId.ToString());
            if (ChannelId!=null && ChannelId != -1)
            {
                string defaultVal = ChannelId == 10 ? "0" : " ";
                Debug.WriteLine("copy the text from the ChannelId : " + ChannelId);                  // users wants to copy the text to ChannelId 1
                string res = FileHandling.ReadData(ChannelId);
                Clipboard.SetText(res==""?defaultVal:res);
                //Debug.WriteLine("ChannelId: " + ChannelId);
                //Thread.Sleep(300);                  //  required to make sure that context doesn't switch fast and the keystroke is additionally added to the text. 
                return true;
            }
            return false;
        }

    }
}
