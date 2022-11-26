using Heluo.Data;
using Heluo.Flow;
using Heluo.Flow.Battle;
using Heluo.Utility;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static RootMotion.FinalIK.IKSolver;

namespace 侠之道mod制作器
{
    public partial class ScheduleInfoForm : Form
    {

        public string scheduleId;

        public ScheduleInfoForm()
        {
            InitializeComponent();
        }

        public ScheduleInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public ScheduleInfoForm(string scheduleId,bool canEdit) : this()
        {
            this.scheduleId = scheduleId;

            if (!canEdit)
            {
                idTextBox.Enabled = false;
                nameTextBox.Enabled = false;
                remarkTextBox.Enabled = false;
                winTipTextBox.Enabled = false;
                loseTipTextBox.Enabled = false;
                splitContainer1.Panel1.Enabled = false;
                panel7.Visible = false;
                panel4.Visible = false;
                saveButton.Visible = false;
            }

            if (!scheduleId.IsNullOrEmpty())
            {
                readScheduleInfo();
            }
        }

        public ListView getScheduleListView()
        {
            return scheduleListView;
        }

        public void readScheduleInfo()
        {
            idTextBox.Text = scheduleId;
            idTextBox.Enabled = false;

            BattleScheduleBundle schedule = DataManager.getData<BattleScheduleBundle>("battle/schedule", scheduleId);

            if (schedule == null)
            {
                MessageBox.Show("读取失败，请检查");
                return;
            }
            nameTextBox.Text = string.IsNullOrEmpty(schedule.Name) ? "" : schedule.Name;
            remarkTextBox.Text = string.IsNullOrEmpty(schedule.Remark) ? "" : schedule.Remark;
            winTipTextBox.Text = string.IsNullOrEmpty(schedule.WinTip) ? "" : schedule.WinTip;
            loseTipTextBox.Text = string.IsNullOrEmpty(schedule.LoseTip) ? "" : schedule.LoseTip;



            for (int i = 0; i < schedule.Infos.Count; i++)
            {

                readSchedulesEffect(schedule.Infos[i]);
            }

            createScheduleTree();
        }

        public void readSchedulesEffect(BattleNodeSaveInfo bnsi)
        {
            ListViewItem lvi = new ListViewItem();

            DescriptionAttribute description = (DescriptionAttribute)bnsi.Node.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
            string[] discriptionArray = description.Value.Split('/');

            string nodeStr = Utils.getScheduleStr(discriptionArray, bnsi.Node, 0);


            lvi.Text = bnsi.Index.ToString();
            lvi.SubItems.Add(nodeStr);
            lvi.SubItems.Add(bnsi.Next.ToString());
            lvi.SubItems.Add(bnsi.Prallel.ToString());



            string[] NodeClassName = bnsi.Node.GetType().ToString().Split('.');
            string tag = getScheduleNodeTag(bnsi.Node, bnsi.Node.GetType());
            if (tag.Length > 0)
            {
                tag = " : " + tag.Substring(0, tag.Length - 2);
            }
            lvi.Tag = "\\\"" + NodeClassName[NodeClassName.Length - 1] + "\\\"" + tag;
            scheduleListView.Items.Add(lvi);
        }

