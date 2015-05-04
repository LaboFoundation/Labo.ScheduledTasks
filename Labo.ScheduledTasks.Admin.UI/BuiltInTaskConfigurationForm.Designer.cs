namespace Labo.ScheduledTasks.Admin.UI
{
    partial class BuiltInTaskConfigurationForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfiguration = new System.Windows.Forms.TextBox();
            this.cbxTaskTypes = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Configuration:";
            // 
            // txtConfiguration
            // 
            this.txtConfiguration.Location = new System.Drawing.Point(130, 33);
            this.txtConfiguration.Multiline = true;
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.ReadOnly = true;
            this.txtConfiguration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConfiguration.Size = new System.Drawing.Size(325, 80);
            this.txtConfiguration.TabIndex = 20;
            // 
            // cbxTaskTypes
            // 
            this.cbxTaskTypes.FormattingEnabled = true;
            this.cbxTaskTypes.Location = new System.Drawing.Point(130, 6);
            this.cbxTaskTypes.Name = "cbxTaskTypes";
            this.cbxTaskTypes.Size = new System.Drawing.Size(171, 21);
            this.cbxTaskTypes.TabIndex = 19;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblType.Location = new System.Drawing.Point(12, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 13);
            this.lblType.TabIndex = 18;
            this.lblType.Text = "Type:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BuiltInTaskConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 151);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfiguration);
            this.Controls.Add(this.cbxTaskTypes);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BuiltInTaskConfigurationForm";
            this.Text = "BuiltInTaskConfigurationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfiguration;
        private System.Windows.Forms.ComboBox cbxTaskTypes;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnSave;

    }
}