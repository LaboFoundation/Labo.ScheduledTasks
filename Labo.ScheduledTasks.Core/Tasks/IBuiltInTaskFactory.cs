namespace Labo.ScheduledTasks.Core.Tasks
{
    public interface IBuiltInTaskFactory
    {
        ITask CreateTask(BuiltInTaskConfiguration configuration);
    }
}
