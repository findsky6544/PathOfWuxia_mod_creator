using Heluo;
using Heluo.Data;
using Heluo.Flow;
using Heluo.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using UnityEngine;
using Color = System.Drawing.Color;

namespace 侠之道mod制作器
{
    public partial class CinematicInfoForm : Form
    {

        public string cinematicId;
        public ScheduleGraph.Bundle cinematic;

        string[] noFormAction = new string[] { "OpenUICommissionAction", "OpenUIElectiveAction", "OpenUIForgeAction", "OpenUINurturanceAction", "OpenUIPawnShopAction", "OpenUIReadingAction", "OpenUIRefiningAction", "OpenUIShopAction", "PlayerResetWeaponAction", "SortOutNpcAndEventCubeAction", "CameraLockPlayerAction", "CameraUnLockAction", "CameraUnShakeAction", "ElectiveCinematicAction", "NextOrEndQuestAction", "SaveAction" };
        public CinematicInfoForm()
        {
            InitializeComponent();
        }

        public CinematicInfoForm(string type,string cinematicId,bool canEdit) : this()
        {
            if(type == "cinematic")
            {
                Text = "cinematic信息";
            }
            else
            {
                Text = "config/schedule信息";
            }
            this.cinematicId = cinematicId;

            if (!canEdit)
            {
                idTextBox.Enabled = false;
                nameTextBox.Enabled = false;
                entryIndexNumericUpDown.Enabled = false;
                splitContainer1.Panel1.Enabled = false;
                panel7.Visible = false;
                panel4.Visible = false;
                saveButton.Visible = false;
            }

            if (!cinematicId.IsNullOrEmpty())
            {
                this.readCinematicInfo();
            }
        }

        public ListView getCinematicListView()
        {
            return cinematicListView;
        }

        public ScheduleGraph.Bundle readCinematic(string id)
        {
            ScheduleGraph.Bundle bundle;
            if (Text == "cinematic信息")
            {
                bundle = DataManager.getData<ScheduleGraph.Bundle>("cinematic", id);
            }
            else
            {
                bundle = DataManager.getData<ScheduleGraph.Bundle>("config/schedule", id);
            }
            return bundle;
        }

