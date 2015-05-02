namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Views
{
    using System.Collections.Generic;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;

    public interface IReflectionTaskCreatorConfigurationView : IView<ReflectionTaskCreatorConfigurationPresenter>, ITaskCreatorConfigurationView
    {
        string TaskType { get; set; }

        IList<string> TaskTypes { set; }
    }
}