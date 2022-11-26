
namespace 侠之道mod制作器
{
    partial class ChangeDayAndNightActionForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.IsRealCheckBox = new System.Windows.Forms.CheckBox();
            this.timeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(143, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(36, 71);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // IsRealCheckBox
            // 
            this.IsRealCheckBox.AutoSize = true;
            this.IsRealCheckBox.Checked = true;
            this.IsRealCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsRealCheckBox.Location = new System.Drawing.Point(75, 38);
            this.IsRealCheckBox.Name = "IsRealCheckBox";
            this.IsRealCheckBox.Size = new System.Drawing.Size(120, 16);
            this.IsRealCheckBox.TabIndex = 56;
            this.IsRealCheckBox.Text = "是否真的影响日夜";
            this.IsRealCheckBox.UseVisualStyleBackColor = true;
            // 
            // timeTypeComboBox
            // 
            this.timeTypeComboBox.FormattingEnabled = true;
            this.timeTypeComboBox.Location = new System.Drawing.Point(143, 12);
            this.timeTypeComboBox.Name = "timeTypeComboBox";
            this.timeTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.timeTypeComboBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "切换到哪个（日、夜）";
            // 
            // ChangeDayAndNightActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 117);
            this.Controls.Add(this.timeTypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IsRealCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ChangeDayAndNightActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "切换日夜（不会跳回合）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox IsRealCheckBox;
        private System.Windows.Forms.ComboBox timeTypeComboBox;
        private System.Windows.Forms.Label label6;
    }
}