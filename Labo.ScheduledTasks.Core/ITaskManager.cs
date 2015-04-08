namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.EventArgs;

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
        /// Gets the task runner information list.
        /// </summary>
        /// <value>
        /// The task runner information list.
        /// </value>
        IList<ITaskRunnerInfo> TaskRunnerInfos { get; }

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