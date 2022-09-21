using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityClipboard
{
    public class ClipboardItem
    {
        public string channelName { get; set; }
        public string data { get; set; }
        public bool append { get; set; }
        public ClipboardItem()               // only called when no object is found in the txt file.
        {
            data = "";
            append = false;                         
        }

        public void DeleteData()
        {
            data = "";
        }
        public void AddData(string s)
        {
            if (append)
            {
                data += s;
            }
            else
            {
                data = s;
            }
            // call the update in file command from here!
        }
    }
}
