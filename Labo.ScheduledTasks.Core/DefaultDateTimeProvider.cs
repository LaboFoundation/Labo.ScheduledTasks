namespace Labo.ScheduledTasks.Core
{
    using System;

    public sealed class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }

        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}