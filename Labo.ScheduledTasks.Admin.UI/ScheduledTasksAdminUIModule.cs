namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Data.Entity.Infrastructure;

    using Labo.Common.Data.EntityFramework.Session;
    using Labo.Common.Data.Session;
    using Labo.Common.Data.SqlServer;
    using Labo.Common.Ioc;
    using Labo.ScheduledTasks.Admin.Presentation;
    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.Data;
    using Labo.ScheduledTasks.Core.Data.EntityFramework;

    internal sealed class ScheduledTasksAdminUIModule : IIocModule
    {
        public void Configure(IIocContainer registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            BaseEntityFrameworkSessionFactoryProvider entityFrameworkSessionFactoryProvider = new SqlServerEntityFrameworkSessionFactoryProvider();
            entityFrameworkSessionFactoryProvider.ObjectContextManager.RegisterObjectContextCreator(() => ((IObjectContextAdapter)new ScheduledTasksDbContext()).ObjectContext);
            registry.RegisterSingleInstance<ISessionFactoryProvider>(x => entityFrameworkSessionFactoryProvider);
            registry.RegisterSingleInstance<ISessionScopeProvider>(x => new SessionScopeProvider(x.GetInstance<ISessionFactoryProvider>()));

            registry.RegisterModule(new ScheduledTasksAdminPresentationModule(x => new DbScheduledTaskStorage(x.GetInstance<ISessionScopeProvider>()), x => x.GetInstance<ITaskCreatorManager>()));
            
            registry.RegisterSingleInstance<IDateTimeProvider>(x => new DefaultDateTimeProvider());
            registry.RegisterSingleInstance<ITimerFactory>(x => new DefaultTimerFactory());
            registry.RegisterSingleInstance<ITaskCreatorManager>(x => new DefaultTaskCreatorManager());
            registry.RegisterSingleInstance<ITaskManagerFactory>(x => new DefaultTaskManagerFactory(x.GetInstance<ITimerFactory>(), x.GetInstance<IDateTimeProvider>()));
            registry.RegisterSingleInstance<ITaskService>(x => new TaskService(x.GetInstance<IScheduledTaskStorage>(), x.GetInstance<ITaskCreatorManager>(), x.GetInstance<ITaskManagerFactory>()));
        }
    }
}
