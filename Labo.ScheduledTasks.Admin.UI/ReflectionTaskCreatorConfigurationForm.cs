namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public partial class ReflectionTaskCreatorConfigurationForm : Form, IReflectionTaskCreatorConfigurationView
    {
        public string TaskType
        {
            get
            {
                return txtSelectedTask.Text;
            }

            set
            {
                txtSelectedTask.Text = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public IList<string> TaskTypes
        {
            set { lbxTaskList.DataSource = value; }
        }

        public string Configuration { get; set; }

        public ReflectionTaskCreatorConfigurationPresenter Presenter { get; set; }

        public IView ParentView { get; set; }

        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as ReflectionTaskCreatorConfigurationPresenter; }
        }

        public string Caption
        {
            get
            {
                return Text;
            }

            set
            {
                Text = value;
            }
        }

        public ReflectionTaskCreatorConfigurationForm(string configuration)
        {
            Configuration = configuration;

            InitializeComponent();
        }

        public void OnLoad()
        {
            Presenter.LoadConfiguration();
            Presenter.LoadAppDomainTasks();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.SaveConfiguration();
        }

        private void lbxTaskList_DoubleClick(object sender, EventArgs e)
        {
            if (lbxTaskList.SelectedValue != null)
            {
                txtSelectedTask.Text = lbxTaskList.SelectedValue.ToString();                
            }
        }
    }
}
