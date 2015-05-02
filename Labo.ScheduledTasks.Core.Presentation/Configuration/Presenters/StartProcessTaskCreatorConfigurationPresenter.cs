namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;
    using Labo.ScheduledTasks.Core.Tasks;

    public sealed class StartProcessTaskCreatorConfigurationPresenter : TaskCreatorConfigurationPresenterBase<IStartProcessTaskCreatorConfigurationView, StartProcessTaskCreatorConfigurationPresenter>, ITaskCreatorConfigurationPresenter
    {
        protected override void LoadConfiguration(string configurationString)
        {
            StartProcessTask.Configuration configuration = SerializationUtils.DeserializeXmlObject<StartProcessTask.Configuration>(configurationString);

            View.FileName = configuration.FileName;
            View.Arguments = configuration.Arguments;
        }

        public override string GenerateConfigurationString()
        {
            StartProcessTask.Configuration configuration = new StartProcessTask.Configuration
                                                               {
                                                                   FileName = View.FileName,
                                                                   Arguments = View.Arguments
                                                               };

            return SerializationUtils.XmlSerializeObject(configuration);
        }
    }
}
