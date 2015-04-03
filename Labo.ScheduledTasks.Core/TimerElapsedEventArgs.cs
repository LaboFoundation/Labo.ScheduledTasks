namespace Labo.ScheduledTasks.Core
{
    using System;

    /// <summary>
    /// The timer elapsed event args.
    /// </summary>
    public sealed class TimerElapsedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the signal time.
        /// </summary>
        /// <value>
        /// The signal time.
        /// </value>
        public DateTime SignalTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerElapsedEventArgs"/> class.
        /// </summary>
        /// <param name="signalTime">The signal time.</param>
        public TimerElapsedEventArgs(DateTime signalTime)
        {
            SignalTime = signalTime;
        }
    }
}