namespace Labo.ScheduledTasks.Core
{
    using System;

    /// <summary>
    /// The timer interface.
    /// </summary>
    public interface ITimer : IDisposable
    {
        /// <summary>
        /// Occurs when the time [elapsed].
        /// </summary>
        event EventHandler<TimerElapsedEventArgs> Elapsed;

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        double Interval { get; }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the timer.
        /// </summary>
        void Stop();
    }
}
