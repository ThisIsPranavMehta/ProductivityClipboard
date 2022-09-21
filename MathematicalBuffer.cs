using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace learningForms
{
    internal static class MathematicalBuffer
    {
        internal static char operation = '+';

        internal static Double GetResult(int ChannelId)
        {
            return MathematicalReader.GetMathsData(ChannelManagement.GetPath(ChannelId)).Resultant;
        }
        
        internal static List<Double> GetList(int ChannelId)
        {
            return MathematicalReader.GetMathsData(ChannelManagement.GetPath(ChannelId)).GetAllValues();
        }

        internal static void WriteData(int ChannelId, string data)
        {
            string path = ChannelManagement.GetPath(ChannelId);
            if (File.Exists(path))
            {
                string CleanData = CleanTheData(data);
                if (CleanData == "" || CleanData == null)
                {
                    // return error here as the right data is not picked up for the buffer
                }
                else
                {
                    MathematicsData MathsData = MathematicalReader.GetMathsData(path);
                    double val = MathsData.Resultant;
                    Double currVal = Double.Parse(CleanData);
                    MathsData.AddValues(currVal);

                    if (operation == '+')
                    {
                        MathsData.Resultant += currVal;
                    }
                    else
                    {
                        MathsData.Resultant *= currVal;
                    }
                    foreach (Double i in MathsData.Values)
                    {
                        Debug.WriteLine("---------------VALUE: " + i);
                    }

                    FileHandling.ClearFile(ChannelId);
                    MathematicalWriter.WriteMathsData(path, MathsData);
                }
            }
            else
            {
                MathematicsData MathsData = new MathematicsData();
                MathsData.Resultant = Double.Parse(data);
                MathsData.AddValues(Double.Parse(data));
                MathematicalWriter.WriteMathsData(path,MathsData);
            }
        }
        internal static string CleanTheData(string data)
        {
            Debug.WriteLine("-----------------data to be cleaned: " + data + "---------------------");
            string res = "";
            foreach (char c in data){
                if(c>='0' && c <= '9')
                {
                    res += c;
                }
            }

            Debug.WriteLine("-----------------Ckeaned Data: " + res + "---------------------");
            return res;
        }
    }
}
