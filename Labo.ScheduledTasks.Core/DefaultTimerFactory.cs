namespace Labo.ScheduledTasks.Core
{
    internal sealed class DefaultTimerFactory : ITimerFactory
    {
        public ITimer CreateTimer(int milliSeconds)
        {
            return new SystemTimersTimer(milliSeconds);
        }
    }
}