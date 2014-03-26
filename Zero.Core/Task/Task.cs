using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Xml;
using System.Threading;

namespace Zero.Core
{
    /// <summary>
    ///1.Scheduled tasks using timer (使用定时器的预定任务)
    ///2.scheduled tasks using cache expiration (scheduled任务使用缓存过期)
    ///3.Scheduled tasks using threading (预定的任务，使用线程) 当前使用
    /// ITask.cs - Task.cs - TaskManager.cs - task.config - global.aspx
    /// </summary>
    public class Task
    {
        #region Fields
        private ITask task = null;
        private Timer timer;
        #endregion

        #region Properties
        public string Name { get; set; }
        public Type TaskType { get; set; }
        public bool IsRunning { get; set; }
        public bool Enabled { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Interval { get; set; }
        #endregion

        public Task(XmlNode configNode)
        {
            if (configNode.Attributes["name"] != null)
            {
                this.Name = configNode.Attributes["name"].Value;
            }
            if (configNode.Attributes["type"] != null)
            {
                this.TaskType = Type.GetType(configNode.Attributes["type"].Value, true);
            }
            if (configNode.Attributes["interval"] != null)
            {
                this.Interval = Int32.Parse(configNode.Attributes["interval"].Value);
            }
            if (configNode.Attributes["enabled"] != null)
            {
                this.Enabled = bool.Parse(configNode.Attributes["enabled"].Value);
            }
        }

        private ITask createTask()
        {
            if (this.Enabled && (this.task == null))
            {
                if (this.TaskType != null)
                {
                    this.task = Activator.CreateInstance(this.TaskType) as ITask;
                }
                this.Enabled = this.task != null;
            }
            return this.task;
        }

        public void StartTask()
        {
            if (this.timer == null)
            {
                this.timer = new Timer(new TimerCallback(this.TimerCallback), null, this.Interval, this.Interval);
            }
        }

        private void TimerCallback(object sender)
        {
            this.IsRunning = true;
            try
            {
                var task = this.createTask();
                if (task != null)
                {
                    this.StartTime = DateTime.Now;
                    task.Execute();
                    this.EndTime = DateTime.Now;
                }
            }
            catch
            {
                //handle exception
            }
            finally
            {
                this.IsRunning = false;
            }
        }
        public void StopTask()
        {
            if (this.timer != null)
            {
                lock (this)
                {
                    this.timer.Dispose();
                    this.timer = null;
                }
            }
        }

    }
}
