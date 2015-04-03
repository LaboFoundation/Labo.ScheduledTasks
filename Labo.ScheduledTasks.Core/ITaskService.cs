namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface ITaskService : IDisposable
    {
        void Start();

        void Stop();
    }
}