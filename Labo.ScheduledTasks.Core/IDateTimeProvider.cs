namespace Labo.ScheduledTasks.Core
{
    using System;

    public interface IDateTimeProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        DateTime GetUtcNow();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        DateTime GetNow();
    }
}
