namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime GetUtcNow();

        DateTime GetNow();
    }
}
