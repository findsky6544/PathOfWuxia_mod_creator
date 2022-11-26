
namespace 侠之道mod制作器
{
    partial class CharacterInfoUpgradeablePropertyForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.CharacterUpgradablePropertyComboBox = new System.Windows.Forms.ComboBox();
            this.UpgradeablePropertyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeablePropertyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(150, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(43, 70);
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
            this.label6.Location = new System.Drawing.Point(26, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 80;
            this.label3.Text = "可升级属性";
            // 
            // CharacterUpgradablePropertyComboBox
            // 
            this.CharacterUpgradablePropertyComboBox.Enabled = false;
            this.CharacterUpgradablePropertyComboBox.FormattingEnabled = true;
            this.CharacterUpgradablePropertyComboBox.Location = new System.Drawing.Point(85, 13);
            this.CharacterUpgradablePropertyComboBox.Name = "CharacterUpgradablePropertyComboBox";
            this.CharacterUpgradablePropertyComboBox.Size = new System.Drawing.Size(121, 20);
            this.CharacterUpgradablePropertyComboBox.TabIndex = 81;
            // 
            // UpgradeablePropertyNumericUpDown
            // 
            this.UpgradeablePropertyNumericUpDown.Location = new System.Drawing.Point(86, 39);
            this.UpgradeablePropertyNumericUpDown.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.UpgradeablePropertyNumericUpDown.Name = "UpgradeablePropertyNumericUpDown";
            this.UpgradeablePropertyNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.UpgradeablePropertyNumericUpDown.TabIndex = 82;
            // 
            // CharacterInfoUpgradeablePropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 105);
            this.Controls.Add(this.UpgradeablePropertyNumericUpDown);
            this.Controls.Add(this.CharacterUpgradablePropertyComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CharacterInfoUpgradeablePropertyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-可升级属性";
            ((System.ComponentModel.ISupportInitialize)(this.UpgradeablePropertyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CharacterUpgradablePropertyComboBox;
        private System.Windows.Forms.NumericUpDown UpgradeablePropertyNumericUpDown;
    }
}