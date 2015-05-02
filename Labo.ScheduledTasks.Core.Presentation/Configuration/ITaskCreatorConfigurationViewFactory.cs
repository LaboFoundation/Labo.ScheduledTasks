namespace Labo.ScheduledTasks.Core.Presentation.Configuration
{
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public interface ITaskCreatorConfigurationViewFactory
    {
        void OpenView(IEditTaskView parentView, string taskType, string configuration);
    }
}