namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.EventArgs;
    using Labo.ScheduledTasks.Core.Model;

    public sealed class TaskService : ITaskService
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        private readonly ITaskCreator m_TaskCreator;

        private readonly ITaskManagerFactory m_TaskManagerFactory;

        private ITaskManager m_TaskManager;

        private bool m_Disposed;

        public TaskService(IScheduledTaskStorage scheduledTaskStorage, ITaskCreator taskCreator, ITaskManagerFactory taskManagerFactory)
        {
            if (scheduledTaskStorage == null)
            {
                throw new ArgumentNullException("scheduledTaskStorage");
            }

            if (taskCreator == null)
            {
                throw new ArgumentNullException("taskCreator");
            }

            if (taskManagerFactory == null)
            {
                throw new ArgumentNullException("taskManagerFactory");
            }

            m_ScheduledTaskStorage = scheduledTaskStorage;
            m_TaskCreator = taskCreator;
            m_TaskManagerFactory = taskManagerFactory;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskService"/> class.
        /// </summary>
        ~TaskService()
        {
            Dispose(false);
        }

        public void Start()
        {
            IList<TaskDefinition> taskDefinitions = GetTaskDefinitions();

            m_TaskManager = m_TaskManagerFactory.CreateTaskManager(taskDefinitions);

            m_TaskManager.AfterTaskEnded += TaskManagerAfterTaskEnded;
            m_TaskManager.OnTaskError += TaskManagerOnTaskError;

            m_TaskManager.Start();
        }

        public void Stop()
        {
            m_TaskManager.Stop();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IList<TaskDefinition> GetTaskDefinitions()
        {
            IList<ScheduleTask> scheduleTasks = m_ScheduledTaskStorage.GetAllTasks();
            IList<TaskDefinition> taskDefinitions = new List<TaskDefinition>();

            for (int i = 0; i < scheduleTasks.Count; i++)
            {
                ScheduleTask scheduleTask = scheduleTasks[i];
                ITask task = m_TaskCreator.CreateTask(scheduleTask.Type);
                taskDefinitions.Add(new TaskDefinition(task, new TaskCofiguration(scheduleTask.Id, scheduleTask.Name, scheduleTask.Seconds, scheduleTask.StopOnError, scheduleTask.Enabled, scheduleTask.RunOnlyOnce)));
            }

            return taskDefinitions;
        }

        private void TaskManagerOnTaskError(object sender, OnTaskErrorEventArgs e)
        {
            m_ScheduledTaskStorage.UpdateEndDate(e.TaskId, e.EndDateUtc.GetValueOrDefault(), false);
        }

        private void TaskManagerAfterTaskEnded(object sender, AfterTaskEndedEventArgs e)
        {
            m_ScheduledTaskStorage.UpdateEndDate(e.TaskId, e.EndDateUtc.GetValueOrDefault(), true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (m_Disposed)
            {
                return;
            }

            if (disposing)
            {
                try
                {
                    if (m_TaskManager != null)
                    {
                        m_TaskManager.Dispose();
                    }
                }
                finally
                {
                    m_Disposed = true;
                }
            }
        }
    }
}
