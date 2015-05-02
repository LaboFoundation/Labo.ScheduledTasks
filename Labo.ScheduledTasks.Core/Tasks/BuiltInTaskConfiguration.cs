namespace Labo.ScheduledTasks.Core.Tasks
{
    using System;

    [Serializable]
    public sealed class BuiltInTaskConfiguration
    {
        public string TaskName { get; set; }

        public string Parameters { get; set; }
    }
}