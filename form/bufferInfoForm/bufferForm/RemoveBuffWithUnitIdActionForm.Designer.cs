
namespace 侠之道mod制作器
{
    partial class RemoveBuffWithUnitIdActionForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unitIdTextBox = new System.Windows.Forms.TextBox();
            this.buffIdTextBox = new System.Windows.Forms.TextBox();
            this.selectUnitIdButton = new System.Windows.Forms.Button();
            this.selectBuffButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(81, 82);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(184, 82);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "指定的ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "添加的Buff id";
            // 
            // unitIdTextBox
            // 
            this.unitIdTextBox.Location = new System.Drawing.Point(98, 18);
            this.unitIdTextBox.Name = "unitIdTextBox";
            this.unitIdTextBox.Size = new System.Drawing.Size(145, 21);
            this.unitIdTextBox.TabIndex = 25;
            // 
            // buffIdTextBox
            // 
            this.buffIdTextBox.Location = new System.Drawing.Point(98, 45);
            this.buffIdTextBox.Name = "buffIdTextBox";
            this.buffIdTextBox.Size = new System.Drawing.Size(145, 21);
            this.buffIdTextBox.TabIndex = 26;
            // 
            // selectUnitIdButton
            // 
            this.selectUnitIdButton.Location = new System.Drawing.Point(249, 16);
            this.selectUnitIdButton.Name = "selectUnitIdButton";
            this.selectUnitIdButton.Size = new System.Drawing.Size(75, 23);
            this.selectUnitIdButton.TabIndex = 29;
            this.selectUnitIdButton.Text = "选择部队";
            this.selectUnitIdButton.UseVisualStyleBackColor = true;
            this.selectUnitIdButton.Click += new System.EventHandler(this.selectUnitIdButton_Click);
            // 
            // selectBuffButton
            // 
            this.selectBuffButton.Location = new System.Drawing.Point(249, 43);
            this.selectBuffButton.Name = "selectBuffButton";
            this.selectBuffButton.Size = new System.Drawing.Size(75, 23);
            this.selectBuffButton.TabIndex = 30;
            this.selectBuffButton.Text = "选择buff";
            this.selectBuffButton.UseVisualStyleBackColor = true;
            this.selectBuffButton.Click += new System.EventHandler(this.selectBuffButton_Click);
            // 
            // RemoveBuffWithUnitIdActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 123);
            this.Controls.Add(this.selectBuffButton);
            this.Controls.Add(this.selectUnitIdButton);
            this.Controls.Add(this.buffIdTextBox);
            this.Controls.Add(this.unitIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "RemoveBuffWithUnitIdActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指定ID移除Buff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unitIdTextBox;
        private System.Windows.Forms.TextBox buffIdTextBox;
        private System.Windows.Forms.Button selectUnitIdButton;
        private System.Windows.Forms.Button selectBuffButton;
    }
}