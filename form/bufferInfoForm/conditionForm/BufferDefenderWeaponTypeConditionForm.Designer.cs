﻿
namespace 侠之道mod制作器
{
    partial class BufferDefenderWeaponTypeConditionForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.propsCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.IsReverseCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(87, 78);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(197, 78);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "武器类型";
            // 
            // propsCategoryComboBox
            // 
            this.propsCategoryComboBox.FormattingEnabled = true;
            this.propsCategoryComboBox.Location = new System.Drawing.Point(107, 23);
            this.propsCategoryComboBox.Name = "propsCategoryComboBox";
            this.propsCategoryComboBox.Size = new System.Drawing.Size(165, 20);
            this.propsCategoryComboBox.TabIndex = 24;
            // 
            // IsReverseCheckBox
            // 
            this.IsReverseCheckBox.AutoSize = true;
            this.IsReverseCheckBox.Location = new System.Drawing.Point(107, 49);
            this.IsReverseCheckBox.Name = "IsReverseCheckBox";
            this.IsReverseCheckBox.Size = new System.Drawing.Size(72, 16);
            this.IsReverseCheckBox.TabIndex = 26;
            this.IsReverseCheckBox.Text = "是否反向";
            this.IsReverseCheckBox.UseVisualStyleBackColor = true;
            // 
            // BufferDefenderWeaponTypeConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 124);
            this.Controls.Add(this.IsReverseCheckBox);
            this.Controls.Add(this.propsCategoryComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BufferDefenderWeaponTypeConditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "判断防御者武器类型";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox propsCategoryComboBox;
        private System.Windows.Forms.CheckBox IsReverseCheckBox;
    }
}