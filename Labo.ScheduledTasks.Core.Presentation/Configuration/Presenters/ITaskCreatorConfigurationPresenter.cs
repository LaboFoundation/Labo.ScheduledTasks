namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    public interface ITaskCreatorConfigurationPresenter
    {
        void LoadConfiguration();

        string GenerateConfigurationString();
    }
}