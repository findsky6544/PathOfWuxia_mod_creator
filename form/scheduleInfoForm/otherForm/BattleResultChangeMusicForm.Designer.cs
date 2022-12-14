
namespace 侠之道mod制作器
{
    partial class BattleResultChangeMusicForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.MusicNameTextBox = new System.Windows.Forms.TextBox();
            this.FadeTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ContinuousCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(83, 115);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(180, 115);
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
            this.label3.Location = new System.Drawing.Point(31, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 88);
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
            this.selectNextButton.Location = new System.Drawing.Point(251, 88);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "音乐名称";
            // 
            // MusicNameTextBox
            // 
            this.MusicNameTextBox.Location = new System.Drawing.Point(102, 12);
            this.MusicNameTextBox.Name = "MusicNameTextBox";
            this.MusicNameTextBox.Size = new System.Drawing.Size(143, 21);
            this.MusicNameTextBox.TabIndex = 14;
            // 
            // FadeTimeNumericUpDown
            // 
            this.FadeTimeNumericUpDown.DecimalPlaces = 5;
            this.FadeTimeNumericUpDown.Location = new System.Drawing.Point(103, 39);
            this.FadeTimeNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.FadeTimeNumericUpDown.Name = "FadeTimeNumericUpDown";
            this.FadeTimeNumericUpDown.Size = new System.Drawing.Size(142, 21);
            this.FadeTimeNumericUpDown.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "转换时间";
            // 
            // ContinuousCheckBox
            // 
            this.ContinuousCheckBox.AutoSize = true;
            this.ContinuousCheckBox.Location = new System.Drawing.Point(103, 66);
            this.ContinuousCheckBox.Name = "ContinuousCheckBox";
            this.ContinuousCheckBox.Size = new System.Drawing.Size(72, 16);
            this.ContinuousCheckBox.TabIndex = 21;
            this.ContinuousCheckBox.Text = "是否连续";
            this.ContinuousCheckBox.UseVisualStyleBackColor = true;
            // 
            // BattleResultChangeMusicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 154);
            this.Controls.Add(this.ContinuousCheckBox);
            this.Controls.Add(this.FadeTimeNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MusicNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BattleResultChangeMusicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换音乐";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FadeTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.Button selectNextButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MusicNameTextBox;
        private System.Windows.Forms.NumericUpDown FadeTimeNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ContinuousCheckBox;
    }
}