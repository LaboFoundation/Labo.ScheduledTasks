namespace Labo.ScheduledTasks.Core
{
    using System;

    using Labo.ScheduledTasks.Core.EventArgs;

    /// <summary>
    /// The task runner interface that runs the task with the specified interval.
    /// </summary>
    public interface ITaskRunner : IDisposable, ITaskRunnerInfo
    {
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