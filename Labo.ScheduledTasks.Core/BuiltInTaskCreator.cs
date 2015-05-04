namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Tasks;

    internal sealed class BuiltInTaskCreator : ITaskCreator
    {
        private readonly IBuiltInTaskFactory m_BuiltInTaskFactory;

        public BuiltInTaskCreator(IBuiltInTaskFactory builtInTaskFactory)
        {
            if (builtInTaskFactory == null)
            {
                throw new ArgumentNullException("builtInTaskFactory");
            }

            m_BuiltInTaskFactory = builtInTaskFactory;
        }

        public ITask CreateTask(string taskConfiguration)
        {
            if (taskConfiguration == null)
            {
                throw new ArgumentNullException("taskConfiguration");
            }

            BuiltInTaskConfiguration configuration = SerializationUtils.DeserializeXmlObject<BuiltInTaskConfiguration>(taskConfiguration);

            return m_BuiltInTaskFactory.CreateTask(configuration);
        }

        public IList<ITaskCreatorInfo> GetTaskCreatorInfos()
        {
            return m_BuiltInTaskFactory.GetTaskCreatorInfos();
        }

        public string Name
        {
            get { return "built-in"; }
        }
    }
}