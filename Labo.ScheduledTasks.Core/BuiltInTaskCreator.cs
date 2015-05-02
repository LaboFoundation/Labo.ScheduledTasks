namespace Labo.ScheduledTasks.Core
{
    using System;

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

        public string Name
        {
            get { return "built-in"; }
        }
    }
}