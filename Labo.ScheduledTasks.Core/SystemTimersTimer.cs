namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Timers;

    public sealed class SystemTimersTimer : ITimer
    {
        /// <summary>
        /// The timer
        /// </summary>
        private readonly Timer m_Timer;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool m_Disposed;

        /// <summary>
        /// Occurs when the time [elapsed].
        /// </summary>
        public event EventHandler<TimerElapsedEventArgs> Elapsed = delegate { };

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public double Interval 
        {
            get
            {
                return m_Timer.Interval;
            }

            set
            {
                m_Timer.Interval = value;
            } 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTimersTimer"/> class.
        /// </summary>
        /// <param name="interval">
        /// The interval.
        /// </param>
        public SystemTimersTimer(int interval)
        {
            if (interval <= 0)
            {
                throw new ArgumentOutOfRangeException("interval", "interval must be greater than 0");
            }

            m_Timer = new Timer(interval);
            m_Timer.Enabled = true;
            m_Timer.AutoReset = true;
            m_Timer.Elapsed += TimerElapsed;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SystemTimersTimer"/> class.
        /// </summary>
        ~SystemTimersTimer()
        {
           Dispose(false); 
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            m_Timer.Start();
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            m_Timer.Stop();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Occurs when timer is elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed(this, new TimerElapsedEventArgs(e.SignalTime));
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (m_Disposed)
            {
                return;
            }

            if (disposing)
            {
                try
                {
                    if (m_Timer != null)
                    {
                        m_Timer.Dispose();
                    }
                }
                finally
                {
                    m_Disposed = true;
                }
            }
        }
    }
}
