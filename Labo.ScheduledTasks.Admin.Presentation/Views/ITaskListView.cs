namespace Labo.ScheduledTasks.Admin.Presentation.Views
{
    using System.Collections.Generic;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Core.Model;

    public interface ITaskListView : IView<TaskListPresenter>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        IList<ScheduledTask> ScheduledTasks { set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        bool TaskServiceRunning { set; }
    }
}
