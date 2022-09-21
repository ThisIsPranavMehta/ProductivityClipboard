using Newtonsoft.Json;
using NLog.Internal.Xamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    [Preserve]
    internal class TaskData
    {
        [Preserve]
        [JsonConstructor]
        public TaskData(string TaskName)
        {
            Name = TaskName;
            Completed = false;
        }
        [Preserve]
        public bool Completed { get; set; }

        [Preserve]
        public String Name { get; set; }
    }
}
