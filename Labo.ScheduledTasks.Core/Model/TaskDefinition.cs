namespace Labo.ScheduledTasks.Core.Model
{
    using System;

    public sealed class TaskDefinition
    {
        /// <summary>
        /// The task.
        /// </summary>
        private readonly ITask m_Task;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly TaskCofiguration m_Configuration;

        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public ITask Task
        {
            get
            {
                return m_Task;
            }
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public TaskCofiguration Configuration
        {
            get
            {
                return m_Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskDefinition"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="System.ArgumentNullException">
        /// task
        /// or
        /// configuration
        /// </exception>
        public TaskDefinition(ITask task, TaskCofiguration configuration)
        {
            if (task == null)
            {
                throw new ArgumentNullException("task");
            }

            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            m_Task = task;
            m_Configuration = configuration;
        }
    }
}