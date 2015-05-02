namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.EventArgs;
    using Labo.ScheduledTasks.Core.Exceptions;
    using Labo.ScheduledTasks.Core.Model;

    public sealed class TaskService : ITaskService
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        private readonly ITaskCreatorManager m_TaskCreatorManager;

        private readonly ITaskManagerFactory m_TaskManagerFactory;

        private ITaskManager m_TaskManager;

        private bool m_Disposed;

        /// <summary>
        /// Gets a value indicating whether the task service [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if the task service [is running]; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning
        {
            get { return m_TaskManager != null && m_TaskManager.IsRunning; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="scheduledTaskStorage">The scheduled task storage.</param>
        /// <param name="taskCreatorManager">The task creator manager.</param>
        /// <param name="taskManagerFactory">The task manager factory.</param>
        /// <exception cref="System.ArgumentNullException">
        /// scheduledTaskStorage
        /// or
        /// taskCreatorManager
        /// or
        /// taskManagerFactory
        /// </exception>
        public TaskService(IScheduledTaskStorage scheduledTaskStorage, ITaskCreatorManager taskCreatorManager, ITaskManagerFactory taskManagerFactory)
        {
            if (scheduledTaskStorage == null)
            {
                throw new ArgumentNullException("scheduledTaskStorage");
            }

            if (taskCreatorManager == null)
            {
                throw new ArgumentNullException("taskCreatorManager");
            }

            if (taskManagerFactory == null)
            {
                throw new ArgumentNullException("taskManagerFactory");
            }

            m_ScheduledTaskStorage = scheduledTaskStorage;
            m_TaskCreatorManager = taskCreatorManager;
            m_TaskManagerFactory = taskManagerFactory;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskService"/> class.
        /// </summary>
        ~TaskService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Starts the task service.
        /// </summary>
        public void Start()
        {
            if (m_TaskManager == null)
            {
                IList<TaskDefinition> taskDefinitions = GetTaskDefinitions();

                m_TaskManager = m_TaskManagerFactory.CreateTaskManager(taskDefinitions);

                m_TaskManager.TaskStarting += TaskManagerBeforeTaskStarted;
                m_TaskManager.TaskEnded += TaskManagerAfterTaskEnded;
                m_TaskManager.OnTaskError += TaskManagerOnTaskError;
            }

            if (m_TaskManager.IsRunning)
            {
                throw new ScheduledTasksException("Task service is already running.");
            }

            m_TaskManager.Start();
        }

        /// <summary>
        /// Stops the task service.
        /// </summary>
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
            IList<ScheduledTask> scheduleTasks = m_ScheduledTaskStorage.GetAllTasks();
            IList<TaskDefinition> taskDefinitions = new List<TaskDefinition>();

            for (int i = 0; i < scheduleTasks.Count; i++)
            {
                ScheduledTask scheduleTask = scheduleTasks[i];
                ITask task = m_TaskCreatorManager.CreateTask(scheduleTask.Configuration);
                taskDefinitions.Add(new TaskDefinition(task, new TaskCofiguration(scheduleTask.Id, scheduleTask.Name, scheduleTask.Seconds, scheduleTask.StopOnError, scheduleTask.Enabled, scheduleTask.RunOnlyOnce)));
            }

            return taskDefinitions;
        }

        private void TaskManagerBeforeTaskStarted(object sender, BeforeTaskStartedEventArgs e)
        {
            m_ScheduledTaskStorage.UpdateStartDate(e.TaskId, e.SignalTime.ToUniversalTime());
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
