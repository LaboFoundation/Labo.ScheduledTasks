namespace Labo.ScheduledTasks.Core.EventArgs
{
    using System;

    /// <summary>
    /// The before task started event args class.
    /// </summary>
    public sealed class BeforeTaskStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        public int TaskId { get; private set; }

        /// <summary>
        /// Gets the signal time.
        /// </summary>
        /// <value>
        /// The signal time.
        /// </value>
        public DateTime SignalTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeforeTaskStartedEventArgs"/> class.
        /// </summary>
        /// <param name="taskId">The tast id.</param>
        /// <param name="signalTime">The signal time.</param>
        public BeforeTaskStartedEventArgs(int taskId, DateTime signalTime)
        {
            TaskId = taskId;
            SignalTime = signalTime;
        }
    }
}