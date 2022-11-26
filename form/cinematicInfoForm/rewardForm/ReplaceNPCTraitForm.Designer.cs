
namespace 侠之道mod制作器
{
    partial class ReplaceNPCTraitForm
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
            this.selectNewTraitButton = new System.Windows.Forms.Button();
            this.NewIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectOldTraitButton = new System.Windows.Forms.Button();
            this.OldIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectNpcButton = new System.Windows.Forms.Button();
            this.npcIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(189, 103);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(82, 103);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNewTraitButton
            // 
            this.selectNewTraitButton.Location = new System.Drawing.Point(247, 47);
            this.selectNewTraitButton.Name = "selectNewTraitButton";
            this.selectNewTraitButton.Size = new System.Drawing.Size(99, 23);
            this.selectNewTraitButton.TabIndex = 73;
            this.selectNewTraitButton.Text = "选择特质";
            this.selectNewTraitButton.UseVisualStyleBackColor = true;
            this.selectNewTraitButton.Click += new System.EventHandler(this.selectNewTraitButton_Click);
            // 
            // NewIDTextBox
            // 
            this.NewIDTextBox.Location = new System.Drawing.Point(120, 49);
            this.NewIDTextBox.Name = "NewIDTextBox";
            this.NewIDTextBox.Size = new System.Drawing.Size(121, 21);
            this.NewIDTextBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "新的特质ID";
            // 
            // selectOldTraitButton
            // 
            this.selectOldTraitButton.Location = new System.Drawing.Point(247, 20);
            this.selectOldTraitButton.Name = "selectOldTraitButton";
            this.selectOldTraitButton.Size = new System.Drawing.Size(99, 23);
            this.selectOldTraitButton.TabIndex = 76;
            this.selectOldTraitButton.Text = "选择特质";
            this.selectOldTraitButton.UseVisualStyleBackColor = true;
            this.selectOldTraitButton.Click += new System.EventHandler(this.selectOldTraitButton_Click);
            // 
            // OldIDTextBox
            // 
            this.OldIDTextBox.Location = new System.Drawing.Point(120, 22);
            this.OldIDTextBox.Name = "OldIDTextBox";
            this.OldIDTextBox.Size = new System.Drawing.Size(121, 21);
            this.OldIDTextBox.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "旧的特质ID";
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
            // ReplaceNPCTraitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 140);
            this.Controls.Add(this.selectNpcButton);
            this.Controls.Add(this.npcIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectOldTraitButton);
            this.Controls.Add(this.OldIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectNewTraitButton);
            this.Controls.Add(this.NewIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ReplaceNPCTraitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC/取代特质";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNewTraitButton;
        private System.Windows.Forms.TextBox NewIDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button selectOldTraitButton;
        private System.Windows.Forms.TextBox OldIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectNpcButton;
        private System.Windows.Forms.TextBox npcIdTextBox;
        private System.Windows.Forms.Label label3;
    }
}