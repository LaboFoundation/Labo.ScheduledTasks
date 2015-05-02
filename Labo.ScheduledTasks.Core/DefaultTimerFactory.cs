namespace Labo.ScheduledTasks.Core
{
    public sealed class DefaultTimerFactory : ITimerFactory
    {
        public ITimer CreateTimer(int milliSeconds)
        {
            return new SystemTimersTimer(milliSeconds);
        }
    }
}