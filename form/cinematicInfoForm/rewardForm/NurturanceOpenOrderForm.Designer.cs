
namespace 侠之道mod制作器
{
    partial class NurturanceOpenOrderForm
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
            this.selectNurturanceButton = new System.Windows.Forms.Button();
            this.orderidTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(183, 47);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(76, 47);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNurturanceButton
            // 
            this.selectNurturanceButton.Location = new System.Drawing.Point(223, 18);
            this.selectNurturanceButton.Name = "selectNurturanceButton";
            this.selectNurturanceButton.Size = new System.Drawing.Size(99, 23);
            this.selectNurturanceButton.TabIndex = 70;
            this.selectNurturanceButton.Text = "选择养成指令";
            this.selectNurturanceButton.UseVisualStyleBackColor = true;
            this.selectNurturanceButton.Click += new System.EventHandler(this.selectNurturanceButton_Click);
            // 
            // orderidTextBox
            // 
            this.orderidTextBox.Location = new System.Drawing.Point(96, 20);
            this.orderidTextBox.Name = "orderidTextBox";
            this.orderidTextBox.Size = new System.Drawing.Size(121, 21);
            this.orderidTextBox.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "养成指令编号";
            // 
            // NurturanceOpenOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 85);
            this.Controls.Add(this.selectNurturanceButton);
            this.Controls.Add(this.orderidTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "NurturanceOpenOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增养成指令";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNurturanceButton;
        private System.Windows.Forms.TextBox orderidTextBox;
        private System.Windows.Forms.Label label6;
    }
}