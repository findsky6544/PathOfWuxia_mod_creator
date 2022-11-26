
namespace 侠之道mod制作器
{
    partial class NurturanceChangeBackgroundForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NurturanceChangeBackgroundForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.backImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nightPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dayPictureBox = new System.Windows.Forms.PictureBox();
            this.backidComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nightPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(289, 38);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(182, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "背景id";
            // 
            // backImageList
            // 
            this.backImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("backImageList.ImageStream")));
            this.backImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.backImageList.Images.SetKeyName(0, "M01_01_2D_Day");
            this.backImageList.Images.SetKeyName(1, "M01_01_2D_Night");
            this.backImageList.Images.SetKeyName(2, "M01_03_2D_Day");
            this.backImageList.Images.SetKeyName(3, "M01_03_2D_Night");
            this.backImageList.Images.SetKeyName(4, "M01_04_2D_Day");
            this.backImageList.Images.SetKeyName(5, "M01_04_2D_Night");
            this.backImageList.Images.SetKeyName(6, "M01_05_2D_Day");
            this.backImageList.Images.SetKeyName(7, "M01_05_2D_Night");
            this.backImageList.Images.SetKeyName(8, "M01_07_2D_Day");
            this.backImageList.Images.SetKeyName(9, "M01_07_2D_Night");
            this.backImageList.Images.SetKeyName(10, "M01_08_2D_Day");
            this.backImageList.Images.SetKeyName(11, "M01_08_2D_Night");
            this.backImageList.Images.SetKeyName(12, "M02_01_2D_Day");
            this.backImageList.Images.SetKeyName(13, "M02_01_2D_Night");
            this.backImageList.Images.SetKeyName(14, "M02_01a_2D_Day");
            this.backImageList.Images.SetKeyName(15, "M02_01a_2D_Night");
            this.backImageList.Images.SetKeyName(16, "M02_03_2D_Day");
            this.backImageList.Images.SetKeyName(17, "M02_03_2D_Night");
            this.backImageList.Images.SetKeyName(18, "M03_02_2D_Day");
            this.backImageList.Images.SetKeyName(19, "M03_02_2D_Night");
            this.backImageList.Images.SetKeyName(20, "M03_03_2D_Day");
            this.backImageList.Images.SetKeyName(21, "M03_03_2D_Night");
            this.backImageList.Images.SetKeyName(22, "M03_06_2D_Day");
            this.backImageList.Images.SetKeyName(23, "M03_06_2D_Night");
            this.backImageList.Images.SetKeyName(24, "M03_08_2D_Day");
            this.backImageList.Images.SetKeyName(25, "M03_08_2D_Night");
            this.backImageList.Images.SetKeyName(26, "M03_08a_2D_Day");
            this.backImageList.Images.SetKeyName(27, "M03_08a_2D_Night");
            this.backImageList.Images.SetKeyName(28, "M06_01_2D_Day");
            this.backImageList.Images.SetKeyName(29, "M06_01_2D_Night");
            this.backImageList.Images.SetKeyName(30, "M06_04_2D_Day");
            this.backImageList.Images.SetKeyName(31, "M06_04_2D_Night");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 200);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nightPictureBox);
            this.groupBox3.Location = new System.Drawing.Point(299, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 174);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "晚上";
            // 
            // nightPictureBox
            // 
            this.nightPictureBox.Location = new System.Drawing.Point(6, 20);
            this.nightPictureBox.Name = "nightPictureBox";
            this.nightPictureBox.Size = new System.Drawing.Size(273, 148);
            this.nightPictureBox.TabIndex = 1;
            this.nightPictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dayPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 174);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "白天";
            // 
            // dayPictureBox
            // 
            this.dayPictureBox.Location = new System.Drawing.Point(6, 20);
            this.dayPictureBox.Name = "dayPictureBox";
            this.dayPictureBox.Size = new System.Drawing.Size(273, 148);
            this.dayPictureBox.TabIndex = 0;
            this.dayPictureBox.TabStop = false;
            // 
            // backidComboBox
            // 
            this.backidComboBox.FormattingEnabled = true;
            this.backidComboBox.Location = new System.Drawing.Point(226, 12);
            this.backidComboBox.Name = "backidComboBox";
            this.backidComboBox.Size = new System.Drawing.Size(121, 20);
            this.backidComboBox.TabIndex = 71;
            this.backidComboBox.SelectedIndexChanged += new System.EventHandler(this.backidComboBox_SelectedIndexChanged);
            // 
            // NurturanceChangeBackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 275);
            this.Controls.Add(this.backidComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "NurturanceChangeBackgroundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换演出背景";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nightPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList backImageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox backidComboBox;
        private System.Windows.Forms.PictureBox nightPictureBox;
        private System.Windows.Forms.PictureBox dayPictureBox;
    }
}