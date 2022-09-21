using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class TasksWriter
    {
        internal static void WriteTasks(string path, TasksData TasksData)
        {



            foreach (TaskData t in TasksData.GetAllTasks())
            {
                Debug.WriteLine("-------------------adding the following tasks: " + t.Name);
            }
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, TasksData);
            }
        }
    }
}
