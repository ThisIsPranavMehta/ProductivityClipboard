using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class TasksReader
    {
        internal static TasksData GetTasksData(string path)
        {
            if (File.Exists(path))
            {

                var serializer = new JsonSerializer();

                using (var sw = new StreamReader(path))
                using (var reader = new JsonTextReader(sw))
                {
                    TasksData tasksdata = serializer.Deserialize<TasksData>(reader);
                    if(tasksdata != null)  return tasksdata;
                    return new TasksData();
                }
            }
            else
            {
                Debug.WriteLine("================NO FILE FOUND!=====================================");
                return new TasksData();
                //eror block here!
            }
        }

    }
}
