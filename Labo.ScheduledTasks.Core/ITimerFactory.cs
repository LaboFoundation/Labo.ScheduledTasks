namespace Labo.ScheduledTasks.Core
{
    public interface ITimerFactory
    {
        ITimer CreateTimer(int milliSeconds);
    }
}
