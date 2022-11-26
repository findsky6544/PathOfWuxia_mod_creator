
namespace 侠之道mod制作器
{
    partial class CheckNpcTraitForm
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
            this.npcIdTextBox = new System.Windows.Forms.TextBox();
            this.selectCharacterInfoButton = new System.Windows.Forms.Button();
            this.selectTraitButton = new System.Windows.Forms.Button();
            this.trait_IdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isContainsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(214, 104);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(107, 104);
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
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "NPC的character编号";
            // 
            // npcIdTextBox
            // 
            this.npcIdTextBox.Location = new System.Drawing.Point(145, 12);
            this.npcIdTextBox.Name = "npcIdTextBox";
            this.npcIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.npcIdTextBox.TabIndex = 22;
            // 
            // selectCharacterInfoButton
            // 
            this.selectCharacterInfoButton.Location = new System.Drawing.Point(272, 10);
            this.selectCharacterInfoButton.Name = "selectCharacterInfoButton";
            this.selectCharacterInfoButton.Size = new System.Drawing.Size(99, 23);
            this.selectCharacterInfoButton.TabIndex = 34;
            this.selectCharacterInfoButton.Text = "选择character";
            this.selectCharacterInfoButton.UseVisualStyleBackColor = true;
            this.selectCharacterInfoButton.Click += new System.EventHandler(this.selectCharacterInfoButton_Click);
            // 
            // selectTraitButton
            // 
            this.selectTraitButton.Location = new System.Drawing.Point(272, 37);
            this.selectTraitButton.Name = "selectTraitButton";
            this.selectTraitButton.Size = new System.Drawing.Size(99, 23);
            this.selectTraitButton.TabIndex = 37;
            this.selectTraitButton.Text = "选择特质";
            this.selectTraitButton.UseVisualStyleBackColor = true;
            this.selectTraitButton.Click += new System.EventHandler(this.selectTraitButton_Click);
            // 
            // trait_IdTextBox
            // 
            this.trait_IdTextBox.Location = new System.Drawing.Point(145, 39);
            this.trait_IdTextBox.Name = "trait_IdTextBox";
            this.trait_IdTextBox.Size = new System.Drawing.Size(121, 21);
            this.trait_IdTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "特质编号";
            // 
            // isContainsCheckBox
            // 
            this.isContainsCheckBox.AutoSize = true;
            this.isContainsCheckBox.Location = new System.Drawing.Point(145, 66);
            this.isContainsCheckBox.Name = "isContainsCheckBox";
            this.isContainsCheckBox.Size = new System.Drawing.Size(84, 16);
            this.isContainsCheckBox.TabIndex = 38;
            this.isContainsCheckBox.Text = "具备此能力";
            this.isContainsCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckNpcTraitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 139);
            this.Controls.Add(this.isContainsCheckBox);
            this.Controls.Add(this.selectTraitButton);
            this.Controls.Add(this.trait_IdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectCharacterInfoButton);
            this.Controls.Add(this.npcIdTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "CheckNpcTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检查NPC特质";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox npcIdTextBox;
        private System.Windows.Forms.Button selectCharacterInfoButton;
        private System.Windows.Forms.Button selectTraitButton;
        private System.Windows.Forms.TextBox trait_IdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isContainsCheckBox;
    }
}