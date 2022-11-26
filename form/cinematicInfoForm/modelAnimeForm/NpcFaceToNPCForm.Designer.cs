
namespace 侠之道mod制作器
{
    partial class NpcFaceToNPCForm
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
            this.selectNpcFaceIdButton = new System.Windows.Forms.Button();
            this.faceidTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.selectNpcTurnIdButton = new System.Windows.Forms.Button();
            this.turnidTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(179, 97);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(72, 97);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNpcFaceIdButton
            // 
            this.selectNpcFaceIdButton.Location = new System.Drawing.Point(228, 42);
            this.selectNpcFaceIdButton.Name = "selectNpcFaceIdButton";
            this.selectNpcFaceIdButton.Size = new System.Drawing.Size(99, 23);
            this.selectNpcFaceIdButton.TabIndex = 70;
            this.selectNpcFaceIdButton.Text = "选择NPC";
            this.selectNpcFaceIdButton.UseVisualStyleBackColor = true;
            this.selectNpcFaceIdButton.Click += new System.EventHandler(this.selectNpcButton_Click);
            // 
            // faceidTextBox
            // 
            this.faceidTextBox.Location = new System.Drawing.Point(101, 44);
            this.faceidTextBox.Name = "faceidTextBox";
            this.faceidTextBox.Size = new System.Drawing.Size(121, 21);
            this.faceidTextBox.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "面对的NPC编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "面向类型";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(101, 71);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 20);
            this.typeComboBox.TabIndex = 72;
            // 
            // selectNpcTurnIdButton
            // 
            this.selectNpcTurnIdButton.Location = new System.Drawing.Point(228, 15);
            this.selectNpcTurnIdButton.Name = "selectNpcTurnIdButton";
            this.selectNpcTurnIdButton.Size = new System.Drawing.Size(99, 23);
            this.selectNpcTurnIdButton.TabIndex = 75;
            this.selectNpcTurnIdButton.Text = "选择NPC";
            this.selectNpcTurnIdButton.UseVisualStyleBackColor = true;
            this.selectNpcTurnIdButton.Click += new System.EventHandler(this.selectNpcTurnIdButton_Click);
            // 
            // turnidTextBox
            // 
            this.turnidTextBox.Location = new System.Drawing.Point(101, 17);
            this.turnidTextBox.Name = "turnidTextBox";
            this.turnidTextBox.Size = new System.Drawing.Size(121, 21);
            this.turnidTextBox.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 73;
            this.label2.Text = "转向的NPC编号";
            // 
            // NpcFaceToNPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 132);
            this.Controls.Add(this.selectNpcTurnIdButton);
            this.Controls.Add(this.turnidTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectNpcFaceIdButton);
            this.Controls.Add(this.faceidTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "NpcFaceToNPCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC 面向or背向 NPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNpcFaceIdButton;
        private System.Windows.Forms.TextBox faceidTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button selectNpcTurnIdButton;
        private System.Windows.Forms.TextBox turnidTextBox;
        private System.Windows.Forms.Label label2;
    }
}