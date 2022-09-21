using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace learningForms
{
    internal class MathematicalReader
    {
        internal static MathematicsData GetMathsData(string path)
        {
            if (File.Exists(path))
            {

                var serializer = new JsonSerializer();

                using (var sw = new StreamReader(path))
                using (var reader = new JsonTextReader(sw))
                {
                    MathematicsData mathsData=serializer.Deserialize<MathematicsData>(reader);
                    if (mathsData != null) return mathsData;
                    return new MathematicsData();
                }
            }
            else
            {
                return new MathematicsData();
                //eror block here!
            }
        }

    }
}
