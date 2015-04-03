namespace Labo.ScheduledTasks.Core.Model
{
    using System;

    public sealed class TaskContext
    {
        /// <summary>
        /// Gets a value indicating whether [is running].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is running]; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the last start UTC date.
        /// </summary>
        /// <value>
        /// The last start UTC date.
        /// </value>
        public DateTime? LastStartDateUtc { get; private set; }

        /// <summary>
        /// Gets the last end UTC date.
        /// </summary>
        /// <value>
        /// The last end UTC date.
        /// </value>
        public DateTime? LastEndDateUtc { get; private set; }

        /// <summary>
        /// Gets the last success UTC date.
        /// </summary>
        /// <value>
        /// The last success UTC date.
        /// </value>
        public DateTime? LastSuccessDateUtc { get; private set; }

        /// <summary>
        /// Gets the type of the task.
        /// </summary>
        /// <value>
        /// The type of the task.
        /// </value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [stop configuration error].
        /// </summary>
        /// <value>
        /// <c>true</c> if [stop configuration error]; otherwise, <c>false</c>.
        /// </value>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is [enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if the task is [enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }
    }
}