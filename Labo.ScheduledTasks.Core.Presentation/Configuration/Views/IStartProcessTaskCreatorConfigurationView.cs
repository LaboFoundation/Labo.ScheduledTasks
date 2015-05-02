namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Views
{
    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;

    public interface IStartProcessTaskCreatorConfigurationView : IView<StartProcessTaskCreatorConfigurationPresenter>, ITaskCreatorConfigurationView
    {
        string FileName { get; set; }

        string Arguments { get; set; }
    }
}
