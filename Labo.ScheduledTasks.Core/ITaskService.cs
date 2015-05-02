namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface ITaskService : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether the task service [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if the task service [is running]; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        /// Starts the task service.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the task service.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Stop")]
        void Stop();
    }
}