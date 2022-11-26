
namespace 侠之道mod制作器
{
    partial class CharacterInfoMantraForm
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
            this.LevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.selectMantraButton = new System.Windows.Forms.Button();
            this.isWorkCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(174, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(67, 96);
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
            this.label6.Location = new System.Drawing.Point(26, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "心法编号";
            // 
            // LevelNumericUpDown
            // 
            this.LevelNumericUpDown.Location = new System.Drawing.Point(85, 39);
            this.LevelNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.LevelNumericUpDown.Name = "LevelNumericUpDown";
            this.LevelNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LevelNumericUpDown.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "目前等级";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(85, 12);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(120, 21);
            this.IdTextBox.TabIndex = 85;
            // 
            // selectMantraButton
            // 
            this.selectMantraButton.Location = new System.Drawing.Point(211, 10);
            this.selectMantraButton.Name = "selectMantraButton";
            this.selectMantraButton.Size = new System.Drawing.Size(99, 23);
            this.selectMantraButton.TabIndex = 86;
            this.selectMantraButton.Text = "选择心法";
            this.selectMantraButton.UseVisualStyleBackColor = true;
            this.selectMantraButton.Click += new System.EventHandler(this.selectMantraButton_Click);
            // 
            // isWorkCheckBox
            // 
            this.isWorkCheckBox.AutoSize = true;
            this.isWorkCheckBox.Location = new System.Drawing.Point(85, 66);
            this.isWorkCheckBox.Name = "isWorkCheckBox";
            this.isWorkCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isWorkCheckBox.TabIndex = 87;
            this.isWorkCheckBox.Text = "是否运行";
            this.isWorkCheckBox.UseVisualStyleBackColor = true;
            // 
            // CharacterInfoMantraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 131);
            this.Controls.Add(this.isWorkCheckBox);
            this.Controls.Add(this.selectMantraButton);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.LevelNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CharacterInfoMantraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-已学心法列表";
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown LevelNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Button selectMantraButton;
        private System.Windows.Forms.CheckBox isWorkCheckBox;
    }
}