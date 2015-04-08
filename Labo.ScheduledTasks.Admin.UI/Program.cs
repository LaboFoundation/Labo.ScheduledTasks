namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Windows.Forms;

    using Labo.Common.Ioc;
    using Labo.Mvp.Core;
    using Labo.Mvp.Core.Menu;
    using Labo.Mvp.WinForms;
    using Labo.ScheduledTasks.Admin.Presentation.Views;

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

            RegisterModules();
            RegisterNavigator();
            RegisterViews();

            OpenMainView();
        }

        private static void RegisterNavigator()
        {
            MvpApplication.SetNavigator(new WinFormsNavigator(MvpApplication.ViewManager, MvpApplication.ViewActivator, MvpApplication.PresenterFactory));
        }

        private static void OpenMainView()
        {
            MvpApplication.PresenterFactory.RegisterPresenter<IMainScreenView, MainScreenPresenter>();
            MvpApplication.ViewManager.RegisterView<IMainScreenView, MainScreenForm>("Main", "Labo Scheduled Tasks Admin UI");
            IMainScreenView mainScreenView =
                MvpApplication.Navigator.GetView<IMainScreenView>(
                    new MenuItemCollection
                        {
                            new Labo.Mvp.Core.Menu.MenuItem("Tasks")
                                {
                                    Children =
                                        new MenuItemCollection
                                            {
                                                new Labo.Mvp.Core.Menu.MenuItem("Add New Task", "SaveTask"),
                                                new Labo.Mvp.Core.Menu.MenuItem("Task List", "TaskList")
                                            }
                                }
                        });

            Form mainForm = (Form)mainScreenView;
            mainForm.Width = 1000;

            Application.Run(mainForm);
        }

        private static void RegisterModules()
        {
            Labo.Common.Ioc.Container.IocContainer iocContainer = new Labo.Common.Ioc.Container.IocContainer();
            iocContainer.RegisterSingleInstance<IIocContainer>(x => iocContainer);
            IocContainer.RegisterIocContainerImplementation(iocContainer);

            iocContainer.RegisterModule(new ScheduledTasksAdminUIModule());
        }

        private static void RegisterViews()
        {
            MvpApplication.ViewManager.RegisterView<IEditTaskView, EditTaskForm>("SaveTask", "Save Task");
            MvpApplication.ViewManager.RegisterView<ITaskListView, TaskListForm>("TaskList", "Task List");
        }
    }
}
