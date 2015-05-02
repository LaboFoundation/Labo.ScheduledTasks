namespace Labo.ScheduledTasks.Core.Configuration
{
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.Model;

    public interface IScheduledTaskConfiguration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IList<ScheduledTask> GetAllTasks();
    }
}
