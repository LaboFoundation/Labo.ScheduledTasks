namespace Labo.ScheduledTasks.Core
{
    using System;

    /// <summary>
    /// The task runner interface that runs the task with the specified interval.
    /// </summary>
    public interface ITaskRunner : IDisposable
    {
        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        int TaskId { get; }

        /// <summary>
        /// Gets the last success date UTC.
        /// </summary>
        /// <value>
        /// The last success date UTC.
        /// </value>
        DateTime? LastSuccessDateUtc { get; }

        /// <summary>
        /// Gets the last start date UTC.
        /// </summary>
        /// <value>
        /// The last start date UTC.
        /// </value>
        DateTime? LastStartDateUtc { get; }

        /// <summary>
        /// Gets the last end date UTC.
        /// </summary>
        /// <value>
        /// The last end date UTC.
        /// </value>
        DateTime? LastEndDateUtc { get; }

        /// <summary>
        /// Gets a value indicating whether the task [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if  the task [is running]; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        /// Gets the signal time.
        /// </summary>
        /// <value>
        /// The signal time.
        /// </value>
        DateTime? SignalTime { get; }

        /// <summary>
        /// Gets the interval in milliseconds
        /// </summary>
        double Interval { get; }

        /// <summary>
        /// Gets a value indicating whether the task runner runs only once.
        /// </summary>
        bool RunOnlyOnce { get; }

        /// <summary>
        /// Gets the initialize date UTC.
        /// </summary>
        /// <value>
        /// The initialize date UTC.
        /// </value>
        DateTime InitDateUtc { get; }

        /// <summary>
        /// Gets a value indicating whether [stop the task runner on error].
        /// </summary>
        /// <value>
        /// <c>true</c> if [stop the task runner on error]; otherwise, <c>false</c>.
        /// </value>
        bool StopOnError { get; }

        /// <summary>
        /// Gets a value indicating whether [the task runner is enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [the task runner is enabled]; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }

        /// <summary>
        /// Occurs when [before task started].
        /// </summary>
        event EventHandler<BeforeTaskStartedEventArgs> BeforeTaskStarted;

        /// <summary>
        /// Occurs when [after task ended].
        /// </summary>
        event EventHandler<AfterTaskEndedEventArgs> AfterTaskEnded;

        /// <summary>
        /// Occurs when [configuration task error].
        /// </summary>
        event EventHandler<OnTaskErrorEventArgs> OnTaskError;

        /// <summary>
        /// Starts the task runner.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the task runner.
        /// </summary>
        void Stop();
    }
}