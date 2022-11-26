
namespace 侠之道mod制作器
{
    partial class OpenUIAdjustmentActionForm
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
            this.adjustmentIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectAdjustmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(62, 93);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // adjustmentIdTextBox
            // 
            this.adjustmentIdTextBox.Location = new System.Drawing.Point(79, 36);
            this.adjustmentIdTextBox.Name = "adjustmentIdTextBox";
            this.adjustmentIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.adjustmentIdTextBox.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "整备编号";
            // 
            // selectAdjustmentButton
            // 
            this.selectAdjustmentButton.Location = new System.Drawing.Point(206, 34);
            this.selectAdjustmentButton.Name = "selectAdjustmentButton";
            this.selectAdjustmentButton.Size = new System.Drawing.Size(99, 23);
            this.selectAdjustmentButton.TabIndex = 41;
            this.selectAdjustmentButton.Text = "选择整备";
            this.selectAdjustmentButton.UseVisualStyleBackColor = true;
            this.selectAdjustmentButton.Click += new System.EventHandler(this.selectAdjustmentButton_Click);
            // 
            // OpenUIAdjustmentActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 126);
            this.Controls.Add(this.selectAdjustmentButton);
            this.Controls.Add(this.adjustmentIdTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "OpenUIAdjustmentActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开启整备界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox adjustmentIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectAdjustmentButton;
    }
}