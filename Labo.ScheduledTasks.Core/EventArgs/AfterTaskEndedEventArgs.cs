namespace Labo.ScheduledTasks.Core.EventArgs
{
    using System;

    /// <summary>
    /// The after task ended event args class.
    /// </summary>
    public sealed class AfterTaskEndedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the started date UTC.
        /// </summary>
        /// <value>
        /// The started date UTC.
        /// </value>
        public DateTime? StartedDateUtc { get; private set; }

        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        public int TaskId { get; private set; }

        /// <summary>
        /// Gets the end date UTC.
        /// </summary>
        /// <value>
        /// The end date UTC.
        /// </value>
        public DateTime? EndDateUtc { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AfterTaskEndedEventArgs"/> class.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="startedDateUtc">The started date UTC.</param>
        /// <param name="endDateUtc">The end date UTC.</param>
        public AfterTaskEndedEventArgs(int taskId, DateTime? startedDateUtc, DateTime? endDateUtc)
        {
            TaskId = taskId;
            EndDateUtc = endDateUtc;
            StartedDateUtc = startedDateUtc;
        }
    }
}