
namespace 侠之道mod制作器
{
    partial class CellDataForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.PosTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CoordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WalkableCheckBox = new System.Windows.Forms.CheckBox();
            this.InActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ElementComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CellNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CellNumberNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(165, 163);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(58, 163);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 56;
            this.label4.Text = "格子坐标";
            // 
            // PosTextBox
            // 
            this.PosTextBox.Location = new System.Drawing.Point(71, 12);
            this.PosTextBox.Name = "PosTextBox";
            this.PosTextBox.Size = new System.Drawing.Size(229, 21);
            this.PosTextBox.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 80;
            this.label3.Text = "格子位置";
            // 
            // CoordTextBox
            // 
            this.CoordTextBox.Location = new System.Drawing.Point(71, 39);
            this.CoordTextBox.Name = "CoordTextBox";
            this.CoordTextBox.Size = new System.Drawing.Size(229, 21);
            this.CoordTextBox.TabIndex = 82;
            this.CoordTextBox.Leave += new System.EventHandler(this.CoordTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "格子编号";
            // 
            // WalkableCheckBox
            // 
            this.WalkableCheckBox.AutoSize = true;
            this.WalkableCheckBox.Location = new System.Drawing.Point(119, 93);
            this.WalkableCheckBox.Name = "WalkableCheckBox";
            this.WalkableCheckBox.Size = new System.Drawing.Size(96, 16);
            this.WalkableCheckBox.TabIndex = 85;
            this.WalkableCheckBox.Text = "是否可以移动";
            this.WalkableCheckBox.UseVisualStyleBackColor = true;
            // 
            // InActiveCheckBox
            // 
            this.InActiveCheckBox.AutoSize = true;
            this.InActiveCheckBox.Location = new System.Drawing.Point(119, 115);
            this.InActiveCheckBox.Name = "InActiveCheckBox";
            this.InActiveCheckBox.Size = new System.Drawing.Size(72, 16);
            this.InActiveCheckBox.TabIndex = 86;
            this.InActiveCheckBox.Text = "是否显示";
            this.InActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ElementComboBox
            // 
            this.ElementComboBox.FormattingEnabled = true;
            this.ElementComboBox.Location = new System.Drawing.Point(119, 137);
            this.ElementComboBox.Name = "ElementComboBox";
            this.ElementComboBox.Size = new System.Drawing.Size(121, 20);
            this.ElementComboBox.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 88;
            this.label2.Text = "五行单位";
            // 
            // CellNumberNumericUpDown
            // 
            this.CellNumberNumericUpDown.Enabled = false;
            this.CellNumberNumericUpDown.Location = new System.Drawing.Point(120, 66);
            this.CellNumberNumericUpDown.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.CellNumberNumericUpDown.Name = "CellNumberNumericUpDown";
            this.CellNumberNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.CellNumberNumericUpDown.TabIndex = 89;
            // 
            // CellDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 202);
            this.Controls.Add(this.CellNumberNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ElementComboBox);
            this.Controls.Add(this.InActiveCheckBox);
            this.Controls.Add(this.WalkableCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CoordTextBox);
            this.Controls.Add(this.PosTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CellDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-格子数据";
            ((System.ComponentModel.ISupportInitialize)(this.CellNumberNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PosTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CoordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox WalkableCheckBox;
        private System.Windows.Forms.CheckBox InActiveCheckBox;
        private System.Windows.Forms.ComboBox ElementComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CellNumberNumericUpDown;
    }
}