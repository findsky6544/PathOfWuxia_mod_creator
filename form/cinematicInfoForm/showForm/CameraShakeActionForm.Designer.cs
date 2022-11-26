
namespace 侠之道mod制作器
{
    partial class CameraShakeActionForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.levelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.vibratoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.fadeOutCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vibratoNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(162, 122);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(55, 122);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "持续时间";
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.DecimalPlaces = 5;
            this.durationNumericUpDown.Location = new System.Drawing.Point(116, 19);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.durationNumericUpDown.TabIndex = 63;
            this.durationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // levelNumericUpDown
            // 
            this.levelNumericUpDown.DecimalPlaces = 5;
            this.levelNumericUpDown.Location = new System.Drawing.Point(116, 46);
            this.levelNumericUpDown.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.levelNumericUpDown.Name = "levelNumericUpDown";
            this.levelNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.levelNumericUpDown.TabIndex = 65;
            this.levelNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 64;
            this.label3.Text = "强度";
            // 
            // vibratoNumericUpDown
            // 
            this.vibratoNumericUpDown.Location = new System.Drawing.Point(117, 73);
            this.vibratoNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.vibratoNumericUpDown.Name = "vibratoNumericUpDown";
            this.vibratoNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.vibratoNumericUpDown.TabIndex = 67;
            this.vibratoNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 66;
            this.label5.Text = "速度";
            // 
            // fadeOutCheckBox
            // 
            this.fadeOutCheckBox.AutoSize = true;
            this.fadeOutCheckBox.Checked = true;
            this.fadeOutCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fadeOutCheckBox.Location = new System.Drawing.Point(116, 100);
            this.fadeOutCheckBox.Name = "fadeOutCheckBox";
            this.fadeOutCheckBox.Size = new System.Drawing.Size(216, 16);
            this.fadeOutCheckBox.TabIndex = 69;
            this.fadeOutCheckBox.Text = "是否淡出(如果有勾, 不会无限播放)";
            this.fadeOutCheckBox.UseVisualStyleBackColor = true;
            // 
            // CameraShakeActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 162);
            this.Controls.Add(this.fadeOutCheckBox);
            this.Controls.Add(this.vibratoNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.levelNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.durationNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CameraShakeActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "镜头/开始震动";
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vibratoNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown vibratoNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox fadeOutCheckBox;
    }
}