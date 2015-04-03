namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface ITaskManager : IDisposable
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
        /// Starts the task manager
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the task manager
        /// </summary>
        void Stop();
    }
}