namespace Labo.ScheduledTasks.Core
{
    public interface ITaskCreator
    {
        ITask CreateTask(string taskName);
    }
}
