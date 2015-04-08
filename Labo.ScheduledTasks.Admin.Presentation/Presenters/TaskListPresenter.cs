namespace Labo.ScheduledTasks.Admin.Presentation.Presenters
{
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core;

    public sealed class TaskListPresenter : BasePresenter<ITaskListView, TaskListPresenter>
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        public TaskListPresenter(IScheduledTaskStorage scheduledTaskStorage)
        {
            m_ScheduledTaskStorage = scheduledTaskStorage;
        }

        public override void OnLoad()
        {
        }

        public void LoadScheduledTaskList()
        {
            View.ScheduledTasks = m_ScheduledTaskStorage.GetAllTasks();
        }

        public void OpenEditTaskView(int p)
        {
            throw new System.NotImplementedException();
        }
    }
}
