namespace Labo.ScheduledTasks.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Labo.ScheduledTasks.Core;
    using Labo.ScheduledTasks.Core.EventArgs;
    using Labo.ScheduledTasks.Core.Model;

    using NSubstitute;

    using NUnit.Framework;

    [TestFixture]
    public class TaskManagerFixture
    {
        [Test]
        public void Constructor()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            TaskCofiguration taskCofiguration = new TaskCofiguration(1, "Task1", 10, true, true, false);
            ITask task = Substitute.For<ITask>();

            TaskDefinition taskDefinition = new TaskDefinition(task, taskCofiguration);
            TaskManager taskManager = new TaskManager(new List<TaskDefinition> { taskDefinition }, new DefaultTimerFactory(), dateTimeProvider);

            Assert.AreEqual(1, taskManager.TaskRunners.Count);
            Assert.AreEqual(taskCofiguration.Enabled, taskManager.TaskRunners[0].Enabled);
            Assert.AreEqual(taskCofiguration.Seconds * 1000, taskManager.TaskRunners[0].Interval);
            Assert.AreEqual(taskCofiguration.RunOnlyOnce, taskManager.TaskRunners[0].RunOnlyOnce);
            Assert.AreEqual(taskCofiguration.StopOnError, taskManager.TaskRunners[0].StopOnError);
            Assert.AreEqual(false, taskManager.TaskRunners[0].IsRunning);
        }

        [Test]
        public void Start()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            TaskCofiguration taskCofiguration = new TaskCofiguration(1, "Task1", 10, true, true, false);
            ITask task = Substitute.For<ITask>();
            ITimerFactory timerFactory = Substitute.For<ITimerFactory>();
            ITimer timer = Substitute.For<ITimer>();
            timerFactory.CreateTimer(1).ReturnsForAnyArgs(timer);

            TaskDefinition taskDefinition = new TaskDefinition(task, taskCofiguration);
            TaskManager taskManager = new TaskManager(new List<TaskDefinition> { taskDefinition }, timerFactory, dateTimeProvider);
            taskManager.Start();

            timer.Received(1).Start();
        }

        private sealed class TimerStub : ITimer
        {
            private readonly DateTime m_SignalTime;

            public event EventHandler<TimerElapsedEventArgs> Elapsed = delegate { };

            public double Interval { get; private set; }

            public TimerStub(DateTime signalTime)
            {
                m_SignalTime = signalTime;
            }

            public void Start()
            {
                Elapsed(this, new TimerElapsedEventArgs(m_SignalTime));
            }

            public void Stop()
            {
            }

            public void Dispose()
            {
            }
        }

        [Test]
        public void OnTaskError_TaskManagerOnTaskErrorEventMustBeCalled()
        {
            Exception exception = new Exception();

            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            TaskCofiguration taskCofiguration = new TaskCofiguration(1, "Task1", 10, true, true, false);
            ITask task = Substitute.For<ITask>();
            task.WhenForAnyArgs(x => x.Run()).Do(
                x =>
                    {
                        throw exception;
                    });
            ITimerFactory timerFactory = Substitute.For<ITimerFactory>();
            ITimer timer = new TimerStub(DateTime.UtcNow);
            timerFactory.CreateTimer(1).ReturnsForAnyArgs(timer);

            TaskDefinition taskDefinition = new TaskDefinition(task, taskCofiguration);
            TaskManager taskManager = new TaskManager(new List<TaskDefinition> { taskDefinition }, timerFactory, dateTimeProvider);
            taskManager.OnTaskError += (sender, args) => Assert.AreEqual(exception, args.Error);
            
            taskManager.Start();
        }

        [Test]
        public void Stop()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            TaskCofiguration taskCofiguration = new TaskCofiguration(1, "Task1", 10, true, true, false);
            ITask task = Substitute.For<ITask>();
            ITimerFactory timerFactory = Substitute.For<ITimerFactory>();
            ITimer timer = Substitute.For<ITimer>();
            timerFactory.CreateTimer(1).ReturnsForAnyArgs(timer);

            TaskDefinition taskDefinition = new TaskDefinition(task, taskCofiguration);
            TaskManager taskManager = new TaskManager(new List<TaskDefinition> { taskDefinition }, timerFactory, dateTimeProvider);
            taskManager.Stop();

            timer.Received(1).Stop();
        }

        [Test]
        public void Dispose()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

            TaskCofiguration taskCofiguration = new TaskCofiguration(1, "Task1", 10, true, true, false);
            ITask task = Substitute.For<ITask>();
            ITimerFactory timerFactory = Substitute.For<ITimerFactory>();
            ITimer timer = Substitute.For<ITimer>();
            timerFactory.CreateTimer(1).ReturnsForAnyArgs(timer);

            TaskDefinition taskDefinition = new TaskDefinition(task, taskCofiguration);
            TaskManager taskManager = new TaskManager(new List<TaskDefinition> { taskDefinition }, timerFactory, dateTimeProvider);
            taskManager.Dispose();

            timer.Received(1).Dispose();
        }
    }
}
