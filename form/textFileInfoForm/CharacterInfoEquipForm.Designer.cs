
namespace 侠之道mod制作器
{
    partial class CharacterInfoEquipForm
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
            this.selectPropsButton = new System.Windows.Forms.Button();
            this.propsIdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EquipTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 66);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(62, 66);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectPropsButton
            // 
            this.selectPropsButton.Location = new System.Drawing.Point(212, 37);
            this.selectPropsButton.Name = "selectPropsButton";
            this.selectPropsButton.Size = new System.Drawing.Size(99, 23);
            this.selectPropsButton.TabIndex = 73;
            this.selectPropsButton.Text = "选择道具";
            this.selectPropsButton.UseVisualStyleBackColor = true;
            this.selectPropsButton.Click += new System.EventHandler(this.selectPropsButton_Click);
            // 
            // propsIdTextBox
            // 
            this.propsIdTextBox.Location = new System.Drawing.Point(85, 39);
            this.propsIdTextBox.Name = "propsIdTextBox";
            this.propsIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.propsIdTextBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "道具编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 80;
            this.label3.Text = "装备栏位";
            // 
            // EquipTypeComboBox
            // 
            this.EquipTypeComboBox.Enabled = false;
            this.EquipTypeComboBox.FormattingEnabled = true;
            this.EquipTypeComboBox.Location = new System.Drawing.Point(85, 13);
            this.EquipTypeComboBox.Name = "EquipTypeComboBox";
            this.EquipTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.EquipTypeComboBox.TabIndex = 81;
            // 
            // CharacterInfoEquipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 105);
            this.Controls.Add(this.EquipTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectPropsButton);
            this.Controls.Add(this.propsIdTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "CharacterInfoEquipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-装备";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectPropsButton;
        private System.Windows.Forms.TextBox propsIdTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EquipTypeComboBox;
    }
}