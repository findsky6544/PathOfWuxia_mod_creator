
namespace 侠之道mod制作器
{
    partial class SetNpcSpecialForm
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
            this.methodComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.selectSkillButton = new System.Windows.Forms.Button();
            this.specialIdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectNpcButton = new System.Windows.Forms.Button();
            this.npcIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // methodComboBox
            // 
            this.methodComboBox.FormattingEnabled = true;
            this.methodComboBox.Location = new System.Drawing.Point(120, 23);
            this.methodComboBox.Name = "methodComboBox";
            this.methodComboBox.Size = new System.Drawing.Size(121, 20);
            this.methodComboBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "修改方式";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(181, 103);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(74, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectSkillButton
            // 
            this.selectSkillButton.Location = new System.Drawing.Point(247, 47);
            this.selectSkillButton.Name = "selectSkillButton";
            this.selectSkillButton.Size = new System.Drawing.Size(99, 23);
            this.selectSkillButton.TabIndex = 73;
            this.selectSkillButton.Text = "选择特技";
            this.selectSkillButton.UseVisualStyleBackColor = true;
            this.selectSkillButton.Click += new System.EventHandler(this.selectPropsButton_Click);
            // 
            // specialIdTextBox
            // 
            this.specialIdTextBox.Location = new System.Drawing.Point(120, 49);
            this.specialIdTextBox.Name = "specialIdTextBox";
            this.specialIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.specialIdTextBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "特技ID";
            // 
            // selectNpcButton
            // 
            this.selectNpcButton.Location = new System.Drawing.Point(247, 74);
            this.selectNpcButton.Name = "selectNpcButton";
            this.selectNpcButton.Size = new System.Drawing.Size(99, 23);
            this.selectNpcButton.TabIndex = 82;
            this.selectNpcButton.Text = "选择NPC";
            this.selectNpcButton.UseVisualStyleBackColor = true;
            this.selectNpcButton.Click += new System.EventHandler(this.selectNpcButton_Click);
            // 
            // npcIdTextBox
            // 
            this.npcIdTextBox.Location = new System.Drawing.Point(120, 76);
            this.npcIdTextBox.Name = "npcIdTextBox";
            this.npcIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.npcIdTextBox.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 80;
            this.label3.Text = "NPC的character编号";
            // 
            // SetNpcSpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 139);
            this.Controls.Add(this.selectNpcButton);
            this.Controls.Add(this.npcIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectSkillButton);
            this.Controls.Add(this.specialIdTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.methodComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SetNpcSpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC/习得特技";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectSkillButton;
        private System.Windows.Forms.TextBox specialIdTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectNpcButton;
        private System.Windows.Forms.TextBox npcIdTextBox;
        private System.Windows.Forms.Label label3;
    }
}