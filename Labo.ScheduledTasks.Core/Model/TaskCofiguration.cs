namespace Labo.ScheduledTasks.Core.Model
{
    using System;

    [Serializable]
    public sealed class TaskCofiguration
    {
        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public string TaskName { get; private set; }

        /// <summary>
        /// Gets the task unique identifier.
        /// </summary>
        /// <value>
        /// The task unique identifier.
        /// </value>
        public int TaskId { get; private set; }

        /// <summary>
        /// Gets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [stop on error].
        /// </summary>
        /// <value>
        /// <c>true</c> if [stop on error]; otherwise, <c>false</c>.
        /// </value>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [run only once].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [run only once]; otherwise, <c>false</c>.
        /// </value>
        public bool RunOnlyOnce { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskCofiguration"/> class.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="taskName">Name of the task.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="stopOnError">if set to <c>true</c> [stop on error].</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="runOnlyOnce">if set to <c>true</c> [run only once].</param>
        public TaskCofiguration(int taskId, string taskName, int seconds, bool stopOnError, bool enabled, bool runOnlyOnce)
        {
            if (taskId < 1)
            {
                throw new ArgumentOutOfRangeException("taskId", "taskId cannot be smaller than 1.");
            }

            if (seconds < 1)
            {
                throw new ArgumentOutOfRangeException("seconds", "seconds cannot be smaller than 1.");
            }

            if (string.IsNullOrWhiteSpace(taskName))
            {
                throw new ArgumentOutOfRangeException("taskName", "taskName cannot be null.");
            }

            TaskId = taskId;
            Seconds = seconds;
            StopOnError = stopOnError;
            Enabled = enabled;
            RunOnlyOnce = runOnlyOnce;
            TaskName = taskName;
        }
    }
}