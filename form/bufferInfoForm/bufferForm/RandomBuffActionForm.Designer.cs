
namespace 侠之道mod制作器
{
    partial class RandomBuffActionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bufferIdTextBox = new System.Windows.Forms.TextBox();
            this.selectBufferButton = new System.Windows.Forms.Button();
            this.randomTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.minAddTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxAddTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.isRepeatCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.randomTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAddTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAddTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(87, 169);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 169);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "随机几次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "buff id";
            // 
            // bufferIdTextBox
            // 
            this.bufferIdTextBox.Location = new System.Drawing.Point(107, 23);
            this.bufferIdTextBox.Name = "bufferIdTextBox";
            this.bufferIdTextBox.Size = new System.Drawing.Size(165, 21);
            this.bufferIdTextBox.TabIndex = 20;
            // 
            // selectBufferButton
            // 
            this.selectBufferButton.Location = new System.Drawing.Point(279, 21);
            this.selectBufferButton.Name = "selectBufferButton";
            this.selectBufferButton.Size = new System.Drawing.Size(75, 23);
            this.selectBufferButton.TabIndex = 21;
            this.selectBufferButton.Text = "选择";
            this.selectBufferButton.UseVisualStyleBackColor = true;
            this.selectBufferButton.Click += new System.EventHandler(this.selectBufferButton_Click);
            // 
            // randomTimeNumericUpDown
            // 
            this.randomTimeNumericUpDown.Location = new System.Drawing.Point(107, 50);
            this.randomTimeNumericUpDown.Name = "randomTimeNumericUpDown";
            this.randomTimeNumericUpDown.Size = new System.Drawing.Size(165, 21);
            this.randomTimeNumericUpDown.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "最少加几次";
            // 
            // minAddTimeNumericUpDown
            // 
            this.minAddTimeNumericUpDown.Location = new System.Drawing.Point(106, 77);
            this.minAddTimeNumericUpDown.Name = "minAddTimeNumericUpDown";
            this.minAddTimeNumericUpDown.Size = new System.Drawing.Size(166, 21);
            this.minAddTimeNumericUpDown.TabIndex = 24;
            // 
            // maxAddTimeNumericUpDown
            // 
            this.maxAddTimeNumericUpDown.Location = new System.Drawing.Point(107, 104);
            this.maxAddTimeNumericUpDown.Name = "maxAddTimeNumericUpDown";
            this.maxAddTimeNumericUpDown.Size = new System.Drawing.Size(165, 21);
            this.maxAddTimeNumericUpDown.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "最多加几次";
            // 
            // isRepeatCheckBox
            // 
            this.isRepeatCheckBox.AutoSize = true;
            this.isRepeatCheckBox.Location = new System.Drawing.Point(106, 131);
            this.isRepeatCheckBox.Name = "isRepeatCheckBox";
            this.isRepeatCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isRepeatCheckBox.TabIndex = 30;
            this.isRepeatCheckBox.Text = "重复随机";
            this.isRepeatCheckBox.UseVisualStyleBackColor = true;
            // 
            // RandomBuffActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 204);
            this.Controls.Add(this.isRepeatCheckBox);
            this.Controls.Add(this.maxAddTimeNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.minAddTimeNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.randomTimeNumericUpDown);
            this.Controls.Add(this.selectBufferButton);
            this.Controls.Add(this.bufferIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "RandomBuffActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机增加Buff或Debuff";
            ((System.ComponentModel.ISupportInitialize)(this.randomTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAddTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAddTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bufferIdTextBox;
        private System.Windows.Forms.Button selectBufferButton;
        private System.Windows.Forms.NumericUpDown randomTimeNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minAddTimeNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxAddTimeNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox isRepeatCheckBox;
    }
}