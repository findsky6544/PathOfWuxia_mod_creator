
namespace 侠之道mod制作器
{
    partial class ReplacePlayerSpecialForm
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
            this.selectNewSpecialButton = new System.Windows.Forms.Button();
            this.NewIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(189, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(82, 41);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNewSpecialButton
            // 
            this.selectNewSpecialButton.Location = new System.Drawing.Point(233, 12);
            this.selectNewSpecialButton.Name = "selectNewSpecialButton";
            this.selectNewSpecialButton.Size = new System.Drawing.Size(99, 23);
            this.selectNewSpecialButton.TabIndex = 73;
            this.selectNewSpecialButton.Text = "选择特技";
            this.selectNewSpecialButton.UseVisualStyleBackColor = true;
            this.selectNewSpecialButton.Click += new System.EventHandler(this.selectNewSpecialButton_Click);
            // 
            // NewIDTextBox
            // 
            this.NewIDTextBox.Location = new System.Drawing.Point(106, 14);
            this.NewIDTextBox.Name = "NewIDTextBox";
            this.NewIDTextBox.Size = new System.Drawing.Size(121, 21);
            this.NewIDTextBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "新的特技ID";
            // 
            // ReplacePlayerSpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 84);
            this.Controls.Add(this.selectNewSpecialButton);
            this.Controls.Add(this.NewIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ReplacePlayerSpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "玩家/取代特技";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNewSpecialButton;
        private System.Windows.Forms.TextBox NewIDTextBox;
        private System.Windows.Forms.Label label6;
    }
}