        public void readCinematicInfo()
        {
            try
            {
                idTextBox.Text = cinematicId;
                idTextBox.Enabled = false;

                cinematic = readCinematic(cinematicId);

                if (cinematic == null)
                {
                    MessageBox.Show("读取失败，请检查");
                    return;
                }
                nameTextBox.Text = string.IsNullOrEmpty(cinematic.Name) ? "" : cinematic.Name;
                entryIndexNumericUpDown.Value = cinematic.EntryIndex;



                for (int i = 0; i < cinematic.Nodes.Count; i++)
                {

                    readCinematicsEffect(cinematic.Nodes[i], i);
                }

                createCinematicTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void readCinematicsEffect(ScheduleGraph.Instruction ins, int index)
        {
            ListViewItem lvi = new ListViewItem();

            DescriptionAttribute description = (DescriptionAttribute)ins.Node.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
            string[] discriptionArray = description.Value.Split('/');

            string nodeStr = Utils.getFlowNodeStr(discriptionArray, ins.Node, 0);


            lvi.Text = index.ToString();
            lvi.SubItems.Add(nodeStr);
            lvi.SubItems.Add(ins.Next.ToString());
            lvi.SubItems.Add(ins.Prallel.ToString());

            if (ins.Node.GetType() == typeof(BranchAction))
            {
                BranchAction node = (BranchAction)ins.Node;
                lvi.SubItems.Add(node.trueNodeIndex.ToString());
                lvi.SubItems.Add(node.falseNodeIndex.ToString());
            }
            else
            {
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
            }



            string[] NodeClassName = ins.Node.GetType().ToString().Split('.');
            string tag = getCinematicNodeTag(ins.Node, ins.Node.GetType());
            if (tag.Length > 0)
            {
                tag = " : " + tag.Substring(0, tag.Length - 2);
            }
            lvi.Tag = "\"" + NodeClassName[NodeClassName.Length - 1] + "\"" + tag;
            cinematicListView.Items.Add(lvi);
        }

        public void createCinematicTree()
        {
            cinematicTreeView.Nodes.Clear();
            hasPassedNodeIndex = ",";
            TreeNode rootNode = cinematicTreeView.Nodes.Add("根节点");
            rootNode.Tag = "root";

            createCinematicTree(rootNode, (int)entryIndexNumericUpDown.Value, false, ",");
            cinematicTreeView.ExpandAll();
        }
        string hasPassedNodeIndex = ",";
        public void createCinematicTree(TreeNode parentNode, int index, bool isPrallel, string parentIndexs)
        {
            if (parentIndexs.Contains("," + index + ","))
            {
                TreeNode tempnode = parentNode.Nodes.Add("存在递归，跳转到" + index);
                tempnode.Tag = "jumpTo-" + index;
                return;
            }
            if (hasPassedNodeIndex.Contains("," + index + ","))
            {
                TreeNode tempnode = parentNode.Nodes.Add(index + "节点在其他节点已加载");
                tempnode.Tag = "jumpTo-" + index;
                return;
            }
            if (index == -1)
            {
                return;
            }
            if (index >= cinematicListView.Items.Count)
            {
                return;
            }
            ListViewItem lvi = cinematicListView.Items[index];
            string str = lvi.Tag.ToString();


            TreeNode node = parentNode.Nodes.Add((isPrallel ? "并行处理:" : "") + lvi.Text + "-" + lvi.SubItems[1].Text);
            hasPassedNodeIndex += index + ",";

            node.Tag = lvi.Tag;
            if (str.Contains("RewardAction"))
            {
                node.ForeColor = Color.Red;
            }
            else if (str.Contains("Flag"))
            {
                node.ForeColor = Color.Orange;
            }
            else if (str.Contains("BranchAction"))
            {
                node.ForeColor = Color.Green;
            }
            else if (str.Contains("RunCinematicAction"))
            {
                node.ForeColor = Color.Cyan;
            }
            else if (str.Contains("TalkAction"))
            {
                node.ForeColor = Color.Blue;
            }
            else if (str.Contains("BattleAction"))
            {
                node.ForeColor = Color.Purple;
            }

            int next;
            int prallel;

            if (str.Contains("BranchAction"))
            {
                TreeNode successNode = node.Nodes.Add("成功");

                next = int.Parse(lvi.SubItems[4].Text);
                createCinematicTree(successNode, next, false, parentIndexs + index + ",");

                prallel = int.Parse(lvi.SubItems[5].Text);
                if (prallel != -1)
                {
                    TreeNode failedNode = node.Nodes.Add("失败");
                    createCinematicTree(failedNode, prallel, false, parentIndexs + index + ",");
                }
            }
            next = int.Parse(lvi.SubItems[2].Text);
            createCinematicTree(parentNode, next, false, parentIndexs + index + ",");
            prallel = int.Parse(lvi.SubItems[3].Text);
            createCinematicTree(node, prallel, true, parentIndexs + index + ",");
        }
        private void readTalkFlow(string talkId, TreeNode parentNode)
        {
            Talk talk = DataManager.getData<Talk>(talkId);
            if (talk != null)
            {
                string talker = "";
                if (talk.MessageType == MessageType.OptionOne || talk.MessageType == MessageType.OptionTwo || talk.MessageType == MessageType.OptionThree || talk.MessageType == MessageType.OptionFour)
                {
                    talker = "(选项)";
                }
                else
                {
                    talker = DataManager.getNpcsName(talk.TalkerId);
                }
                if (talk.Condition == null)
                {
                    TreeNode talkNode = parentNode.Nodes.Add(talker + ":(" + talkId + ")" + talk.Message);
                    if (talk.Behaviour != null)
                    {
                        TreeNode node = talkNode.Nodes.Add("行为");
                        readBehavior((OutputNode)talk.Behaviour.Output, node);
                    }

                    if (!string.IsNullOrEmpty(talk.NextTalkId))
                    {
                        if (talk.NextTalkType == TalkType.Option)
                        {
                            TreeNode node = parentNode.Nodes.Add("选项");
                            string[] nextTalkIds = talk.NextTalkId.Split(',');
                            for (int i = 0; i < nextTalkIds.Length; i++)
                            {
                                readTalkFlow(nextTalkIds[i], node);
                            }
                        }
                        else if (talk.MessageType == MessageType.OptionOne || talk.MessageType == MessageType.OptionTwo || talk.MessageType == MessageType.OptionThree || talk.MessageType == MessageType.OptionFour)
                        {
                            readTalkFlow(talk.NextTalkId, talkNode);
                        }
                        else
                        {
                            readTalkFlow(talk.NextTalkId, parentNode);
                        }
                    }
                }
                else
                {
                    TreeNode node = parentNode.Nodes.Add(getConditionStr(talk.Condition));
                    TreeNode successNode = node.Nodes.Add("成功");
                    successNode.Nodes.Add(talker + ":(" + talkId + ")" + talk.Message);
                    readTalkFlow(talk.NextTalkId, successNode);

                    if (!string.IsNullOrEmpty(talk.FailTalkId))
                    {
                        TreeNode failedNode = node.Nodes.Add("失败");
                        readTalkFlow(talk.FailTalkId, failedNode);
                    }
                }
            }
        }
        public string getConditionStr(BaseFlowGraph condition)
        {
            string conditionStr = "";
            if (condition != null)
            {
                conditionStr = condition.ToString();
            }

            return conditionStr;
        }

        private void readBehavior(OutputNode output, TreeNode parentNode)
        {
            MultiAction node = (MultiAction)output;
            for (int i = 0; i < node.actionListNode.Count; i++)
            {
                ActionNode actionNode = node.actionListNode[i];

                DescriptionAttribute description = (DescriptionAttribute)actionNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray = description.Value.Split('/');

                parentNode.Nodes.Add(Utils.getFlowNodeStr(discriptionArray, actionNode, 0));
            }

        }

        public string getCinematicNodeTag(System.Object output, Type type)
        {
            string tag = "";

            if (type.IsSubclassOf(typeof(OutputNode)) && type.BaseType != typeof(OutputNode))
            {
                tag += getCinematicNodeTag(output, type.BaseType);
            }

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.DeclaringType != type || (fieldInfo.GetCustomAttribute<InputFieldAttribute>() == null && fieldInfo.GetCustomAttribute<DisplayNameAttribute>() == null && fieldInfo.GetCustomAttribute<ArgumentAttribute>() == null))
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
                    tag += "\"" + fieldInfo.GetValue(output) + "\", ";
                }
                else if (fieldInfo.FieldType == typeof(bool))
                {
                    tag += fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(Vector3))
                {
                    Vector3 vector = (Vector3)fieldInfo.GetValue(output);
                    tag += "{" + vector.x.ToString("0.00000") + ", " + vector.y.ToString("0.00000") + ", " + vector.z.ToString("0.00000") + "}, ";
                }
                else if (fieldInfo.FieldType == typeof(List<AnimationCilpInfo>))
                {
                    tag += "[";

                    List<AnimationCilpInfo> animationClipInfos = (List<AnimationCilpInfo>)fieldInfo.GetValue(output);
                    for (int i = 0; i < animationClipInfos.Count; i++)
                    {
                        string tempTag = getCinematicNodeTag(animationClipInfos[i], typeof(AnimationCilpInfo));
                        tag += "{" + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    if (tag.Length > 1)
                    {
                        tag = tag.Substring(0, tag.Length - 2);
                    }

                    tag += "], ";
                }
                else if (fieldInfo.FieldType == typeof(List<GroupTransformAction.TransformInfo>))
                {
                    tag += "[";

                    List<GroupTransformAction.TransformInfo> infos = (List<GroupTransformAction.TransformInfo>)fieldInfo.GetValue(output);
                    for (int i = 0; i < infos.Count; i++)
                    {
                        string tempTag = getCinematicNodeTag(infos[i], typeof(GroupTransformAction.TransformInfo));
                        tag += "{" + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    if (tag.Length > 1)
                    {
                        tag = tag.Substring(0, tag.Length - 2);
                    }

                    tag += "], ";
                }
                else if (fieldInfo.FieldType.IsSubclassOf(typeof(OutputNode)))
                {
                    OutputNode outputNode = (OutputNode)fieldInfo.GetValue(output);
                    string name = outputNode.GetType().Name;
                    string tempTag = getCinematicNodeTag(outputNode, outputNode.GetType());
                    tag += "{ \"" + name + "\" : " + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                }
                else if (fieldInfo.FieldType == typeof(List<OutputNode<bool>>))
                {
                    tag += "[";
                    List<OutputNode<bool>> list = (List<OutputNode<bool>>)fieldInfo.GetValue(output);
                    for (int i = 0; i < list.Count; i++)
                    {
                        string tempTag = getCinematicNodeTag(list[i], list[i].GetType());
                        tag += "{ \"" + list[i].GetType().Name + "\" : " + tempTag.Substring(0, tempTag.Length - 2) + "}, ";
                    }

                    tag = tag.Substring(0, tag.Length - 2);
                    tag += "], ";
                }
            }

            return tag;
        }
        private void addCinematicNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cinematicNodeTabControl.SelectedIndex)
                {
                    case 0:
                        addCinematicNodeButton_click_common(CinematicNodeOpenUIListView);
                        break;
                    case 1:
                        addCinematicNodeButton_click_common(CinematicNodeModelAnimeListView);
                        break;
                    case 2:
                        addCinematicNodeButton_click_common(CinematicNodeRewardListView);
                        break;
                    case 3:
                        addCinematicNodeButton_click_common(CinematicNodeShowListView);
                        break;
                    case 4:
                        addCinematicNodeButton_click_common(CinematicNodeOtherListView);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addCinematicNodeButton_click_common(ListView listView)
        {
            try
            {

                if (listView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要添加的节点");
                    return;
                }

                bool isAdd = false;

                ListViewItem lvi = new ListViewItem();
                lvi.Text = cinematicListView.Items.Count.ToString();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("-1");
                lvi.SubItems.Add("-1");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.Tag = ":";

                if (noFormAction.Contains(listView.SelectedItems[0].SubItems[1].Text))
                {
                    isAdd = true;
                    lvi.SubItems[1].Text = listView.SelectedItems[0].Text;
                    lvi.Tag = "\"" + listView.SelectedItems[0].SubItems[1].Text + "\"";
                }
                else
                {
                    string className = "侠之道mod制作器." + listView.SelectedItems[0].SubItems[1].Text + "Form";
                    if (className == "侠之道mod制作器.NPCTransformActionForm")
                    {
                        className = "侠之道mod制作器.NPCTransformActionForm2";
                    }
                    Type clazz = Type.GetType(className);


                    if (className.Contains("BranchAction"))
                    {
                        BranchActionForm form = new BranchActionForm(lvi, true, this);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            isAdd = false;
                        }
                    }
                    else if (clazz != null)
                    {
                        object obj = Activator.CreateInstance(clazz, new object[] { lvi, true });

                        MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                        if ((DialogResult)method.Invoke(obj, new object[] { }) == DialogResult.OK)
                        {
                            isAdd = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("---未完成---");
                    }
                }

                if (isAdd)
                {
                    cinematicListView.Items.Add(lvi);
                    if (cinematicListView.Items.Count == 1)
                    {
                        entryIndexNumericUpDown.Text = lvi.Text;
                    }
                    if (cinematicListView.SelectedItems.Count > 0)
                    {
                        lvi.SubItems[2].Text = cinematicListView.SelectedItems[0].SubItems[2].Text;
                        cinematicListView.SelectedItems[0].SubItems[2].Text = lvi.Text;
                    }
                    lvi.Selected = true;
                    cinematicListView.EnsureVisible(lvi.Index);

                    createCinematicTree();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editCinematicNodeButton_Click(object sender, EventArgs e)
        {
            editOpenCinematicNodeInfoForm();
        }

        private void editNewCinematicEventButton2_Click(object sender, EventArgs e)
        {
            editOpenCinematicNodeInfoForm();
        }

        public void editOpenCinematicNodeInfoForm()
        {
            try
            {
                if (cinematicListView.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = cinematicListView.SelectedItems[0];
                    if (lvi.Tag != null)
                    {
                        string tag = lvi.Tag.ToString().Split(':')[0].Trim();
                        tag = tag.Substring(1, tag.Length - 2);
                        if (tag.EndsWith("\""))
                        {
                            tag = tag.Substring(0, tag.Length - 1);
                        }
                        if (tag == "BranchAction")
                        {
                            BranchActionForm form = new BranchActionForm(lvi, false, this);
                            form.ShowDialog();
                        }
                        else if (noFormAction.Contains(tag))
                        {
                            MessageBox.Show("该节点无需修改");
                        }
                        else
                        {
                            string className = "侠之道mod制作器." + tag + "Form";
                            if (className == "侠之道mod制作器.NPCTransformActionForm")
                            {
                                className = "侠之道mod制作器.NPCTransformActionForm2";
                            }
                            Type clazz = Type.GetType(className);

                            if (clazz != null)
                            {
                                object obj = Activator.CreateInstance(clazz, new object[] { lvi, false });

                                MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                                if ((DialogResult)method.Invoke(obj, new object[] { }) == DialogResult.OK)
                                {

                                    createCinematicTree();
                                }
                            }
                            else
                            {
                                MessageBox.Show("---未完成---");
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void deleteCinematicNodeButton_Click(object sender, EventArgs e)
        {
            int i = cinematicListView.SelectedItems[0].Index;
            deleteCinematicNode();

            if (cinematicListView.Items.Count >= i + 1)
            {
                cinematicListView.Items[i].Selected = true;
            }
            else if (cinematicListView.Items.Count > 0)
            {
                cinematicListView.Items[i - 1].Selected = true;
            }
        }

        private void deleteNewCinematicEventButton2_Click(object sender, EventArgs e)
        {
            deleteCinematicNode();
        }

        private void deleteCinematicNode()
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int index = cinematicListView.SelectedItems[0].Index;
                    cinematicListView.Items.Remove(cinematicListView.SelectedItems[0]);
                    for (int i = index; i < cinematicListView.Items.Count; i++)
                    {
                        cinematicListView.Items[i].Text = (int.Parse(cinematicListView.Items[i].Text) - 1).ToString();
                        cinematicListView.Items[i].SubItems[2].Text = (Math.Max(-1, int.Parse(cinematicListView.Items[i].SubItems[2].Text) - 1)).ToString();
                        cinematicListView.Items[i].SubItems[3].Text = (Math.Max(-1, int.Parse(cinematicListView.Items[i].SubItems[3].Text) - 1)).ToString();
                    }
                    createCinematicTree();
                }
            }
        }

        private void NextOrPrallelEditButton_Click(object sender, EventArgs e)
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = cinematicListView.SelectedItems[0];
                NextOrPrallelForm form = new NextOrPrallelForm(lvi, this);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    createCinematicTree();
                }
            }
        }

        private void NextOrPrallelEditButton2_Click(object sender, EventArgs e)
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = cinematicListView.SelectedItems[0];
                NextOrPrallelForm form = new NextOrPrallelForm(lvi, this);
                form.ShowDialog();
            }
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("请输入ID");
                return;
            }
            /*if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("请输入名称");
                return;
            }*/
            if (string.IsNullOrEmpty(entryIndexNumericUpDown.Text))
            {
                MessageBox.Show("请输入进入点");
                return;
            }


            string savePath = "";
            //写文件
            if (Text == "cinematic信息")
            {
                savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + idTextBox.Text + ".json";
            }
            else
            {
                savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + idTextBox.Text + ".json";
            }


            using (StreamWriter sw = new StreamWriter(savePath))
            {
                string result = "";
                result =
                    "{\n"
                    + "  \"EntryIndex\": " + entryIndexNumericUpDown.Text + ",\n"
                    + "  \"Nodes\":[\n"
                    + getOutputStr()
                    + "],\n"
                    + "  \"Name\": \"" + nameTextBox.Text + "\"\n"
                    + "}"
                    ;

                sw.Write(result);
            }
            //禁止修改id
            idTextBox.Enabled = false;

            //刷新buff列表
            //获得列表项
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");


            if (DataManager.allCinematicLvis.ContainsKey(idTextBox.Text))
            {
                lvi = DataManager.allCinematicLvis[idTextBox.Text];
            }

            lvi.Text = idTextBox.Text;
            lvi.SubItems[1].Text = nameTextBox.Text;
            lvi.SubItems[2].Text = entryIndexNumericUpDown.Text;
            lvi.SubItems[3].Text = getOutputStr();
            lvi.SubItems[4].Text = "1";

            cinematic = DataManager.loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\config\\cinematic", idTextBox.Text + ".json");


            if (Text == "cinematic信息")
            {
                cinematic = DataManager.loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\config\\cinematic", idTextBox.Text + ".json");
                if (DataManager.dict["cinematic_cus"].Contains(idTextBox.Text))
                {
                    DataManager.dict["cinematic_cus"][idTextBox.Text] = cinematic;
                }
                else
                {
                    DataManager.dict["cinematic_cus"].Add(idTextBox.Text, cinematic);
                }
                if (DataManager.allCinematicLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allCinematicLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allCinematicLvis.Add(idTextBox.Text, lvi);
                    if (MainForm.userControls.ContainsKey("cinematic"))
                    {
                        CinematicTabControlUserControl cinematicTabControlUserControl = (CinematicTabControlUserControl)MainForm.userControls["cinematic"];
                        cinematicTabControlUserControl.getCinematicListView().Items.Add(lvi);
                    }
                }
            }
            else
            {
                cinematic = DataManager.loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\config\\schedule", idTextBox.Text + ".json");
                if (DataManager.dict["config/schedule_cus"].Contains(idTextBox.Text))
                {
                    DataManager.dict["config/schedule_cus"][idTextBox.Text] = cinematic;
                }
                else
                {
                    DataManager.dict["config/schedule_cus"].Add(idTextBox.Text, cinematic);
                }
                if (DataManager.allConfigScheduleLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allConfigScheduleLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allConfigScheduleLvis.Add(idTextBox.Text, lvi);
                    if (MainForm.userControls.ContainsKey("config/schedule"))
                    {
                        ConfigScheduleTabControlUserControl configScheduleTabControlUserControl = (ConfigScheduleTabControlUserControl)MainForm.userControls["config/schedule"];
                        configScheduleTabControlUserControl.getScheduleListView().Items.Add(lvi);
                    }
                }
            }

        }

        private string getOutputStr()
        {
            string outputStr = "";

            if (cinematicListView.Items.Count > 0)
            {
                for (int i = 0; i < cinematicListView.Items.Count; i++)
                {
                    ListViewItem lvi = cinematicListView.Items[i];
                    outputStr +=
                        "    {\n"
                        + "      \"Node\": \"{ " + lvi.Tag.ToString().Replace("\"", "\\\"") + "} \",\n"
                        + "      \"Next\": " + lvi.SubItems[2].Text + ",\n"
                        + "      \"Prallel\": " + lvi.SubItems[3].Text + "\n"
                        + "    },\n";
                }
                outputStr = outputStr.Substring(0, outputStr.Length - 2) + "\n";
            }

            return outputStr;
        }

        private void cinematicTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
            if (index == -1 || index > cinematicListView.Items.Count)
            {
                cinematicListView.SelectedItems.Clear();
            }
            else
            {
                cinematicListView.Items[index].Selected = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.createCinematicContextMenuStrip(contextMenuStrip1, cinematicTreeView,e);



            TreeNode node = cinematicTreeView.SelectedNode;

            if (node.Tag == null)
            {
                return;
            }

            string tag = node.Tag.ToString();

            if (tag.Contains("jumpTo"))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem("跳转至该节点");
                tsmi.Click += JumpNodeToolStripMenuItem_Click;
                contextMenuStrip1.Items.Add(tsmi);
                contextMenuStrip1.Items.Add(new ToolStripSeparator());
            }
        }

