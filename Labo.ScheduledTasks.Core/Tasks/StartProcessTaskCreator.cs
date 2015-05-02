namespace Labo.ScheduledTasks.Core.Tasks
{
    using Labo.Common.Utils;

    internal sealed class StartProcessTaskCreator : ITaskCreator
    {
        public string Name
        {
            get
            {
                return "start-process";
            }
        }

        public ITask CreateTask(string taskConfiguration)
        {
            StartProcessTask.Configuration configuration = SerializationUtils.DeserializeXmlObject<StartProcessTask.Configuration>(taskConfiguration);

            return new StartProcessTask(configuration.FileName, configuration.Arguments);
        }
    }
}