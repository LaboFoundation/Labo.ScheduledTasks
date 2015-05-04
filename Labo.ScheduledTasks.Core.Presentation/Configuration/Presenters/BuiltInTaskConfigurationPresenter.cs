namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    using System.Collections.Generic;
    using System.Linq;

    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;
    using Labo.ScheduledTasks.Core.Tasks;

    public sealed class BuiltInTaskConfigurationPresenter : TaskCreatorConfigurationPresenterBase<IBuiltInTaskConfigurationView, BuiltInTaskConfigurationPresenter>
    {
        private readonly ITaskCreatorManager m_TaskCreatorManager;

        private readonly ITaskCreatorConfigurationViewFactory m_TaskCreatorConfigurationViewFactory;

        public BuiltInTaskConfigurationPresenter(ITaskCreatorManager taskCreatorManager, ITaskCreatorConfigurationViewFactory taskCreatorConfigurationViewFactory)
        {
            m_TaskCreatorManager = taskCreatorManager;
            m_TaskCreatorConfigurationViewFactory = taskCreatorConfigurationViewFactory;
        }

        public override void OnLoad()
        {
            List<string> taskTypeSelectItems = m_TaskCreatorManager.GetBuiltInTaskCreatorInfos().Select(x => x.Name).ToList();
            taskTypeSelectItems.Insert(0, "Select..");

            View.TaskTypeSelectItems = taskTypeSelectItems;
        }

        public void OnSelectedTaskTypeChanged(string type)
        {
            m_TaskCreatorConfigurationViewFactory.OpenView(View, type, View.Configuration ?? string.Empty);
        }

        protected override void LoadConfiguration(string configurationString)
        {
            BuiltInTaskConfiguration configuration = SerializationUtils.DeserializeXmlObject<BuiltInTaskConfiguration>(configurationString);

            View.TaskType = configuration.TaskName;
            View.Configuration = configuration.Parameters;
        }

        public override string GenerateConfigurationString()
        {
            BuiltInTaskConfiguration configuration = new BuiltInTaskConfiguration
            {
                TaskName = View.TaskType,
                Parameters = View.Configuration
            };

            return SerializationUtils.XmlSerializeObject(configuration);
        }
    }
}