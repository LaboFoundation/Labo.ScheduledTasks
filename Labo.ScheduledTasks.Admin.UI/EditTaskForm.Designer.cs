namespace Labo.ScheduledTasks.Admin.UI
{
    partial class EditTaskForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudSeconds = new System.Windows.Forms.NumericUpDown();
            this.cbxEnabled = new System.Windows.Forms.CheckBox();
            this.cbxRunOnlyOnce = new System.Windows.Forms.CheckBox();
            this.cbxStopOnError = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbxTaskTypes = new System.Windows.Forms.ComboBox();
            this.txtConfiguration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblName.Location = new System.Drawing.Point(13, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblType.Location = new System.Drawing.Point(13, 98);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeconds.Location = new System.Drawing.Point(13, 211);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(60, 13);
            this.lblSeconds.TabIndex = 2;
            this.lblSeconds.Text = "Seconds:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(325, 20);
            this.txtName.TabIndex = 6;
            // 
            // nudSeconds
            // 
            this.nudSeconds.Location = new System.Drawing.Point(131, 208);
            this.nudSeconds.Maximum = new decimal(new int[] {
            10080,
            0,
            0,
            0});
            this.nudSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeconds.Name = "nudSeconds";
            this.nudSeconds.Size = new System.Drawing.Size(57, 20);
            this.nudSeconds.TabIndex = 8;
            this.nudSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxEnabled
            // 
            this.cbxEnabled.AutoSize = true;
            this.cbxEnabled.Location = new System.Drawing.Point(49, 234);
            this.cbxEnabled.Name = "cbxEnabled";
            this.cbxEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbxEnabled.TabIndex = 9;
            this.cbxEnabled.Text = "Enabled";
            this.cbxEnabled.UseVisualStyleBackColor = true;
            // 
            // cbxRunOnlyOnce
            // 
            this.cbxRunOnlyOnce.AutoSize = true;
            this.cbxRunOnlyOnce.Location = new System.Drawing.Point(243, 234);
            this.cbxRunOnlyOnce.Name = "cbxRunOnlyOnce";
            this.cbxRunOnlyOnce.Size = new System.Drawing.Size(99, 17);
            this.cbxRunOnlyOnce.TabIndex = 10;
            this.cbxRunOnlyOnce.Text = "Run Only Once";
            this.cbxRunOnlyOnce.UseVisualStyleBackColor = true;
            // 
            // cbxStopOnError
            // 
            this.cbxStopOnError.AutoSize = true;
            this.cbxStopOnError.Location = new System.Drawing.Point(131, 234);
            this.cbxStopOnError.Name = "cbxStopOnError";
            this.cbxStopOnError.Size = new System.Drawing.Size(90, 17);
            this.cbxStopOnError.TabIndex = 11;
            this.cbxStopOnError.Text = "Stop On Error";
            this.cbxStopOnError.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(131, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(131, 39);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(325, 50);
            this.txtDescription.TabIndex = 14;
            // 
            // cbxTaskTypes
            // 
            this.cbxTaskTypes.FormattingEnabled = true;
            this.cbxTaskTypes.Location = new System.Drawing.Point(131, 95);
            this.cbxTaskTypes.Name = "cbxTaskTypes";
            this.cbxTaskTypes.Size = new System.Drawing.Size(171, 21);
            this.cbxTaskTypes.TabIndex = 15;
            // 
            // txtConfiguration
            // 
            this.txtConfiguration.Location = new System.Drawing.Point(131, 122);
            this.txtConfiguration.Multiline = true;
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.ReadOnly = true;
            this.txtConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfiguration.Size = new System.Drawing.Size(325, 80);
            this.txtConfiguration.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Configuration:";
            // 
            // EditTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 288);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfiguration);
            this.Controls.Add(this.cbxTaskTypes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxStopOnError);
            this.Controls.Add(this.cbxRunOnlyOnce);
            this.Controls.Add(this.cbxEnabled);
            this.Controls.Add(this.nudSeconds);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditTaskForm";
            this.Text = "EditTaskForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudSeconds;
        private System.Windows.Forms.CheckBox cbxEnabled;
        private System.Windows.Forms.CheckBox cbxRunOnlyOnce;
        private System.Windows.Forms.CheckBox cbxStopOnError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbxTaskTypes;
        private System.Windows.Forms.TextBox txtConfiguration;
        private System.Windows.Forms.Label label2;
    }
}