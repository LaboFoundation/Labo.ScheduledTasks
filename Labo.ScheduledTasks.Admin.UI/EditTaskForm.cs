namespace Labo.ScheduledTasks.Admin.UI
{
    using System.Windows.Forms;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Admin.Presentation.Presenters;
    using Labo.ScheduledTasks.Admin.Presentation.Views;
    using Labo.ScheduledTasks.Core.Model;

    public partial class EditTaskForm : Form, IEditTaskView
    {
        private int m_TaskId;

        public EditTaskPresenter Presenter { get; set; }

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
                    Type = txtType.Text.Trim(),
                    Seconds = (int)nudSeconds.Value,
                    Enabled = cbxEnabled.Checked,
                    RunOnlyOnce = cbxRunOnlyOnce.Checked,
                    StopOnError = cbxStopOnError.Checked
                };
            }

            set
            {
                ScheduledTask task = value;

                txtName.Text = task.Name;
                txtType.Text = task.Type;
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
        }

        public void OnLoad()
        {
            Presenter.LoadTask();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Presenter.SaveTask();
        }
    }
}
