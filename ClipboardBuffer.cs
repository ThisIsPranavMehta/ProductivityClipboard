using learningForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProductivityClipboard
{
    internal static class ClipboardBuffer
    {
        internal static void SetEnabled(bool enabled, int ChannelId)
        {
            string path = ChannelManagement.GetPath(ChannelId);
            if (File.Exists(path))
            {
                ClipboardItem clipboardItem = ClipboardItemReader.GetDataFromBuffer(path);
                clipboardItem.append = enabled;

                FileHandling.ClearFile(ChannelId);              // deleting the earlier file
                ClipboardItemWriter.WriteDataToBuffer(path, clipboardItem);
            }
            else
            {
                ClipboardItem clipboardItem = new ClipboardItem();
                clipboardItem.append = enabled;
                ClipboardItemWriter.WriteDataToBuffer(path, clipboardItem);
                
                        // create the file too!
            }
        }
        internal static void WriteData(int channelId, string Data)
        {
            string path = ChannelManagement.GetPath(channelId);
            if (File.Exists(path))                              // need to check if it's in append mode and then do accordingly
            {
                ClipboardItem clipboardItem = ClipboardItemReader.GetDataFromBuffer(path);
                if (clipboardItem.append)
                {
                    clipboardItem.data+=Data;
                }
                else
                {
                    clipboardItem.data = Data;
                }
                FileHandling.ClearFile(channelId);
                ClipboardItemWriter.WriteDataToBuffer(path,clipboardItem);
            }
            else
            {
                ClipboardItem clipboardItem=new ClipboardItem();            // make a new file and add the required data to it!
                clipboardItem.data= Data;
                FileHandling.ClearFile(channelId);
                ClipboardItemWriter.WriteDataToBuffer(path, clipboardItem);
            }
        }
        internal static ClipboardItem ReadData(int channelId)
        {
            string path = ChannelManagement.GetPath(channelId);
            if (File.Exists(path))
            {
                ClipboardItem clipboardItem = ClipboardItemReader.GetDataFromBuffer(path);
                return clipboardItem;
            }
            else
            {
                ClipboardItem clipboardItem = new ClipboardItem();
                return clipboardItem;
            }
        }
    }
}
