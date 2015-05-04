namespace Labo.ScheduledTasks.Core.Tasks
{
    using System.Collections.Generic;

    public interface IBuiltInTaskFactory
    {
        ITask CreateTask(BuiltInTaskConfiguration configuration);

        IList<ITaskCreatorInfo> GetTaskCreatorInfos();
    }
}
