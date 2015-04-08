namespace Labo.ScheduledTasks.Admin.Presentation
{
    using System;

    using Labo.Common.Ioc;
    using Labo.Mvp.Core;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core;

    public sealed class ScheduledTasksAdminPresentationModule : IIocModule
    {
        private readonly Func<IIocContainerResolver, IScheduledTaskStorage> m_ScheduledTaskStorageCreator;

        public ScheduledTasksAdminPresentationModule(Func<IIocContainerResolver, IScheduledTaskStorage> scheduledTaskStorageCreator)
        {
            if (scheduledTaskStorageCreator == null)
            {
                throw new ArgumentNullException("scheduledTaskStorageCreator");
            }

            m_ScheduledTaskStorageCreator = scheduledTaskStorageCreator;
        }

        public void Configure(IIocContainer registry)
        {
            registry.RegisterSingleInstance(m_ScheduledTaskStorageCreator);

            MvpApplication.PresenterFactory.RegisterPresenter<IEditTaskView, EditTaskPresenter>();
            MvpApplication.PresenterFactory.RegisterPresenter<ITaskListView, TaskListPresenter>();
        }
    }
}
