namespace Labo.ScheduledTasks.Core.Model
{
    using System;

    [Serializable]
    public sealed class ScheduledTask
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the run period (in seconds)
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Gets or sets the type of appropriate ITask class
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a task is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [run only once].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [run only once]; otherwise, <c>false</c>.
        /// </value>
        public bool RunOnlyOnce { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a task should be stopped on some error
        /// </summary>
        public bool StopOnError { get; set; }

        /// <summary>
        /// Gets or sets the last start UTC.
        /// </summary>
        /// <value>
        /// The last start UTC.
        /// </value>
        public DateTime? LastStartUtc { get; set; }

        /// <summary>
        /// Gets or sets the last end UTC.
        /// </summary>
        /// <value>
        /// The last end UTC.
        /// </value>
        public DateTime? LastEndUtc { get; set; }

        /// <summary>
        /// Gets or sets the last success UTC.
        /// </summary>
        /// <value>
        /// The last success UTC.
        /// </value>
        public DateTime? LastSuccessUtc { get; set; }
    }
}