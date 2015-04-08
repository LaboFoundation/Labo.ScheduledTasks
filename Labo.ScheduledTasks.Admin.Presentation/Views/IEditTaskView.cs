namespace Labo.ScheduledTasks.Admin.Presentation.Views
{
    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Core.Model;

    public interface IEditTaskView : IView<EditTaskPresenter>
    {
        ScheduledTask Task { set; get; }

        int TaskId { get; }
    }
}