        public void createScheduleTree()
        {
            scheduleTreeView.Nodes.Clear();
            for (int i = 0; i < scheduleListView.Items.Count; i++)
            {
                ListViewItem lvi = scheduleListView.Items[i];
                if (lvi.Tag.ToString().Contains("BattleEventNode"))
                {
                    TreeNode battleEventNode = scheduleTreeView.Nodes.Add(lvi.Text + "-" + lvi.SubItems[1].Text);
                    int next = int.Parse(lvi.SubItems[2].Text);
                    createScheduleTree(battleEventNode, next);
                }
            }
            scheduleTreeView.ExpandAll();
        }
        public void createScheduleTree(TreeNode parentNode, int index)
        {
            if (index == -1)
            {
                return;
            }
            ListViewItem lvi = scheduleListView.Items[index];
            string str = lvi.Tag.ToString();
            TreeNode node = parentNode.Nodes.Add(lvi.Text + "-" + lvi.SubItems[1].Text);
            if (str.Contains("BattleResultAddReward"))
            {
                node.ForeColor = Color.Red;
            }
            else if (str.Contains("BattleResultTalk"))
            {
                node.ForeColor = Color.Blue;
            }
            else if (str.Contains("Flag"))
            {
                node.ForeColor = Color.Orange;
            }
            else if (str.Contains("BattleBranchNode"))
            {
                node.ForeColor = Color.Green;
            }

            if (lvi.Tag.ToString().Contains("BattleBranchNode"))
            {
                TreeNode successNode = node.Nodes.Add("成功");

                int next = int.Parse(lvi.SubItems[2].Text);
                createScheduleTree(successNode, next);

                TreeNode failedNode = node.Nodes.Add("失败");

                int prallel = int.Parse(lvi.SubItems[3].Text);
                createScheduleTree(failedNode, prallel);
            }
            else
            {
                int next = int.Parse(lvi.SubItems[2].Text);
                if (lvi.Tag.ToString().Contains("StepByStepNode") || lvi.Tag.ToString().Contains("SequenceNode"))
                {

                    createScheduleTree(node, next);
                }
                else
                {
                    createScheduleTree(parentNode, next);
                }
            }
        }

        public string getScheduleNodeTag(BattleNode output, Type type)
        {
            string tag = "";

            if (type.BaseType != typeof(BattleNode))
            {
                tag += getScheduleNodeTag(output, type.BaseType);
            }

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.DeclaringType != type || (fieldInfo.GetCustomAttribute<InputFieldAttribute>() == null && fieldInfo.GetCustomAttribute<ArgumentAttribute>() == null))
                {
                    continue;
                }

