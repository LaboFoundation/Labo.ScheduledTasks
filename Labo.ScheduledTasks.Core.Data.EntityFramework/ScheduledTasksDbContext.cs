namespace Labo.ScheduledTasks.Core.Data.EntityFramework
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Labo.ScheduledTasks.Core.Data.EntityFramework.Mapping;

    public sealed class ScheduledTasksDbContext : DbContext
    {
        static ScheduledTasksDbContext()
        {
            Database.SetInitializer<ScheduledTasksDbContext>(null);
        }

        public ScheduledTasksDbContext()
            : base("name=ScheduledTasksDbContext")
        {
        }

        public ScheduledTasksDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public ScheduledTasksDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        public ScheduledTasksDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public ScheduledTasksDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ScheduledTaskMapping());
        }
    }
}