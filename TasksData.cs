
using Newtonsoft.Json;
using NLog.Internal.Xamarin;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    [Preserve]
    internal class TasksData
    {

        [Preserve]
        public List<TaskData> Tasks = new List<TaskData>();


        [JsonConstructor]
        [Preserve]
        public TasksData()
        {
        }

        public TasksData(List<TaskData> Tasks)
        {
            this.Tasks = Tasks;
        }



        public void deleteTask(int idx)
        {
            if (idx < Tasks.Count())
            {
                Tasks.RemoveAt(idx);
            }

        }

        [Preserve]
        public void AddTasks(TaskData Task)
        {
            Tasks.Add(Task);
            Debug.WriteLine("-------------task added! : " + Task.Name);
        }
        [Preserve]
        public List<TaskData> GetAllTasks()
        {
            return Tasks;
        }


    }
}
