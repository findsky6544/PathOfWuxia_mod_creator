
namespace 侠之道mod制作器
{
    partial class AssignAuraPromoteActionForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unitFactionComboBox = new System.Windows.Forms.ComboBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.distanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unitIdTextBox = new System.Windows.Forms.TextBox();
            this.buffIdTextBox = new System.Windows.Forms.TextBox();
            this.selectUnitIdButton = new System.Windows.Forms.Button();
            this.selectBuffButton = new System.Windows.Forms.Button();
            this.hasSelfCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(82, 177);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 177);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "部队阵营";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "部队性别";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "距离";
            // 
            // unitFactionComboBox
            // 
            this.unitFactionComboBox.FormattingEnabled = true;
            this.unitFactionComboBox.Location = new System.Drawing.Point(113, 66);
            this.unitFactionComboBox.Name = "unitFactionComboBox";
            this.unitFactionComboBox.Size = new System.Drawing.Size(146, 20);
            this.unitFactionComboBox.TabIndex = 19;
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(113, 92);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(145, 20);
            this.genderComboBox.TabIndex = 20;
            // 
            // distanceNumericUpDown
            // 
            this.distanceNumericUpDown.Location = new System.Drawing.Point(113, 39);
            this.distanceNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.distanceNumericUpDown.Name = "distanceNumericUpDown";
            this.distanceNumericUpDown.Size = new System.Drawing.Size(146, 21);
            this.distanceNumericUpDown.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "指定的ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "添加的Buff id";
            // 
            // unitIdTextBox
            // 
            this.unitIdTextBox.Location = new System.Drawing.Point(113, 12);
            this.unitIdTextBox.Name = "unitIdTextBox";
            this.unitIdTextBox.Size = new System.Drawing.Size(145, 21);
            this.unitIdTextBox.TabIndex = 25;
            // 
            // buffIdTextBox
            // 
            this.buffIdTextBox.Location = new System.Drawing.Point(113, 118);
            this.buffIdTextBox.Name = "buffIdTextBox";
            this.buffIdTextBox.Size = new System.Drawing.Size(145, 21);
            this.buffIdTextBox.TabIndex = 26;
            // 
            // selectUnitIdButton
            // 
            this.selectUnitIdButton.Location = new System.Drawing.Point(264, 10);
            this.selectUnitIdButton.Name = "selectUnitIdButton";
            this.selectUnitIdButton.Size = new System.Drawing.Size(75, 23);
            this.selectUnitIdButton.TabIndex = 29;
            this.selectUnitIdButton.Text = "选择部队";
            this.selectUnitIdButton.UseVisualStyleBackColor = true;
            this.selectUnitIdButton.Click += new System.EventHandler(this.selectUnitIdButton_Click);
            // 
            // selectBuffButton
            // 
            this.selectBuffButton.Location = new System.Drawing.Point(266, 116);
            this.selectBuffButton.Name = "selectBuffButton";
            this.selectBuffButton.Size = new System.Drawing.Size(75, 23);
            this.selectBuffButton.TabIndex = 30;
            this.selectBuffButton.Text = "选择buff";
            this.selectBuffButton.UseVisualStyleBackColor = true;
            this.selectBuffButton.Click += new System.EventHandler(this.selectBuffButton_Click);
            // 
            // hasSelfCheckBox
            // 
            this.hasSelfCheckBox.AutoSize = true;
            this.hasSelfCheckBox.Location = new System.Drawing.Point(114, 145);
            this.hasSelfCheckBox.Name = "hasSelfCheckBox";
            this.hasSelfCheckBox.Size = new System.Drawing.Size(72, 16);
            this.hasSelfCheckBox.TabIndex = 31;
            this.hasSelfCheckBox.Text = "包含自身";
            this.hasSelfCheckBox.UseVisualStyleBackColor = true;
            // 
            // AssignAuraPromoteActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 216);
            this.Controls.Add(this.hasSelfCheckBox);
            this.Controls.Add(this.selectBuffButton);
            this.Controls.Add(this.selectUnitIdButton);
            this.Controls.Add(this.buffIdTextBox);
            this.Controls.Add(this.unitIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.distanceNumericUpDown);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.unitFactionComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "AssignAuraPromoteActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指定ID范围增加Buff";
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox unitFactionComboBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.NumericUpDown distanceNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox unitIdTextBox;
        private System.Windows.Forms.TextBox buffIdTextBox;
        private System.Windows.Forms.Button selectUnitIdButton;
        private System.Windows.Forms.Button selectBuffButton;
        private System.Windows.Forms.CheckBox hasSelfCheckBox;
    }
}