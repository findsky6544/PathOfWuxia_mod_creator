
namespace 侠之道mod制作器
{
    partial class MantraBufferEffectForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.MartraLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BufferIdTextBox = new System.Windows.Forms.TextBox();
            this.selectBufferButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MartraLevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(78, 96);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "buffer编号";
            // 
            // MartraLevelNumericUpDown
            // 
            this.MartraLevelNumericUpDown.Location = new System.Drawing.Point(91, 12);
            this.MartraLevelNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.MartraLevelNumericUpDown.Name = "MartraLevelNumericUpDown";
            this.MartraLevelNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.MartraLevelNumericUpDown.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "内功需求等级";
            // 
            // BufferIdTextBox
            // 
            this.BufferIdTextBox.Location = new System.Drawing.Point(91, 39);
            this.BufferIdTextBox.Name = "BufferIdTextBox";
            this.BufferIdTextBox.Size = new System.Drawing.Size(120, 21);
            this.BufferIdTextBox.TabIndex = 85;
            // 
            // selectBufferButton
            // 
            this.selectBufferButton.Location = new System.Drawing.Point(217, 37);
            this.selectBufferButton.Name = "selectBufferButton";
            this.selectBufferButton.Size = new System.Drawing.Size(99, 23);
            this.selectBufferButton.TabIndex = 86;
            this.selectBufferButton.Text = "选择buffer";
            this.selectBufferButton.UseVisualStyleBackColor = true;
            this.selectBufferButton.Click += new System.EventHandler(this.selectMantraButton_Click);
            // 
            // MantraBufferEffectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 131);
            this.Controls.Add(this.selectBufferButton);
            this.Controls.Add(this.BufferIdTextBox);
            this.Controls.Add(this.MartraLevelNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "MantraBufferEffectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-特殊效果(buffer)";
            ((System.ComponentModel.ISupportInitialize)(this.MartraLevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown MartraLevelNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BufferIdTextBox;
        private System.Windows.Forms.Button selectBufferButton;
    }
}