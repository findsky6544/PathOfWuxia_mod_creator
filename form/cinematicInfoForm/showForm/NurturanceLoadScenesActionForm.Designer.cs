
namespace 侠之道mod制作器
{
    partial class NurturanceLoadScenesActionForm
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
            this.positionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isNextTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.rotationTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loadTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeStageComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectMapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(177, 170);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(70, 170);
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
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "场景编号";
            // 
            // mapIdTextBox
            // 
            this.mapIdTextBox.Location = new System.Drawing.Point(95, 12);
            this.mapIdTextBox.Name = "mapIdTextBox";
            this.mapIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.mapIdTextBox.TabIndex = 22;
            // 
            // positionTextBox
            // 
            this.positionTextBox.Location = new System.Drawing.Point(95, 39);
            this.positionTextBox.Name = "positionTextBox";
            this.positionTextBox.Size = new System.Drawing.Size(120, 21);
            this.positionTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "玩家位置";
            // 
            // isNextTimeCheckBox
            // 
            this.isNextTimeCheckBox.AutoSize = true;
            this.isNextTimeCheckBox.Checked = true;
            this.isNextTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isNextTimeCheckBox.Location = new System.Drawing.Point(95, 122);
            this.isNextTimeCheckBox.Name = "isNextTimeCheckBox";
            this.isNextTimeCheckBox.Size = new System.Drawing.Size(96, 16);
            this.isNextTimeCheckBox.TabIndex = 56;
            this.isNextTimeCheckBox.Text = "是否切换日夜";
            this.isNextTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // rotationTextBox
            // 
            this.rotationTextBox.Location = new System.Drawing.Point(95, 66);
            this.rotationTextBox.Name = "rotationTextBox";
            this.rotationTextBox.Size = new System.Drawing.Size(120, 21);
            this.rotationTextBox.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 69;
            this.label5.Text = "玩家旋转值";
            // 
            // loadTypeComboBox
            // 
            this.loadTypeComboBox.FormattingEnabled = true;
            this.loadTypeComboBox.Location = new System.Drawing.Point(95, 93);
            this.loadTypeComboBox.Name = "loadTypeComboBox";
            this.loadTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.loadTypeComboBox.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 71;
            this.label6.Text = "载入类型";
            // 
            // timeStageComboBox
            // 
            this.timeStageComboBox.FormattingEnabled = true;
            this.timeStageComboBox.Location = new System.Drawing.Point(95, 144);
            this.timeStageComboBox.Name = "timeStageComboBox";
            this.timeStageComboBox.Size = new System.Drawing.Size(121, 20);
            this.timeStageComboBox.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 73;
            this.label8.Text = "切换到哪个阶段";
            // 
            // selectMapButton
            // 
            this.selectMapButton.Location = new System.Drawing.Point(222, 10);
            this.selectMapButton.Name = "selectMapButton";
            this.selectMapButton.Size = new System.Drawing.Size(99, 23);
            this.selectMapButton.TabIndex = 77;
            this.selectMapButton.Text = "选择场景";
            this.selectMapButton.UseVisualStyleBackColor = true;
            this.selectMapButton.Click += new System.EventHandler(this.selectMapButton_Click);
            // 
            // NurturanceLoadScenesActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 207);
            this.Controls.Add(this.selectMapButton);
            this.Controls.Add(this.timeStageComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.loadTypeComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rotationTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isNextTimeCheckBox);
            this.Controls.Add(this.positionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mapIdTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Name = "NurturanceLoadScenesActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "养成/切换阶段、日夜";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mapIdTextBox;
        private System.Windows.Forms.TextBox positionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isNextTimeCheckBox;
        private System.Windows.Forms.TextBox rotationTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox loadTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox timeStageComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selectMapButton;
    }
}