        private void readTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string talkId = "";
            string temp = "{\"Node\": \"{" + cinematicListView.SelectedItems[0].Tag.ToString().Replace("\"", "\\\"") + "} \",\"Next\": -1,\"Prallel\": -1}";
            ScheduleGraph.Instruction bnsi = DataManager.loadData<ScheduleGraph.Instruction>(temp);

            ActionNode scheduleNode = bnsi.Node;

            if (scheduleNode.GetType() == typeof(TalkAction))
            {
                TalkAction node = (TalkAction)scheduleNode;
                talkId = node.talkId;
            }

            TalkInfoForm form = new TalkInfoForm(talkId,false);

            form.Show();
        }

        private void JumpNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jumpToIndex = cinematicTreeView.SelectedNode.Tag.ToString().Split('-')[1];

            TreeNode jumpNode = findNode(cinematicTreeView.Nodes[0], jumpToIndex + "-");

            if (jumpNode != null)
            {
                cinematicTreeView.SelectedNode = jumpNode;
                jumpNode.Expand();
            }
        }

        private TreeNode findNode(TreeNode node, string text)
        {
            if (node.Text.StartsWith(text) || node.Text.StartsWith("并行处理:" + text))
            {
                return node;
            }
            else
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    TreeNode node1 = findNode(node.Nodes[i], text);
                    if (node1 != null)
                    {
                        return node1;
                    }
                }
                return null;
            }
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string cinematicId = "";
            string temp = "{\"Node\": \"{" + cinematicListView.SelectedItems[0].Tag.ToString().Replace("\"", "\\\"") + "} \",\"Next\": -1,\"Prallel\": -1}";
            ScheduleGraph.Instruction bnsi = DataManager.loadData<ScheduleGraph.Instruction>(temp);

            ActionNode scheduleNode = bnsi.Node;

            if (scheduleNode.GetType() == typeof(RunCinematicAction))
            {
                RunCinematicAction node = (RunCinematicAction)scheduleNode;
                cinematicId = node.cinematicId;
            }

            CinematicInfoForm form = new CinematicInfoForm("cinematic",cinematicId,false);

            form.Show();
        }

        private void readBattleAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string battleAreaId = "";
                string temp = "{\"Node\": \"{" + cinematicListView.SelectedItems[0].Tag.ToString().Replace("\"", "\\\"") + "} \",\"Next\": -1,\"Prallel\": -1}";
                ScheduleGraph.Instruction bnsi = DataManager.loadData<ScheduleGraph.Instruction>(temp);

                ActionNode scheduleNode = bnsi.Node;

                if (scheduleNode.GetType() == typeof(BattleAction))
                {
                    BattleAction node = (BattleAction)scheduleNode;
                    battleAreaId = node.battleId;
                }

                BattleAreaInfoForm form = new BattleAreaInfoForm();
                form.battleAreaId = battleAreaId;

                form.readBattleAreaInfo();
                form.idTextBox.Enabled = false;
                form.battleMapTextBox.Enabled = false;
                form.scheduleIDTextBox.Enabled = false;
                form.musicNameTextBox.Enabled = false;
                form.afterWinMovieTextBox.Enabled = false;
                form.afterLoseMovieTextBox.Enabled = false;
                form.remarkTextBox.Enabled = false;
                form.addDropButton.Enabled = false;
                form.editDropButton.Enabled = false;
                form.deleteDropButton.Enabled = false;
                form.saveButton.Enabled = false;

                form.selectWinCinematicButton.Text = "查看cinematic";
                form.selectWinCinematicButton.Click += new System.EventHandler(form.jumpToCinematicInfoForm);

                form.selectLoseCinematicButton.Text = "查看cinematic";
                form.selectLoseCinematicButton.Click += new System.EventHandler(form.jumpToCinematicInfoForm);

                form.selectBattleScheduleButton.Text = "查看schedule";
                form.selectBattleScheduleButton.Click += new System.EventHandler(form.jumpToScheduleInfoForm);

                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void entryIndexNumericUpDown_Leave(object sender, EventArgs e)
        {
            createCinematicTree();
        }

        private void cinematicListView_DoubleClick(object sender, EventArgs e)
        {
            editOpenCinematicNodeInfoForm();
        }

        private void cinematicListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cinematicListView.SelectedItems.Count > 0)
            {
                TreeNode jumpNode = findNode(cinematicTreeView.Nodes[0], cinematicListView.SelectedItems[0].Text + "-");

                if (jumpNode != null)
                {
                    cinematicTreeView.SelectedNode = jumpNode;
                    jumpNode.Expand();
                }
            }
        }
    }
}
