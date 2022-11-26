
namespace 侠之道mod制作器
{
    partial class SetNpcSchedulerIdActionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.schedulerIdTextBox = new System.Windows.Forms.TextBox();
            this.selectNpcButton = new System.Windows.Forms.Button();
            this.characterBehaviourIdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectSchedulerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(202, 66);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(95, 66);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "排程编号";
            // 
            // schedulerIdTextBox
            // 
            this.schedulerIdTextBox.Location = new System.Drawing.Point(117, 39);
            this.schedulerIdTextBox.Name = "schedulerIdTextBox";
            this.schedulerIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.schedulerIdTextBox.TabIndex = 22;
            // 
            // selectNpcButton
            // 
            this.selectNpcButton.Location = new System.Drawing.Point(244, 10);
            this.selectNpcButton.Name = "selectNpcButton";
            this.selectNpcButton.Size = new System.Drawing.Size(103, 23);
            this.selectNpcButton.TabIndex = 64;
            this.selectNpcButton.Text = "选择行为";
            this.selectNpcButton.UseVisualStyleBackColor = true;
            this.selectNpcButton.Click += new System.EventHandler(this.selectNpcButton_Click);
            // 
            // characterBehaviourIdTextBox
            // 
            this.characterBehaviourIdTextBox.Location = new System.Drawing.Point(117, 12);
            this.characterBehaviourIdTextBox.Name = "characterBehaviourIdTextBox";
            this.characterBehaviourIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.characterBehaviourIdTextBox.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "行为编号";
            // 
            // selectSchedulerButton
            // 
            this.selectSchedulerButton.Location = new System.Drawing.Point(244, 37);
            this.selectSchedulerButton.Name = "selectSchedulerButton";
            this.selectSchedulerButton.Size = new System.Drawing.Size(103, 23);
            this.selectSchedulerButton.TabIndex = 65;
            this.selectSchedulerButton.Text = "选择排程";
            this.selectSchedulerButton.UseVisualStyleBackColor = true;
            this.selectSchedulerButton.Click += new System.EventHandler(this.selectSchedulerButton_Click);
            // 
            // SetNpcSchedulerIdActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 98);
            this.Controls.Add(this.selectSchedulerButton);
            this.Controls.Add(this.selectNpcButton);
            this.Controls.Add(this.characterBehaviourIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.schedulerIdTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "SetNpcSchedulerIdActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC设定/排程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox schedulerIdTextBox;
        private System.Windows.Forms.Button selectNpcButton;
        private System.Windows.Forms.TextBox characterBehaviourIdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectSchedulerButton;
    }
}