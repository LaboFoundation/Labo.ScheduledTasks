namespace Labo.ScheduledTasks.Core
{
    using System.Collections.Generic;

    public interface ITaskCreatorManager
    {
        void AddTaskCreator(ITaskCreator taskCreator);

        ITask CreateTask(string taskDefinition);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IList<ITaskCreatorInfo> GetTaskCreatorInfos();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IList<ITaskCreatorInfo> GetBuiltInTaskCreatorInfos();
    }
}