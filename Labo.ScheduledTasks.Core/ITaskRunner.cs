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
        /// Occurs when [task is starting].
        /// </summary>
        event EventHandler<BeforeTaskStartedEventArgs> TaskStarting;

        /// <summary>
        /// Occurs when [task is ended].
        /// </summary>
        event EventHandler<AfterTaskEndedEventArgs> TaskEnded;

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Stop")]
        void Stop();
    }
}