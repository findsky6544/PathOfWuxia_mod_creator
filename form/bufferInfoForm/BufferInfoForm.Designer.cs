
namespace 侠之道mod制作器
{
    partial class BufferInfoForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "执行到成功",
            "BufferPriorityNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "执行到失败",
            "BufferSequenceNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "增益者是否为攻击者",
            "BufferAttackCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "增益者是否为防御者",
            "BufferDefenderCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "双方属性比较(HP&MP是绝对值)",
            "BufferBothPropertyCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身养成属性",
            "BufferNurturancePropertyCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身战斗属性",
            "BufferPropertyCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身气血",
            "BufferSelfHPCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身气血(值)",
            "BufferSelfHPValueCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断敌方属性",
            "BufferEnemyPropertyCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身持有特定BUFF",
            "IsHasBufferCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "攻击者是否存在指定buff",
            "AttackerHasBufferCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "防御者是否存在指定buff",
            "DefendeHasBufferCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者阵营",
            "AttackerFactionCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者阵营",
            "DefenderFactionCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者是否同阵营",
            "AttackerIsSameFactionCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者是否同阵营",
            "DefenderIsSameFactionCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者正面状态",
            "AttackerPositiveStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者负面状态",
            "AttackerNegativeStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者正面状态",
            "DefenderPositiveStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者负面状态",
            "DefenderNegativeStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身正面状态",
            "SelfPositiveStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断自身负面状态",
            "SelfNegativeStateCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者是否剋防御者",
            "IsAttackerSuperiorityDefenderCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者是否剋攻击者",
            "IsDefenderSuperiorityAttackrCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断移动",
            "BufferMoveCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem(new string[] {
            "攻击面向判断",
            "DamageDirectionCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者是否闪避",
            "DefenderIsDodgeCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem29 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断是否致死",
            "IsLethalCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem30 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断是否已经行动",
            "IsEndUnitCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem31 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断持有者状态",
            "SelfBufferOrientedCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem32 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断机率",
            "ProbabilityCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem33 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者ID",
            "AttackerIDCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem34 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者ID",
            "DefenderIDCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem35 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断攻击者武器类型",
            "BufferAttackerWeaponTypeCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem36 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断防御者武器类型",
            "BufferDefenderWeaponTypeCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem37 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断武学武器类型",
            "BufferSkillTypeCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem38 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予战斗属性",
            "BufferPropertyAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem39 = new System.Windows.Forms.ListViewItem(new string[] {
            "攻击距离提升属性",
            "BufferDistancePromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem40 = new System.Windows.Forms.ListViewItem(new string[] {
            "移动距离提升属性",
            "BufferMovePromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem41 = new System.Windows.Forms.ListViewItem(new string[] {
            "正面状态重数提升属性",
            "BufferPositiveStatePromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem42 = new System.Windows.Forms.ListViewItem(new string[] {
            "负面状态重数提升属性",
            "BufferNegativeStatePromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem43 = new System.Windows.Forms.ListViewItem(new string[] {
            "战斗行动数值数提升属性",
            "BufferNumberOfBattleActionsPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem44 = new System.Windows.Forms.ListViewItem(new string[] {
            "Buffer重数提升属性",
            "BufferOverlayPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem45 = new System.Windows.Forms.ListViewItem(new string[] {
            "回合数提升属性",
            "BufferTurnPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem46 = new System.Windows.Forms.ListViewItem(new string[] {
            "部队数提升属性",
            "BufferUnitPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem47 = new System.Windows.Forms.ListViewItem(new string[] {
            "HP百分比修改属性",
            "HPPercentPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem48 = new System.Windows.Forms.ListViewItem(new string[] {
            "MP百分比修改属性",
            "MPPercentPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem49 = new System.Windows.Forms.ListViewItem(new string[] {
            "攻击者剩馀移动数提升属性",
            "NumberOfMovementsPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem50 = new System.Windows.Forms.ListViewItem(new string[] {
            "增益重数",
            "BufferOverlayAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem51 = new System.Windows.Forms.ListViewItem(new string[] {
            "增益次数",
            "BufferTimesAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem52 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予自身Buff",
            "AttacherAddBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem53 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予攻击者Buff",
            "AttackerAddBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem54 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予防御者Buff",
            "DefenderAddBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem55 = new System.Windows.Forms.ListViewItem(new string[] {
            "依攻击者属性加入Buff",
            "AttackerElementAddBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem56 = new System.Windows.Forms.ListViewItem(new string[] {
            "依防御者属性加入Buff",
            "DefenderElementAddBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem57 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定清除自身Buff",
            "AttacherClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem58 = new System.Windows.Forms.ListViewItem(new string[] {
            "随机清除自身Buff",
            "AttacherRandomClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem59 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定清除攻击者Buff",
            "AttackerClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem60 = new System.Windows.Forms.ListViewItem(new string[] {
            "随机清除攻击者Buff",
            "AttackerRandomClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem61 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定清除防御者Buff",
            "DefenderClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem62 = new System.Windows.Forms.ListViewItem(new string[] {
            "随机清除防御者Buff",
            "DefenderRandomClearBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem63 = new System.Windows.Forms.ListViewItem(new string[] {
            "随机增加buff或debuff",
            "RandomBuffAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem64 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定ID增加Buff",
            "AddBuffWithUnitIdAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem65 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定ID移除Buff",
            "RemoveBuffWithUnitIdAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem66 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定ID范围增加Buff",
            "AssignAuraPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem67 = new System.Windows.Forms.ListViewItem(new string[] {
            "条件式范围增加Buff(持续性)",
            "AuraPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem68 = new System.Windows.Forms.ListViewItem(new string[] {
            "条件式范围增加Buff(单次触发)",
            "SingleAuraPromoteAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem69 = new System.Windows.Forms.ListViewItem(new string[] {
            "转换阵营",
            "ChanageFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem70 = new System.Windows.Forms.ListViewItem(new string[] {
            "激励部队",
            "EncourageAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem71 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予解放状态",
            "BufferLiberatedStateAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem72 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予限制状态",
            "BufferRestrictedStateAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem73 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予正面状态(迭加类型)",
            "BufferPositiveStateAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem74 = new System.Windows.Forms.ListViewItem(new string[] {
            "赋予负面状态(迭加类型)",
            "BufferNegativeStateAction"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BufferInfoForm));
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.iconNameComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.orientedComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TimesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.overlayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bufferNodeTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BufferNodeFlowListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BufferNodeConditionListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BufferNodePropertyListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BufferNodeBufferListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BufferNodeOtherListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.addBufferNodeButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bufferNodeTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.addNewBufferEventButton = new System.Windows.Forms.Button();
            this.editBufferNodeButton = new System.Windows.Forms.Button();
            this.deleteBufferNodeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.bufferIconPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bufferImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TimesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.bufferNodeTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bufferIconPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Location = new System.Drawing.Point(6, 21);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(29, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(89, 18);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(175, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(341, 17);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(162, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称";
            // 
            // descTextBox
            // 
            this.descTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descTextBox.Location = new System.Drawing.Point(53, 75);
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(1096, 21);
            this.descTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "描述";
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox.Location = new System.Drawing.Point(53, 102);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(1096, 21);
            this.remarkTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "图片";
            // 
            // iconNameComboBox
            // 
            this.iconNameComboBox.FormattingEnabled = true;
            this.iconNameComboBox.Location = new System.Drawing.Point(568, 18);
            this.iconNameComboBox.Name = "iconNameComboBox";
            this.iconNameComboBox.Size = new System.Drawing.Size(135, 20);
            this.iconNameComboBox.TabIndex = 2;
            this.iconNameComboBox.SelectedIndexChanged += new System.EventHandler(this.iconNameComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "持续作用次数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "是否可叠加";
            // 
            // orientedComboBox
            // 
            this.orientedComboBox.FormattingEnabled = true;
            this.orientedComboBox.Location = new System.Drawing.Point(568, 45);
            this.orientedComboBox.Name = "orientedComboBox";
            this.orientedComboBox.Size = new System.Drawing.Size(135, 20);
            this.orientedComboBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "效果面向";
            // 
            // TimesNumericUpDown
            // 
            this.TimesNumericUpDown.Location = new System.Drawing.Point(89, 46);
            this.TimesNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.TimesNumericUpDown.Name = "TimesNumericUpDown";
            this.TimesNumericUpDown.Size = new System.Drawing.Size(175, 21);
            this.TimesNumericUpDown.TabIndex = 3;
            // 
            // overlayNumericUpDown
            // 
            this.overlayNumericUpDown.Location = new System.Drawing.Point(341, 45);
            this.overlayNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.overlayNumericUpDown.Name = "overlayNumericUpDown";
            this.overlayNumericUpDown.Size = new System.Drawing.Size(162, 21);
            this.overlayNumericUpDown.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1161, 481);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "buffer效果";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bufferNodeTabControl);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1155, 461);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 14;
            // 
            // bufferNodeTabControl
            // 
            this.bufferNodeTabControl.Controls.Add(this.tabPage1);
            this.bufferNodeTabControl.Controls.Add(this.tabPage2);
            this.bufferNodeTabControl.Controls.Add(this.tabPage4);
            this.bufferNodeTabControl.Controls.Add(this.tabPage5);
            this.bufferNodeTabControl.Controls.Add(this.tabPage3);
            this.bufferNodeTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufferNodeTabControl.Location = new System.Drawing.Point(0, 33);
            this.bufferNodeTabControl.Name = "bufferNodeTabControl";
            this.bufferNodeTabControl.SelectedIndex = 0;
            this.bufferNodeTabControl.Size = new System.Drawing.Size(385, 428);
            this.bufferNodeTabControl.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BufferNodeFlowListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "流程控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BufferNodeFlowListView
            // 
            this.BufferNodeFlowListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader11});
            this.BufferNodeFlowListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BufferNodeFlowListView.FullRowSelect = true;
            this.BufferNodeFlowListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BufferNodeFlowListView.HideSelection = false;
            this.BufferNodeFlowListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.BufferNodeFlowListView.Location = new System.Drawing.Point(3, 3);
            this.BufferNodeFlowListView.MultiSelect = false;
            this.BufferNodeFlowListView.Name = "BufferNodeFlowListView";
            this.BufferNodeFlowListView.Size = new System.Drawing.Size(371, 396);
            this.BufferNodeFlowListView.TabIndex = 0;
            this.BufferNodeFlowListView.UseCompatibleStateImageBehavior = false;
            this.BufferNodeFlowListView.View = System.Windows.Forms.View.Details;
            this.BufferNodeFlowListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BufferNodeFlowListView_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 367;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BufferNodeConditionListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "条件判断";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BufferNodeConditionListView
            // 
            this.BufferNodeConditionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.BufferNodeConditionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BufferNodeConditionListView.FullRowSelect = true;
            this.BufferNodeConditionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BufferNodeConditionListView.HideSelection = false;
            this.BufferNodeConditionListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28,
            listViewItem29,
            listViewItem30,
            listViewItem31,
            listViewItem32,
            listViewItem33,
            listViewItem34,
            listViewItem35,
            listViewItem36,
            listViewItem37});
            this.BufferNodeConditionListView.Location = new System.Drawing.Point(3, 3);
            this.BufferNodeConditionListView.MultiSelect = false;
            this.BufferNodeConditionListView.Name = "BufferNodeConditionListView";
            this.BufferNodeConditionListView.Size = new System.Drawing.Size(371, 396);
            this.BufferNodeConditionListView.TabIndex = 1;
            this.BufferNodeConditionListView.UseCompatibleStateImageBehavior = false;
            this.BufferNodeConditionListView.View = System.Windows.Forms.View.Details;
            this.BufferNodeConditionListView.DoubleClick += new System.EventHandler(this.BufferNodeConditionListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "名字";
            this.columnHeader3.Width = 348;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.BufferNodePropertyListView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(377, 402);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "属性调整";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BufferNodePropertyListView
            // 
            this.BufferNodePropertyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.BufferNodePropertyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BufferNodePropertyListView.FullRowSelect = true;
            this.BufferNodePropertyListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BufferNodePropertyListView.HideSelection = false;
            this.BufferNodePropertyListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem38,
            listViewItem39,
            listViewItem40,
            listViewItem41,
            listViewItem42,
            listViewItem43,
            listViewItem44,
            listViewItem45,
            listViewItem46,
            listViewItem47,
            listViewItem48,
            listViewItem49});
            this.BufferNodePropertyListView.Location = new System.Drawing.Point(0, 0);
            this.BufferNodePropertyListView.MultiSelect = false;
            this.BufferNodePropertyListView.Name = "BufferNodePropertyListView";
            this.BufferNodePropertyListView.Size = new System.Drawing.Size(377, 402);
            this.BufferNodePropertyListView.TabIndex = 1;
            this.BufferNodePropertyListView.UseCompatibleStateImageBehavior = false;
            this.BufferNodePropertyListView.View = System.Windows.Forms.View.Details;
            this.BufferNodePropertyListView.DoubleClick += new System.EventHandler(this.BufferNodePropertyListView_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名字";
            this.columnHeader5.Width = 372;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描述";
            this.columnHeader6.Width = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BufferNodeBufferListView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(377, 402);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "buffer相关";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BufferNodeBufferListView
            // 
            this.BufferNodeBufferListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.BufferNodeBufferListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BufferNodeBufferListView.FullRowSelect = true;
            this.BufferNodeBufferListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BufferNodeBufferListView.HideSelection = false;
            this.BufferNodeBufferListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem50,
            listViewItem51,
            listViewItem52,
            listViewItem53,
            listViewItem54,
            listViewItem55,
            listViewItem56,
            listViewItem57,
            listViewItem58,
            listViewItem59,
            listViewItem60,
            listViewItem61,
            listViewItem62,
            listViewItem63,
            listViewItem64,
            listViewItem65,
            listViewItem66,
            listViewItem67,
            listViewItem68});
            this.BufferNodeBufferListView.Location = new System.Drawing.Point(0, 0);
            this.BufferNodeBufferListView.MultiSelect = false;
            this.BufferNodeBufferListView.Name = "BufferNodeBufferListView";
            this.BufferNodeBufferListView.Size = new System.Drawing.Size(377, 402);
            this.BufferNodeBufferListView.TabIndex = 1;
            this.BufferNodeBufferListView.UseCompatibleStateImageBehavior = false;
            this.BufferNodeBufferListView.View = System.Windows.Forms.View.Details;
            this.BufferNodeBufferListView.DoubleClick += new System.EventHandler(this.BufferNodeBufferListView_DoubleClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "名字";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "描述";
            this.columnHeader8.Width = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BufferNodeOtherListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(377, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "其他";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BufferNodeOtherListView
            // 
            this.BufferNodeOtherListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.BufferNodeOtherListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BufferNodeOtherListView.FullRowSelect = true;
            this.BufferNodeOtherListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BufferNodeOtherListView.HideSelection = false;
            this.BufferNodeOtherListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem69,
            listViewItem70,
            listViewItem71,
            listViewItem72,
            listViewItem73,
            listViewItem74});
            this.BufferNodeOtherListView.Location = new System.Drawing.Point(0, 0);
            this.BufferNodeOtherListView.MultiSelect = false;
            this.BufferNodeOtherListView.Name = "BufferNodeOtherListView";
            this.BufferNodeOtherListView.Size = new System.Drawing.Size(377, 402);
            this.BufferNodeOtherListView.TabIndex = 1;
            this.BufferNodeOtherListView.UseCompatibleStateImageBehavior = false;
            this.BufferNodeOtherListView.View = System.Windows.Forms.View.Details;
            this.BufferNodeOtherListView.DoubleClick += new System.EventHandler(this.BufferNodeOtherListView_DoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "名字";
            this.columnHeader9.Width = 371;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "描述";
            this.columnHeader10.Width = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.addBufferNodeButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(385, 33);
            this.panel5.TabIndex = 9;
            // 
            // addBufferNodeButton
            // 
            this.addBufferNodeButton.Location = new System.Drawing.Point(3, 4);
            this.addBufferNodeButton.Name = "addBufferNodeButton";
            this.addBufferNodeButton.Size = new System.Drawing.Size(108, 23);
            this.addBufferNodeButton.TabIndex = 10;
            this.addBufferNodeButton.Text = "添加至当前节点";
            this.addBufferNodeButton.UseVisualStyleBackColor = true;
            this.addBufferNodeButton.Click += new System.EventHandler(this.addBufferNodeButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bufferNodeTreeView);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(766, 461);
            this.panel3.TabIndex = 13;
            // 
            // bufferNodeTreeView
            // 
            this.bufferNodeTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.bufferNodeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufferNodeTreeView.FullRowSelect = true;
            this.bufferNodeTreeView.HideSelection = false;
            this.bufferNodeTreeView.Location = new System.Drawing.Point(0, 33);
            this.bufferNodeTreeView.Name = "bufferNodeTreeView";
            this.bufferNodeTreeView.ShowNodeToolTips = true;
            this.bufferNodeTreeView.Size = new System.Drawing.Size(766, 428);
            this.bufferNodeTreeView.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // panel4
            // 
            this.panel4.AllowDrop = true;
            this.panel4.Controls.Add(this.addNewBufferEventButton);
            this.panel4.Controls.Add(this.editBufferNodeButton);
            this.panel4.Controls.Add(this.deleteBufferNodeButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 33);
            this.panel4.TabIndex = 13;
            // 
            // addNewBufferEventButton
            // 
            this.addNewBufferEventButton.Location = new System.Drawing.Point(3, 4);
            this.addNewBufferEventButton.Name = "addNewBufferEventButton";
            this.addNewBufferEventButton.Size = new System.Drawing.Size(75, 23);
            this.addNewBufferEventButton.TabIndex = 12;
            this.addNewBufferEventButton.Text = "添加新时点";
            this.addNewBufferEventButton.UseVisualStyleBackColor = true;
            this.addNewBufferEventButton.Click += new System.EventHandler(this.addNewBufferEventButton_Click);
            // 
            // editBufferNodeButton
            // 
            this.editBufferNodeButton.Location = new System.Drawing.Point(84, 4);
            this.editBufferNodeButton.Name = "editBufferNodeButton";
            this.editBufferNodeButton.Size = new System.Drawing.Size(97, 23);
            this.editBufferNodeButton.TabIndex = 10;
            this.editBufferNodeButton.Text = "修改选中节点";
            this.editBufferNodeButton.UseVisualStyleBackColor = true;
            this.editBufferNodeButton.Click += new System.EventHandler(this.editBufferNodeButton_Click);
            // 
            // deleteBufferNodeButton
            // 
            this.deleteBufferNodeButton.Location = new System.Drawing.Point(187, 4);
            this.deleteBufferNodeButton.Name = "deleteBufferNodeButton";
            this.deleteBufferNodeButton.Size = new System.Drawing.Size(97, 23);
            this.deleteBufferNodeButton.TabIndex = 11;
            this.deleteBufferNodeButton.Text = "删除选中节点";
            this.deleteBufferNodeButton.UseVisualStyleBackColor = true;
            this.deleteBufferNodeButton.Click += new System.EventHandler(this.deleteBufferNodeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.overlayNumericUpDown);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.TimesNumericUpDown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bufferIconPictureBox);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.orientedComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.descTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.remarkTextBox);
            this.panel1.Controls.Add(this.iconNameComboBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 139);
            this.panel1.TabIndex = 20;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(1074, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // bufferIconPictureBox
            // 
            this.bufferIconPictureBox.Location = new System.Drawing.Point(709, 5);
            this.bufferIconPictureBox.Name = "bufferIconPictureBox";
            this.bufferIconPictureBox.Size = new System.Drawing.Size(64, 64);
            this.bufferIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bufferIconPictureBox.TabIndex = 16;
            this.bufferIconPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 481);
            this.panel2.TabIndex = 21;
            // 
            // bufferImageList
            // 
            this.bufferImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bufferImageList.ImageStream")));
            this.bufferImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bufferImageList.Images.SetKeyName(0, "buff_critical");
            this.bufferImageList.Images.SetKeyName(1, "buff_damage");
            this.bufferImageList.Images.SetKeyName(2, "buff_dodge");
            this.bufferImageList.Images.SetKeyName(3, "buff_fury");
            this.bufferImageList.Images.SetKeyName(4, "buff_hp");
            this.bufferImageList.Images.SetKeyName(5, "buff_move");
            this.bufferImageList.Images.SetKeyName(6, "buff_mp");
            this.bufferImageList.Images.SetKeyName(7, "buff_parry");
            this.bufferImageList.Images.SetKeyName(8, "buff_trait");
            this.bufferImageList.Images.SetKeyName(9, "buff_xingfa");
            this.bufferImageList.Images.SetKeyName(10, "debuff_critical");
            this.bufferImageList.Images.SetKeyName(11, "debuff_damage");
            this.bufferImageList.Images.SetKeyName(12, "debuff_dodge");
            this.bufferImageList.Images.SetKeyName(13, "debuff_hp");
            this.bufferImageList.Images.SetKeyName(14, "debuff_move");
            this.bufferImageList.Images.SetKeyName(15, "debuff_mp");
            this.bufferImageList.Images.SetKeyName(16, "debuff_parry");
            this.bufferImageList.Images.SetKeyName(17, "debuff_poison");
            // 
            // BufferInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(900, 39);
            this.Name = "BufferInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "buffer信息";
            ((System.ComponentModel.ISupportInitialize)(this.TimesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlayNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.bufferNodeTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bufferIconPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox iconNameComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox orientedComboBox;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.PictureBox bufferIconPictureBox;
        public System.Windows.Forms.NumericUpDown TimesNumericUpDown;
        public System.Windows.Forms.NumericUpDown overlayNumericUpDown;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TreeView bufferNodeTreeView;
        public System.Windows.Forms.Button deleteBufferNodeButton;
        public System.Windows.Forms.Button editBufferNodeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Button addBufferNodeButton;
        public System.Windows.Forms.TabControl bufferNodeTabControl;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Button addNewBufferEventButton;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.ListView BufferNodeFlowListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        public System.Windows.Forms.ListView BufferNodeConditionListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ListView BufferNodePropertyListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView BufferNodeBufferListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        public System.Windows.Forms.ListView BufferNodeOtherListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ImageList bufferImageList;
    }
}