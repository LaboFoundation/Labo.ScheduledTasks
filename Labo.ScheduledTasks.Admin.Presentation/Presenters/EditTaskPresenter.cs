namespace Labo.ScheduledTasks.Admin.Presentation.Presenters
{
    using Labo.Common.Exceptions;
    using Labo.Mvp.Core.Presenter;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.Model;

    public sealed class EditTaskPresenter : BasePresenter<IEditTaskView, EditTaskPresenter>
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        public EditTaskPresenter(IScheduledTaskStorage scheduledTaskStorage)
        {
            m_ScheduledTaskStorage = scheduledTaskStorage;
        }

        public void LoadTask()
        {
            int taskId = View.TaskId;
            if (taskId == 0)
            {
                View.Task = new ScheduledTask
                                {
                                    Seconds = 1,
                                    Enabled = true
                                };
            }
            else
            {
                View.Task = m_ScheduledTaskStorage.GetTaskById(taskId);                
            }
        }

        public void SaveTask()
        {
            ScheduledTask task = View.Task;

            try
            {
                if (task.Id > 0)
                {
                    m_ScheduledTaskStorage.UpdateTask(task);
                }
                else
                {
                    m_ScheduledTaskStorage.InsertTask(task);
                }

                Navigator.ShowMessage("Task Saved!");

                Navigator.CloseView(View);
            }
            catch (UserLevelException userLevelException)
            {
                Navigator.ShowMessage(userLevelException.Message);
            }
        }
    }
}
