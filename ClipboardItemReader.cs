using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityClipboard
{
    internal class ClipboardItemReader
    {
        internal static ClipboardItem GetDataFromBuffer(string path)
        {
            if (!File.Exists(path)) return new ClipboardItem();
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                 ClipboardItem clipboarditem= serializer.Deserialize<ClipboardItem>(reader);
                if (clipboarditem != null) return clipboarditem;
                return new ClipboardItem();
            }
           
        }
    }
}
