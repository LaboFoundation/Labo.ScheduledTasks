namespace Labo.ScheduledTasks.Core
{
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core.Model;

    public interface ITaskManagerFactory
    {
        ITaskManager CreateTaskManager(IList<TaskDefinition> taskDefinitions);
    }
}