                if (fieldInfo.FieldType.IsSubclassOf(typeof(Enum)))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(float))
                {
                    tag += ((float)fieldInfo.GetValue(output)).ToString("0.00000") + ", ";
                }
                else if (fieldInfo.FieldType == typeof(int))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(string))
                {
                    tag += "\\\"" + fieldInfo.GetValue(output) + "\\\", ";
                }
                else if (fieldInfo.FieldType == typeof(bool))
                {
                    tag += "" + fieldInfo.GetValue(output) + ", ";
                }
            }

            return tag;
        }


        private void addNewScheduleEventButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = scheduleListView.Items.Count.ToString();
            lvi.SubItems.Add(":");
            lvi.SubItems.Add("-1");
            lvi.SubItems.Add("-1");
            ScheduleEventNodeForm form = new ScheduleEventNodeForm(lvi, true, this);
            form.ShowDialog();
        }

        private void editScheduleNodeButton_Click(object sender, EventArgs e)
        {
            editOpenScheduleNodeInfoForm();
        }

        private void deleteScheduleNodeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("如果删除中间节点，后续节点编号都将减1补位，确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int index = scheduleListView.Items.IndexOf(scheduleListView.SelectedItems[0]);

                scheduleListView.Items.Remove(scheduleListView.SelectedItems[0]);

                for (int i = 0; i < scheduleListView.Items.Count; i++)
                {
                    if (int.Parse(scheduleListView.Items[i].Text) > index)
                    {
                        scheduleListView.Items[i].Text = (int.Parse(scheduleListView.Items[i].Text) - 1).ToString();
                    }

                    if (int.Parse(scheduleListView.Items[i].SubItems[2].Text) == index)
                    {
                        scheduleListView.Items[i].SubItems[2].Text = "-1";
                    }
                    else if (int.Parse(scheduleListView.Items[i].SubItems[2].Text) > index)
                    {
                        scheduleListView.Items[i].SubItems[2].Text = (int.Parse(scheduleListView.Items[i].SubItems[2].Text) - 1).ToString();
                    }

                    if (int.Parse(scheduleListView.Items[i].SubItems[3].Text) == index)
                    {
                        scheduleListView.Items[i].SubItems[3].Text = "-1";
                    }
                    else if (int.Parse(scheduleListView.Items[i].SubItems[3].Text) > index)
                    {
                        scheduleListView.Items[i].SubItems[3].Text = (int.Parse(scheduleListView.Items[i].SubItems[3].Text) - 1).ToString();
                    }
                }

                createScheduleTree();
            }
        }
        private void addScheduleNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (scheduleNodeTabControl.SelectedIndex)
                {
                    case 0:
                        addNode(ScheduleNodeFlowListView);
                        break;
                    case 1:
                        addNode(ScheduleNodeConditionListView);
                        break;
                    case 2:
                        addNode(ScheduleNodeUnitListView);
                        break;
                    case 3:
                        addNode(ScheduleNodeCellListView);
                        break;
                    case 4:
                        addNode(ScheduleNodeWinLoseListView);
                        break;
                    case 5:
                        addNode(ScheduleNodeWaitListView);
                        break;
                    case 6:
                        addNode(ScheduleNodeOtherListView);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addNode(ListView listView)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = scheduleListView.Items.Count.ToString();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("-1");
            lvi.SubItems.Add("-1");
            lvi.Tag = ":";

            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要添加的节点");
                return;
            }

            string className = "侠之道mod制作器." + listView.SelectedItems[0].SubItems[1].Text + "Form";
            Type clazz = Type.GetType(className);

            if (clazz != null)
            {
                object obj = Activator.CreateInstance(clazz, new object[] { lvi, true, this });

                MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                method.Invoke(obj, new object[] { });

                if (scheduleListView.Items.Contains(lvi))
                {
                    lvi.Selected = true;
                    scheduleListView.EnsureVisible(lvi.Index);
                }
            }
            else
            {
                MessageBox.Show("---未完成---");
            }
        }

        private void ScheduleNodeFlowListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodeConditionListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodePropertyListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodeScheduleListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodeOtherListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodeWinLoseListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }

        private void ScheduleNodeWaitListView_DoubleClick(object sender, EventArgs e)
        {
            addScheduleNodeButton_Click(sender, e);
        }



        public void editOpenScheduleNodeInfoForm()
        {
            try
            {
                if (scheduleListView.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = scheduleListView.SelectedItems[0];
                    if (lvi.Tag != null)
                    {
                        string tag = lvi.Tag.ToString().Split(':')[0].Trim();
                        tag = tag.Substring(2, tag.Length - 4);
                        if (tag.EndsWith("\""))
                        {
                            tag = tag.Substring(0, tag.Length - 1);
                        }
                        if (tag == "BattleEventNode")
                        {
                            ScheduleEventNodeForm form = new ScheduleEventNodeForm(lvi, false, this);
                            form.ShowDialog();
                        }
                        else
                        {
                            string className = "侠之道mod制作器." + tag + "Form";
                            Type clazz = Type.GetType(className);

                            if (clazz != null)
                            {
                                object obj = Activator.CreateInstance(clazz, new object[] { lvi, false, this });

                                MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                                method.Invoke(obj, new object[] { });
                            }
                            else
                            {
                                MessageBox.Show("---未完成---");
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("请输入ID");
                return;
            }
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("请输入名称");
                return;
            }
            if (string.IsNullOrEmpty(winTipTextBox.Text))
            {
                MessageBox.Show("请输入胜利条件");
                return;
            }
            if (string.IsNullOrEmpty(loseTipTextBox.Text))
            {
                MessageBox.Show("请输入失败条件");
                return;
            }
            if (scheduleListView.Items.Count == 0)
            {
                MessageBox.Show("请至少添加一个节点");
                return;
            }

            //写文件
            string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + idTextBox.Text + ".json";


            using (StreamWriter sw = new StreamWriter(savePath))
            {
                string result = "";
                result =
                    "{\n"
                    + "  \"Id\": \"" + idTextBox.Text + "\",\n"
                    + "  \"Name\": \"" + nameTextBox.Text + "\",\n"
                    + "  \"Infos\": "
                    + getOutputStr()
                    + "  \"Remark\": \"" + remarkTextBox.Text + "\",\n"
                    + "  \"WinTip\": \"" + winTipTextBox.Text + "\",\n"
                    + "  \"LoseTip\": \"" + winTipTextBox.Text + "\"\n"
                    + "}"
                    ;

                sw.Write(result);
            }
            //禁止修改id
            idTextBox.Enabled = false;

            //刷新schedule列表
            //获得列表项
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");


            if (DataManager.allBattleScheduleLvis.ContainsKey(idTextBox.Text))
            {
                lvi = DataManager.allBattleScheduleLvis[idTextBox.Text];
            }

            lvi.Text = idTextBox.Text;
            lvi.SubItems[1].Text = nameTextBox.Text;
            lvi.SubItems[2].Text = remarkTextBox.Text;
            lvi.SubItems[3].Text = winTipTextBox.Text;
            lvi.SubItems[4].Text = loseTipTextBox.Text;
            lvi.SubItems[5].Text = getOutputStr();
            lvi.SubItems[6].Text = "1";

            

            BattleScheduleBundle schedule = DataManager.loadData<BattleScheduleBundle>(MainForm.savePath + MainForm.modName + "\\" +DataManager.modBattleSchedulePath, idTextBox.Text + ".json");


            if (DataManager.dict["battle/schedule_cus"].Contains(idTextBox.Text))
            {
                DataManager.dict["battle/schedule_cus"][idTextBox.Text] = schedule;
            }
            else
            {
                DataManager.dict["battle/schedule_cus"].Add(idTextBox.Text, schedule);
            }

            BattleScheduleTabControlUserControl scheduleTabControlUserControl = (BattleScheduleTabControlUserControl)MainForm.userControls["battle/schedule"];
            if (DataManager.allBattleScheduleLvis.ContainsKey(lvi.Text))
            {
                ListViewItem oldLvi = DataManager.allBattleScheduleLvis[idTextBox.Text];
                for (int i = 0; i < oldLvi.SubItems.Count; i++)
                {
                    oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                }
            }
            else
            {
                DataManager.allBattleScheduleLvis.Add(idTextBox.Text, lvi);
                scheduleTabControlUserControl.getScheduleListView().Items.Add(lvi);
            }
        }

        private string getOutputStr()
        {
            string outputStr = "[\n";

            for (int i = 0; i < scheduleListView.Items.Count; i++)
            {
                ListViewItem lvi = scheduleListView.Items[i];
                outputStr +=
                    "    {\n"
                    + "      \"Index\": " + lvi.Text + ",\n"
                    + "      \"Node\": \"{ " + lvi.Tag + "} \",\n"
                    + "      \"Next\": " + lvi.SubItems[2].Text + ",\n"
                    + "      \"Prallel\": " + lvi.SubItems[3].Text + ",\n"
                    + "      \"Child\": []\n"
                    + "    },\n";
            }
            outputStr = outputStr.Substring(0, outputStr.Length - 2) + "\n";

            outputStr += "  ],\n";

            return outputStr;
        }

        private void scheduleTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string text = e.Node.Text;
            string indexStr = "-1";
            if (text.Contains("-"))
            {
                indexStr = text.Split('-')[0];
                if (indexStr.Contains("并行"))
                {
                    indexStr = indexStr.Split(':')[1];
                }
            }
            int index = int.Parse(indexStr);
            if (index == -1 || index > scheduleListView.Items.Count)
            {
                scheduleListView.SelectedItems.Clear();
            }
            else
            {
                scheduleListView.Items[index].Selected = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            ListViewItem lvi = scheduleListView.SelectedItems[0];

            if (lvi.Tag == null)
            {
                return;
            }
            if (lvi.Tag.ToString().Contains("Buff"))
            {
                Utils.addToolStripMenuItem("buffer", lvi.Tag.ToString(), contextMenuStrip1);
            }
            if (lvi.Tag.ToString().Contains("Talk"))
            {
                Utils.addToolStripMenuItem("Talk", lvi.Tag.ToString(), contextMenuStrip1);
            }
            if (lvi.Tag.ToString().Contains("EndBattleAction"))
            {
                Utils.addToolStripMenuItem("cinematic", lvi.Tag.ToString(), contextMenuStrip1);
            }

            if (contextMenuStrip1.Items.Count > 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ReadBuffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string bufferId = "";
            int index = int.Parse(scheduleListView.SelectedItems[0].Text);
            BattleScheduleBundle schedule = DataManager.getData<BattleScheduleBundle>("battle/schedule", scheduleId);
            BattleNodeSaveInfo bnsi = schedule.Infos[index];

            BattleNode scheduleNode = bnsi.Node;

            //单位加入增益
            if (scheduleNode.GetType() == typeof(BattleResultAddBuff))
            {
                BattleResultAddBuff node = (BattleResultAddBuff)scheduleNode;
                bufferId = node.buffId;
            }
            //阵营加入增益
            else if (scheduleNode.GetType() == typeof(BattleResultAddFactionBuff))
            {
                BattleResultAddFactionBuff node = (BattleResultAddFactionBuff)scheduleNode;
                bufferId = node.buffId;
            }
            //单位移除增益
            else if (scheduleNode.GetType() == typeof(BattleResultRmoveBuff))
            {
                BattleResultRmoveBuff node = (BattleResultRmoveBuff)scheduleNode;
                bufferId = node.buffId;
            }
            //阵营移除增益
            else if (scheduleNode.GetType() == typeof(BattleResultRmoveFactionBuff))
            {
                BattleResultRmoveFactionBuff node = (BattleResultRmoveFactionBuff)scheduleNode;
                bufferId = node.buffId;
            }

            BufferInfoForm form = new BufferInfoForm();
            form.bufferId = bufferId;

            form.readBufferInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.descTextBox.Enabled = false;
            form.iconNameComboBox.Enabled = false;
            form.TimesNumericUpDown.Enabled = false;
            form.overlayNumericUpDown.Enabled = false;
            form.orientedComboBox.Enabled = false;
            form.remarkTextBox.Enabled = false;
            form.addBufferNodeButton.Enabled = false;
            form.addNewBufferEventButton.Enabled = false;
            form.editBufferNodeButton.Enabled = false;
            form.deleteBufferNodeButton.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void readTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string talkId = "";
            int index = int.Parse(scheduleListView.SelectedItems[0].Text);
            BattleScheduleBundle schedule = DataManager.getData<BattleScheduleBundle>("battle/schedule", scheduleId);
            BattleNodeSaveInfo bnsi = schedule.Infos[index];

            BattleNode scheduleNode = bnsi.Node;

            //单位加入增益
            if (scheduleNode.GetType() == typeof(BattleResultTalk))
            {
                BattleResultTalk node = (BattleResultTalk)scheduleNode;
                talkId = node.TalkID;
            }

            TalkInfoForm form = new TalkInfoForm();
            form.talkId = talkId;

            form.readTalkInfo();
            form.idTextBox.Enabled = false;
            form.TalkerIdTextBox.Enabled = false;
            form.selectNpcButton.Enabled = false;
            form.EmotionTypeComboBox.Enabled = false;
            form.MessageTypeComboBox.Enabled = false;
            form.AnimationTextBox.Enabled = false;
            form.NextTalkTypeComboBox.Enabled = false;
            form.NextTalkIdTextBox.Enabled = false;
            form.FailTalkIdTextBox.Enabled = false;
            form.MessageTextBox.Enabled = false;
            form.ConditioNaddNodeButton.Enabled = false;
            form.BehaviourAddNodeButton.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }
    }
}
