namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Labo.ScheduledTasks.Core.EventArgs;
    using Labo.ScheduledTasks.Core.Model;

    public sealed class TaskManager : ITaskManager
    {
        /// <summary>
        /// The timer factory.
        /// </summary>
        private readonly ITimerFactory m_TimerFactory;

        /// <summary>
        /// The date time provider.
        /// </summary>
        private readonly IDateTimeProvider m_DateTimeProvider;

        /// <summary>
        /// The task runners
        /// </summary>
        private IList<ITaskRunner> m_TaskRunners;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool m_Disposed;

        /// <summary>
        /// Gets the task runner information list.
        /// </summary>
        /// <value>
        /// The task runner information list.
        /// </value>
        public IList<ITaskRunnerInfo> TaskRunnerInfos
        {
            get
            {
                return m_TaskRunners.Cast<ITaskRunnerInfo>().ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the task runners.
        /// </summary>
        /// <value>
        /// The task runners.
        /// </value>
        internal IList<ITaskRunner> TaskRunners
        {
            get
            {
                return m_TaskRunners;
            }
        }

        /// <summary>
        /// Occurs when [before task started].
        /// </summary>
        public event EventHandler<BeforeTaskStartedEventArgs> BeforeTaskStarted = delegate { };

        /// <summary>
        /// Occurs when [after task ended].
        /// </summary>
        public event EventHandler<AfterTaskEndedEventArgs> AfterTaskEnded = delegate { };

        /// <summary>
        /// Occurs when [configuration task error].
        /// </summary>
        public event EventHandler<OnTaskErrorEventArgs> OnTaskError = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class.
        /// </summary>
        /// <param name="taskDefinitions">The task definitions.</param>
        /// <param name="timerFactory">The timer factory.</param>
        /// <param name="dateTimeProvider">The date time provider.</param>
        /// <exception cref="System.ArgumentNullException">
        /// taskDefinitions
        /// or
        /// timerFactory
        /// or
        /// dateTimeProvider
        /// </exception>
        public TaskManager(IList<TaskDefinition> taskDefinitions, ITimerFactory timerFactory, IDateTimeProvider dateTimeProvider)
        {
            if (taskDefinitions == null)
            {
                throw new ArgumentNullException("taskDefinitions");
            }

            if (timerFactory == null)
            {
                throw new ArgumentNullException("timerFactory");
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException("dateTimeProvider");
            }

            m_TimerFactory = timerFactory;
            m_DateTimeProvider = dateTimeProvider;

            InitTaskRunner(taskDefinitions);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskManager"/> class.
        /// </summary>
        ~TaskManager()
        {
            Dispose(false);
        }

        /// <summary>
        /// Starts the task manager
        /// </summary>
        public void Start()
        {
            for (int i = 0; i < TaskRunners.Count; i++)
            {
                ITaskRunner taskRunner = TaskRunners[i];
                taskRunner.Start();
            }
        }

        /// <summary>
        /// Stops the task manager
        /// </summary>
        public void Stop()
        {
            for (int i = 0; i < TaskRunners.Count; i++)
            {
                ITaskRunner taskRunner = TaskRunners[i];
                taskRunner.Stop();
            }
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

        private void InitTaskRunner(IList<TaskDefinition> taskDefinitions)
        {
            m_TaskRunners = new List<ITaskRunner>(taskDefinitions.Count);

            for (int i = 0; i < taskDefinitions.Count; i++)
            {
                TaskDefinition taskDefinition = taskDefinitions[i];
                TaskCofiguration taskCofiguration = taskDefinition.Configuration;
                ITimer timer = m_TimerFactory.CreateTimer(taskCofiguration.Seconds * 1000);

                ITaskRunner taskRunner = new TaskRunner(taskDefinition.Task, taskCofiguration.TaskId, m_DateTimeProvider, timer, taskCofiguration.Enabled, taskCofiguration.StopOnError, taskCofiguration.RunOnlyOnce);

                taskRunner.OnTaskError += TaskRunnerOnTaskError;
                taskRunner.AfterTaskEnded += TaskRunnerAfterTaskEnded;
                taskRunner.BeforeTaskStarted += TaskRunnerBeforeTaskStarted;

                TaskRunners.Add(taskRunner);
            }
        }

        private void TaskRunnerBeforeTaskStarted(object sender, BeforeTaskStartedEventArgs e)
        {
            BeforeTaskStarted(sender, e);
        }

        private void TaskRunnerAfterTaskEnded(object sender, AfterTaskEndedEventArgs e)
        {
            AfterTaskEnded(sender, e);
        }

        private void TaskRunnerOnTaskError(object sender, OnTaskErrorEventArgs e)
        {
            OnTaskError(sender, e);
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
                    if (TaskRunners != null)
                    {
                        for (int i = 0; i < TaskRunners.Count; i++)
                        {
                            ITaskRunner taskRunner = TaskRunners[i];
                            taskRunner.Dispose();
                        }
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