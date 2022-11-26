
namespace 侠之道mod制作器
{
    partial class NurturanceTabControlUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NurturanceTabControlUserControl));
            this.NurturanceTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NurturanceListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NurturanceContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NurturanceImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newNurturanceButton = new System.Windows.Forms.Button();
            this.editNurturanceButton = new System.Windows.Forms.Button();
            this.showOriginalNurturanceCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteNurturanceButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.NurturanceTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.NurturanceContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // NurturanceTabPage
            // 
            this.NurturanceTabPage.Controls.Add(this.panel2);
            this.NurturanceTabPage.Controls.Add(this.panel1);
            this.NurturanceTabPage.Location = new System.Drawing.Point(4, 22);
            this.NurturanceTabPage.Name = "NurturanceTabPage";
            this.NurturanceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NurturanceTabPage.Size = new System.Drawing.Size(838, 518);
            this.NurturanceTabPage.TabIndex = 3;
            this.NurturanceTabPage.Text = "Nurturance     ";
            this.NurturanceTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NurturanceListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // NurturanceListView
            // 
            this.NurturanceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.NurturanceListView.ContextMenuStrip = this.NurturanceContextMenuStrip;
            this.NurturanceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NurturanceListView.FullRowSelect = true;
            this.NurturanceListView.HideSelection = false;
            this.NurturanceListView.Location = new System.Drawing.Point(0, 0);
            this.NurturanceListView.MultiSelect = false;
            this.NurturanceListView.Name = "NurturanceListView";
            this.NurturanceListView.ShowItemToolTips = true;
            this.NurturanceListView.Size = new System.Drawing.Size(832, 483);
            this.NurturanceListView.SmallImageList = this.NurturanceImageList;
            this.NurturanceListView.TabIndex = 12;
            this.NurturanceListView.UseCompatibleStateImageBehavior = false;
            this.NurturanceListView.View = System.Windows.Forms.View.Details;
            this.NurturanceListView.SelectedIndexChanged += new System.EventHandler(this.NurturanceListView_SelectedIndexChanged);
            this.NurturanceListView.DoubleClick += new System.EventHandler(this.NurturanceListView_DoubleClick);
            this.NurturanceListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NurturanceListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图片";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "指令名称";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "指令功能";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "开启的界面";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "增加的疲惫值";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "显示条件";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "开放条件";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "加成条件";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "加成数值";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "加成Tip";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "背景编号";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "movie编号（基础编号）";
            this.columnHeader15.Width = 150;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "未开放的Tip";
            this.columnHeader16.Width = 150;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "其他提升的Tip";
            this.columnHeader17.Width = 150;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "设施功能Tip";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "奖励";
            this.columnHeader19.Width = 150;
            // 
            // NurturanceContextMenuStrip
            // 
            this.NurturanceContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.NurturanceContextMenuStrip.Name = "NurturanceContextMenuStrip";
            this.NurturanceContextMenuStrip.Size = new System.Drawing.Size(149, 48);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileToolStripMenuItem.Text = "打开文件";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFilePathToolStripMenuItem
            // 
            this.openFilePathToolStripMenuItem.Name = "openFilePathToolStripMenuItem";
            this.openFilePathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFilePathToolStripMenuItem.Text = "打开文件位置";
            this.openFilePathToolStripMenuItem.Click += new System.EventHandler(this.OpenFilePathToolStripMenuItem_Click);
            // 
            // NurturanceImageList
            // 
            this.NurturanceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NurturanceImageList.ImageStream")));
            this.NurturanceImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.NurturanceImageList.Images.SetKeyName(0, "60211");
            this.NurturanceImageList.Images.SetKeyName(1, "60212");
            this.NurturanceImageList.Images.SetKeyName(2, "60213");
            this.NurturanceImageList.Images.SetKeyName(3, "60221");
            this.NurturanceImageList.Images.SetKeyName(4, "60222");
            this.NurturanceImageList.Images.SetKeyName(5, "60223");
            this.NurturanceImageList.Images.SetKeyName(6, "60231");
            this.NurturanceImageList.Images.SetKeyName(7, "60232");
            this.NurturanceImageList.Images.SetKeyName(8, "60233");
            this.NurturanceImageList.Images.SetKeyName(9, "60241");
            this.NurturanceImageList.Images.SetKeyName(10, "60242");
            this.NurturanceImageList.Images.SetKeyName(11, "60243");
            this.NurturanceImageList.Images.SetKeyName(12, "60300");
            this.NurturanceImageList.Images.SetKeyName(13, "60301");
            this.NurturanceImageList.Images.SetKeyName(14, "60302");
            this.NurturanceImageList.Images.SetKeyName(15, "60303");
            this.NurturanceImageList.Images.SetKeyName(16, "60304");
            this.NurturanceImageList.Images.SetKeyName(17, "60305");
            this.NurturanceImageList.Images.SetKeyName(18, "60306");
            this.NurturanceImageList.Images.SetKeyName(19, "60307");
            this.NurturanceImageList.Images.SetKeyName(20, "60313");
            this.NurturanceImageList.Images.SetKeyName(21, "60411");
            this.NurturanceImageList.Images.SetKeyName(22, "60412");
            this.NurturanceImageList.Images.SetKeyName(23, "60413");
            this.NurturanceImageList.Images.SetKeyName(24, "60421");
            this.NurturanceImageList.Images.SetKeyName(25, "60422");
            this.NurturanceImageList.Images.SetKeyName(26, "60423");
            this.NurturanceImageList.Images.SetKeyName(27, "60431");
            this.NurturanceImageList.Images.SetKeyName(28, "60432");
            this.NurturanceImageList.Images.SetKeyName(29, "60433");
            this.NurturanceImageList.Images.SetKeyName(30, "60441");
            this.NurturanceImageList.Images.SetKeyName(31, "60442");
            this.NurturanceImageList.Images.SetKeyName(32, "60443");
            this.NurturanceImageList.Images.SetKeyName(33, "60451");
            this.NurturanceImageList.Images.SetKeyName(34, "60452");
            this.NurturanceImageList.Images.SetKeyName(35, "60453");
            this.NurturanceImageList.Images.SetKeyName(36, "60461");
            this.NurturanceImageList.Images.SetKeyName(37, "60462");
            this.NurturanceImageList.Images.SetKeyName(38, "60463");
            this.NurturanceImageList.Images.SetKeyName(39, "60464");
            this.NurturanceImageList.Images.SetKeyName(40, "60465");
            this.NurturanceImageList.Images.SetKeyName(41, "60466");
            this.NurturanceImageList.Images.SetKeyName(42, "60467");
            this.NurturanceImageList.Images.SetKeyName(43, "60601");
            this.NurturanceImageList.Images.SetKeyName(44, "60602");
            this.NurturanceImageList.Images.SetKeyName(45, "60603");
            this.NurturanceImageList.Images.SetKeyName(46, "60604");
            this.NurturanceImageList.Images.SetKeyName(47, "60615");
            this.NurturanceImageList.Images.SetKeyName(48, "60624");
            this.NurturanceImageList.Images.SetKeyName(49, "60625");
            this.NurturanceImageList.Images.SetKeyName(50, "60626");
            this.NurturanceImageList.Images.SetKeyName(51, "60627");
            this.NurturanceImageList.Images.SetKeyName(52, "60628");
            this.NurturanceImageList.Images.SetKeyName(53, "60629");
            this.NurturanceImageList.Images.SetKeyName(54, "60701");
            this.NurturanceImageList.Images.SetKeyName(55, "60702");
            this.NurturanceImageList.Images.SetKeyName(56, "60703");
            this.NurturanceImageList.Images.SetKeyName(57, "60704");
            this.NurturanceImageList.Images.SetKeyName(58, "60705");
            this.NurturanceImageList.Images.SetKeyName(59, "60706");
            this.NurturanceImageList.Images.SetKeyName(60, "60707");
            this.NurturanceImageList.Images.SetKeyName(61, "60911");
            this.NurturanceImageList.Images.SetKeyName(62, "60912");
            this.NurturanceImageList.Images.SetKeyName(63, "60913");
            this.NurturanceImageList.Images.SetKeyName(64, "Nurturance_601");
            this.NurturanceImageList.Images.SetKeyName(65, "Nurturance_602");
            this.NurturanceImageList.Images.SetKeyName(66, "Nurturance_603");
            this.NurturanceImageList.Images.SetKeyName(67, "Nurturance_604");
            this.NurturanceImageList.Images.SetKeyName(68, "Nurturance_605");
            this.NurturanceImageList.Images.SetKeyName(69, "Nurturance_606");
            this.NurturanceImageList.Images.SetKeyName(70, "Nurturance_607");
            this.NurturanceImageList.Images.SetKeyName(71, "Nurturance_608");
            this.NurturanceImageList.Images.SetKeyName(72, "Nurturance_609");
            this.NurturanceImageList.Images.SetKeyName(73, "ar0101");
            this.NurturanceImageList.Images.SetKeyName(74, "ar0201");
            this.NurturanceImageList.Images.SetKeyName(75, "ar0305");
            this.NurturanceImageList.Images.SetKeyName(76, "ar0313");
            this.NurturanceImageList.Images.SetKeyName(77, "ar0320");
            this.NurturanceImageList.Images.SetKeyName(78, "ar0323");
            this.NurturanceImageList.Images.SetKeyName(79, "ar0325");
            this.NurturanceImageList.Images.SetKeyName(80, "ar0328");
            this.NurturanceImageList.Images.SetKeyName(81, "ar0330");
            this.NurturanceImageList.Images.SetKeyName(82, "ar0332");
            this.NurturanceImageList.Images.SetKeyName(83, "ar0334");
            this.NurturanceImageList.Images.SetKeyName(84, "ar0335");
            this.NurturanceImageList.Images.SetKeyName(85, "ar0339");
            this.NurturanceImageList.Images.SetKeyName(86, "ar0340");
            this.NurturanceImageList.Images.SetKeyName(87, "ar0343");
            this.NurturanceImageList.Images.SetKeyName(88, "ar0345");
            this.NurturanceImageList.Images.SetKeyName(89, "ar0348");
            this.NurturanceImageList.Images.SetKeyName(90, "ar0352");
            this.NurturanceImageList.Images.SetKeyName(91, "ar0401");
            this.NurturanceImageList.Images.SetKeyName(92, "ar0402");
            this.NurturanceImageList.Images.SetKeyName(93, "ar0403");
            this.NurturanceImageList.Images.SetKeyName(94, "ar0501");
            this.NurturanceImageList.Images.SetKeyName(95, "ar0502");
            this.NurturanceImageList.Images.SetKeyName(96, "ar0503");
            this.NurturanceImageList.Images.SetKeyName(97, "ar0601");
            this.NurturanceImageList.Images.SetKeyName(98, "ar0603");
            this.NurturanceImageList.Images.SetKeyName(99, "ar0604");
            this.NurturanceImageList.Images.SetKeyName(100, "ar0701");
            this.NurturanceImageList.Images.SetKeyName(101, "ar0702");
            this.NurturanceImageList.Images.SetKeyName(102, "ar0703");
            this.NurturanceImageList.Images.SetKeyName(103, "ar0704");
            this.NurturanceImageList.Images.SetKeyName(104, "ar0705");
            this.NurturanceImageList.Images.SetKeyName(105, "ar0706");
            this.NurturanceImageList.Images.SetKeyName(106, "be0101");
            this.NurturanceImageList.Images.SetKeyName(107, "be0102");
            this.NurturanceImageList.Images.SetKeyName(108, "be0103");
            this.NurturanceImageList.Images.SetKeyName(109, "be0104");
            this.NurturanceImageList.Images.SetKeyName(110, "be0105");
            this.NurturanceImageList.Images.SetKeyName(111, "be0106");
            this.NurturanceImageList.Images.SetKeyName(112, "be0107");
            this.NurturanceImageList.Images.SetKeyName(113, "be0108");
            this.NurturanceImageList.Images.SetKeyName(114, "be0109");
            this.NurturanceImageList.Images.SetKeyName(115, "ci0101_1");
            this.NurturanceImageList.Images.SetKeyName(116, "ci0101_2");
            this.NurturanceImageList.Images.SetKeyName(117, "ci0101_3");
            this.NurturanceImageList.Images.SetKeyName(118, "ci0101_4");
            this.NurturanceImageList.Images.SetKeyName(119, "ci0101_5");
            this.NurturanceImageList.Images.SetKeyName(120, "ci0101_6");
            this.NurturanceImageList.Images.SetKeyName(121, "ci0115_1");
            this.NurturanceImageList.Images.SetKeyName(122, "ci0115_2");
            this.NurturanceImageList.Images.SetKeyName(123, "ci0115_3");
            this.NurturanceImageList.Images.SetKeyName(124, "ci0115_4");
            this.NurturanceImageList.Images.SetKeyName(125, "ci0115_5");
            this.NurturanceImageList.Images.SetKeyName(126, "ci0115_6");
            this.NurturanceImageList.Images.SetKeyName(127, "ev0101");
            this.NurturanceImageList.Images.SetKeyName(128, "ev0102");
            this.NurturanceImageList.Images.SetKeyName(129, "ev0103");
            this.NurturanceImageList.Images.SetKeyName(130, "ev0104");
            this.NurturanceImageList.Images.SetKeyName(131, "ev0105");
            this.NurturanceImageList.Images.SetKeyName(132, "ev0106");
            this.NurturanceImageList.Images.SetKeyName(133, "ev0107");
            this.NurturanceImageList.Images.SetKeyName(134, "ev0108");
            this.NurturanceImageList.Images.SetKeyName(135, "ev0109");
            this.NurturanceImageList.Images.SetKeyName(136, "ev0110");
            this.NurturanceImageList.Images.SetKeyName(137, "ev0112");
            this.NurturanceImageList.Images.SetKeyName(138, "ev0113");
            this.NurturanceImageList.Images.SetKeyName(139, "ev0114");
            this.NurturanceImageList.Images.SetKeyName(140, "ev0115");
            this.NurturanceImageList.Images.SetKeyName(141, "ev0116");
            this.NurturanceImageList.Images.SetKeyName(142, "ev0117");
            this.NurturanceImageList.Images.SetKeyName(143, "ev0118");
            this.NurturanceImageList.Images.SetKeyName(144, "ev0119");
            this.NurturanceImageList.Images.SetKeyName(145, "ev0120");
            this.NurturanceImageList.Images.SetKeyName(146, "ev0202");
            this.NurturanceImageList.Images.SetKeyName(147, "ev0203");
            this.NurturanceImageList.Images.SetKeyName(148, "ev0204");
            this.NurturanceImageList.Images.SetKeyName(149, "ev0205");
            this.NurturanceImageList.Images.SetKeyName(150, "ev0206");
            this.NurturanceImageList.Images.SetKeyName(151, "ev0301");
            this.NurturanceImageList.Images.SetKeyName(152, "ev0401");
            this.NurturanceImageList.Images.SetKeyName(153, "ev0402");
            this.NurturanceImageList.Images.SetKeyName(154, "ev0403");
            this.NurturanceImageList.Images.SetKeyName(155, "ev0501");
            this.NurturanceImageList.Images.SetKeyName(157, "ev0502");
            this.NurturanceImageList.Images.SetKeyName(158, "ev0503");
            this.NurturanceImageList.Images.SetKeyName(159, "ev0504");
            this.NurturanceImageList.Images.SetKeyName(160, "ev0507");
            this.NurturanceImageList.Images.SetKeyName(161, "ev0508");
            this.NurturanceImageList.Images.SetKeyName(163, "ev0520");
            this.NurturanceImageList.Images.SetKeyName(164, "ev0526");
            this.NurturanceImageList.Images.SetKeyName(165, "ev0601");
            this.NurturanceImageList.Images.SetKeyName(166, "ev0603");
            this.NurturanceImageList.Images.SetKeyName(167, "ev0605");
            this.NurturanceImageList.Images.SetKeyName(168, "ev0606");
            this.NurturanceImageList.Images.SetKeyName(169, "ev0607");
            this.NurturanceImageList.Images.SetKeyName(170, "ev0608");
            this.NurturanceImageList.Images.SetKeyName(171, "ev0609");
            this.NurturanceImageList.Images.SetKeyName(172, "ev0610");
            this.NurturanceImageList.Images.SetKeyName(173, "ev0611");
            this.NurturanceImageList.Images.SetKeyName(174, "ev0612");
            this.NurturanceImageList.Images.SetKeyName(175, "ev0613");
            this.NurturanceImageList.Images.SetKeyName(176, "ev0614");
            this.NurturanceImageList.Images.SetKeyName(177, "ev0615");
            this.NurturanceImageList.Images.SetKeyName(178, "ev0616");
            this.NurturanceImageList.Images.SetKeyName(179, "ev0701");
            this.NurturanceImageList.Images.SetKeyName(180, "ev0702");
            this.NurturanceImageList.Images.SetKeyName(181, "ev0703");
            this.NurturanceImageList.Images.SetKeyName(182, "ev0704");
            this.NurturanceImageList.Images.SetKeyName(183, "ev0705");
            this.NurturanceImageList.Images.SetKeyName(184, "ev0706");
            this.NurturanceImageList.Images.SetKeyName(185, "ev0707");
            this.NurturanceImageList.Images.SetKeyName(186, "ev0708");
            this.NurturanceImageList.Images.SetKeyName(187, "ev0709");
            this.NurturanceImageList.Images.SetKeyName(188, "ev0710");
            this.NurturanceImageList.Images.SetKeyName(189, "ev0711");
            this.NurturanceImageList.Images.SetKeyName(190, "ev0712");
            this.NurturanceImageList.Images.SetKeyName(191, "ev0714");
            this.NurturanceImageList.Images.SetKeyName(192, "ev0715");
            this.NurturanceImageList.Images.SetKeyName(193, "ev0716");
            this.NurturanceImageList.Images.SetKeyName(194, "ev0717");
            this.NurturanceImageList.Images.SetKeyName(195, "ev0718");
            this.NurturanceImageList.Images.SetKeyName(196, "ev0719");
            this.NurturanceImageList.Images.SetKeyName(197, "ev0720");
            this.NurturanceImageList.Images.SetKeyName(198, "ev0721");
            this.NurturanceImageList.Images.SetKeyName(199, "ev0722");
            this.NurturanceImageList.Images.SetKeyName(200, "ev0723");
            this.NurturanceImageList.Images.SetKeyName(201, "ev0724");
            this.NurturanceImageList.Images.SetKeyName(202, "ev0725");
            this.NurturanceImageList.Images.SetKeyName(203, "ev0726");
            this.NurturanceImageList.Images.SetKeyName(204, "ev0727");
            this.NurturanceImageList.Images.SetKeyName(205, "ev0728");
            this.NurturanceImageList.Images.SetKeyName(206, "in0000");
            this.NurturanceImageList.Images.SetKeyName(207, "in0001");
            this.NurturanceImageList.Images.SetKeyName(208, "in0101_1");
            this.NurturanceImageList.Images.SetKeyName(209, "in0101_2");
            this.NurturanceImageList.Images.SetKeyName(210, "in0101_3");
            this.NurturanceImageList.Images.SetKeyName(211, "in0101_4");
            this.NurturanceImageList.Images.SetKeyName(212, "in0101_5");
            this.NurturanceImageList.Images.SetKeyName(213, "in0101_6");
            this.NurturanceImageList.Images.SetKeyName(214, "in0102");
            this.NurturanceImageList.Images.SetKeyName(215, "in0103");
            this.NurturanceImageList.Images.SetKeyName(216, "in0104");
            this.NurturanceImageList.Images.SetKeyName(217, "in0105");
            this.NurturanceImageList.Images.SetKeyName(218, "in0106");
            this.NurturanceImageList.Images.SetKeyName(219, "in0107");
            this.NurturanceImageList.Images.SetKeyName(220, "in0109");
            this.NurturanceImageList.Images.SetKeyName(221, "in0109c");
            this.NurturanceImageList.Images.SetKeyName(222, "in0110");
            this.NurturanceImageList.Images.SetKeyName(223, "in0111");
            this.NurturanceImageList.Images.SetKeyName(224, "in0112");
            this.NurturanceImageList.Images.SetKeyName(225, "in0113");
            this.NurturanceImageList.Images.SetKeyName(226, "in0114");
            this.NurturanceImageList.Images.SetKeyName(227, "in0115_1");
            this.NurturanceImageList.Images.SetKeyName(228, "in0115_2");
            this.NurturanceImageList.Images.SetKeyName(229, "in0115_3");
            this.NurturanceImageList.Images.SetKeyName(230, "in0115_4");
            this.NurturanceImageList.Images.SetKeyName(231, "in0115_5");
            this.NurturanceImageList.Images.SetKeyName(232, "in0115_6");
            this.NurturanceImageList.Images.SetKeyName(233, "in0131");
            this.NurturanceImageList.Images.SetKeyName(234, "in0132");
            this.NurturanceImageList.Images.SetKeyName(235, "in0201");
            this.NurturanceImageList.Images.SetKeyName(236, "in0202");
            this.NurturanceImageList.Images.SetKeyName(237, "in0203");
            this.NurturanceImageList.Images.SetKeyName(238, "in0204");
            this.NurturanceImageList.Images.SetKeyName(239, "in0205");
            this.NurturanceImageList.Images.SetKeyName(240, "in0206");
            this.NurturanceImageList.Images.SetKeyName(241, "in0207");
            this.NurturanceImageList.Images.SetKeyName(242, "in0208");
            this.NurturanceImageList.Images.SetKeyName(243, "in0209");
            this.NurturanceImageList.Images.SetKeyName(244, "in0210");
            this.NurturanceImageList.Images.SetKeyName(245, "in0211");
            this.NurturanceImageList.Images.SetKeyName(246, "in0301");
            this.NurturanceImageList.Images.SetKeyName(247, "in0302");
            this.NurturanceImageList.Images.SetKeyName(248, "in0303");
            this.NurturanceImageList.Images.SetKeyName(249, "in0304");
            this.NurturanceImageList.Images.SetKeyName(250, "in0305");
            this.NurturanceImageList.Images.SetKeyName(251, "in0306");
            this.NurturanceImageList.Images.SetKeyName(252, "in0307");
            this.NurturanceImageList.Images.SetKeyName(253, "in0308");
            this.NurturanceImageList.Images.SetKeyName(254, "in0309");
            this.NurturanceImageList.Images.SetKeyName(255, "in0310");
            this.NurturanceImageList.Images.SetKeyName(256, "in0311");
            this.NurturanceImageList.Images.SetKeyName(257, "in0312");
            this.NurturanceImageList.Images.SetKeyName(258, "in0702");
            this.NurturanceImageList.Images.SetKeyName(259, "in0703");
            this.NurturanceImageList.Images.SetKeyName(260, "in01041");
            this.NurturanceImageList.Images.SetKeyName(261, "in03001");
            this.NurturanceImageList.Images.SetKeyName(262, "in03002");
            this.NurturanceImageList.Images.SetKeyName(263, "in03003");
            this.NurturanceImageList.Images.SetKeyName(264, "in03004");
            this.NurturanceImageList.Images.SetKeyName(265, "in03005");
            this.NurturanceImageList.Images.SetKeyName(266, "in03006");
            this.NurturanceImageList.Images.SetKeyName(267, "in03007");
            this.NurturanceImageList.Images.SetKeyName(268, "in03008");
            this.NurturanceImageList.Images.SetKeyName(269, "in03009");
            this.NurturanceImageList.Images.SetKeyName(270, "in03010");
            this.NurturanceImageList.Images.SetKeyName(271, "in03011");
            this.NurturanceImageList.Images.SetKeyName(272, "in03012");
            this.NurturanceImageList.Images.SetKeyName(273, "in03013");
            this.NurturanceImageList.Images.SetKeyName(274, "in03015");
            this.NurturanceImageList.Images.SetKeyName(275, "in03016");
            this.NurturanceImageList.Images.SetKeyName(276, "in05510");
            this.NurturanceImageList.Images.SetKeyName(277, "in05511");
            this.NurturanceImageList.Images.SetKeyName(278, "in29001");
            this.NurturanceImageList.Images.SetKeyName(279, "nd0101_1");
            this.NurturanceImageList.Images.SetKeyName(280, "nd0101_2");
            this.NurturanceImageList.Images.SetKeyName(281, "nd0101_3");
            this.NurturanceImageList.Images.SetKeyName(282, "nd0101_4");
            this.NurturanceImageList.Images.SetKeyName(283, "nd0101_5");
            this.NurturanceImageList.Images.SetKeyName(284, "nd0101_6");
            this.NurturanceImageList.Images.SetKeyName(285, "nd0115_1");
            this.NurturanceImageList.Images.SetKeyName(286, "nd0115_2");
            this.NurturanceImageList.Images.SetKeyName(287, "nd0115_3");
            this.NurturanceImageList.Images.SetKeyName(288, "nd0115_4");
            this.NurturanceImageList.Images.SetKeyName(289, "nd0115_5");
            this.NurturanceImageList.Images.SetKeyName(290, "nd0115_6");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 29);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.refreshButton);
            this.panel4.Controls.Add(this.newNurturanceButton);
            this.panel4.Controls.Add(this.editNurturanceButton);
            this.panel4.Controls.Add(this.showOriginalNurturanceCheckBox);
            this.panel4.Controls.Add(this.deleteNurturanceButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(442, 29);
            this.panel4.TabIndex = 7;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(246, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "刷新";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // newNurturanceButton
            // 
            this.newNurturanceButton.Location = new System.Drawing.Point(3, 3);
            this.newNurturanceButton.Name = "newNurturanceButton";
            this.newNurturanceButton.Size = new System.Drawing.Size(75, 23);
            this.newNurturanceButton.TabIndex = 0;
            this.newNurturanceButton.Text = "新增";
            this.newNurturanceButton.UseVisualStyleBackColor = true;
            this.newNurturanceButton.Click += new System.EventHandler(this.newNurturanceButton_Click);
            // 
            // editNurturanceButton
            // 
            this.editNurturanceButton.Location = new System.Drawing.Point(84, 3);
            this.editNurturanceButton.Name = "editNurturanceButton";
            this.editNurturanceButton.Size = new System.Drawing.Size(75, 23);
            this.editNurturanceButton.TabIndex = 1;
            this.editNurturanceButton.Text = "修改";
            this.editNurturanceButton.UseVisualStyleBackColor = true;
            this.editNurturanceButton.Click += new System.EventHandler(this.editNurturanceButton_Click);
            // 
            // showOriginalNurturanceCheckBox
            // 
            this.showOriginalNurturanceCheckBox.AutoSize = true;
            this.showOriginalNurturanceCheckBox.Checked = true;
            this.showOriginalNurturanceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalNurturanceCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalNurturanceCheckBox.Name = "showOriginalNurturanceCheckBox";
            this.showOriginalNurturanceCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalNurturanceCheckBox.TabIndex = 3;
            this.showOriginalNurturanceCheckBox.Text = "显示原游戏数据";
            this.showOriginalNurturanceCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalNurturanceCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalNurturanceCheckBox_CheckedChanged);
            // 
            // deleteNurturanceButton
            // 
            this.deleteNurturanceButton.Location = new System.Drawing.Point(165, 3);
            this.deleteNurturanceButton.Name = "deleteNurturanceButton";
            this.deleteNurturanceButton.Size = new System.Drawing.Size(75, 23);
            this.deleteNurturanceButton.TabIndex = 2;
            this.deleteNurturanceButton.Text = "删除";
            this.deleteNurturanceButton.UseVisualStyleBackColor = true;
            this.deleteNurturanceButton.Click += new System.EventHandler(this.deleteNurturanceButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.searchTextBox);
            this.panel3.Controls.Add(this.searchButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(542, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 29);
            this.panel3.TabIndex = 6;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(203, 21);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(212, 1);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // CustomTabControl
            // 
            this.CustomTabControl.Controls.Add(this.NurturanceTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // NurturanceTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "NurturanceTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.NurturanceTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.NurturanceContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage NurturanceTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newNurturanceButton;
        private System.Windows.Forms.Button editNurturanceButton;
        private System.Windows.Forms.CheckBox showOriginalNurturanceCheckBox;
        private System.Windows.Forms.Button deleteNurturanceButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip NurturanceContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView NurturanceListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ImageList NurturanceImageList;
    }
}
