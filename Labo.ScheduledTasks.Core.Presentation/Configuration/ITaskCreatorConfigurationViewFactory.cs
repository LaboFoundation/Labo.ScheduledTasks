namespace Labo.ScheduledTasks.Core.Presentation.Configuration
{
    using Labo.Mvp.Core.View;

    public interface ITaskCreatorConfigurationViewFactory
    {
        void OpenView(IView parentView, string taskType, string configuration);
    }
}