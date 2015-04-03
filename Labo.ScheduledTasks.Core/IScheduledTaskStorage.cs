namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.Model;

    public interface IScheduledTaskStorage
    {
        void DeleteTask(int taskId);

        ScheduleTask GetTaskById(int taskId);

        ScheduleTask GetTaskByType(string type);

        IList<ScheduleTask> GetAllTasks();

        void InsertTask(ScheduleTask task);

        void UpdateTask(ScheduleTask task);

        void UpdateStartDate(int taskId, DateTime startDateUtc);

        void UpdateEndDate(int taskId, DateTime endDateUtc, bool success);
    }
}
