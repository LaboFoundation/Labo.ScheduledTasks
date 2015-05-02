namespace Labo.ScheduledTasks.Admin.UI
{
    using System.Windows.Forms;

    using Labo.Mvp.Core.View;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Presenters;
    using Labo.ScheduledTasks.Core.Presentation.Configuration.Views;

    public partial class StartProcessTaskCreatorConfigurationForm : Form, IStartProcessTaskCreatorConfigurationView
    {
        public string FileName
        {
            get
            {
                return txtFile.Text;
            }

            set
            {
                txtFile.Text = value;
            }
        }

        public string Arguments
        {
            get
            {
                return txtArguments.Text;
            }

            set
            {
                txtArguments.Text = value;
            }
        }

        public string Configuration { get; set; }

        public StartProcessTaskCreatorConfigurationPresenter Presenter { get; set; }

        public IView ParentView { get; set; }

        object IView.Presenter
        {
            get { return Presenter; }
            set { Presenter = value as StartProcessTaskCreatorConfigurationPresenter; }
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

        public StartProcessTaskCreatorConfigurationForm(string configuration)
        {
            Configuration = configuration;

            InitializeComponent();
        }

        public void OnLoad()
        {
            Presenter.LoadConfiguration();
        }

        private void btnSelectFile_Click(object sender, System.EventArgs e)
        {
            if (ofdFile.ShowDialog(this) == DialogResult.OK)
            {
                FileName = ofdFile.FileName;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Presenter.SaveConfiguration();
        }
    }
}
