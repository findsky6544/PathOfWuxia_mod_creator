
namespace 侠之道mod制作器
{
    partial class SetNpcCurrentBehaviourClickTypeForm
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
            this.selectcharacterBehaviourButton = new System.Windows.Forms.Button();
            this.characterBehaviourIdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClickTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(200, 65);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(93, 65);
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
            this.label1.Location = new System.Drawing.Point(53, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "互动名称";
            // 
            // selectcharacterBehaviourButton
            // 
            this.selectcharacterBehaviourButton.Location = new System.Drawing.Point(239, 10);
            this.selectcharacterBehaviourButton.Name = "selectcharacterBehaviourButton";
            this.selectcharacterBehaviourButton.Size = new System.Drawing.Size(108, 23);
            this.selectcharacterBehaviourButton.TabIndex = 64;
            this.selectcharacterBehaviourButton.Text = "选择行为";
            this.selectcharacterBehaviourButton.UseVisualStyleBackColor = true;
            this.selectcharacterBehaviourButton.Click += new System.EventHandler(this.selectNpcButton_Click);
            // 
            // characterBehaviourIdTextBox
            // 
            this.characterBehaviourIdTextBox.Location = new System.Drawing.Point(112, 12);
            this.characterBehaviourIdTextBox.Name = "characterBehaviourIdTextBox";
            this.characterBehaviourIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.characterBehaviourIdTextBox.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 62;
            this.label5.Text = "行为编号";
            // 
            // ClickTypeComboBox
            // 
            this.ClickTypeComboBox.FormattingEnabled = true;
            this.ClickTypeComboBox.Location = new System.Drawing.Point(112, 39);
            this.ClickTypeComboBox.Name = "ClickTypeComboBox";
            this.ClickTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.ClickTypeComboBox.TabIndex = 65;
            // 
            // SetNpcCurrentBehaviourClickTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 103);
            this.Controls.Add(this.ClickTypeComboBox);
            this.Controls.Add(this.selectcharacterBehaviourButton);
            this.Controls.Add(this.characterBehaviourIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "SetNpcCurrentBehaviourClickTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NPC设定/行为互动类型（必须过loading）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectcharacterBehaviourButton;
        private System.Windows.Forms.TextBox characterBehaviourIdTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ClickTypeComboBox;
    }
}