namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface ITask : IDisposable
    {
        /// <summary>
        /// Runs the task.
        /// </summary>
        void Run();
    }
}
