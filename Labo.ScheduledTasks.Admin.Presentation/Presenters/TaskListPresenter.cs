namespace Labo.ScheduledTasks.Admin.Presentation.Presenters
{
    using System;

    using Labo.Mvp.Core.Presenter;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public sealed class TaskListPresenter : BasePresenter<ITaskListView, TaskListPresenter>
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        private readonly ITaskService m_TaskService;

        public TaskListPresenter(IScheduledTaskStorage scheduledTaskStorage, ITaskService taskService)
        {
            if (scheduledTaskStorage == null)
            {
                throw new ArgumentNullException("scheduledTaskStorage");
            }

            if (taskService == null)
            {
                throw new ArgumentNullException("taskService");
            }

            m_ScheduledTaskStorage = scheduledTaskStorage;
            m_TaskService = taskService;
        }

        public override void OnLoad()
        {
            UpdateTaskServiceRunningState();
        }

        public void LoadScheduledTaskList()
        {
            View.ScheduledTasks = m_ScheduledTaskStorage.GetAllTasks();
        }

        public void OpenEditTaskView(int taskId)
        {
            Navigator.OpenView<IEditTaskView>(View, taskId);
        }

        public void StartTaskService()
        {
           m_TaskService.Start();

           UpdateTaskServiceRunningState();
        }

        public void StopTaskService()
        {
            m_TaskService.Stop();

            UpdateTaskServiceRunningState();
        }

        private void UpdateTaskServiceRunningState()
        {
            View.TaskServiceRunning = m_TaskService.IsRunning;
        }
    }
}
