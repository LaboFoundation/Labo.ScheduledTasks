namespace Labo.ScheduledTasks.Admin.UI
{
    using System.Data.Entity.Infrastructure;

    using Labo.Common.Data.EntityFramework.Session;
    using Labo.Common.Data.Session;
    using Labo.Common.Data.SqlServer;
    using Labo.Common.Ioc;
    using Labo.ScheduledTasks.Admin.Presentation;
    using Labo.ScheduledTasks.Core.Data;
    using Labo.ScheduledTasks.Core.Data.EntityFramework;

    internal sealed class ScheduledTasksAdminUIModule : IIocModule
    {
        public void Configure(IIocContainer registry)
        {
            BaseEntityFrameworkSessionFactoryProvider entityFrameworkSessionFactoryProvider = new SqlServerEntityFrameworkSessionFactoryProvider();
            entityFrameworkSessionFactoryProvider.ObjectContextManager.RegisterObjectContextCreator(() => ((IObjectContextAdapter)new ScheduledTasksDbContext()).ObjectContext);
            registry.RegisterSingleInstance<ISessionFactoryProvider>(x => entityFrameworkSessionFactoryProvider);
            registry.RegisterSingleInstance<ISessionScopeProvider>(x => new SessionScopeProvider(x.GetInstance<ISessionFactoryProvider>()));

            registry.RegisterModule(new ScheduledTasksAdminPresentationModule(x => new DbScheduledTaskStorage(x.GetInstance<ISessionScopeProvider>())));
        }
    }
}
