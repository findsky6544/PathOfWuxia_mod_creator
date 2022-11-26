
namespace 侠之道mod制作器
{
    partial class BattlSetTargetCellForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.selectCellButton = new System.Windows.Forms.Button();
            this.cellIndexTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectUnitButton = new System.Windows.Forms.Button();
            this.unitIDTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(89, 92);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(186, 92);
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
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 65);
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
            this.selectNextButton.Location = new System.Drawing.Point(251, 65);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "unit编号";
            // 
            // selectCellButton
            // 
            this.selectCellButton.Location = new System.Drawing.Point(251, 36);
            this.selectCellButton.Name = "selectCellButton";
            this.selectCellButton.Size = new System.Drawing.Size(75, 23);
            this.selectCellButton.TabIndex = 24;
            this.selectCellButton.Text = "选择格子";
            this.selectCellButton.UseVisualStyleBackColor = true;
            this.selectCellButton.Click += new System.EventHandler(this.selectCellButton_Click);
            // 
            // cellIndexTextBox
            // 
            this.cellIndexTextBox.Location = new System.Drawing.Point(102, 38);
            this.cellIndexTextBox.Name = "cellIndexTextBox";
            this.cellIndexTextBox.Size = new System.Drawing.Size(143, 21);
            this.cellIndexTextBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "点编号";
            // 
            // selectUnitButton
            // 
            this.selectUnitButton.Location = new System.Drawing.Point(251, 10);
            this.selectUnitButton.Name = "selectUnitButton";
            this.selectUnitButton.Size = new System.Drawing.Size(75, 23);
            this.selectUnitButton.TabIndex = 26;
            this.selectUnitButton.Text = "选择单位";
            this.selectUnitButton.UseVisualStyleBackColor = true;
            this.selectUnitButton.Click += new System.EventHandler(this.selectUnitButton_Click);
            // 
            // unitIDTextBox
            // 
            this.unitIDTextBox.Location = new System.Drawing.Point(102, 12);
            this.unitIDTextBox.Name = "unitIDTextBox";
            this.unitIDTextBox.Size = new System.Drawing.Size(143, 21);
            this.unitIDTextBox.TabIndex = 25;
            // 
            // BattlSetTargetCellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 132);
            this.Controls.Add(this.selectUnitButton);
            this.Controls.Add(this.unitIDTextBox);
            this.Controls.Add(this.selectCellButton);
            this.Controls.Add(this.cellIndexTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BattlSetTargetCellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设定目标点";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectCellButton;
        private System.Windows.Forms.TextBox cellIndexTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectUnitButton;
        private System.Windows.Forms.TextBox unitIDTextBox;
    }
}