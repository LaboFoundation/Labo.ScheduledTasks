namespace Labo.ScheduledTasks.Core
{
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.Model;

    public sealed class DefaultTaskManagerFactory : ITaskManagerFactory
    {
        private readonly ITimerFactory m_TimerFactory;

        private readonly IDateTimeProvider m_DateTimeProvider;

        public DefaultTaskManagerFactory(ITimerFactory timerFactory, IDateTimeProvider dateTimeProvider)
        {
            m_TimerFactory = timerFactory;
            m_DateTimeProvider = dateTimeProvider;
        }

        public ITaskManager CreateTaskManager(IList<TaskDefinition> taskDefinitions)
        {
            return new TaskManager(taskDefinitions, m_TimerFactory, m_DateTimeProvider);
        }
    }
}