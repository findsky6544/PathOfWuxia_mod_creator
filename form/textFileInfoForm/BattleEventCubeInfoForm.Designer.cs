
namespace 侠之道mod制作器
{
    partial class BattleEventCubeInfoForm
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
            this.InfoIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectCharacterExteriorButton = new System.Windows.Forms.Button();
            this.ExteriorIdTextBox = new System.Windows.Forms.TextBox();
            this.selectCharacterInfoButton = new System.Windows.Forms.Button();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Location = new System.Drawing.Point(30, 21);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(29, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(65, 18);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(335, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // InfoIdTextBox
            // 
            this.InfoIdTextBox.Location = new System.Drawing.Point(65, 45);
            this.InfoIdTextBox.Name = "InfoIdTextBox";
            this.InfoIdTextBox.Size = new System.Drawing.Size(335, 21);
            this.InfoIdTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "角色编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "外观编号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectCharacterExteriorButton);
            this.panel1.Controls.Add(this.ExteriorIdTextBox);
            this.panel1.Controls.Add(this.selectCharacterInfoButton);
            this.panel1.Controls.Add(this.RemarkTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.InfoIdTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 166);
            this.panel1.TabIndex = 20;
            // 
            // selectCharacterExteriorButton
            // 
            this.selectCharacterExteriorButton.Location = new System.Drawing.Point(406, 70);
            this.selectCharacterExteriorButton.Name = "selectCharacterExteriorButton";
            this.selectCharacterExteriorButton.Size = new System.Drawing.Size(96, 23);
            this.selectCharacterExteriorButton.TabIndex = 24;
            this.selectCharacterExteriorButton.Text = "选择外观";
            this.selectCharacterExteriorButton.UseVisualStyleBackColor = true;
            this.selectCharacterExteriorButton.Click += new System.EventHandler(this.selectCharacterExteriorButton_Click);
            // 
            // ExteriorIdTextBox
            // 
            this.ExteriorIdTextBox.Location = new System.Drawing.Point(65, 72);
            this.ExteriorIdTextBox.Name = "ExteriorIdTextBox";
            this.ExteriorIdTextBox.Size = new System.Drawing.Size(335, 21);
            this.ExteriorIdTextBox.TabIndex = 23;
            // 
            // selectCharacterInfoButton
            // 
            this.selectCharacterInfoButton.Location = new System.Drawing.Point(406, 43);
            this.selectCharacterInfoButton.Name = "selectCharacterInfoButton";
            this.selectCharacterInfoButton.Size = new System.Drawing.Size(96, 23);
            this.selectCharacterInfoButton.TabIndex = 22;
            this.selectCharacterInfoButton.Text = "选择角色";
            this.selectCharacterInfoButton.UseVisualStyleBackColor = true;
            this.selectCharacterInfoButton.Click += new System.EventHandler(this.selectCharacterInfoButton_Click);
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Location = new System.Drawing.Point(65, 99);
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(335, 21);
            this.RemarkTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "备注";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(214, 126);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BattleEventCubeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 166);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "BattleEventCubeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleEventCube信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox InfoIdTextBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox RemarkTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button selectCharacterInfoButton;
        public System.Windows.Forms.Button selectCharacterExteriorButton;
        public System.Windows.Forms.TextBox ExteriorIdTextBox;
    }
}