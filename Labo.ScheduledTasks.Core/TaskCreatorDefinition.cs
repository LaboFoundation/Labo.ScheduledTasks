namespace Labo.ScheduledTasks.Core
{
    using System;

    [Serializable]
    public sealed class TaskCreatorDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public string Type { get; set; }

        public string Configuration { get; set; }
    }
}