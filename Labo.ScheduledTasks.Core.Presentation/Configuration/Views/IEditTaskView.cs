namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Views
{
    using System.Collections.Generic;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Model;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;

    public interface IEditTaskView : IView<EditTaskPresenter>, ITaskCreatorConfigurationView
    {
        ScheduledTask Task { set; get; }

        int TaskId { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly")]
        IList<string> TaskTypeSelectItems { set; }
    }
}
