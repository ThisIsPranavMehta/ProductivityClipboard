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
            priority = "5";                   //priority is set to least by default 
            Name = TaskName;
            Completed = false;
        }
        [Preserve]
        public bool Completed { get; set; }

        [Preserve]
        public String Name { get; set; }

        public string priority { get; set; }   // the lower the more important it is!
    }
}
