namespace Labo.ScheduledTasks.Core
{
    public interface ITaskCreator : ITaskCreatorInfo
    {
        ITask CreateTask(string taskConfiguration);
    }
}
