namespace Labo.ScheduledTasks.Admin.Presentation.Views
{
    using System.Collections.Generic;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Core.Model;

    public interface ITaskListView : IView<TaskListPresenter>
    {
       IList<ScheduledTask> ScheduledTasks { set; }
    }
}
