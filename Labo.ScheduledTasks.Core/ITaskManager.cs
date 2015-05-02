namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.EventArgs;

    public interface ITaskManager : IDisposable
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
        /// Gets the task runner information list.
        /// </summary>
        /// <value>
        /// The task runner information list.
        /// </value>
        IList<ITaskRunnerInfo> TaskRunnerInfos { get; }

        /// <summary>
        /// Gets a value indicating whether the task manager [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if the task manager [is running]; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        /// Starts the task manager
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the task manager
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Stop")]
        void Stop();
    }
}