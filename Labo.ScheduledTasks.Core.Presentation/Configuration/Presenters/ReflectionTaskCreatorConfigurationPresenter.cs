namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Labo.Common.Utils;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;
    using Labo.ScheduledTasks.Core.Tasks;

    public sealed class ReflectionTaskCreatorConfigurationPresenter : TaskCreatorConfigurationPresenterBase<IReflectionTaskCreatorConfigurationView, ReflectionTaskCreatorConfigurationPresenter>
    {
        protected override void LoadConfiguration(string configurationString)
        {
            ReflectionTaskCreator.Configuration configuration = SerializationUtils.DeserializeXmlObject<ReflectionTaskCreator.Configuration>(configurationString);

            View.TaskType = configuration.TaskType;
        }

        public override string GenerateConfigurationString()
        {
            ReflectionTaskCreator.Configuration configuration = new ReflectionTaskCreator.Configuration
                                                                    {
                                                                        TaskType = View.TaskType
                                                                    };

            return SerializationUtils.XmlSerializeObject(configuration);
        }

        public void LoadAppDomainTasks()
        {
            Type taskType = typeof(ITask);

            ICollection<string> taskTypes = new SortedSet<string>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                Assembly assembly = assemblies[i];
                Type[] types = assembly.GetTypes();

                for (int j = 0; j < types.Length; j++)
                {
                    Type type = types[j];
                    if (type != taskType && taskType.IsAssignableFrom(type))
                    {
                        if (!ReflectionUtils.HasCustomAttribute<BuiltInTaskAttribute>(type, false))
                        {
                            taskTypes.Add(type.AssemblyQualifiedName);                            
                        }
                    }
                }
            }

            View.TaskTypes = taskTypes.ToList();
        }
    }
}