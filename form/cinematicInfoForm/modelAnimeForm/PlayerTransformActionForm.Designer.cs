
namespace 侠之道mod制作器
{
    partial class PlayerTransformActionForm
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
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.rotationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.isRotateCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(175, 113);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(68, 113);
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
            this.label1.Location = new System.Drawing.Point(60, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "位置";
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(95, 37);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(226, 21);
            this.positionTextBox.TabIndex = 22;
            // 
            // rotationTextBox
            // 
            this.rotationTextBox.Location = new System.Drawing.Point(95, 86);
            this.rotationTextBox.Name = "rotationTextBox";
            this.rotationTextBox.Size = new System.Drawing.Size(225, 21);
            this.rotationTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "旋转";
            // 
            // isMoveCheckBox
            // 
            this.isMoveCheckBox.AutoSize = true;
            this.isMoveCheckBox.Checked = true;
            this.isMoveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isMoveCheckBox.Location = new System.Drawing.Point(95, 12);
            this.isMoveCheckBox.Name = "isMoveCheckBox";
            this.isMoveCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isMoveCheckBox.TabIndex = 56;
            this.isMoveCheckBox.Text = "是否移动";
            this.isMoveCheckBox.UseVisualStyleBackColor = true;
            // 
            // isRotateCheckBox
            // 
            this.isRotateCheckBox.AutoSize = true;
            this.isRotateCheckBox.Location = new System.Drawing.Point(95, 64);
            this.isRotateCheckBox.Name = "isRotateCheckBox";
            this.isRotateCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isRotateCheckBox.TabIndex = 59;
            this.isRotateCheckBox.Text = "是否旋转";
            this.isRotateCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlayerTransformActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 154);
            this.Controls.Add(this.isRotateCheckBox);
            this.Controls.Add(this.isMoveCheckBox);
            this.Controls.Add(this.rotationTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "PlayerTransformActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player 瞬移 + 瞬转(限定演出用)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.TextBox rotationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isMoveCheckBox;
        private System.Windows.Forms.CheckBox isRotateCheckBox;
    }
}