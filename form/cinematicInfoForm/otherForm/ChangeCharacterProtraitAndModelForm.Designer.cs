
namespace 侠之道mod制作器
{
    partial class ChangeCharacterProtraitAndModelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeCharacterProtraitAndModelForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.isChangeProtraitCheckBox = new System.Windows.Forms.CheckBox();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.selectExteriorButton = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.isChangeModelCheckBox = new System.Windows.Forms.CheckBox();
            this.protraitImageList = new System.Windows.Forms.ImageList(this.components);
            this.protraitComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.protraitPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.protraitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(178, 137);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(71, 137);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "立绘";
            // 
            // isChangeProtraitCheckBox
            // 
            this.isChangeProtraitCheckBox.AutoSize = true;
            this.isChangeProtraitCheckBox.Location = new System.Drawing.Point(94, 39);
            this.isChangeProtraitCheckBox.Name = "isChangeProtraitCheckBox";
            this.isChangeProtraitCheckBox.Size = new System.Drawing.Size(96, 16);
            this.isChangeProtraitCheckBox.TabIndex = 56;
            this.isChangeProtraitCheckBox.Text = "是否改变立绘";
            this.isChangeProtraitCheckBox.UseVisualStyleBackColor = true;
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(94, 110);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(120, 21);
            this.modelTextBox.TabIndex = 70;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 69;
            this.label5.Text = "模型";
            // 
            // selectExteriorButton
            // 
            this.selectExteriorButton.Location = new System.Drawing.Point(221, 10);
            this.selectExteriorButton.Name = "selectExteriorButton";
            this.selectExteriorButton.Size = new System.Drawing.Size(99, 23);
            this.selectExteriorButton.TabIndex = 85;
            this.selectExteriorButton.Text = "选择Exterior";
            this.selectExteriorButton.UseVisualStyleBackColor = true;
            this.selectExteriorButton.Click += new System.EventHandler(this.selectExteriorButton_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(94, 12);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(121, 21);
            this.idTextBox.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "Exterior编号";
            // 
            // isChangeModelCheckBox
            // 
            this.isChangeModelCheckBox.AutoSize = true;
            this.isChangeModelCheckBox.Location = new System.Drawing.Point(94, 88);
            this.isChangeModelCheckBox.Name = "isChangeModelCheckBox";
            this.isChangeModelCheckBox.Size = new System.Drawing.Size(96, 16);
            this.isChangeModelCheckBox.TabIndex = 86;
            this.isChangeModelCheckBox.Text = "是否改变模型";
            this.isChangeModelCheckBox.UseVisualStyleBackColor = true;
            // 
            // protraitImageList
            // 
            this.protraitImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("protraitImageList.ImageStream")));
            this.protraitImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.protraitImageList.Images.SetKeyName(0, "ar0101_General");
            this.protraitImageList.Images.SetKeyName(1, "ar0201_General");
            this.protraitImageList.Images.SetKeyName(2, "ar0305_General");
            this.protraitImageList.Images.SetKeyName(3, "ar0313_General");
            this.protraitImageList.Images.SetKeyName(4, "ar0320_General");
            this.protraitImageList.Images.SetKeyName(5, "ar0320_Unhappy");
            this.protraitImageList.Images.SetKeyName(6, "ar0323_General");
            this.protraitImageList.Images.SetKeyName(7, "ar0325_General");
            this.protraitImageList.Images.SetKeyName(8, "ar0328_General");
            this.protraitImageList.Images.SetKeyName(9, "ar0330_General");
            this.protraitImageList.Images.SetKeyName(10, "ar0332_General");
            this.protraitImageList.Images.SetKeyName(11, "ar0334_General");
            this.protraitImageList.Images.SetKeyName(12, "ar0335_General");
            this.protraitImageList.Images.SetKeyName(13, "ar0339_General");
            this.protraitImageList.Images.SetKeyName(14, "ar0339_Sad");
            this.protraitImageList.Images.SetKeyName(15, "ar0339_Unhappy");
            this.protraitImageList.Images.SetKeyName(16, "ar0340_General");
            this.protraitImageList.Images.SetKeyName(17, "ar0340_Happy");
            this.protraitImageList.Images.SetKeyName(18, "ar0340_Sad");
            this.protraitImageList.Images.SetKeyName(19, "ar0343_General");
            this.protraitImageList.Images.SetKeyName(20, "ar0343_Sad");
            this.protraitImageList.Images.SetKeyName(21, "ar0345_General");
            this.protraitImageList.Images.SetKeyName(22, "ar0348_General");
            this.protraitImageList.Images.SetKeyName(23, "ar0352_General");
            this.protraitImageList.Images.SetKeyName(24, "ar0401_General");
            this.protraitImageList.Images.SetKeyName(25, "ar0402_General");
            this.protraitImageList.Images.SetKeyName(26, "ar0403_General");
            this.protraitImageList.Images.SetKeyName(27, "ar0501_General");
            this.protraitImageList.Images.SetKeyName(28, "ar0502_General");
            this.protraitImageList.Images.SetKeyName(29, "ar0503_General");
            this.protraitImageList.Images.SetKeyName(30, "ar0601_General");
            this.protraitImageList.Images.SetKeyName(31, "ar0603_General");
            this.protraitImageList.Images.SetKeyName(32, "ar0604_General");
            this.protraitImageList.Images.SetKeyName(33, "ar0701_General");
            this.protraitImageList.Images.SetKeyName(34, "ar0702_General");
            this.protraitImageList.Images.SetKeyName(35, "ar0703_General");
            this.protraitImageList.Images.SetKeyName(36, "ar0704_General");
            this.protraitImageList.Images.SetKeyName(37, "ar0705_General");
            this.protraitImageList.Images.SetKeyName(38, "ar0706_General");
            this.protraitImageList.Images.SetKeyName(39, "be0101_General");
            this.protraitImageList.Images.SetKeyName(40, "be0102_General");
            this.protraitImageList.Images.SetKeyName(41, "be0103_General");
            this.protraitImageList.Images.SetKeyName(42, "be0104_General");
            this.protraitImageList.Images.SetKeyName(43, "be0105_General");
            this.protraitImageList.Images.SetKeyName(44, "be0106_General");
            this.protraitImageList.Images.SetKeyName(45, "be0107_General");
            this.protraitImageList.Images.SetKeyName(46, "be0108_General");
            this.protraitImageList.Images.SetKeyName(47, "be0109_General");
            this.protraitImageList.Images.SetKeyName(48, "ci0101_1_General");
            this.protraitImageList.Images.SetKeyName(49, "ci0101_2_General");
            this.protraitImageList.Images.SetKeyName(50, "ci0101_3_General");
            this.protraitImageList.Images.SetKeyName(51, "ci0101_4_General");
            this.protraitImageList.Images.SetKeyName(52, "ci0101_5_General");
            this.protraitImageList.Images.SetKeyName(53, "ci0101_6_General");
            this.protraitImageList.Images.SetKeyName(54, "ci0115_1_General");
            this.protraitImageList.Images.SetKeyName(55, "ci0115_2_General");
            this.protraitImageList.Images.SetKeyName(56, "ci0115_3_General");
            this.protraitImageList.Images.SetKeyName(57, "ci0115_4_General");
            this.protraitImageList.Images.SetKeyName(58, "ci0115_5_General");
            this.protraitImageList.Images.SetKeyName(59, "ci0115_6_General");
            this.protraitImageList.Images.SetKeyName(60, "ev0101_General");
            this.protraitImageList.Images.SetKeyName(61, "ev0102_General");
            this.protraitImageList.Images.SetKeyName(62, "ev0103_General");
            this.protraitImageList.Images.SetKeyName(63, "ev0104_General");
            this.protraitImageList.Images.SetKeyName(64, "ev0105_General");
            this.protraitImageList.Images.SetKeyName(65, "ev0106_General");
            this.protraitImageList.Images.SetKeyName(66, "ev0107_General");
            this.protraitImageList.Images.SetKeyName(67, "ev0108_General");
            this.protraitImageList.Images.SetKeyName(68, "ev0109_General");
            this.protraitImageList.Images.SetKeyName(69, "ev0110_General");
            this.protraitImageList.Images.SetKeyName(70, "ev0112_General");
            this.protraitImageList.Images.SetKeyName(71, "ev0113_General");
            this.protraitImageList.Images.SetKeyName(72, "ev0114_General");
            this.protraitImageList.Images.SetKeyName(73, "ev0115_General");
            this.protraitImageList.Images.SetKeyName(74, "ev0116_General");
            this.protraitImageList.Images.SetKeyName(75, "ev0117_General");
            this.protraitImageList.Images.SetKeyName(76, "ev0118_General");
            this.protraitImageList.Images.SetKeyName(77, "ev0119_General");
            this.protraitImageList.Images.SetKeyName(78, "ev0120_General");
            this.protraitImageList.Images.SetKeyName(79, "ev0202_General");
            this.protraitImageList.Images.SetKeyName(80, "ev0203_General");
            this.protraitImageList.Images.SetKeyName(81, "ev0204_General");
            this.protraitImageList.Images.SetKeyName(82, "ev0205_General");
            this.protraitImageList.Images.SetKeyName(83, "ev0206_General");
            this.protraitImageList.Images.SetKeyName(84, "ev0301_General");
            this.protraitImageList.Images.SetKeyName(85, "ev0401_General");
            this.protraitImageList.Images.SetKeyName(86, "ev0402_General");
            this.protraitImageList.Images.SetKeyName(87, "ev0403_General");
            this.protraitImageList.Images.SetKeyName(88, "ev0501_General");
            this.protraitImageList.Images.SetKeyName(89, "ev0502_General");
            this.protraitImageList.Images.SetKeyName(90, "ev0503_General");
            this.protraitImageList.Images.SetKeyName(91, "ev0504_General");
            this.protraitImageList.Images.SetKeyName(92, "ev0507_General");
            this.protraitImageList.Images.SetKeyName(93, "ev0508_General");
            this.protraitImageList.Images.SetKeyName(94, "ev0508_Happy");
            this.protraitImageList.Images.SetKeyName(95, "ev0520_General");
            this.protraitImageList.Images.SetKeyName(96, "ev0526_General");
            this.protraitImageList.Images.SetKeyName(97, "ev0601_General");
            this.protraitImageList.Images.SetKeyName(98, "ev0603_General");
            this.protraitImageList.Images.SetKeyName(99, "ev0605_General");
            this.protraitImageList.Images.SetKeyName(100, "ev0606_General");
            this.protraitImageList.Images.SetKeyName(101, "ev0607_General");
            this.protraitImageList.Images.SetKeyName(102, "ev0608_General");
            this.protraitImageList.Images.SetKeyName(103, "ev0609_General");
            this.protraitImageList.Images.SetKeyName(104, "ev0610_General");
            this.protraitImageList.Images.SetKeyName(105, "ev0611_General");
            this.protraitImageList.Images.SetKeyName(106, "ev0612_General");
            this.protraitImageList.Images.SetKeyName(107, "ev0613_General");
            this.protraitImageList.Images.SetKeyName(108, "ev0614_General");
            this.protraitImageList.Images.SetKeyName(109, "ev0615_General");
            this.protraitImageList.Images.SetKeyName(110, "ev0616_General");
            this.protraitImageList.Images.SetKeyName(111, "ev0701_General");
            this.protraitImageList.Images.SetKeyName(112, "ev0702_General");
            this.protraitImageList.Images.SetKeyName(113, "ev0703_General");
            this.protraitImageList.Images.SetKeyName(114, "ev0704_General");
            this.protraitImageList.Images.SetKeyName(115, "ev0705_General");
            this.protraitImageList.Images.SetKeyName(116, "ev0706_General");
            this.protraitImageList.Images.SetKeyName(117, "ev0707_General");
            this.protraitImageList.Images.SetKeyName(118, "ev0708_General");
            this.protraitImageList.Images.SetKeyName(119, "ev0709_General");
            this.protraitImageList.Images.SetKeyName(120, "ev0710_General");
            this.protraitImageList.Images.SetKeyName(121, "ev0711_General");
            this.protraitImageList.Images.SetKeyName(122, "ev0712_General");
            this.protraitImageList.Images.SetKeyName(123, "ev0714_General");
            this.protraitImageList.Images.SetKeyName(124, "ev0715_General");
            this.protraitImageList.Images.SetKeyName(125, "ev0716_General");
            this.protraitImageList.Images.SetKeyName(126, "ev0717_General");
            this.protraitImageList.Images.SetKeyName(127, "ev0718_General");
            this.protraitImageList.Images.SetKeyName(128, "ev0719_General");
            this.protraitImageList.Images.SetKeyName(129, "ev0720_General");
            this.protraitImageList.Images.SetKeyName(130, "ev0721_General");
            this.protraitImageList.Images.SetKeyName(131, "ev0722_General");
            this.protraitImageList.Images.SetKeyName(132, "ev0722_Happy");
            this.protraitImageList.Images.SetKeyName(133, "ev0723_General");
            this.protraitImageList.Images.SetKeyName(134, "ev0724_General");
            this.protraitImageList.Images.SetKeyName(135, "ev0725_General");
            this.protraitImageList.Images.SetKeyName(136, "ev0726_General");
            this.protraitImageList.Images.SetKeyName(137, "ev0727_General");
            this.protraitImageList.Images.SetKeyName(138, "ev0728_General");
            this.protraitImageList.Images.SetKeyName(139, "in0000_General");
            this.protraitImageList.Images.SetKeyName(140, "in0001_General");
            this.protraitImageList.Images.SetKeyName(141, "in0101_1_General");
            this.protraitImageList.Images.SetKeyName(142, "in0101_2_General");
            this.protraitImageList.Images.SetKeyName(143, "in0101_3_General");
            this.protraitImageList.Images.SetKeyName(144, "in0101_4_General");
            this.protraitImageList.Images.SetKeyName(145, "in0101_5_General");
            this.protraitImageList.Images.SetKeyName(146, "in0101_6_General");
            this.protraitImageList.Images.SetKeyName(147, "in0102_General");
            this.protraitImageList.Images.SetKeyName(148, "in0102_Happy");
            this.protraitImageList.Images.SetKeyName(149, "in0102_Sad");
            this.protraitImageList.Images.SetKeyName(150, "in0102_Shy");
            this.protraitImageList.Images.SetKeyName(151, "in0102_Surprised");
            this.protraitImageList.Images.SetKeyName(152, "in0102_Unhappy");
            this.protraitImageList.Images.SetKeyName(153, "in0103_General");
            this.protraitImageList.Images.SetKeyName(154, "in0103_Happy");
            this.protraitImageList.Images.SetKeyName(155, "in0103_Sad");
            this.protraitImageList.Images.SetKeyName(156, "in0103_Shy");
            this.protraitImageList.Images.SetKeyName(157, "in0103_Surprised");
            this.protraitImageList.Images.SetKeyName(158, "in0103_Unhappy");
            this.protraitImageList.Images.SetKeyName(159, "in0104_General");
            this.protraitImageList.Images.SetKeyName(160, "in0104_Happy");
            this.protraitImageList.Images.SetKeyName(161, "in0104_Sad");
            this.protraitImageList.Images.SetKeyName(162, "in0104_Shy");
            this.protraitImageList.Images.SetKeyName(163, "in0104_Surprised");
            this.protraitImageList.Images.SetKeyName(164, "in0104_Unhappy");
            this.protraitImageList.Images.SetKeyName(165, "in0105_General");
            this.protraitImageList.Images.SetKeyName(166, "in0105_Happy");
            this.protraitImageList.Images.SetKeyName(167, "in0105_Sad");
            this.protraitImageList.Images.SetKeyName(168, "in0105_Shy");
            this.protraitImageList.Images.SetKeyName(169, "in0105_Surprised");
            this.protraitImageList.Images.SetKeyName(170, "in0105_Unhappy");
            this.protraitImageList.Images.SetKeyName(171, "in0106_General");
            this.protraitImageList.Images.SetKeyName(172, "in0106_Happy");
            this.protraitImageList.Images.SetKeyName(173, "in0106_Sad");
            this.protraitImageList.Images.SetKeyName(174, "in0106_Shy");
            this.protraitImageList.Images.SetKeyName(175, "in0106_Surprised");
            this.protraitImageList.Images.SetKeyName(176, "in0106_Unhappy");
            this.protraitImageList.Images.SetKeyName(177, "in0107_General");
            this.protraitImageList.Images.SetKeyName(178, "in0107_Happy");
            this.protraitImageList.Images.SetKeyName(179, "in0107_Sad");
            this.protraitImageList.Images.SetKeyName(180, "in0107_Shy");
            this.protraitImageList.Images.SetKeyName(181, "in0107_Surprised");
            this.protraitImageList.Images.SetKeyName(182, "in0107_Unhappy");
            this.protraitImageList.Images.SetKeyName(183, "in0109_General");
            this.protraitImageList.Images.SetKeyName(184, "in0109_Happy");
            this.protraitImageList.Images.SetKeyName(185, "in0109_Sad");
            this.protraitImageList.Images.SetKeyName(186, "in0109c_General");
            this.protraitImageList.Images.SetKeyName(187, "in0109c_Happy");
            this.protraitImageList.Images.SetKeyName(188, "in0109c_Sad");
            this.protraitImageList.Images.SetKeyName(189, "in0109c_Shy");
            this.protraitImageList.Images.SetKeyName(190, "in0109c_Surprised");
            this.protraitImageList.Images.SetKeyName(191, "in0109c_Unhappy");
            this.protraitImageList.Images.SetKeyName(192, "in0110_General");
            this.protraitImageList.Images.SetKeyName(193, "in0110_Happy");
            this.protraitImageList.Images.SetKeyName(194, "in0110_Sad");
            this.protraitImageList.Images.SetKeyName(195, "in0110_Shy");
            this.protraitImageList.Images.SetKeyName(196, "in0110_Surprised");
            this.protraitImageList.Images.SetKeyName(197, "in0110_Unhappy");
            this.protraitImageList.Images.SetKeyName(198, "in0111_General");
            this.protraitImageList.Images.SetKeyName(199, "in0111_Happy");
            this.protraitImageList.Images.SetKeyName(200, "in0111_Sad");
            this.protraitImageList.Images.SetKeyName(201, "in0111_Shy");
            this.protraitImageList.Images.SetKeyName(202, "in0111_Surprised");
            this.protraitImageList.Images.SetKeyName(203, "in0111_Unhappy");
            this.protraitImageList.Images.SetKeyName(204, "in0112_General");
            this.protraitImageList.Images.SetKeyName(205, "in0113_General");
            this.protraitImageList.Images.SetKeyName(206, "in0114_General");
            this.protraitImageList.Images.SetKeyName(207, "in0115_1_General");
            this.protraitImageList.Images.SetKeyName(208, "in0115_2_General");
            this.protraitImageList.Images.SetKeyName(209, "in0115_3_General");
            this.protraitImageList.Images.SetKeyName(210, "in0115_4_General");
            this.protraitImageList.Images.SetKeyName(211, "in0115_5_General");
            this.protraitImageList.Images.SetKeyName(212, "in0115_6_General");
            this.protraitImageList.Images.SetKeyName(213, "in0131_General");
            this.protraitImageList.Images.SetKeyName(214, "in0131_Unhappy");
            this.protraitImageList.Images.SetKeyName(215, "in0132_General");
            this.protraitImageList.Images.SetKeyName(216, "in0132_Unhappy");
            this.protraitImageList.Images.SetKeyName(217, "in0201_General");
            this.protraitImageList.Images.SetKeyName(218, "in0202_General");
            this.protraitImageList.Images.SetKeyName(219, "in0203_General");
            this.protraitImageList.Images.SetKeyName(220, "in0204_General");
            this.protraitImageList.Images.SetKeyName(221, "in0205_General");
            this.protraitImageList.Images.SetKeyName(222, "in0206_General");
            this.protraitImageList.Images.SetKeyName(223, "in0207_General");
            this.protraitImageList.Images.SetKeyName(224, "in0208_General");
            this.protraitImageList.Images.SetKeyName(225, "in0209_General");
            this.protraitImageList.Images.SetKeyName(226, "in0210_General");
            this.protraitImageList.Images.SetKeyName(227, "in0210_Happy");
            this.protraitImageList.Images.SetKeyName(228, "in0210_Sad");
            this.protraitImageList.Images.SetKeyName(229, "in0211_General");
            this.protraitImageList.Images.SetKeyName(230, "in0211_Happy");
            this.protraitImageList.Images.SetKeyName(231, "in0211_Sad");
            this.protraitImageList.Images.SetKeyName(232, "in0211_Shy");
            this.protraitImageList.Images.SetKeyName(233, "in0211_Surprised");
            this.protraitImageList.Images.SetKeyName(234, "in0211_Unhappy");
            this.protraitImageList.Images.SetKeyName(235, "in0301_General");
            this.protraitImageList.Images.SetKeyName(236, "in0302_General");
            this.protraitImageList.Images.SetKeyName(237, "in0303_General");
            this.protraitImageList.Images.SetKeyName(238, "in0304_General");
            this.protraitImageList.Images.SetKeyName(239, "in0305_General");
            this.protraitImageList.Images.SetKeyName(240, "in0306_General");
            this.protraitImageList.Images.SetKeyName(241, "in0307_General");
            this.protraitImageList.Images.SetKeyName(242, "in0308_General");
            this.protraitImageList.Images.SetKeyName(243, "in0309_General");
            this.protraitImageList.Images.SetKeyName(244, "in0310_General");
            this.protraitImageList.Images.SetKeyName(245, "in0311_General");
            this.protraitImageList.Images.SetKeyName(246, "in0312_General");
            this.protraitImageList.Images.SetKeyName(247, "in0702_General");
            this.protraitImageList.Images.SetKeyName(248, "in0703_General");
            this.protraitImageList.Images.SetKeyName(249, "in01041_General");
            this.protraitImageList.Images.SetKeyName(250, "in01041_Happy");
            this.protraitImageList.Images.SetKeyName(251, "in01041_Sad");
            this.protraitImageList.Images.SetKeyName(252, "in01041_Shy");
            this.protraitImageList.Images.SetKeyName(253, "in01041_Surprised");
            this.protraitImageList.Images.SetKeyName(254, "in01041_Unhappy");
            this.protraitImageList.Images.SetKeyName(255, "in03001_General");
            this.protraitImageList.Images.SetKeyName(256, "in03002_General");
            this.protraitImageList.Images.SetKeyName(257, "in03003_General");
            this.protraitImageList.Images.SetKeyName(258, "in03004_General");
            this.protraitImageList.Images.SetKeyName(259, "in03005_General");
            this.protraitImageList.Images.SetKeyName(260, "in03006_General");
            this.protraitImageList.Images.SetKeyName(261, "in03007_General");
            this.protraitImageList.Images.SetKeyName(262, "in03008_General");
            this.protraitImageList.Images.SetKeyName(263, "in03009_General");
            this.protraitImageList.Images.SetKeyName(264, "in03010_General");
            this.protraitImageList.Images.SetKeyName(265, "in03011_General");
            this.protraitImageList.Images.SetKeyName(266, "in03012_General");
            this.protraitImageList.Images.SetKeyName(267, "in03013_General");
            this.protraitImageList.Images.SetKeyName(268, "in03015_General");
            this.protraitImageList.Images.SetKeyName(269, "in03016_General");
            this.protraitImageList.Images.SetKeyName(270, "in05510_General");
            this.protraitImageList.Images.SetKeyName(271, "in05511_General");
            this.protraitImageList.Images.SetKeyName(272, "in05511_Sad");
            this.protraitImageList.Images.SetKeyName(273, "in29001_General");
            this.protraitImageList.Images.SetKeyName(274, "in29001_Happy");
            this.protraitImageList.Images.SetKeyName(275, "nd0101_1_General");
            this.protraitImageList.Images.SetKeyName(276, "nd0101_2_General");
            this.protraitImageList.Images.SetKeyName(277, "nd0101_3_General");
            this.protraitImageList.Images.SetKeyName(278, "nd0101_4_General");
            this.protraitImageList.Images.SetKeyName(279, "nd0101_5_General");
            this.protraitImageList.Images.SetKeyName(280, "nd0101_6_General");
            this.protraitImageList.Images.SetKeyName(281, "nd0115_1_General");
            this.protraitImageList.Images.SetKeyName(282, "nd0115_2_General");
            this.protraitImageList.Images.SetKeyName(283, "nd0115_3_General");
            this.protraitImageList.Images.SetKeyName(284, "nd0115_4_General");
            this.protraitImageList.Images.SetKeyName(285, "nd0115_5_General");
            this.protraitImageList.Images.SetKeyName(286, "nd0115_6_General");
            // 
            // protraitComboBox
            // 
            this.protraitComboBox.FormattingEnabled = true;
            this.protraitComboBox.Location = new System.Drawing.Point(94, 61);
            this.protraitComboBox.Name = "protraitComboBox";
            this.protraitComboBox.Size = new System.Drawing.Size(121, 20);
            this.protraitComboBox.TabIndex = 87;
            this.protraitComboBox.SelectedIndexChanged += new System.EventHandler(this.protraitComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.protraitPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(10, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 222);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // protraitPictureBox
            // 
            this.protraitPictureBox.Location = new System.Drawing.Point(6, 20);
            this.protraitPictureBox.Name = "protraitPictureBox";
            this.protraitPictureBox.Size = new System.Drawing.Size(313, 196);
            this.protraitPictureBox.TabIndex = 1;
            this.protraitPictureBox.TabStop = false;
            // 
            // ChangeCharacterProtraitAndModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.protraitComboBox);
            this.Controls.Add(this.isChangeModelCheckBox);
            this.Controls.Add(this.selectExteriorButton);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isChangeProtraitCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ChangeCharacterProtraitAndModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变更立绘与模型";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.protraitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isChangeProtraitCheckBox;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectExteriorButton;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isChangeModelCheckBox;
        private System.Windows.Forms.ImageList protraitImageList;
        private System.Windows.Forms.ComboBox protraitComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox protraitPictureBox;
    }
}