
namespace 侠之道mod制作器
{
    partial class SoundActionForm
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
            this.SoundNameTextBox = new System.Windows.Forms.TextBox();
            this.DelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.VolumeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(159, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(52, 119);
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
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "音效档名（需加副档名）";
            // 
            // SoundNameTextBox
            // 
            this.SoundNameTextBox.Location = new System.Drawing.Point(146, 38);
            this.SoundNameTextBox.Name = "SoundNameTextBox";
            this.SoundNameTextBox.Size = new System.Drawing.Size(121, 21);
            this.SoundNameTextBox.TabIndex = 22;
            // 
            // DelayNumericUpDown
            // 
            this.DelayNumericUpDown.DecimalPlaces = 5;
            this.DelayNumericUpDown.Location = new System.Drawing.Point(147, 65);
            this.DelayNumericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.DelayNumericUpDown.Name = "DelayNumericUpDown";
            this.DelayNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.DelayNumericUpDown.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "延迟";
            // 
            // VolumeNumericUpDown
            // 
            this.VolumeNumericUpDown.DecimalPlaces = 5;
            this.VolumeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.VolumeNumericUpDown.Location = new System.Drawing.Point(146, 92);
            this.VolumeNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VolumeNumericUpDown.Name = "VolumeNumericUpDown";
            this.VolumeNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.VolumeNumericUpDown.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "音量大小（0-1）";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(147, 12);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.TypeComboBox.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 76;
            this.label6.Text = "音效类型";
            // 
            // SoundActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 161);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VolumeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DelayNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SoundNameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "SoundActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放音效";
            ((System.ComponentModel.ISupportInitialize)(this.DelayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SoundNameTextBox;
        private System.Windows.Forms.NumericUpDown DelayNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown VolumeNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label6;
    }
}