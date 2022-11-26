
namespace 侠之道mod制作器
{
    partial class ReplacePlayerSkillForm
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
            this.selectNewSkillButton = new System.Windows.Forms.Button();
            this.NewIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectOldSkillButton = new System.Windows.Forms.Button();
            this.OldIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(192, 76);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(85, 76);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNewSkillButton
            // 
            this.selectNewSkillButton.Location = new System.Drawing.Point(247, 47);
            this.selectNewSkillButton.Name = "selectNewSkillButton";
            this.selectNewSkillButton.Size = new System.Drawing.Size(99, 23);
            this.selectNewSkillButton.TabIndex = 73;
            this.selectNewSkillButton.Text = "选择技能";
            this.selectNewSkillButton.UseVisualStyleBackColor = true;
            this.selectNewSkillButton.Click += new System.EventHandler(this.selectNewSkillButton_Click);
            // 
            // NewIDTextBox
            // 
            this.NewIDTextBox.Location = new System.Drawing.Point(120, 49);
            this.NewIDTextBox.Name = "NewIDTextBox";
            this.NewIDTextBox.Size = new System.Drawing.Size(121, 21);
            this.NewIDTextBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "新的技能ID";
            // 
            // selectOldSkillButton
            // 
            this.selectOldSkillButton.Location = new System.Drawing.Point(247, 20);
            this.selectOldSkillButton.Name = "selectOldSkillButton";
            this.selectOldSkillButton.Size = new System.Drawing.Size(99, 23);
            this.selectOldSkillButton.TabIndex = 76;
            this.selectOldSkillButton.Text = "选择技能";
            this.selectOldSkillButton.UseVisualStyleBackColor = true;
            this.selectOldSkillButton.Click += new System.EventHandler(this.selectOldSkillButton_Click);
            // 
            // OldIDTextBox
            // 
            this.OldIDTextBox.Location = new System.Drawing.Point(120, 22);
            this.OldIDTextBox.Name = "OldIDTextBox";
            this.OldIDTextBox.Size = new System.Drawing.Size(121, 21);
            this.OldIDTextBox.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "旧的技能ID";
            // 
            // ReplacePlayerSkillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 112);
            this.Controls.Add(this.selectOldSkillButton);
            this.Controls.Add(this.OldIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectNewSkillButton);
            this.Controls.Add(this.NewIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ReplacePlayerSkillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "玩家/取代技能";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNewSkillButton;
        private System.Windows.Forms.TextBox NewIDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectOldSkillButton;
        private System.Windows.Forms.TextBox OldIDTextBox;
        private System.Windows.Forms.Label label2;
    }
}