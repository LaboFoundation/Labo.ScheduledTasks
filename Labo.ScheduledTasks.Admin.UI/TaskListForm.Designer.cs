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
            this.dgvTasks.Location = new System.Drawing.Point(12, 12);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.Size = new System.Drawing.Size(760, 312);
            this.dgvTasks.TabIndex = 0;
            // 
            // scheduleTaskBindingSource
            // 
            this.scheduleTaskBindingSource.DataSource = typeof(Labo.ScheduledTasks.Core.Model.ScheduledTask);
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
            this.secondsDataGridViewTextBoxColumn.FillWeight = 70F;
            this.secondsDataGridViewTextBoxColumn.HeaderText = "Seconds";
            this.secondsDataGridViewTextBoxColumn.Name = "secondsDataGridViewTextBoxColumn";
            this.secondsDataGridViewTextBoxColumn.ReadOnly = true;
            this.secondsDataGridViewTextBoxColumn.Width = 70;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.lastStartUtcDataGridViewTextBoxColumn.DataPropertyName = "LastStartUtc";
            this.lastStartUtcDataGridViewTextBoxColumn.FillWeight = 75F;
            this.lastStartUtcDataGridViewTextBoxColumn.HeaderText = "LastStartUtc";
            this.lastStartUtcDataGridViewTextBoxColumn.Name = "lastStartUtcDataGridViewTextBoxColumn";
            this.lastStartUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastStartUtcDataGridViewTextBoxColumn.Width = 75;
            // 
            // lastEndUtcDataGridViewTextBoxColumn
            // 
            this.lastEndUtcDataGridViewTextBoxColumn.DataPropertyName = "LastEndUtc";
            this.lastEndUtcDataGridViewTextBoxColumn.FillWeight = 75F;
            this.lastEndUtcDataGridViewTextBoxColumn.HeaderText = "LastEndUtc";
            this.lastEndUtcDataGridViewTextBoxColumn.Name = "lastEndUtcDataGridViewTextBoxColumn";
            this.lastEndUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastEndUtcDataGridViewTextBoxColumn.Width = 75;
            // 
            // lastSuccessUtcDataGridViewTextBoxColumn
            // 
            this.lastSuccessUtcDataGridViewTextBoxColumn.DataPropertyName = "LastSuccessUtc";
            this.lastSuccessUtcDataGridViewTextBoxColumn.FillWeight = 85F;
            this.lastSuccessUtcDataGridViewTextBoxColumn.HeaderText = "LastSuccessUtc";
            this.lastSuccessUtcDataGridViewTextBoxColumn.Name = "lastSuccessUtcDataGridViewTextBoxColumn";
            this.lastSuccessUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastSuccessUtcDataGridViewTextBoxColumn.Width = 85;
            // 
            // TaskListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 336);
            this.Controls.Add(this.dgvTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TaskListForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleTaskBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn runOnlyOnceDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stopOnErrorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastStartUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEndUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSuccessUtcDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource scheduleTaskBindingSource;
    }
}

