
namespace 侠之道mod制作器
{
    partial class MusicActionForm
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
            this.MusicNameTextBox = new System.Windows.Forms.TextBox();
            this.ContinuousCheckBox = new System.Windows.Forms.CheckBox();
            this.FadeTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.VolumeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.IsStopCheckBox = new System.Windows.Forms.CheckBox();
            this.FadeOutTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FadeTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeOutTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(174, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(67, 164);
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
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "音乐名（需加副档名）";
            // 
            // MusicNameTextBox
            // 
            this.MusicNameTextBox.Location = new System.Drawing.Point(143, 12);
            this.MusicNameTextBox.Name = "MusicNameTextBox";
            this.MusicNameTextBox.Size = new System.Drawing.Size(121, 21);
            this.MusicNameTextBox.TabIndex = 22;
            // 
            // ContinuousCheckBox
            // 
            this.ContinuousCheckBox.AutoSize = true;
            this.ContinuousCheckBox.Checked = true;
            this.ContinuousCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContinuousCheckBox.Location = new System.Drawing.Point(144, 66);
            this.ContinuousCheckBox.Name = "ContinuousCheckBox";
            this.ContinuousCheckBox.Size = new System.Drawing.Size(72, 16);
            this.ContinuousCheckBox.TabIndex = 56;
            this.ContinuousCheckBox.Text = "是否连续";
            this.ContinuousCheckBox.UseVisualStyleBackColor = true;
            // 
            // FadeTimeNumericUpDown
            // 
            this.FadeTimeNumericUpDown.DecimalPlaces = 5;
            this.FadeTimeNumericUpDown.Location = new System.Drawing.Point(144, 39);
            this.FadeTimeNumericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.FadeTimeNumericUpDown.Name = "FadeTimeNumericUpDown";
            this.FadeTimeNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.FadeTimeNumericUpDown.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 71;
            this.label7.Text = "转换时间";
            // 
            // VolumeNumericUpDown
            // 
            this.VolumeNumericUpDown.DecimalPlaces = 5;
            this.VolumeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.VolumeNumericUpDown.Location = new System.Drawing.Point(144, 88);
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
            this.label2.Location = new System.Drawing.Point(43, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "音量大小（0-1）";
            // 
            // IsStopCheckBox
            // 
            this.IsStopCheckBox.AutoSize = true;
            this.IsStopCheckBox.Checked = true;
            this.IsStopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsStopCheckBox.Location = new System.Drawing.Point(144, 115);
            this.IsStopCheckBox.Name = "IsStopCheckBox";
            this.IsStopCheckBox.Size = new System.Drawing.Size(150, 16);
            this.IsStopCheckBox.TabIndex = 73;
            this.IsStopCheckBox.Text = "是否停止（打勾=停止）";
            this.IsStopCheckBox.UseVisualStyleBackColor = true;
            // 
            // FadeOutTimeNumericUpDown
            // 
            this.FadeOutTimeNumericUpDown.DecimalPlaces = 5;
            this.FadeOutTimeNumericUpDown.Location = new System.Drawing.Point(144, 137);
            this.FadeOutTimeNumericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.FadeOutTimeNumericUpDown.Name = "FadeOutTimeNumericUpDown";
            this.FadeOutTimeNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.FadeOutTimeNumericUpDown.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 76;
            this.label5.Text = "停止淡出时间";
            // 
            // MusicActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.FadeOutTimeNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VolumeNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsStopCheckBox);
            this.Controls.Add(this.FadeTimeNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ContinuousCheckBox);
            this.Controls.Add(this.MusicNameTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "MusicActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放or停止音乐";
            ((System.ComponentModel.ISupportInitialize)(this.FadeTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeOutTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MusicNameTextBox;
        private System.Windows.Forms.CheckBox ContinuousCheckBox;
        private System.Windows.Forms.NumericUpDown FadeTimeNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown VolumeNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsStopCheckBox;
        private System.Windows.Forms.NumericUpDown FadeOutTimeNumericUpDown;
        private System.Windows.Forms.Label label5;
    }
}