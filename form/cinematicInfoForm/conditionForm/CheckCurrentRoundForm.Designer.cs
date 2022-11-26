
namespace 侠之道mod制作器
{
    partial class CheckCurrentRoundForm
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
            this.maxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.roundNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.multipleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.otherTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multipleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // maxNumericUpDown
            // 
            this.maxNumericUpDown.Location = new System.Drawing.Point(121, 63);
            this.maxNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.maxNumericUpDown.Name = "maxNumericUpDown";
            this.maxNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.maxNumericUpDown.TabIndex = 20;
            this.maxNumericUpDown.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "最大回合";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "倍数";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(166, 121);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(59, 121);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(86, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 12);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "回合";
            // 
            // roundNumericUpDown
            // 
            this.roundNumericUpDown.Location = new System.Drawing.Point(121, 11);
            this.roundNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.roundNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.roundNumericUpDown.Name = "roundNumericUpDown";
            this.roundNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.roundNumericUpDown.TabIndex = 21;
            this.roundNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // multipleNumericUpDown
            // 
            this.multipleNumericUpDown.Location = new System.Drawing.Point(121, 38);
            this.multipleNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.multipleNumericUpDown.Name = "multipleNumericUpDown";
            this.multipleNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.multipleNumericUpDown.TabIndex = 22;
            this.multipleNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "其余回合";
            // 
            // otherTextBox
            // 
            this.otherTextBox.Location = new System.Drawing.Point(121, 90);
            this.otherTextBox.Name = "otherTextBox";
            this.otherTextBox.Size = new System.Drawing.Size(120, 21);
            this.otherTextBox.TabIndex = 24;
            // 
            // CheckCurrentRoundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 156);
            this.Controls.Add(this.otherTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.multipleNumericUpDown);
            this.Controls.Add(this.roundNumericUpDown);
            this.Controls.Add(this.maxNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.Label1);
            this.Name = "CheckCurrentRoundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查当前回合";
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multipleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown maxNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.NumericUpDown roundNumericUpDown;
        private System.Windows.Forms.NumericUpDown multipleNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox otherTextBox;
    }
}