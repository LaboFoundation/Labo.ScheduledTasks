namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    using System.Collections.Generic;
    using System.Linq;

    using Labo.Common.Exceptions;
    using Labo.Common.Utils;
    using Labo.Mvp.Core.Presenter;
    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.Model;
    using Labo.ScheduledTasks.Core.Presentation.Configuration;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public sealed class EditTaskPresenter : BasePresenter<IEditTaskView, EditTaskPresenter>
    {
        private readonly IScheduledTaskStorage m_ScheduledTaskStorage;

        private readonly ITaskCreatorManager m_TaskCreatorManager;

        private readonly ITaskCreatorConfigurationViewFactory m_TaskCreatorConfigurationViewFactory;

        public EditTaskPresenter(IScheduledTaskStorage scheduledTaskStorage, ITaskCreatorManager taskCreatorManager, ITaskCreatorConfigurationViewFactory taskCreatorConfigurationViewFactory)
        {
            m_ScheduledTaskStorage = scheduledTaskStorage;
            m_TaskCreatorManager = taskCreatorManager;
            m_TaskCreatorConfigurationViewFactory = taskCreatorConfigurationViewFactory;
        }

        public void LoadTask()
        {
            List<string> taskTypeSelectItems = m_TaskCreatorManager.GetTaskCreatorInfos().Select(x => x.Name).ToList();
            taskTypeSelectItems.Insert(0, "Select..");

            View.TaskTypeSelectItems = taskTypeSelectItems;

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
                ScheduledTask scheduledTask = m_ScheduledTaskStorage.GetTaskById(taskId);

                TaskCreatorDefinition taskCreatorDefinition = SerializationUtils.DeserializeXmlObject<TaskCreatorDefinition>(scheduledTask.Configuration);

                scheduledTask.Configuration = taskCreatorDefinition.Configuration;

                View.Task = scheduledTask;
            }
        }

        public void SaveTask()
        {
            ScheduledTask task = View.Task;

            task.Configuration = SerializationUtils.XmlSerializeObject(new TaskCreatorDefinition { Configuration = task.Configuration, Type = task.Type });

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
                Navigator.RefreshParentView(View);
                Navigator.CloseView(View);
            }
            catch (UserLevelException userLevelException)
            {
                Navigator.ShowMessage(userLevelException.Message);
            }
        }

        public void OnSelectedTaskTypeChanged(string type)
        {
            m_TaskCreatorConfigurationViewFactory.OpenView(View, type, View.Task.Configuration ?? string.Empty);
        }
    }
}
