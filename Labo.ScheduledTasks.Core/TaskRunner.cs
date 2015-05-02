namespace Labo.ScheduledTasks.Core
{
    using System;

    using Labo.ScheduledTasks.Core.EventArgs;

    /// <summary>
    /// The task runner that runs the task with the specified interval.
    /// </summary>
    public sealed class TaskRunner : ITaskRunner
    {
        /// <summary>
        /// The task
        /// </summary>
        private readonly ITask m_Task;

        /// <summary>
        /// The date time provider
        /// </summary>
        private readonly IDateTimeProvider m_DateTimeProvider;

        /// <summary>
        /// The interval in milliseconds
        /// </summary>
        private readonly double m_Interval;

        /// <summary>
        /// The run only once
        /// </summary>
        private readonly bool m_RunOnlyOnce;

        /// <summary>
        /// The timer
        /// </summary>
        private readonly ITimer m_Timer;

        /// <summary>
        /// The stop on error
        /// </summary>
        private readonly bool m_StopOnError;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool m_Disposed;

        /// <summary>
        /// Gets the initialize date UTC.
        /// </summary>
        /// <value>
        /// The initialize date UTC.
        /// </value>
        public DateTime InitDateUtc { get; private set; }

        /// <summary>
        /// Gets the started date UTC.
        /// </summary>
        /// <value>
        /// The started date UTC.
        /// </value>
        public DateTime? LastStartDateUtc { get; private set; }

        /// <summary>
        /// Gets the end date UTC.
        /// </summary>
        /// <value>
        /// The end date UTC.
        /// </value>
        public DateTime? LastEndDateUtc { get; private set; }

        /// <summary>
        /// Gets the last success date UTC.
        /// </summary>
        /// <value>
        /// The last success date UTC.
        /// </value>
        public DateTime? LastSuccessDateUtc { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is running]; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the signal time.
        /// </summary>
        /// <value>
        /// The signal time.
        /// </value>
        public DateTime? SignalTime { get; private set; }

        /// <summary>
        /// Gets the interval in milliseconds
        /// </summary>
        public double Interval
        {
            get
            {
                return m_Interval;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the task runner runs only once.
        /// </summary>
        public bool RunOnlyOnce
        {
            get
            {
                return m_RunOnlyOnce;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [stop the task runner on error].
        /// </summary>
        /// <value>
        /// <c>true</c> if [stop the task runner on error]; otherwise, <c>false</c>.
        /// </value>
        public bool StopOnError
        {
            get
            {
                return m_StopOnError;
            }
        }

        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        public int TaskId { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [the task runner is enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [the task runner is enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; private set; }

        /// <summary>
        /// Occurs when [before task started].
        /// </summary>
        public event EventHandler<BeforeTaskStartedEventArgs> TaskStarting = delegate { };

        /// <summary>
        /// Occurs when [after task ended].
        /// </summary>
        public event EventHandler<AfterTaskEndedEventArgs> TaskEnded = delegate { };

        /// <summary>
        /// Occurs when [configuration task error].
        /// </summary>
        public event EventHandler<OnTaskErrorEventArgs> OnTaskError = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRunner"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="taskId">The task id.</param>
        /// <param name="dateTimeProvider">The date time provider.</param>
        /// <param name="timer">The timer.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="stopOnError">Stop on error.</param>
        /// <param name="runOnlyOnce">if set to <c>true</c> [run only once].</param>
        /// <exception cref="System.ArgumentNullException">task</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">interval;interval must be greater than 0</exception>
        public TaskRunner(ITask task, int taskId, IDateTimeProvider dateTimeProvider, ITimer timer, bool enabled, bool stopOnError, bool runOnlyOnce)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }

            if (taskId < 1)
            {
                throw new ArgumentOutOfRangeException("taskId", "taskId cannot be smaller than 1.");
            }

            if (dateTimeProvider == null)
            {
                throw new ArgumentNullException("dateTimeProvider");
            }

            if (timer == null)
            {
                throw new ArgumentNullException("timer");
            }

            m_Task = task;
            m_DateTimeProvider = dateTimeProvider;
            m_Interval = timer.Interval;
            m_RunOnlyOnce = runOnlyOnce;

            m_Timer = timer;
            TaskId = taskId;
            Enabled = enabled;
            m_StopOnError = stopOnError;
            m_Timer.Elapsed += TimerElapsed;

            InitDateUtc = m_DateTimeProvider.GetUtcNow();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TaskRunner"/> class.
        /// </summary>
        ~TaskRunner()
        {
            Dispose(false);
        }

        /// <summary>
        /// Starts the task runner.
        /// </summary>
        public void Start()
        {
            m_Timer.Start();
        }

        /// <summary>
        /// Stops the task runner.
        /// </summary>
        public void Stop()
        {
            m_Timer.Stop();

            IsRunning = false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Occurs when timer is elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TimerElapsedEventArgs"/> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void TimerElapsed(object sender, TimerElapsedEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            try
            {
                m_Timer.Stop();

                SignalTime = e.SignalTime;

                TaskStarting(this, new BeforeTaskStartedEventArgs(TaskId, SignalTime.GetValueOrDefault()));

                LastStartDateUtc = m_DateTimeProvider.GetUtcNow();
                IsRunning = true;

                m_Task.Run();

                LastSuccessDateUtc = LastEndDateUtc = m_DateTimeProvider.GetUtcNow();

                TaskEnded(this, new AfterTaskEndedEventArgs(TaskId, LastStartDateUtc, LastEndDateUtc));

                if (RunOnlyOnce)
                {
                    Dispose();
                }
                else
                {
                    m_Timer.Start();
                }
            }
            catch (Exception ex)
            {
                if (StopOnError)
                {
                    Enabled = false;
                    Stop();
                }

                OnTaskError(this, new OnTaskErrorEventArgs(TaskId, LastStartDateUtc, LastEndDateUtc, ex));
            }
            finally 
            {
                IsRunning = false;
            }
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
                    if (m_Timer != null)
                    {
                        m_Timer.Dispose();
                    }

                    if (m_Task != null)
                    {
                        m_Task.Dispose();
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