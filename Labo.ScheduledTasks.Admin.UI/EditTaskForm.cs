namespace Labo.ScheduledTasks.Admin.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Forms;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Model;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public partial class EditTaskForm : Form, IEditTaskView
    {
        private int m_TaskId;

        private bool m_CbxTaskTypesEnabled = true;

        public EditTaskPresenter Presenter { get; set; }

        public IView ParentView { get; set; }

        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as EditTaskPresenter; }
        }

        public string Caption
        {
            get { return Text; }
            set { Text = value; }
        }

        public int TaskId
        {
            get
            {
                return m_TaskId;
            }
        }

        public ScheduledTask Task
        {
            get
            {
                return new ScheduledTask
                {
                    Id = TaskId,
                    Name = txtName.Text.Trim(),
                    Type = Convert.ToString(cbxTaskTypes.SelectedItem, CultureInfo.InvariantCulture),
                    Description = txtDescription.Text.Trim(),
                    Configuration = txtConfiguration.Text,
                    Seconds = (int)nudSeconds.Value,
                    Enabled = cbxEnabled.Checked,
                    RunOnlyOnce = cbxRunOnlyOnce.Checked,
                    StopOnError = cbxStopOnError.Checked
                };
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                ScheduledTask task = value;
                
                if (!string.IsNullOrWhiteSpace(task.Type))
                {
                    m_CbxTaskTypesEnabled = false;
                    btnChangeType.Enabled = true;
                    cbxTaskTypes.Enabled = false;
                    cbxTaskTypes.Text = task.Type;
                    m_CbxTaskTypesEnabled = true;                   
                }

                txtName.Text = task.Name;
                txtDescription.Text = task.Description;
                txtConfiguration.Text = task.Configuration;
                nudSeconds.Value = task.Seconds;
                cbxEnabled.Checked = task.Enabled;
                cbxRunOnlyOnce.Checked = task.RunOnlyOnce;
                cbxStopOnError.Checked = task.StopOnError;

                m_TaskId = task.Id;
            }
        }

        public EditTaskForm()
            : this(0)
        {
        }

        public EditTaskForm(int taskId)
        {
            InitializeComponent();

            m_TaskId = taskId;

            cbxTaskTypes.SelectedIndexChanged += cbxTaskTypes_SelectedIndexChanged;
        }

        private void cbxTaskTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CbxTaskTypesEnabled && cbxTaskTypes.SelectedIndex > 0)
            {
                Presenter.OnSelectedTaskTypeChanged(cbxTaskTypes.SelectedItem.ToString());
            }
        }

        public void OnLoad()
        {
            Presenter.LoadTask();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Presenter.SaveTask();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public IList<string> TaskTypeSelectItems
        {
            set
            {
                cbxTaskTypes.DataSource = value;
            }
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
                btnChangeType.Enabled = true;
                cbxTaskTypes.Enabled = false;
            }
        }

        private void btnChangeType_Click(object sender, EventArgs e)
        {
            Configuration = string.Empty;
            cbxTaskTypes.SelectedIndex = 0;
            cbxTaskTypes.Enabled = true;
            btnChangeType.Enabled = false;
        }
    }
}
