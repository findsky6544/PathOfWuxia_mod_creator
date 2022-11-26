
namespace 侠之道mod制作器
{
    partial class MantraPropertyEffectForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PropertyComboBox = new System.Windows.Forms.ComboBox();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.MaxValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MartraLevelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxValueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(175, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(68, 118);
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
            this.label6.Location = new System.Drawing.Point(58, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "内功效果属性";
            // 
            // MartraLevelNumericUpDown
            // 
            this.MartraLevelNumericUpDown.Location = new System.Drawing.Point(140, 12);
            this.MartraLevelNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.MartraLevelNumericUpDown.Name = "MartraLevelNumericUpDown";
            this.MartraLevelNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.MartraLevelNumericUpDown.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "内功需求等级";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 85;
            this.label2.Text = "提升方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 86;
            this.label3.Text = "等级最高提升值";
            // 
            // PropertyComboBox
            // 
            this.PropertyComboBox.FormattingEnabled = true;
            this.PropertyComboBox.Location = new System.Drawing.Point(141, 39);
            this.PropertyComboBox.Name = "PropertyComboBox";
            this.PropertyComboBox.Size = new System.Drawing.Size(121, 20);
            this.PropertyComboBox.TabIndex = 87;
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Location = new System.Drawing.Point(140, 65);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(121, 20);
            this.MethodComboBox.TabIndex = 88;
            // 
            // MaxValueNumericUpDown
            // 
            this.MaxValueNumericUpDown.Location = new System.Drawing.Point(139, 91);
            this.MaxValueNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.MaxValueNumericUpDown.Name = "MaxValueNumericUpDown";
            this.MaxValueNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.MaxValueNumericUpDown.TabIndex = 89;
            // 
            // MantraPropertyEffectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 157);
            this.Controls.Add(this.MaxValueNumericUpDown);
            this.Controls.Add(this.MethodComboBox);
            this.Controls.Add(this.PropertyComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MartraLevelNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "MantraPropertyEffectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-修炼效果描述";
            ((System.ComponentModel.ISupportInitialize)(this.MartraLevelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxValueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown MartraLevelNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PropertyComboBox;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.NumericUpDown MaxValueNumericUpDown;
    }
}