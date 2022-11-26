
namespace 侠之道mod制作器
{
    partial class AlchemyInfoForm
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
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectPropsButton = new System.Windows.Forms.Button();
            this.PropsIdTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(68, 15);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(17, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(96, 12);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(202, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Location = new System.Drawing.Point(96, 39);
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(202, 21);
            this.RemarkTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "备注";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectPropsButton);
            this.panel1.Controls.Add(this.PropsIdTextBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RemarkTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 132);
            this.panel1.TabIndex = 20;
            // 
            // selectPropsButton
            // 
            this.selectPropsButton.Location = new System.Drawing.Point(202, 64);
            this.selectPropsButton.Name = "selectPropsButton";
            this.selectPropsButton.Size = new System.Drawing.Size(96, 23);
            this.selectPropsButton.TabIndex = 32;
            this.selectPropsButton.Text = "选择药品";
            this.selectPropsButton.UseVisualStyleBackColor = true;
            this.selectPropsButton.Click += new System.EventHandler(this.selectPropsButton_Click);
            // 
            // PropsIdTextBox
            // 
            this.PropsIdTextBox.Location = new System.Drawing.Point(96, 66);
            this.PropsIdTextBox.Name = "PropsIdTextBox";
            this.PropsIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.PropsIdTextBox.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "炼制药品编号";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(144, 93);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AlchemyInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 132);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(300, 39);
            this.Name = "AlchemyInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alchemy信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox RemarkTextBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.Button selectPropsButton;
        public System.Windows.Forms.TextBox PropsIdTextBox;
        private System.Windows.Forms.Label label9;
    }
}