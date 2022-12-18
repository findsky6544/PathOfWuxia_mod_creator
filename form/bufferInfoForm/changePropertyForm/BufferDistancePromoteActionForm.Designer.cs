
namespace 侠之道mod制作器
{
    partial class BufferDistancePromoteActionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.propertyComboBox = new System.Windows.Forms.ComboBox();
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.percentLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.minDisNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.minDisNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "作用属性";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "作用方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "提升值（每次）";
            // 
            // propertyComboBox
            // 
            this.propertyComboBox.FormattingEnabled = true;
            this.propertyComboBox.Location = new System.Drawing.Point(114, 39);
            this.propertyComboBox.Name = "propertyComboBox";
            this.propertyComboBox.Size = new System.Drawing.Size(121, 20);
            this.propertyComboBox.TabIndex = 3;
            this.propertyComboBox.SelectedIndexChanged += new System.EventHandler(this.propertyComboBox_SelectedIndexChanged);
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Location = new System.Drawing.Point(114, 66);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 20);
            this.methodComboBox.TabIndex = 4;
            this.methodComboBox.SelectedIndexChanged += new System.EventHandler(this.methodComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(42, 152);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 152);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(241, 94);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(11, 12);
            this.percentLabel.TabIndex = 13;
            this.percentLabel.Text = "%";
            this.percentLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "提升上限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "最小格数";
            // 
            // minDisNumericUpDown
            // 
            this.minDisNumericUpDown.Location = new System.Drawing.Point(115, 12);
            this.minDisNumericUpDown.Name = "minDisNumericUpDown";
            this.minDisNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.minDisNumericUpDown.TabIndex = 17;
            // 
            // valueNumericUpDown
            // 
            this.valueNumericUpDown.DecimalPlaces = 5;
            this.valueNumericUpDown.Location = new System.Drawing.Point(114, 92);
            this.valueNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.valueNumericUpDown.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            this.valueNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.valueNumericUpDown.TabIndex = 18;
            // 
            // valueLimitNumericUpDown
            // 
            this.valueLimitNumericUpDown.DecimalPlaces = 5;
            this.valueLimitNumericUpDown.Location = new System.Drawing.Point(114, 119);
            this.valueLimitNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.valueLimitNumericUpDown.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.valueLimitNumericUpDown.Name = "valueLimitNumericUpDown";
            this.valueLimitNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.valueLimitNumericUpDown.TabIndex = 19;
            this.valueLimitNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // BufferDistancePromoteActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 189);
            this.Controls.Add(this.valueLimitNumericUpDown);
            this.Controls.Add(this.valueNumericUpDown);
            this.Controls.Add(this.minDisNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.propertyComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BufferDistancePromoteActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "攻击距离提升属性";
            ((System.ComponentModel.ISupportInitialize)(this.minDisNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox propertyComboBox;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown minDisNumericUpDown;
        private System.Windows.Forms.NumericUpDown valueNumericUpDown;
        private System.Windows.Forms.NumericUpDown valueLimitNumericUpDown;
    }
}