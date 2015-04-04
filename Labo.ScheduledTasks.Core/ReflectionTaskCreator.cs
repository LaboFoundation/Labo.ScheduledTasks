namespace Labo.ScheduledTasks.Core
{
    using System;

    public sealed class ReflectionTaskCreator : ITaskCreator
    {
        public ITask CreateTask(string taskName)
        {
            Type type = Type.GetType(taskName);

            return (ITask)Activator.CreateInstance(type);
        }
    }
}