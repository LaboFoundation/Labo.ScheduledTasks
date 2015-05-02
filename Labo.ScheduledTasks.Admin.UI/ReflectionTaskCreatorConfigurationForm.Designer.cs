namespace Labo.ScheduledTasks.Admin.UI
{
    partial class ReflectionTaskCreatorConfigurationForm
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
            this.lbxTaskList = new System.Windows.Forms.ListBox();
            this.txtSelectedTask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxTaskList
            // 
            this.lbxTaskList.FormattingEnabled = true;
            this.lbxTaskList.Location = new System.Drawing.Point(12, 28);
            this.lbxTaskList.Name = "lbxTaskList";
            this.lbxTaskList.Size = new System.Drawing.Size(580, 199);
            this.lbxTaskList.TabIndex = 0;
            this.lbxTaskList.DoubleClick += new System.EventHandler(this.lbxTaskList_DoubleClick);
            // 
            // txtSelectedTask
            // 
            this.txtSelectedTask.Location = new System.Drawing.Point(108, 233);
            this.txtSelectedTask.Name = "txtSelectedTask";
            this.txtSelectedTask.ReadOnly = true;
            this.txtSelectedTask.Size = new System.Drawing.Size(484, 20);
            this.txtSelectedTask.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Double click an item to select the task:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected Task:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(517, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ReflectionTaskCreatorConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 294);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelectedTask);
            this.Controls.Add(this.lbxTaskList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReflectionTaskCreatorConfigurationForm";
            this.Text = "ReflectionTaskCreatorConfigurationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTaskList;
        private System.Windows.Forms.TextBox txtSelectedTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}