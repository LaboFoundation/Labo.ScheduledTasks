namespace Labo.ScheduledTasks.Admin.UI.Tasks
{
    using System.Windows.Forms;

    using Labo.ScheduledTasks.Core;

    public sealed class TestTask : ITask
    {
        public void Run()
        {
            MessageBox.Show("Test");
        }

        public void Dispose()
        {
        }
    }
}
