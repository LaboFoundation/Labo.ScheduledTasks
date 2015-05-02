namespace Labo.ScheduledTasks.Core
{
    using System;

    using Labo.ScheduledTasks.Core.Configuration;
    using Labo.ScheduledTasks.Core.Model;

    public interface IScheduledTaskStorage : IScheduledTaskConfiguration
    {
        void DeleteTask(int taskId);

        ScheduledTask GetTaskById(int taskId);

        ScheduledTask GetTaskByName(string name);

        void InsertTask(ScheduledTask task);

        void UpdateTask(ScheduledTask task);

        void UpdateStartDate(int taskId, DateTime startDateUtc);

        void UpdateEndDate(int taskId, DateTime endDateUtc, bool success);
    }
}
