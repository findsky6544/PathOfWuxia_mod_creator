
namespace 侠之道mod制作器
{
    partial class RewardActionForm
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
            this.selectRewardButton = new System.Windows.Forms.Button();
            this.RewardidTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(182, 47);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(75, 47);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectRewardButton
            // 
            this.selectRewardButton.Location = new System.Drawing.Point(223, 18);
            this.selectRewardButton.Name = "selectRewardButton";
            this.selectRewardButton.Size = new System.Drawing.Size(99, 23);
            this.selectRewardButton.TabIndex = 70;
            this.selectRewardButton.Text = "选择奖励";
            this.selectRewardButton.UseVisualStyleBackColor = true;
            this.selectRewardButton.Click += new System.EventHandler(this.selectRewardButton_Click);
            // 
            // RewardidTextBox
            // 
            this.RewardidTextBox.Location = new System.Drawing.Point(96, 20);
            this.RewardidTextBox.Name = "RewardidTextBox";
            this.RewardidTextBox.Size = new System.Drawing.Size(121, 21);
            this.RewardidTextBox.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "奖励编号";
            // 
            // RewardActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 85);
            this.Controls.Add(this.selectRewardButton);
            this.Controls.Add(this.RewardidTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "RewardActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "给奖励";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectRewardButton;
        private System.Windows.Forms.TextBox RewardidTextBox;
        private System.Windows.Forms.Label label6;
    }
}