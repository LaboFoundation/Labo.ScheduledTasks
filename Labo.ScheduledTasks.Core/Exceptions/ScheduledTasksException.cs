namespace Labo.ScheduledTasks.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using Labo.Common.Exceptions;

    [Serializable]
    public class ScheduledTasksException : CoreLevelException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTasksException"/> class.
        /// </summary>
        public ScheduledTasksException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTasksException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ScheduledTasksException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTasksException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ScheduledTasksException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledTasksException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected ScheduledTasksException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
