using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class MathematicalWriter
    {
        internal static void WriteMathsData(string path,MathematicsData MathsData)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, MathsData);
            }
        }
    }
}
