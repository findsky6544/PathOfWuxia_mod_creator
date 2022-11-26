
namespace 侠之道mod制作器
{
    partial class ScheduleInfoForm
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
            System.Windows.Forms.ListViewItem listViewItem85 = new System.Windows.Forms.ListViewItem(new string[] {
            "单步执行",
            "StepByStepNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem86 = new System.Windows.Forms.ListViewItem(new string[] {
            "执行到失败",
            "SequenceNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem87 = new System.Windows.Forms.ListViewItem(new string[] {
            "条件分歧",
            "BattleBranchNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem88 = new System.Windows.Forms.ListViewItem(new string[] {
            "一次性节点",
            "ExecuteOnceNode"}, -1);
            System.Windows.Forms.ListViewItem listViewItem89 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断全域旗标",
            "BattleFactorGlobalFlag"}, -1);
            System.Windows.Forms.ListViewItem listViewItem90 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断战斗旗标",
            "BattleFactorLocalFlag"}, -1);
            System.Windows.Forms.ListViewItem listViewItem91 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断战斗单位血量",
            "BattleFactorTargetHp"}, -1);
            System.Windows.Forms.ListViewItem listViewItem92 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断回合数",
            "BattleFactorTurn"}, -1);
            System.Windows.Forms.ListViewItem listViewItem93 = new System.Windows.Forms.ListViewItem(new string[] {
            "部队A是否攻击部队B",
            "BattleAttackUnitCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem94 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断格子上有阵营",
            "BattleFactorCellFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem95 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断格子上有unit",
            "BattleFactorUnitCell"}, -1);
            System.Windows.Forms.ListViewItem listViewItem96 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断目标到达格子",
            "BattleFactorCharacterTile"}, -1);
            System.Windows.Forms.ListViewItem listViewItem97 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断当前阵营",
            "BattleFactorCurrentFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem98 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断阵营全灭",
            "BattleFactorFactionDefeat"}, -1);
            System.Windows.Forms.ListViewItem listViewItem99 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断主角功体",
            "BattleFactorPlayerElement"}, -1);
            System.Windows.Forms.ListViewItem listViewItem100 = new System.Windows.Forms.ListViewItem(new string[] {
            "判断目标死亡",
            "BattleFactorTargetDestroy"}, -1);
            System.Windows.Forms.ListViewItem listViewItem101 = new System.Windows.Forms.ListViewItem(new string[] {
            "战斗单位是否使用技能",
            "BattleUseSkillCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem102 = new System.Windows.Forms.ListViewItem(new string[] {
            "战斗单位是否使用特技",
            "BattleUseSpecialSkillCondition"}, -1);
            System.Windows.Forms.ListViewItem listViewItem103 = new System.Windows.Forms.ListViewItem(new string[] {
            "单位加入增益",
            "BattleResultAddBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem104 = new System.Windows.Forms.ListViewItem(new string[] {
            "阵营加入增益",
            "BattleResultAddFactionBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem105 = new System.Windows.Forms.ListViewItem(new string[] {
            "单位移除增益",
            "BattleResultRmoveBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem106 = new System.Windows.Forms.ListViewItem(new string[] {
            "阵营移除增益",
            "BattleResultRmoveFactionBuff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem107 = new System.Windows.Forms.ListViewItem(new string[] {
            "转换AI类型",
            "BattlChanageAItype"}, -1);
            System.Windows.Forms.ListViewItem listViewItem108 = new System.Windows.Forms.ListViewItem(new string[] {
            "转换阵营",
            "BattlChanageFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem109 = new System.Windows.Forms.ListViewItem(new string[] {
            "调整血量（百分比）",
            "BattleResultUnitHP"}, -1);
            System.Windows.Forms.ListViewItem listViewItem110 = new System.Windows.Forms.ListViewItem(new string[] {
            "调整内力",
            "BattleResultUnitMP"}, -1);
            System.Windows.Forms.ListViewItem listViewItem111 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定目标点",
            "BattlSetTargetCell"}, -1);
            System.Windows.Forms.ListViewItem listViewItem112 = new System.Windows.Forms.ListViewItem(new string[] {
            "指定单位播放动画",
            "BattleResultPlayAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem113 = new System.Windows.Forms.ListViewItem(new string[] {
            "加入部队",
            "BattleResultAddUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem114 = new System.Windows.Forms.ListViewItem(new string[] {
            "加入复数部队",
            "BattleResultAddUnits"}, -1);
            System.Windows.Forms.ListViewItem listViewItem115 = new System.Windows.Forms.ListViewItem(new string[] {
            "移除部队",
            "BattleResultRemoveUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem116 = new System.Windows.Forms.ListViewItem(new string[] {
            "移除复数部队",
            "BattleResultRemoveUnits"}, -1);
            System.Windows.Forms.ListViewItem listViewItem117 = new System.Windows.Forms.ListViewItem(new string[] {
            "取代部队",
            "BattleResultrReplaceUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem118 = new System.Windows.Forms.ListViewItem(new string[] {
            "新增布阵点",
            "BattleResultAddDistributionPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem119 = new System.Windows.Forms.ListViewItem(new string[] {
            "删除布阵点",
            "BattleResultRemoveDistributionPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem120 = new System.Windows.Forms.ListViewItem(new string[] {
            "新增事件点",
            "BattleResultEventPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem121 = new System.Windows.Forms.ListViewItem(new string[] {
            "删除事件点",
            "BattleResultRemoveEventPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem122 = new System.Windows.Forms.ListViewItem(new string[] {
            "新增逃出点",
            "BattleResultExitPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem123 = new System.Windows.Forms.ListViewItem(new string[] {
            "删除逃出点",
            "BattleResultRemoveExitPoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem124 = new System.Windows.Forms.ListViewItem(new string[] {
            "新增宝藏点",
            "BattleResultTreasurePoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem125 = new System.Windows.Forms.ListViewItem(new string[] {
            "删除宝藏点",
            "BattleResultRemoveTreasurePoint"}, -1);
            System.Windows.Forms.ListViewItem listViewItem126 = new System.Windows.Forms.ListViewItem(new string[] {
            "修改行走点",
            "BattleResultWalkable"}, -1);
            System.Windows.Forms.ListViewItem listViewItem127 = new System.Windows.Forms.ListViewItem(new string[] {
            "直接获胜",
            "BattleResultWin"}, -1);
            System.Windows.Forms.ListViewItem listViewItem128 = new System.Windows.Forms.ListViewItem(new string[] {
            "直接失败",
            "BattleResultLose"}, -1);
            System.Windows.Forms.ListViewItem listViewItem129 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加勝利條件/角色到達目標點",
            "BattleResultWinCharacterExit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem130 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加失敗條件/角色到達目標點",
            "BattleResultLoseCharacterExit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem131 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加勝利條件/陣營到達目標點",
            "BattleResultWinFactionExit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem132 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加失敗條件/陣營到達目標點",
            "BattleResultLoseFactionExit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem133 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加勝利條件/到達回合數",
            "BattleResultWinTurn"}, -1);
            System.Windows.Forms.ListViewItem listViewItem134 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加失敗條件/到達回合數",
            "BattleResultLoseTurn"}, -1);
            System.Windows.Forms.ListViewItem listViewItem135 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加勝利條件/陣營全滅",
            "BattleResultWinFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem136 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加失敗條件/陣營全滅",
            "BattleResultLoseFaction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem137 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加勝利條件/目標死亡",
            "BattleResultWinTargetDestroy"}, -1);
            System.Windows.Forms.ListViewItem listViewItem138 = new System.Windows.Forms.ListViewItem(new string[] {
            "增加失敗條件/目標死亡",
            "BattleResultLoseTargetDestroy"}, -1);
            System.Windows.Forms.ListViewItem listViewItem139 = new System.Windows.Forms.ListViewItem(new string[] {
            "移除勝利條件",
            "BattleResultWinRemove"}, -1);
            System.Windows.Forms.ListViewItem listViewItem140 = new System.Windows.Forms.ListViewItem(new string[] {
            "移除失敗條件",
            "BattleResultLoseRemove"}, -1);
            System.Windows.Forms.ListViewItem listViewItem141 = new System.Windows.Forms.ListViewItem(new string[] {
            "修改勝利條件說明",
            "BattleResultChangeWinTip"}, -1);
            System.Windows.Forms.ListViewItem listViewItem142 = new System.Windows.Forms.ListViewItem(new string[] {
            "修改失敗條件說明",
            "BattleResultChangeLoseTip"}, -1);
            System.Windows.Forms.ListViewItem listViewItem143 = new System.Windows.Forms.ListViewItem(new string[] {
            "新增次要條件說明",
            "BattleResultAddSecondaryGoal"}, -1);
            System.Windows.Forms.ListViewItem listViewItem144 = new System.Windows.Forms.ListViewItem(new string[] {
            "修改次要條件狀態",
            "BattleResultChangeSecondaryGoal"}, -1);
            System.Windows.Forms.ListViewItem listViewItem145 = new System.Windows.Forms.ListViewItem(new string[] {
            "部队会面",
            "BattleResultUnitToUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem146 = new System.Windows.Forms.ListViewItem(new string[] {
            "部队移动",
            "BattleResultMoveUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem147 = new System.Windows.Forms.ListViewItem(new string[] {
            "摄影机移动（锁定格子）",
            "BattleResultCameraMoveCell"}, -1);
            System.Windows.Forms.ListViewItem listViewItem148 = new System.Windows.Forms.ListViewItem(new string[] {
            "摄影机移动（锁定部队）",
            "BattleResultCameraMoveUnit"}, -1);
            System.Windows.Forms.ListViewItem listViewItem149 = new System.Windows.Forms.ListViewItem(new string[] {
            "呼叫对话",
            "BattleResultTalk"}, -1);
            System.Windows.Forms.ListViewItem listViewItem150 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定部队是否行动完毕",
            "BattleResultUnitIsEndAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem151 = new System.Windows.Forms.ListViewItem(new string[] {
            "等待X秒",
            "BattleResultWaitAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem152 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定全域旗标",
            "SetGlobalFlagBattleAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem153 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定战斗旗标",
            "SetLocalFlagBattleAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem154 = new System.Windows.Forms.ListViewItem(new string[] {
            "给奖励",
            "BattleResultAddReward"}, -1);
            System.Windows.Forms.ListViewItem listViewItem155 = new System.Windows.Forms.ListViewItem(new string[] {
            "转换音乐",
            "BattleResultChangeMusic"}, -1);
            System.Windows.Forms.ListViewItem listViewItem156 = new System.Windows.Forms.ListViewItem(new string[] {
            "淡出音乐",
            "BattleResultFadeOutMusic"}, -1);
            System.Windows.Forms.ListViewItem listViewItem157 = new System.Windows.Forms.ListViewItem(new string[] {
            "播放音效",
            "BattleResultPalySound"}, -1);
            System.Windows.Forms.ListViewItem listViewItem158 = new System.Windows.Forms.ListViewItem(new string[] {
            "直接结束战斗",
            "EndBattleAction"}, -1);
            System.Windows.Forms.ListViewItem listViewItem159 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定掉落奖励百分比",
            "SetDropRewardProbability"}, -1);
            System.Windows.Forms.ListViewItem listViewItem160 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定是否掉落奖励（预设开）",
            "SetIsDropReward"}, -1);
            System.Windows.Forms.ListViewItem listViewItem161 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定装备按钮开关（全部队）",
            "SetIsShowEquip"}, -1);
            System.Windows.Forms.ListViewItem listViewItem162 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定道具按钮开关（全部队）",
            "SetIsShowItem"}, -1);
            System.Windows.Forms.ListViewItem listViewItem163 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定技能按钮开关（全部队）",
            "SetIsShowSkill"}, -1);
            System.Windows.Forms.ListViewItem listViewItem164 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定特技按钮开关（全部队）",
            "SetIsShowSpecial"}, -1);
            System.Windows.Forms.ListViewItem listViewItem165 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定部队装备按钮开关（指定部队）",
            "SetUnitCanEquip"}, -1);
            System.Windows.Forms.ListViewItem listViewItem166 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定部队道具按钮开关（指定部队）",
            "SetUnitCanUseItem"}, -1);
            System.Windows.Forms.ListViewItem listViewItem167 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定部队技能按钮开关（指定部队）",
            "SetUnitCanUseSkills"}, -1);
            System.Windows.Forms.ListViewItem listViewItem168 = new System.Windows.Forms.ListViewItem(new string[] {
            "设定部队特技按钮开关（指定部队）",
            "SetUnitCanUseSpecialSkill"}, -1);
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.winTipTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scheduleNodeTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeFlowListView = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeConditionListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeUnitListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeCellListView = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeWinLoseListView = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeWaitListView = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ScheduleNodeOtherListView = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.addScheduleNodeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.scheduleListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel7 = new System.Windows.Forms.Panel();
            this.addNewScheduleEventButton = new System.Windows.Forms.Button();
            this.editScheduleNodeButton = new System.Windows.Forms.Button();
            this.deleteScheduleNodeButton = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.scheduleTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.loseTipTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.scheduleNodeTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.idTextBox.Location = new System.Drawing.Point(65, 18);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(175, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(305, 18);
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
            // winTipTextBox
            // 
            this.winTipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winTipTextBox.Location = new System.Drawing.Point(65, 72);
            this.winTipTextBox.Name = "winTipTextBox";
            this.winTipTextBox.Size = new System.Drawing.Size(1084, 21);
            this.winTipTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "胜利提示";
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remarkTextBox.Location = new System.Drawing.Point(65, 45);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(1084, 21);
            this.remarkTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
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
            this.groupBox1.Text = "schedule效果";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 17);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scheduleNodeTabControl);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1155, 461);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 14;
            // 
            // scheduleNodeTabControl
            // 
            this.scheduleNodeTabControl.Controls.Add(this.tabPage1);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage2);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage4);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage5);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage8);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage9);
            this.scheduleNodeTabControl.Controls.Add(this.tabPage3);
            this.scheduleNodeTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleNodeTabControl.Location = new System.Drawing.Point(0, 33);
            this.scheduleNodeTabControl.Name = "scheduleNodeTabControl";
            this.scheduleNodeTabControl.SelectedIndex = 0;
            this.scheduleNodeTabControl.Size = new System.Drawing.Size(385, 428);
            this.scheduleNodeTabControl.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ScheduleNodeFlowListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "流程控制";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeFlowListView
            // 
            this.ScheduleNodeFlowListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader2});
            this.ScheduleNodeFlowListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeFlowListView.FullRowSelect = true;
            this.ScheduleNodeFlowListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeFlowListView.HideSelection = false;
            this.ScheduleNodeFlowListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem85,
            listViewItem86,
            listViewItem87,
            listViewItem88});
            this.ScheduleNodeFlowListView.Location = new System.Drawing.Point(3, 3);
            this.ScheduleNodeFlowListView.MultiSelect = false;
            this.ScheduleNodeFlowListView.Name = "ScheduleNodeFlowListView";
            this.ScheduleNodeFlowListView.Size = new System.Drawing.Size(371, 396);
            this.ScheduleNodeFlowListView.TabIndex = 0;
            this.ScheduleNodeFlowListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeFlowListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeFlowListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ScheduleNodeFlowListView_MouseDoubleClick);
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 1;
            this.columnHeader11.Width = 367;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ScheduleNodeConditionListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(377, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "条件判断";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeConditionListView
            // 
            this.ScheduleNodeConditionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3});
            this.ScheduleNodeConditionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeConditionListView.FullRowSelect = true;
            this.ScheduleNodeConditionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeConditionListView.HideSelection = false;
            this.ScheduleNodeConditionListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem89,
            listViewItem90,
            listViewItem91,
            listViewItem92,
            listViewItem93,
            listViewItem94,
            listViewItem95,
            listViewItem96,
            listViewItem97,
            listViewItem98,
            listViewItem99,
            listViewItem100,
            listViewItem101,
            listViewItem102});
            this.ScheduleNodeConditionListView.Location = new System.Drawing.Point(3, 3);
            this.ScheduleNodeConditionListView.MultiSelect = false;
            this.ScheduleNodeConditionListView.Name = "ScheduleNodeConditionListView";
            this.ScheduleNodeConditionListView.Size = new System.Drawing.Size(371, 396);
            this.ScheduleNodeConditionListView.TabIndex = 1;
            this.ScheduleNodeConditionListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeConditionListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeConditionListView.DoubleClick += new System.EventHandler(this.ScheduleNodeConditionListView_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 1;
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 348;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 0;
            this.columnHeader3.Text = "名字";
            this.columnHeader3.Width = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ScheduleNodeUnitListView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(377, 402);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "部队";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeUnitListView
            // 
            this.ScheduleNodeUnitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5});
            this.ScheduleNodeUnitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeUnitListView.FullRowSelect = true;
            this.ScheduleNodeUnitListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeUnitListView.HideSelection = false;
            this.ScheduleNodeUnitListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem103,
            listViewItem104,
            listViewItem105,
            listViewItem106,
            listViewItem107,
            listViewItem108,
            listViewItem109,
            listViewItem110,
            listViewItem111,
            listViewItem112,
            listViewItem113,
            listViewItem114,
            listViewItem115,
            listViewItem116,
            listViewItem117});
            this.ScheduleNodeUnitListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleNodeUnitListView.MultiSelect = false;
            this.ScheduleNodeUnitListView.Name = "ScheduleNodeUnitListView";
            this.ScheduleNodeUnitListView.Size = new System.Drawing.Size(377, 402);
            this.ScheduleNodeUnitListView.TabIndex = 1;
            this.ScheduleNodeUnitListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeUnitListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeUnitListView.DoubleClick += new System.EventHandler(this.ScheduleNodePropertyListView_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 1;
            this.columnHeader6.Text = "描述";
            this.columnHeader6.Width = 372;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 0;
            this.columnHeader5.Text = "名字";
            this.columnHeader5.Width = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ScheduleNodeCellListView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(377, 402);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "网格";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeCellListView
            // 
            this.ScheduleNodeCellListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader7});
            this.ScheduleNodeCellListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeCellListView.FullRowSelect = true;
            this.ScheduleNodeCellListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeCellListView.HideSelection = false;
            this.ScheduleNodeCellListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem118,
            listViewItem119,
            listViewItem120,
            listViewItem121,
            listViewItem122,
            listViewItem123,
            listViewItem124,
            listViewItem125,
            listViewItem126});
            this.ScheduleNodeCellListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleNodeCellListView.MultiSelect = false;
            this.ScheduleNodeCellListView.Name = "ScheduleNodeCellListView";
            this.ScheduleNodeCellListView.Size = new System.Drawing.Size(377, 402);
            this.ScheduleNodeCellListView.TabIndex = 1;
            this.ScheduleNodeCellListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeCellListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeCellListView.DoubleClick += new System.EventHandler(this.ScheduleNodeScheduleListView_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 1;
            this.columnHeader8.Text = "描述";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 0;
            this.columnHeader7.Text = "名字";
            this.columnHeader7.Width = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.ScheduleNodeWinLoseListView);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(377, 402);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "胜败";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeWinLoseListView
            // 
            this.ScheduleNodeWinLoseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16});
            this.ScheduleNodeWinLoseListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeWinLoseListView.FullRowSelect = true;
            this.ScheduleNodeWinLoseListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeWinLoseListView.HideSelection = false;
            this.ScheduleNodeWinLoseListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem127,
            listViewItem128,
            listViewItem129,
            listViewItem130,
            listViewItem131,
            listViewItem132,
            listViewItem133,
            listViewItem134,
            listViewItem135,
            listViewItem136,
            listViewItem137,
            listViewItem138,
            listViewItem139,
            listViewItem140,
            listViewItem141,
            listViewItem142,
            listViewItem143,
            listViewItem144});
            this.ScheduleNodeWinLoseListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleNodeWinLoseListView.MultiSelect = false;
            this.ScheduleNodeWinLoseListView.Name = "ScheduleNodeWinLoseListView";
            this.ScheduleNodeWinLoseListView.Size = new System.Drawing.Size(377, 402);
            this.ScheduleNodeWinLoseListView.TabIndex = 2;
            this.ScheduleNodeWinLoseListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeWinLoseListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeWinLoseListView.DoubleClick += new System.EventHandler(this.ScheduleNodeWinLoseListView_DoubleClick);
            // 
            // columnHeader15
            // 
            this.columnHeader15.DisplayIndex = 1;
            this.columnHeader15.Text = "描述";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.DisplayIndex = 0;
            this.columnHeader16.Text = "名字";
            this.columnHeader16.Width = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.ScheduleNodeWaitListView);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(377, 402);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "等待动作";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeWaitListView
            // 
            this.ScheduleNodeWaitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18});
            this.ScheduleNodeWaitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeWaitListView.FullRowSelect = true;
            this.ScheduleNodeWaitListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeWaitListView.HideSelection = false;
            this.ScheduleNodeWaitListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem145,
            listViewItem146,
            listViewItem147,
            listViewItem148,
            listViewItem149,
            listViewItem150,
            listViewItem151});
            this.ScheduleNodeWaitListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleNodeWaitListView.MultiSelect = false;
            this.ScheduleNodeWaitListView.Name = "ScheduleNodeWaitListView";
            this.ScheduleNodeWaitListView.Size = new System.Drawing.Size(377, 402);
            this.ScheduleNodeWaitListView.TabIndex = 3;
            this.ScheduleNodeWaitListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeWaitListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeWaitListView.DoubleClick += new System.EventHandler(this.ScheduleNodeWaitListView_DoubleClick);
            // 
            // columnHeader17
            // 
            this.columnHeader17.DisplayIndex = 1;
            this.columnHeader17.Text = "描述";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader18
            // 
            this.columnHeader18.DisplayIndex = 0;
            this.columnHeader18.Text = "名字";
            this.columnHeader18.Width = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ScheduleNodeOtherListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(377, 402);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "其他";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ScheduleNodeOtherListView
            // 
            this.ScheduleNodeOtherListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader9});
            this.ScheduleNodeOtherListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduleNodeOtherListView.FullRowSelect = true;
            this.ScheduleNodeOtherListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ScheduleNodeOtherListView.HideSelection = false;
            this.ScheduleNodeOtherListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem152,
            listViewItem153,
            listViewItem154,
            listViewItem155,
            listViewItem156,
            listViewItem157,
            listViewItem158,
            listViewItem159,
            listViewItem160,
            listViewItem161,
            listViewItem162,
            listViewItem163,
            listViewItem164,
            listViewItem165,
            listViewItem166,
            listViewItem167,
            listViewItem168});
            this.ScheduleNodeOtherListView.Location = new System.Drawing.Point(0, 0);
            this.ScheduleNodeOtherListView.MultiSelect = false;
            this.ScheduleNodeOtherListView.Name = "ScheduleNodeOtherListView";
            this.ScheduleNodeOtherListView.Size = new System.Drawing.Size(377, 402);
            this.ScheduleNodeOtherListView.TabIndex = 1;
            this.ScheduleNodeOtherListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleNodeOtherListView.View = System.Windows.Forms.View.Details;
            this.ScheduleNodeOtherListView.DoubleClick += new System.EventHandler(this.ScheduleNodeOtherListView_DoubleClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 1;
            this.columnHeader10.Text = "描述";
            this.columnHeader10.Width = 371;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 0;
            this.columnHeader9.Text = "名字";
            this.columnHeader9.Width = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.addScheduleNodeButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(385, 33);
            this.panel5.TabIndex = 9;
            // 
            // addScheduleNodeButton
            // 
            this.addScheduleNodeButton.Location = new System.Drawing.Point(3, 4);
            this.addScheduleNodeButton.Name = "addScheduleNodeButton";
            this.addScheduleNodeButton.Size = new System.Drawing.Size(108, 23);
            this.addScheduleNodeButton.TabIndex = 10;
            this.addScheduleNodeButton.Text = "添加节点";
            this.addScheduleNodeButton.UseVisualStyleBackColor = true;
            this.addScheduleNodeButton.Click += new System.EventHandler(this.addScheduleNodeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 461);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(758, 435);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "列表";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.scheduleListView);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(752, 429);
            this.panel3.TabIndex = 13;
            // 
            // scheduleListView
            // 
            this.scheduleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.scheduleListView.ContextMenuStrip = this.contextMenuStrip1;
            this.scheduleListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleListView.FullRowSelect = true;
            this.scheduleListView.HideSelection = false;
            this.scheduleListView.Location = new System.Drawing.Point(0, 33);
            this.scheduleListView.MultiSelect = false;
            this.scheduleListView.Name = "scheduleListView";
            this.scheduleListView.ShowItemToolTips = true;
            this.scheduleListView.Size = new System.Drawing.Size(752, 396);
            this.scheduleListView.TabIndex = 14;
            this.scheduleListView.UseCompatibleStateImageBehavior = false;
            this.scheduleListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "节点";
            this.columnHeader12.Width = 300;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "下一个";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "下一个（失败时）";
            this.columnHeader14.Width = 120;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.addNewScheduleEventButton);
            this.panel7.Controls.Add(this.editScheduleNodeButton);
            this.panel7.Controls.Add(this.deleteScheduleNodeButton);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(752, 33);
            this.panel7.TabIndex = 14;
            // 
            // addNewScheduleEventButton
            // 
            this.addNewScheduleEventButton.Location = new System.Drawing.Point(3, 4);
            this.addNewScheduleEventButton.Name = "addNewScheduleEventButton";
            this.addNewScheduleEventButton.Size = new System.Drawing.Size(75, 23);
            this.addNewScheduleEventButton.TabIndex = 12;
            this.addNewScheduleEventButton.Text = "添加新时点";
            this.addNewScheduleEventButton.UseVisualStyleBackColor = true;
            this.addNewScheduleEventButton.Click += new System.EventHandler(this.addNewScheduleEventButton_Click);
            // 
            // editScheduleNodeButton
            // 
            this.editScheduleNodeButton.Location = new System.Drawing.Point(84, 4);
            this.editScheduleNodeButton.Name = "editScheduleNodeButton";
            this.editScheduleNodeButton.Size = new System.Drawing.Size(97, 23);
            this.editScheduleNodeButton.TabIndex = 10;
            this.editScheduleNodeButton.Text = "修改选中节点";
            this.editScheduleNodeButton.UseVisualStyleBackColor = true;
            this.editScheduleNodeButton.Click += new System.EventHandler(this.editScheduleNodeButton_Click);
            // 
            // deleteScheduleNodeButton
            // 
            this.deleteScheduleNodeButton.Location = new System.Drawing.Point(187, 4);
            this.deleteScheduleNodeButton.Name = "deleteScheduleNodeButton";
            this.deleteScheduleNodeButton.Size = new System.Drawing.Size(97, 23);
            this.deleteScheduleNodeButton.TabIndex = 11;
            this.deleteScheduleNodeButton.Text = "删除选中节点";
            this.deleteScheduleNodeButton.UseVisualStyleBackColor = true;
            this.deleteScheduleNodeButton.Click += new System.EventHandler(this.deleteScheduleNodeButton_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.scheduleTreeView);
            this.tabPage7.Controls.Add(this.panel4);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(758, 435);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "树形图";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // scheduleTreeView
            // 
            this.scheduleTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.scheduleTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleTreeView.FullRowSelect = true;
            this.scheduleTreeView.HideSelection = false;
            this.scheduleTreeView.HotTracking = true;
            this.scheduleTreeView.Location = new System.Drawing.Point(3, 36);
            this.scheduleTreeView.Name = "scheduleTreeView";
            this.scheduleTreeView.Size = new System.Drawing.Size(752, 396);
            this.scheduleTreeView.TabIndex = 15;
            this.scheduleTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.scheduleTreeView_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(752, 33);
            this.panel4.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "添加新时点";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewScheduleEventButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "修改选中节点";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.editScheduleNodeButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(187, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "删除选中节点";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.deleteScheduleNodeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.loseTipTextBox);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.winTipTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.remarkTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 139);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "失败提示";
            // 
            // loseTipTextBox
            // 
            this.loseTipTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loseTipTextBox.Location = new System.Drawing.Point(65, 99);
            this.loseTipTextBox.Name = "loseTipTextBox";
            this.loseTipTextBox.Size = new System.Drawing.Size(1084, 21);
            this.loseTipTextBox.TabIndex = 19;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 481);
            this.panel2.TabIndex = 21;
            // 
            // ScheduleInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 620);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(900, 39);
            this.Name = "ScheduleInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "schedule信息";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.scheduleNodeTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ListView ScheduleNodeConditionListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView scheduleListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TreeView scheduleTreeView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.TextBox winTipTextBox;
        public System.Windows.Forms.TextBox remarkTextBox;
        public System.Windows.Forms.TextBox loseTipTextBox;
        public System.Windows.Forms.Button addScheduleNodeButton;
        public System.Windows.Forms.Button addNewScheduleEventButton;
        public System.Windows.Forms.Button editScheduleNodeButton;
        public System.Windows.Forms.Button deleteScheduleNodeButton;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.ListView ScheduleNodeFlowListView;
        public System.Windows.Forms.TabControl scheduleNodeTabControl;
        public System.Windows.Forms.ListView ScheduleNodeUnitListView;
        public System.Windows.Forms.ListView ScheduleNodeCellListView;
        public System.Windows.Forms.ListView ScheduleNodeOtherListView;
        public System.Windows.Forms.ListView ScheduleNodeWinLoseListView;
        public System.Windows.Forms.ListView ScheduleNodeWaitListView;
    }
}