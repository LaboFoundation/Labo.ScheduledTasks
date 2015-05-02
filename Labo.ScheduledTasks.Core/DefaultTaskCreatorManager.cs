namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Exceptions;
    using Labo.ScheduledTasks.Core.Tasks;

    public sealed class DefaultTaskCreatorManager : ITaskCreatorManager
    {
        private readonly SortedList<string, ITaskCreator> m_TaskCreators;

        public DefaultTaskCreatorManager()
            : this(GetDefaultTaskCreators())
        {
        }

        public DefaultTaskCreatorManager(IList<ITaskCreator> taskCreators)
        {
            if (taskCreators == null)
            {
                throw new ArgumentNullException("taskCreators");
            }

            m_TaskCreators = new SortedList<string, ITaskCreator>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < taskCreators.Count; i++)
            {
                ITaskCreator taskCreator = taskCreators[i];
                AddTaskCreator(taskCreator);
            }
        }

        public void AddTaskCreator(ITaskCreator taskCreator)
        {
            if (taskCreator == null)
            {
                throw new ArgumentNullException("taskCreator");
            }

            m_TaskCreators.Add(taskCreator.Name, taskCreator);
        }

        public ITask CreateTask(string taskDefinition)
        {
            if (taskDefinition == null)
            {
                throw new ArgumentNullException("taskDefinition");
            }

            TaskCreatorDefinition taskDefinitionObject = SerializationUtils.DeserializeXmlObject<TaskCreatorDefinition>(taskDefinition);

            ITaskCreator taskCreator;
            if (m_TaskCreators.TryGetValue(taskDefinitionObject.Type, out taskCreator))
            {
                return taskCreator.CreateTask(taskDefinitionObject.Configuration);
            }

            throw new ScheduledTasksException(string.Format(CultureInfo.CurrentCulture, "Task creator for '{0}' could not be found.", taskDefinitionObject.Type));
        }

        private static ITaskCreator[] GetDefaultTaskCreators()
        {
            return new ITaskCreator[]
                       {
                           new BuiltInTaskCreator(new DefaultBuiltInTaskFactory()), 
                           new ReflectionTaskCreator()
                       };
        }

        public IList<ITaskCreatorInfo> GetTaskCreatorInfos()
        {
            return m_TaskCreators.Values.Cast<ITaskCreatorInfo>().ToList();
        }
    }
}