﻿
namespace 侠之道mod制作器
{
    partial class CheckMapIdForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.mapIdTextBox = new System.Windows.Forms.TextBox();
            this.selectMapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(166, 90);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(59, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "地图编号";
            // 
            // mapIdTextBox
            // 
            this.mapIdTextBox.Location = new System.Drawing.Point(85, 28);
            this.mapIdTextBox.Name = "mapIdTextBox";
            this.mapIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.mapIdTextBox.TabIndex = 22;
            // 
            // selectMapButton
            // 
            this.selectMapButton.Location = new System.Drawing.Point(212, 26);
            this.selectMapButton.Name = "selectMapButton";
            this.selectMapButton.Size = new System.Drawing.Size(75, 23);
            this.selectMapButton.TabIndex = 34;
            this.selectMapButton.Text = "选择地图";
            this.selectMapButton.UseVisualStyleBackColor = true;
            this.selectMapButton.Click += new System.EventHandler(this.selectMapButton_Click);
            // 
            // CheckMapIdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 124);
            this.Controls.Add(this.selectMapButton);
            this.Controls.Add(this.mapIdTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "CheckMapIdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查当前地图编号";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mapIdTextBox;
        private System.Windows.Forms.Button selectMapButton;
    }
}