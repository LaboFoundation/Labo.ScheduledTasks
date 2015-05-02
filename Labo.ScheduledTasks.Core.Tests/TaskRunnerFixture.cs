namespace Labo.ScheduledTasks.Core.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.EventArgs;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class TaskRunnerFixture
    {
        [Test]
        public void Initialize_TaskRunnerIntervalMustBeEqualTo_TimerInterval()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            ITimer timer = Substitute.For<ITimer>();

            const double interval = 100;
            timer.Interval.Returns(x => interval);
            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);

            Assert.AreEqual(interval, taskRunner.Interval);
        }

        [Test]
        public void Initialize_TaskRunnerInitDateUtcMustBeEqualTo_DateTimeProviderDateUtc()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            ITimer timer = Substitute.For<ITimer>();

            DateTime utcNow = new DateTime(2005, 2, 18);
            dateTimeProvider.GetUtcNow().Returns(x => utcNow);
            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);

            Assert.AreEqual(utcNow, taskRunner.InitDateUtc);
        }

        [Test]
        public void Start_TimerMustStart_WhenTaskRunnerIsStarted()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            ITimer timer = Substitute.For<ITimer>();

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);
            taskRunner.Start();

            timer.Received(1).Start();
        }

        private sealed class TimerStub : ITimer
        {
            private int m_StartCallCount;

            private int m_StopCallCount;

            private int m_DisposeCallCount;

            private readonly DateTime m_SignalTime;

            public event EventHandler<TimerElapsedEventArgs> Elapsed = delegate { };

            public double Interval { get; private set; }

            public int StartCallCount
            {
                get
                {
                    return m_StartCallCount;
                }
            }

            public bool Started
            {
                get
                {
                    return m_StartCallCount > 0;
                }
            }

            public int StopCallCount
            {
                get
                {
                    return m_StopCallCount;
                }
            }

            public bool Stoped
            {
                get
                {
                    return m_StopCallCount > 0;
                }
            }

            public int DisposeCallCount
            {
                get
                {
                    return m_DisposeCallCount;
                }
            }

            public bool Disposed
            {
                get
                {
                    return m_DisposeCallCount > 0;
                }
            }

            public bool IsRunning { get; private set; }

            private readonly Thread m_Thread;

            public TimerStub(DateTime signalTime, int interval)
            {
                Interval = interval;
                m_SignalTime = signalTime;

                m_Thread = new Thread(ThreadStart);
            }

            public void Start()
            {
                m_StartCallCount++;

                IsRunning = true;

                m_Thread.Start(m_SignalTime);
            }

            public void Stop()
            {
                m_StopCallCount++;

                IsRunning = false;
            }

            public void Dispose()
            {
                m_DisposeCallCount++;

                IsRunning = false;

                if (m_Thread != null)
                {
                    m_Thread.Abort();
                }
            }

            private void ThreadStart(object signalTime)
            {
                Thread.Sleep((int)Interval);

                Elapsed(this, new TimerElapsedEventArgs((DateTime)signalTime));
            }
        }

        [Test]
        public void Start_TimerStartMustBeCalled()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            bool timerElapsedCalled = false;
            TimerStub timer = new TimerStub(utcNow, 1000);
            timer.Elapsed += (sender, args) =>
                {
                    timerElapsedCalled = true;

                    Assert.AreEqual(utcNow, args.SignalTime);
                };

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);
            taskRunner.Start();

            Stopwatch sw = Stopwatch.StartNew();
            const int timeout = 10 * 1000;
            while (timer.DisposeCallCount < 1 && sw.ElapsedMilliseconds < timeout)
            {
            }

            sw.Stop();

            Assert.IsTrue(timerElapsedCalled);
            Assert.IsTrue(timer.Started);
        }

        [Test]
        public void Start_TimerMustBeDisposedAfterTaskRunWhenOnlyOnceIsTrue()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            TimerStub timer = new TimerStub(utcNow, 1000);
            timer.Elapsed += (sender, args) =>
            {
                Assert.IsTrue(timer.Started);
            };

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, true);
            taskRunner.Start();

            Stopwatch sw = Stopwatch.StartNew();
            const int timeout = 10 * 1000;
            while (timer.DisposeCallCount < 1 && sw.ElapsedMilliseconds < timeout)
            {
            }

            sw.Stop();

            Assert.IsTrue(timer.Started);
            Assert.IsTrue(timer.Stoped);
            Assert.IsTrue(timer.Disposed);
            Assert.IsFalse(timer.IsRunning);
        }

        [Test]
        public void Start_TimerMustBeDisposedAfterTaskRunWhenOnlyOnceIsFalse()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            TimerStub timer = new TimerStub(utcNow, 1000);
            timer.Elapsed += (sender, args) =>
            {
                Assert.IsTrue(timer.Started);
            };

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, false, false, false);
            taskRunner.Start();

            Assert.IsTrue(timer.Started);

            Stopwatch sw = Stopwatch.StartNew();
            const int timeout = 10 * 1000;
            while (timer.StartCallCount < 2 && sw.ElapsedMilliseconds < timeout)
            { 
            }

            sw.Stop();

            taskRunner.Stop();

            Assert.IsTrue(timer.Stoped);
            Assert.IsFalse(timer.IsRunning);

            taskRunner.Dispose();
        }

        [Test]
        public void Start_TimerMustBeStopedBeforeTaskStarted()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            TimerStub timer = new TimerStub(utcNow, 1000);

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);
            taskRunner.TaskStarting += (sender, args) =>
                {
                    Assert.IsFalse(timer.IsRunning);
                    Assert.IsTrue(timer.Stoped);
                };
            taskRunner.Start();
        }

        [Test]
        public void Start_TaskRunnerIsRunningMustBeFalseBeforeTaskStarted()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            TimerStub timer = new TimerStub(utcNow, 1000);

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);
            taskRunner.TaskStarting += (sender, args) =>
            {
                Assert.IsFalse(taskRunner.IsRunning);
            };
            taskRunner.Start();
        }

        [Test]
        public void Start_TaskRunnerSignalTimeMustBeSetBeforeTaskStarted()
        {
            ITask task = Substitute.For<ITask>();
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            DateTime utcNow = new DateTime(2005, 2, 18);

            TimerStub timer = new TimerStub(utcNow, 1000);

            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, false, false);
            taskRunner.TaskStarting += (sender, args) =>
            {
                Assert.AreEqual(utcNow, args.SignalTime);
            };
            taskRunner.Start();
        }

        [Test]
        public void Elapsed_WhenStopOnErrorIsTrue_ThenTimerAndTaskRunnerMustBeStopped()
        {
            Exception exception = new Exception();
            ITask task = Substitute.For<ITask>();
            task.When(x => x.Run()).Do(
                x =>
                    {
                        throw exception;
                    });
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            DateTime utcNow = new DateTime(2005, 3, 15);
            TimerStub timer = new TimerStub(utcNow, 0);
            TaskRunner taskRunner = new TaskRunner(task, 1, dateTimeProvider, timer, true, true, false);

            bool hasError = false;
            taskRunner.OnTaskError += (sender, args) =>
                {
                    hasError = true;

                    Assert.AreEqual(exception, args.Error);

                    Thread.Sleep(500);
                };
            taskRunner.Start();

            Stopwatch sw = Stopwatch.StartNew();
            const int timeout = 10 * 1000;
            while (!hasError && sw.ElapsedMilliseconds < timeout)
            {
                Thread.Sleep(100);
            }

            Assert.IsFalse(taskRunner.Enabled);
            Assert.IsFalse(taskRunner.IsRunning);
            Assert.IsTrue(timer.Stoped);

            Assert.AreEqual(1, timer.StartCallCount);
            Assert.AreEqual(2, timer.StopCallCount);
        }
    }
}
