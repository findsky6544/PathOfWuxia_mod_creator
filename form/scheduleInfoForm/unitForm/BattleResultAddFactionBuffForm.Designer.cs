
namespace 侠之道mod制作器
{
    partial class BattleResultAddFactionBuffForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nextNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectNextButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.selectUnitBIDButton = new System.Windows.Forms.Button();
            this.buffIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showEffectCheckBox = new System.Windows.Forms.CheckBox();
            this.isBufferCheckBox = new System.Windows.Forms.CheckBox();
            this.factionComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(87, 122);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(184, 122);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 92);
            this.nextNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nextNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nextNumericUpDown.Name = "nextNumericUpDown";
            this.nextNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.nextNumericUpDown.TabIndex = 7;
            this.nextNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // selectNextButton
            // 
            this.selectNextButton.Location = new System.Drawing.Point(251, 92);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "部队阵营";
            // 
            // selectUnitBIDButton
            // 
            this.selectUnitBIDButton.Location = new System.Drawing.Point(251, 41);
            this.selectUnitBIDButton.Name = "selectUnitBIDButton";
            this.selectUnitBIDButton.Size = new System.Drawing.Size(75, 23);
            this.selectUnitBIDButton.TabIndex = 30;
            this.selectUnitBIDButton.Text = "选择增益";
            this.selectUnitBIDButton.UseVisualStyleBackColor = true;
            this.selectUnitBIDButton.Click += new System.EventHandler(this.selectUnitBIDButton_Click);
            // 
            // buffIdTextBox
            // 
            this.buffIdTextBox.Location = new System.Drawing.Point(102, 43);
            this.buffIdTextBox.Name = "buffIdTextBox";
            this.buffIdTextBox.Size = new System.Drawing.Size(143, 21);
            this.buffIdTextBox.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "状态ID";
            // 
            // showEffectCheckBox
            // 
            this.showEffectCheckBox.AutoSize = true;
            this.showEffectCheckBox.Location = new System.Drawing.Point(39, 70);
            this.showEffectCheckBox.Name = "showEffectCheckBox";
            this.showEffectCheckBox.Size = new System.Drawing.Size(72, 16);
            this.showEffectCheckBox.TabIndex = 34;
            this.showEffectCheckBox.Text = "显示特效";
            this.showEffectCheckBox.UseVisualStyleBackColor = true;
            // 
            // isBufferCheckBox
            // 
            this.isBufferCheckBox.AutoSize = true;
            this.isBufferCheckBox.Location = new System.Drawing.Point(117, 70);
            this.isBufferCheckBox.Name = "isBufferCheckBox";
            this.isBufferCheckBox.Size = new System.Drawing.Size(60, 16);
            this.isBufferCheckBox.TabIndex = 35;
            this.isBufferCheckBox.Text = "是增益";
            this.isBufferCheckBox.UseVisualStyleBackColor = true;
            // 
            // factionComboBox
            // 
            this.factionComboBox.FormattingEnabled = true;
            this.factionComboBox.Location = new System.Drawing.Point(102, 16);
            this.factionComboBox.Name = "factionComboBox";
            this.factionComboBox.Size = new System.Drawing.Size(143, 20);
            this.factionComboBox.TabIndex = 36;
            // 
            // BattleResultAddFactionBuffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 165);
            this.Controls.Add(this.factionComboBox);
            this.Controls.Add(this.isBufferCheckBox);
            this.Controls.Add(this.showEffectCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectUnitBIDButton);
            this.Controls.Add(this.buffIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BattleResultAddFactionBuffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阵营加入增益";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.Button selectNextButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectUnitBIDButton;
        private System.Windows.Forms.TextBox buffIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showEffectCheckBox;
        private System.Windows.Forms.CheckBox isBufferCheckBox;
        private System.Windows.Forms.ComboBox factionComboBox;
    }
}