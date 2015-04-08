namespace Labo.ScheduledTasks.Core.Configuration
{
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.Model;

    public interface IScheduledTaskConfiguration
    {
        IList<ScheduledTask> GetAllTasks();
    }
}
