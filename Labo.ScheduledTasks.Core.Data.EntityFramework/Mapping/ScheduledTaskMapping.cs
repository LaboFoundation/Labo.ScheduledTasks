namespace Labo.ScheduledTasks.Core.Data.EntityFramework.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Labo.ScheduledTasks.Core.Model;

    public sealed class ScheduledTaskMapping : EntityTypeConfiguration<ScheduledTask>
    {
        public ScheduledTaskMapping()
            : this("ScheduledTask")
        {
        }

        public ScheduledTaskMapping(string tableName)
        {
            HasKey(t => t.Id);
            ToTable(tableName);
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Enabled).HasColumnName("Enabled").IsRequired();
            Property(t => t.LastEndUtc).HasColumnName("LastEndUtc");
            Property(t => t.LastStartUtc).HasColumnName("LastStartUtc");
            Property(t => t.LastSuccessUtc).HasColumnName("LastSuccessUtc");
            Property(t => t.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.RunOnlyOnce).HasColumnName("RunOnlyOnce").IsRequired();
            Property(t => t.Seconds).HasColumnName("Seconds").IsRequired();
            Property(t => t.StopOnError).HasColumnName("StopOnError").IsRequired();
            Property(t => t.Type).HasColumnName("Type").IsRequired().IsUnicode(false).HasMaxLength(1000);
            
        }
    }
}
