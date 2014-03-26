using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace Zero.Core
{
    public partial class TaskManager
    {
        private static TaskManager instance;
        private static List<Task> tasks;
        private TaskManager()
        {

        }
        public void Initialize(XmlNodeList nodes)
        {
            tasks = new List<Task>();
            foreach (XmlNode node in nodes)
            {
                if (node.Name.ToLower() == "task")
                {
                    try
                    {
                        XmlAttributeCollection attributes = node.Attributes;
                        var taskType = Type.GetType(node.Attributes["type"].Value);
                        if (taskType != null && bool.Parse(attributes["enabled"].Value))
                        {
                            Task task = new Task(node);
                            tasks.Add(task);
                        }
                    }
                    catch
                    {
                        // Handle the exception
                    }

                }
            }
        }

        public void Start()
        {
            foreach (Task task in tasks)
            {
                if (!task.IsRunning)
                    task.StartTask();
            }

        }

        public void Stop()
        {
            foreach (Task task in tasks)
            {
                task.StopTask();
            }
        }

        public static TaskManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskManager();
                }
                return instance;
            }
        }
    }
}
