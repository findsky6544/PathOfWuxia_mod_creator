
namespace 侠之道mod制作器
{
    partial class NpcChangeAccessoryActionForm
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
            this.accessoryTextBox = new System.Windows.Forms.TextBox();
            this.selectNpcButton = new System.Windows.Forms.Button();
            this.npcIdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(185, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(78, 71);
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
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "配件名称（复数用,隔开）";
            // 
            // accessoryTextBox
            // 
            this.accessoryTextBox.Location = new System.Drawing.Point(169, 17);
            this.accessoryTextBox.Name = "accessoryTextBox";
            this.accessoryTextBox.Size = new System.Drawing.Size(152, 21);
            this.accessoryTextBox.TabIndex = 22;
            // 
            // selectNpcButton
            // 
            this.selectNpcButton.Location = new System.Drawing.Point(222, 42);
            this.selectNpcButton.Name = "selectNpcButton";
            this.selectNpcButton.Size = new System.Drawing.Size(99, 23);
            this.selectNpcButton.TabIndex = 67;
            this.selectNpcButton.Text = "选择NPC";
            this.selectNpcButton.UseVisualStyleBackColor = true;
            this.selectNpcButton.Click += new System.EventHandler(this.selectNpcButton_Click);
            // 
            // npcIdTextBox
            // 
            this.npcIdTextBox.Location = new System.Drawing.Point(95, 44);
            this.npcIdTextBox.Name = "npcIdTextBox";
            this.npcIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.npcIdTextBox.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "NPC编号";
            // 
            // NpcChangeAccessoryActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 113);
            this.Controls.Add(this.selectNpcButton);
            this.Controls.Add(this.npcIdTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.accessoryTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "NpcChangeAccessoryActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Npc隐藏武器并装上配件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accessoryTextBox;
        private System.Windows.Forms.Button selectNpcButton;
        private System.Windows.Forms.TextBox npcIdTextBox;
        private System.Windows.Forms.Label label6;
    }
}