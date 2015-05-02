namespace Labo.ScheduledTasks.Core
{
    using System;
    using System.Globalization;

    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Exceptions;

    public sealed class ReflectionTaskCreator : ITaskCreator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible"), Serializable]
        public sealed class Configuration
        {
            public string TaskType { get; set; }
        }

        public ITask CreateTask(string taskConfiguration)
        {
            Configuration configuration = SerializationUtils.DeserializeXmlObject<Configuration>(taskConfiguration);
            Type type = Type.GetType(configuration.TaskType, false);

            if (type != null)
            {
                return (ITask)Activator.CreateInstance(type);
            }
            else
            {
                throw new ScheduledTasksException(string.Format(CultureInfo.CurrentCulture, "'{0}' type could not be found.", taskConfiguration));
            }
        }

        public string Name
        {
            get { return "reflection"; }
        }
    }
}