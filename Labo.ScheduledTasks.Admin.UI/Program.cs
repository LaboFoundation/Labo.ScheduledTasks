namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Windows.Forms;

    using Labo.Common.Ioc;
    using Labo.Mvp.Core;
    using Labo.Mvp.Core.Menu;
    using Labo.Mvp.Core.Navigator;
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;
    using Labo.Mvp.WinForms;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core.Presentation.Configuration;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Common.Ioc.Container.IocContainer iocContainer = new Common.Ioc.Container.IocContainer();
            iocContainer.RegisterSingleInstance<IIocContainer>(x => iocContainer);
            IocContainer.RegisterIocContainerImplementation(iocContainer);

            RegisterModules(iocContainer);
            RegisterViews();

            iocContainer.RegisterSingleInstance(x => MvpApplication.ViewManager);
            iocContainer.RegisterSingleInstance(x => MvpApplication.PresenterFactory);
            iocContainer.RegisterSingleInstance<INavigator>(x => new WinFormsNavigator(x.GetInstance<IViewManager>(), MvpApplication.ViewActivator, x.GetInstance<IPresenterFactory>()));
            iocContainer.RegisterSingleInstance<ITaskCreatorConfigurationViewFactory>(x => new TaskCreatorConfigurationViewFactory(x.GetInstance<IPresenterFactory>(), x.GetInstance<INavigator>()));

            OpenMainView(iocContainer);
        }

        private static void OpenMainView(IIocContainer iocContainer)
        {
            MvpApplication.PresenterFactory.RegisterPresenter<IMainScreenView, MainScreenPresenter>();
            MvpApplication.ViewManager.RegisterView<IMainScreenView, MainScreenForm>("Main", "Labo Scheduled Tasks Admin UI");

            MvpApplication.SetNavigator(iocContainer.GetInstance<INavigator>());

            IMainScreenView mainScreenView =
                MvpApplication.Navigator.GetView<IMainScreenView>(
                    new MenuItemCollection
                        {
                            new Mvp.Core.Menu.MenuItem("Tasks")
                                {
                                    Children =
                                        new MenuItemCollection
                                            {
                                                new Mvp.Core.Menu.MenuItem("Add New Task", "SaveTask"),
                                                new Mvp.Core.Menu.MenuItem("Task List", "TaskList")
                                            }
                                }
                        });

            Form mainForm = (Form)mainScreenView;
            mainForm.Width = 1000;

            Application.Run(mainForm);
        }

        private static void RegisterModules(IIocContainer iocContainer)
        {
            iocContainer.RegisterModule(new ScheduledTasksAdminUIModule());
        }

        private static void RegisterViews()
        {
            IViewManager viewManager = MvpApplication.ViewManager;
            viewManager.RegisterView<IEditTaskView, EditTaskForm>("SaveTask", "Save Task");
            viewManager.RegisterView<ITaskListView, TaskListForm>("TaskList", "Task List");
            viewManager.RegisterView<IStartProcessTaskCreatorConfigurationView, StartProcessTaskCreatorConfigurationForm>("StartProcessTaskConfiguration", "Start Process Task Configuration");
            viewManager.RegisterView<IReflectionTaskCreatorConfigurationView, ReflectionTaskCreatorConfigurationForm>("ReflectionTaskConfiguration", "Reflection Task Configuration");
            viewManager.RegisterView<IBuiltInTaskConfigurationView, BuiltInTaskConfigurationForm>("BuiltInTaskConfiguration", "Built-in Task Configuration");
        }
    }
}
