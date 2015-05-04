namespace Labo.ScheduledTasks.Core.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Labo.ScheduledTasks.Core.Exceptions;

    internal sealed class DefaultBuiltInTaskFactory : IBuiltInTaskFactory
    {
        private readonly SortedList<string, ITaskCreator> m_BuiltInTaskCreators;

        public DefaultBuiltInTaskFactory()
        {
            m_BuiltInTaskCreators = new SortedList<string, ITaskCreator>(StringComparer.OrdinalIgnoreCase);

            AddTaskCreator(new StartProcessTaskCreator());
        }

        private void AddTaskCreator(ITaskCreator startProcessTaskCreator)
        {
            m_BuiltInTaskCreators.Add(startProcessTaskCreator.Name, startProcessTaskCreator);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly")]
        public ITask CreateTask(BuiltInTaskConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            string taskName = configuration.TaskName;

            if (taskName == null)
            {
                throw new ArgumentNullException("configuration.TaskName");
            }

            ITaskCreator taskCreator;
            if (m_BuiltInTaskCreators.TryGetValue(taskName, out taskCreator))
            {
                string arguments = configuration.Parameters;

                return taskCreator.CreateTask(arguments);
            }

            throw new ScheduledTasksException(string.Format(CultureInfo.CurrentCulture, "'{0}' built-in task could not be found.", taskName));
        }

        public IList<ITaskCreatorInfo> GetTaskCreatorInfos()
        {
            return m_BuiltInTaskCreators.Values.Cast<ITaskCreatorInfo>().ToList();
        }
    }
}