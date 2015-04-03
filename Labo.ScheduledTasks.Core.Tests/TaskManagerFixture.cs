namespace Labo.ScheduledTasks.Core.Tests
{
    using System.Collections.Generic;

    using Labo.ScheduledTasks.Core;
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
