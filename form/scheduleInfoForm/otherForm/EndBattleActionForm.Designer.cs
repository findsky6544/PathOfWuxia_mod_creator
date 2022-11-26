
namespace 侠之道mod制作器
{
    partial class EndBattleActionForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.nextNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectNextButton = new System.Windows.Forms.Button();
            this.selectRewardButton = new System.Windows.Forms.Button();
            this.MovieIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(88, 96);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 59);
            this.nextNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nextNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nextNumericUpDown.Name = "nextNumericUpDown";
            this.nextNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.nextNumericUpDown.TabIndex = 7;
            this.nextNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // selectNextButton
            // 
            this.selectNextButton.Location = new System.Drawing.Point(251, 59);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // selectRewardButton
            // 
            this.selectRewardButton.Location = new System.Drawing.Point(251, 14);
            this.selectRewardButton.Name = "selectRewardButton";
            this.selectRewardButton.Size = new System.Drawing.Size(75, 23);
            this.selectRewardButton.TabIndex = 33;
            this.selectRewardButton.Text = "选择演出";
            this.selectRewardButton.UseVisualStyleBackColor = true;
            this.selectRewardButton.Click += new System.EventHandler(this.selectUnitButton_Click);
            // 
            // MovieIdTextBox
            // 
            this.MovieIdTextBox.Location = new System.Drawing.Point(102, 16);
            this.MovieIdTextBox.Name = "MovieIdTextBox";
            this.MovieIdTextBox.Size = new System.Drawing.Size(143, 21);
            this.MovieIdTextBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "播放的movie id";
            // 
            // EndBattleActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 139);
            this.Controls.Add(this.selectRewardButton);
            this.Controls.Add(this.MovieIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "EndBattleActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "直接结束战斗";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.Button selectNextButton;
        private System.Windows.Forms.Button selectRewardButton;
        private System.Windows.Forms.TextBox MovieIdTextBox;
        private System.Windows.Forms.Label label2;
    }
}