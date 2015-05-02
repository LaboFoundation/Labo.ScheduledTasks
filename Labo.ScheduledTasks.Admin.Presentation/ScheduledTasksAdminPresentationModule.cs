namespace Labo.ScheduledTasks.Admin.Presentation
{
    using System;

    using Labo.Common.Ioc;
    using Labo.Mvp.Core;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public sealed class ScheduledTasksAdminPresentationModule : IIocModule
    {
        private readonly Func<IIocContainerResolver, IScheduledTaskStorage> m_ScheduledTaskStorageCreator;

        private readonly Func<IIocContainerResolver, ITaskCreatorManager> m_TaskCreatorManagerCreator;

        public ScheduledTasksAdminPresentationModule(
            Func<IIocContainerResolver, IScheduledTaskStorage> scheduledTaskStorageCreator,
            Func<IIocContainerResolver, ITaskCreatorManager> taskCreatorManagerCreator)
        {
            if (scheduledTaskStorageCreator == null)
            {
                throw new ArgumentNullException("scheduledTaskStorageCreator");
            }

            m_ScheduledTaskStorageCreator = scheduledTaskStorageCreator;
            m_TaskCreatorManagerCreator = taskCreatorManagerCreator;
        }

        public void Configure(IIocContainer registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            registry.RegisterSingleInstance(m_ScheduledTaskStorageCreator);
            registry.RegisterSingleInstance(m_TaskCreatorManagerCreator);

            MvpApplication.PresenterFactory.RegisterPresenter<IEditTaskView, EditTaskPresenter>();
            MvpApplication.PresenterFactory.RegisterPresenter<ITaskListView, TaskListPresenter>();
        }
    }
}
