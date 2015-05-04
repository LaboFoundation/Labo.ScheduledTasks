namespace Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters
{
    using Labo.Mvp.Core.Presenter;
    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public abstract class TaskCreatorConfigurationPresenterBase<TView, TPresenter> : BasePresenter<TView, TPresenter>
        where TView : class, IView<TPresenter>, ITaskCreatorConfigurationView
        where TPresenter : class, IPresenter<TView, TPresenter>
    {
        public void LoadConfiguration()
        {
            string configurationString = View.Configuration;
            if (!string.IsNullOrWhiteSpace(configurationString))
            {
                LoadConfiguration(configurationString);
            }
        }

        protected abstract void LoadConfiguration(string configurationString);

        public abstract string GenerateConfigurationString();

        public void SaveConfiguration()
        {
            View.Configuration = GenerateConfigurationString();

            ITaskCreatorConfigurationView taskCreatorConfigurationView = View.ParentView as ITaskCreatorConfigurationView;
            if (taskCreatorConfigurationView != null)
            {
                taskCreatorConfigurationView.Configuration = View.Configuration;
            }

            Navigator.CloseView(View);
        }
    }
}