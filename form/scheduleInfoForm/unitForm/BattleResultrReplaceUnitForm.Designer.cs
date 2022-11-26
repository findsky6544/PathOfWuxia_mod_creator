
namespace 侠之道mod制作器
{
    partial class BattleResultrReplaceUnitForm
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
            this.selectUnitButton = new System.Windows.Forms.Button();
            this.unitIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.magnificationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectAddUnitButton = new System.Windows.Forms.Button();
            this.addIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnificationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(89, 147);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(186, 147);
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
            this.label3.Location = new System.Drawing.Point(31, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 120);
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
            this.selectNextButton.Location = new System.Drawing.Point(251, 120);
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
            this.label6.Text = "取代的ID";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "放大倍率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "面向角度";
            // 
            // magnificationNumericUpDown
            // 
            this.magnificationNumericUpDown.DecimalPlaces = 5;
            this.magnificationNumericUpDown.Location = new System.Drawing.Point(102, 66);
            this.magnificationNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.magnificationNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.magnificationNumericUpDown.Name = "magnificationNumericUpDown";
            this.magnificationNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.magnificationNumericUpDown.TabIndex = 41;
            this.magnificationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.DecimalPlaces = 5;
            this.angleNumericUpDown.Location = new System.Drawing.Point(102, 93);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.angleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.angleNumericUpDown.TabIndex = 42;
            this.angleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // selectAddUnitButton
            // 
            this.selectAddUnitButton.Location = new System.Drawing.Point(251, 37);
            this.selectAddUnitButton.Name = "selectAddUnitButton";
            this.selectAddUnitButton.Size = new System.Drawing.Size(75, 23);
            this.selectAddUnitButton.TabIndex = 45;
            this.selectAddUnitButton.Text = "选择单位";
            this.selectAddUnitButton.UseVisualStyleBackColor = true;
            this.selectAddUnitButton.Click += new System.EventHandler(this.selectAddUnitButton_Click);
            // 
            // addIDTextBox
            // 
            this.addIDTextBox.Location = new System.Drawing.Point(102, 39);
            this.addIDTextBox.Name = "addIDTextBox";
            this.addIDTextBox.Size = new System.Drawing.Size(143, 21);
            this.addIDTextBox.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "加入的ID";
            // 
            // BattleResultrReplaceUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 186);
            this.Controls.Add(this.selectAddUnitButton);
            this.Controls.Add(this.addIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.magnificationNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectUnitButton);
            this.Controls.Add(this.unitIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BattleResultrReplaceUnitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取代部队";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magnificationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
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
        private System.Windows.Forms.Button selectUnitButton;
        private System.Windows.Forms.TextBox unitIDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown magnificationNumericUpDown;
        private System.Windows.Forms.NumericUpDown angleNumericUpDown;
        private System.Windows.Forms.Button selectAddUnitButton;
        private System.Windows.Forms.TextBox addIDTextBox;
        private System.Windows.Forms.Label label2;
    }
}