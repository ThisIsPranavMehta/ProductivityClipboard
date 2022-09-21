using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class TaskBuffer
    {
        internal static void WriteData(int channelId,string TaskData)
        {
            TaskData NewTask = new TaskData(TaskData);
            Debug.WriteLine("------------------task created with name: "+ NewTask.Name);
            string path=ChannelManagement.GetPath(channelId);
            if (File.Exists(path))
            {
                TasksData TasksData=TasksReader.GetTasksData(path);
                TasksData.AddTasks(NewTask);
                FileHandling.ClearFile(channelId);
                TasksWriter.WriteTasks(path, TasksData);
            }
            else
            {
                TasksData NewTasksData = new TasksData();
                NewTasksData.AddTasks(NewTask);
                TasksWriter.WriteTasks(path,NewTasksData);

            }
        }
        internal static List<TaskData> ReadData(int channelId)
        {
            string path = ChannelManagement.GetPath(channelId);
            if (File.Exists(path))
            {
                TasksData TasksData = TasksReader.GetTasksData(path);
                return TasksData.GetAllTasks();
            }
            else
            {

                //return error messsage or tell it to be null!
                return null;
            }
        }

    }
}
