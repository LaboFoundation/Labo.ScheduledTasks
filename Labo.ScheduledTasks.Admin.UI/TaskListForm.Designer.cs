namespace Labo.ScheduledTasks.Admin.UI
{
    partial class TaskListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.scheduleTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnStartTaskService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopTaskService = new System.Windows.Forms.Button();
            this.tmrTaskList = new System.Windows.Forms.Timer(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.runOnlyOnceDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stopOnErrorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastStartUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEndUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastSuccessUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTaskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToDeleteRows = false;
            this.dgvTasks.AutoGenerateColumns = false;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.secondsDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.runOnlyOnceDataGridViewCheckBoxColumn,
            this.stopOnErrorDataGridViewCheckBoxColumn,
            this.lastStartUtcDataGridViewTextBoxColumn,
            this.lastEndUtcDataGridViewTextBoxColumn,
            this.lastSuccessUtcDataGridViewTextBoxColumn});
            this.dgvTasks.DataSource = this.scheduleTaskBindingSource;
            this.dgvTasks.Location = new System.Drawing.Point(12, 42);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.Size = new System.Drawing.Size(760, 329);
            this.dgvTasks.TabIndex = 0;
            // 
            // scheduleTaskBindingSource
            // 
            this.scheduleTaskBindingSource.DataSource = typeof(Labo.ScheduledTasks.Core.Model.ScheduledTask);
            // 
            // btnStartTaskService
            // 
            this.btnStartTaskService.Location = new System.Drawing.Point(104, 13);
            this.btnStartTaskService.Name = "btnStartTaskService";
            this.btnStartTaskService.Size = new System.Drawing.Size(75, 23);
            this.btnStartTaskService.TabIndex = 1;
            this.btnStartTaskService.Text = "Start";
            this.btnStartTaskService.UseVisualStyleBackColor = true;
            this.btnStartTaskService.Click += new System.EventHandler(this.btnStartTaskService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task Service:";
            // 
            // btnStopTaskService
            // 
            this.btnStopTaskService.Location = new System.Drawing.Point(185, 13);
            this.btnStopTaskService.Name = "btnStopTaskService";
            this.btnStopTaskService.Size = new System.Drawing.Size(75, 23);
            this.btnStopTaskService.TabIndex = 3;
            this.btnStopTaskService.Text = "Stop";
            this.btnStopTaskService.UseVisualStyleBackColor = true;
            this.btnStopTaskService.Click += new System.EventHandler(this.btnStopTaskService_Click);
            // 
            // tmrTaskList
            // 
            this.tmrTaskList.Enabled = true;
            this.tmrTaskList.Interval = 5000;
            this.tmrTaskList.Tick += new System.EventHandler(this.tmrTaskList_Tick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secondsDataGridViewTextBoxColumn
            // 
            this.secondsDataGridViewTextBoxColumn.DataPropertyName = "Seconds";
            this.secondsDataGridViewTextBoxColumn.FillWeight = 50F;
            this.secondsDataGridViewTextBoxColumn.HeaderText = "Seconds";
            this.secondsDataGridViewTextBoxColumn.Name = "secondsDataGridViewTextBoxColumn";
            this.secondsDataGridViewTextBoxColumn.ReadOnly = true;
            this.secondsDataGridViewTextBoxColumn.Width = 50;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.FillWeight = 90F;
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 90;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.FillWeight = 50F;
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.ReadOnly = true;
            this.enabledDataGridViewCheckBoxColumn.Width = 50;
            // 
            // runOnlyOnceDataGridViewCheckBoxColumn
            // 
            this.runOnlyOnceDataGridViewCheckBoxColumn.DataPropertyName = "RunOnlyOnce";
            this.runOnlyOnceDataGridViewCheckBoxColumn.FillWeight = 80F;
            this.runOnlyOnceDataGridViewCheckBoxColumn.HeaderText = "RunOnlyOnce";
            this.runOnlyOnceDataGridViewCheckBoxColumn.Name = "runOnlyOnceDataGridViewCheckBoxColumn";
            this.runOnlyOnceDataGridViewCheckBoxColumn.ReadOnly = true;
            this.runOnlyOnceDataGridViewCheckBoxColumn.Width = 80;
            // 
            // stopOnErrorDataGridViewCheckBoxColumn
            // 
            this.stopOnErrorDataGridViewCheckBoxColumn.DataPropertyName = "StopOnError";
            this.stopOnErrorDataGridViewCheckBoxColumn.FillWeight = 70F;
            this.stopOnErrorDataGridViewCheckBoxColumn.HeaderText = "StopOnError";
            this.stopOnErrorDataGridViewCheckBoxColumn.Name = "stopOnErrorDataGridViewCheckBoxColumn";
            this.stopOnErrorDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stopOnErrorDataGridViewCheckBoxColumn.Width = 70;
            // 
            // lastStartUtcDataGridViewTextBoxColumn
            // 
            this.lastStartUtcDataGridViewTextBoxColumn.DataPropertyName = "LastStartDate";
            this.lastStartUtcDataGridViewTextBoxColumn.FillWeight = 92F;
            this.lastStartUtcDataGridViewTextBoxColumn.HeaderText = "Last Start";
            this.lastStartUtcDataGridViewTextBoxColumn.Name = "lastStartUtcDataGridViewTextBoxColumn";
            this.lastStartUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastStartUtcDataGridViewTextBoxColumn.Width = 92;
            // 
            // lastEndUtcDataGridViewTextBoxColumn
            // 
            this.lastEndUtcDataGridViewTextBoxColumn.DataPropertyName = "LastEndDate";
            this.lastEndUtcDataGridViewTextBoxColumn.FillWeight = 92F;
            this.lastEndUtcDataGridViewTextBoxColumn.HeaderText = "Last End";
            this.lastEndUtcDataGridViewTextBoxColumn.Name = "lastEndUtcDataGridViewTextBoxColumn";
            this.lastEndUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastEndUtcDataGridViewTextBoxColumn.Width = 92;
            // 
            // lastSuccessUtcDataGridViewTextBoxColumn
            // 
            this.lastSuccessUtcDataGridViewTextBoxColumn.DataPropertyName = "LastSuccessDate";
            this.lastSuccessUtcDataGridViewTextBoxColumn.FillWeight = 92F;
            this.lastSuccessUtcDataGridViewTextBoxColumn.HeaderText = "Last Success";
            this.lastSuccessUtcDataGridViewTextBoxColumn.Name = "lastSuccessUtcDataGridViewTextBoxColumn";
            this.lastSuccessUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastSuccessUtcDataGridViewTextBoxColumn.Width = 92;
            // 
            // TaskListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 383);
            this.Controls.Add(this.btnStopTaskService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartTaskService);
            this.Controls.Add(this.dgvTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TaskListForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTaskBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.BindingSource scheduleTaskBindingSource;
        private System.Windows.Forms.Button btnStartTaskService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopTaskService;
        private System.Windows.Forms.Timer tmrTaskList;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn runOnlyOnceDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stopOnErrorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastStartUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEndUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSuccessUtcDataGridViewTextBoxColumn;
    }
}

