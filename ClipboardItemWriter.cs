using learningForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityClipboard
{
    internal class ClipboardItemWriter
    {
        internal static void WriteDataToBuffer(string path, ClipboardItem clipBoardItem)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, clipBoardItem);
            }
        }
    }
}
