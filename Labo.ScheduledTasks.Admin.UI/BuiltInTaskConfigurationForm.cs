namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public partial class BuiltInTaskConfigurationForm : Form, IBuiltInTaskConfigurationView
    {
        private bool m_CbxTaskTypesEnabled = true;

        public BuiltInTaskConfigurationPresenter Presenter { get; set; }

        public IView ParentView { get; set; }

        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as BuiltInTaskConfigurationPresenter; }
        }

        public string Caption
        {
            get { return Text; }
            set { Text = value; }
        }

        public string Configuration
        {
            get
            {
                return txtConfiguration.Text;
            }

            set
            {
                txtConfiguration.Text = value;
            }
        }

        public string TaskType
        {
            get
            {
                return cbxTaskTypes.Text;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    m_CbxTaskTypesEnabled = false;
                    cbxTaskTypes.Text = value;
                    m_CbxTaskTypesEnabled = true;
                }
            }
        }

        public BuiltInTaskConfigurationForm(string configuration)
        {
            InitializeComponent();

            Configuration = configuration;

            cbxTaskTypes.SelectedIndexChanged += cbxTaskTypes_SelectedIndexChanged;
        }

        private void cbxTaskTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CbxTaskTypesEnabled && cbxTaskTypes.SelectedIndex > 0)
            {
                Presenter.OnSelectedTaskTypeChanged(cbxTaskTypes.SelectedItem.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.SaveConfiguration();
        }

        public IList<string> TaskTypeSelectItems
        {
            set { cbxTaskTypes.DataSource = value; }
        }

        public void OnLoad()
        {
            Presenter.LoadConfiguration();
        }
    }
}
