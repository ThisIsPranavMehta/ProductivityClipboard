using ProductivityClipboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class FileHandling
    {
        static bool []ShouldAppend=new bool[13];
        static string delimeter = "\n";                 // configurable by the user.

        static FileHandling()
        {
            for(int i = 0; i < 13; i++)
            {
                ShouldAppend[i] = true;                 // let the values be true by default!
            }
        }
        public static void ClearFile(int ChannelId)
        {

            string path = ChannelManagement.GetPath(ChannelId);
            if (File.Exists(path))
            {

                FileStream fileStream = File.Open(path, FileMode.Open);

                /* 
                 * Set the length of filestream to 0 and flush it to the physical file.
                 *
                 * Flushing the stream is important because this ensures that
                 * the changes to the stream trickle down to the physical file.
                 * 
                 */
                fileStream.SetLength(0);
                fileStream.Close(); // This flushes the content, too.
            }

        }
        public static void WriteData(int ChannelId, string data)
        {

            string path = ChannelManagement.GetPath(ChannelId);
            if (ChannelId != -1)
            {
                if (ChannelId <= 9)
                {
                    ClipboardBuffer.WriteData(ChannelId, data);  
                }
                else if (ChannelId == 10)             //  the mathematical ChannelId
                {
                    MathematicalBuffer.WriteData(ChannelId, data);
                }
                else if(ChannelId == 11)
                {
                    TaskBuffer.WriteData(ChannelId, data);
                    // make a TO DO List here!
                }
            }
        }
        private static void  ClearAsPerSetting(int ChannelId)
        {
            if (!ShouldAppend[ChannelId])
            {
                ClearFile(ChannelId);
            }
        }
        public static string ReadData(int ChannelId,string path="")
        {
            if (path == "")
            {
                path = ChannelManagement.GetPath(ChannelId);
            }
            string res="";
            if (ChannelId >= 0 && ChannelId <= 9)
            {
                res += (ClipboardItemReader.GetDataFromBuffer(path)).data.ToString();
            }
            else if(ChannelId==10)
            {
                if (File.Exists(path)) res += (MathematicalReader.GetMathsData(path)).Resultant.ToString();
                else res = "0";
            }
            else if (ChannelId == 11)
            {
                res += "!ERROR COPY!- Can't copy tasks data";               // cant' copy task directly!
                // maybe print a error message to here!
            }
            return res;
        }
    }
}
