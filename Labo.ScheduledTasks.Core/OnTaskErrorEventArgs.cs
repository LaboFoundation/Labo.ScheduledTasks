namespace Labo.ScheduledTasks.Core
{
    using System;

    /// <summary>
    /// The on task error event args class.
    /// </summary>
    public sealed class OnTaskErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        public int TaskId { get; private set; }

        /// <summary>
        /// Gets the started date UTC.
        /// </summary>
        /// <value>
        /// The started date UTC.
        /// </value>
        public DateTime? StartedDateUtc { get; private set; }

        /// <summary>
        /// Gets the end date UTC.
        /// </summary>
        /// <value>
        /// The end date UTC.
        /// </value>
        public DateTime? EndDateUtc { get; private set; }

        /// <summary>
        /// The error.
        /// </summary>
        private readonly Exception m_Error;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Exception Error
        {
            get
            {
                return m_Error;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnTaskErrorEventArgs"/> class.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="endDateUtc">The end date utc.</param>
        /// <param name="error">The error.</param>
        /// <param name="startedDateUtc">The start date utc.</param>
        public OnTaskErrorEventArgs(int taskId, DateTime? startedDateUtc, DateTime? endDateUtc, Exception error)
        {
            if (error == null)
            {
                throw new ArgumentNullException("error");
            }

            m_Error = error;
            TaskId = taskId;
            StartedDateUtc = startedDateUtc;
            EndDateUtc = endDateUtc;
        }
    }
}