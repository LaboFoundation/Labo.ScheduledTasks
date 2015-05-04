namespace Labo.ScheduledTasks.Core.Presentation.Configuration
{
    using System;
    using System.Globalization;

    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Exceptions;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public sealed class TaskCreatorConfigurationViewFactory : ITaskCreatorConfigurationViewFactory
    {
        private readonly INavigator m_Navigator;

        public TaskCreatorConfigurationViewFactory(IPresenterFactory presenterFactory, INavigator navigator)
        {
            if (presenterFactory == null)
            {
                throw new ArgumentNullException("presenterFactory");
            }

            if (navigator == null)
            {
                throw new ArgumentNullException("navigator");
            }

            m_Navigator = navigator;

            presenterFactory.RegisterPresenter<IStartProcessTaskCreatorConfigurationView, StartProcessTaskCreatorConfigurationPresenter>();
            presenterFactory.RegisterPresenter<IReflectionTaskCreatorConfigurationView, ReflectionTaskCreatorConfigurationPresenter>();
            presenterFactory.RegisterPresenter<IBuiltInTaskConfigurationView, BuiltInTaskConfigurationPresenter>();
        }

        public void OpenView(IView parentView, string taskType, string configuration)
        {
            switch (taskType)
            {
                case "reflection":
                    m_Navigator.OpenView(parentView, "ReflectionTaskConfiguration", configuration);
                    break;
                case "built-in":
                    m_Navigator.OpenView(parentView, "BuiltInTaskConfiguration", configuration);
                    break;
                case "start-process":
                    m_Navigator.OpenView(parentView, "StartProcessTaskConfiguration", configuration);
                    break;
                default:
                    throw new ScheduledTasksException(string.Format(CultureInfo.CurrentCulture, "Task creator configuration '{0}' could not be found.", taskType));
            }
        }
    }
}
