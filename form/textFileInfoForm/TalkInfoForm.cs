using Heluo.Data;
using Heluo.Flow;
using Heluo.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using ListViewItem = System.Windows.Forms.ListViewItem;
using MessageType = Heluo.Data.MessageType;
using Talk = Heluo.Data.Talk;
using TextBox = System.Windows.Forms.TextBox;
using TreeView = System.Windows.Forms.TreeView;

namespace 侠之道mod制作器
{
    public partial class TalkInfoForm : Form
    {

        public string talkId;

        public TalkInfoForm()
        {
            InitializeComponent();

            Utils.initComboBox(EmotionTypeComboBox, typeof(EmotionType));
            Utils.initComboBox(MessageTypeComboBox, typeof(MessageType));
            Utils.initComboBox(NextTalkTypeComboBox, typeof(TalkType));



            initButtons();
        }

        public TalkInfoForm(string talkId,bool canEdit) : this()
        {
            this.talkId = talkId;

            if (!canEdit)
            {
                idTextBox.Enabled = false;
                TalkerIdTextBox.Enabled = false;
                selectNpcButton.Enabled = false;
                EmotionTypeComboBox.Enabled = false;
                MessageTypeComboBox.Enabled = false;
                AnimationTextBox.Enabled = false;
                NextTalkTypeComboBox.Enabled = false;
                NextTalkIdTextBox.Enabled = false;
                selectNextTalkButton.Enabled = false;
                FailTalkIdTextBox.Enabled = false;
                selectFailTalkButton.Enabled = false;
                MessageTextBox.Enabled = false;
                ConditionNodeListView.Enabled = false;
                ConditioNaddNodeButton.Enabled = false;
                ConditionAddLogicalNodeButton.Enabled = false;
                ConditionEditNodeButton.Enabled = false;
                ConditionDeleteNodeButton.Enabled = false;
                CinematicNodeOpenUIListView.Enabled = false;
                CinematicNodeModelAnimeListView.Enabled = false;
                CinematicNodeRewardListView.Enabled = false;
                CinematicNodeShowListView.Enabled = false;
                CinematicNodeOtherListView.Enabled = false;
                BehaviourAddNodeButton.Enabled = false;
                BehaviourAddMultiActionButton.Enabled = false;
                BehaviourEditNodeButton.Enabled = false;
                BehaviourDeleteNodeButton.Enabled = false;
                flowLayoutPanel1.Visible = false;
                updateFlowTreeButton.Enabled = false;
                saveButton.Enabled = false;
            }

            if (!talkId.IsNullOrEmpty())
            {
                this.readTalkInfo();
            }
        }

        public TreeView getTalkNodeTreeView()
        {
            return ConditionTreeView;
        }

        public void initEmotionTypeComboBox()
        {
            EmotionTypeComboBox.DisplayMember = "value";
            EmotionTypeComboBox.ValueMember = "key";
            foreach (EmotionType temp in Enum.GetValues(typeof(EmotionType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                EmotionTypeComboBox.Items.Add(cbi);
            }
        }

        public void initMessageTypeComboBox()
        {
            MessageTypeComboBox.DisplayMember = "value";
            MessageTypeComboBox.ValueMember = "key";
            foreach (MessageType temp in Enum.GetValues(typeof(MessageType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                MessageTypeComboBox.Items.Add(cbi);
            }
        }

        public void initNextTalkTypeComboBox()
        {
            NextTalkTypeComboBox.DisplayMember = "value";
            NextTalkTypeComboBox.ValueMember = "key";
            foreach (TalkType temp in Enum.GetValues(typeof(TalkType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                NextTalkTypeComboBox.Items.Add(cbi);
            }
        }


        public void initButtons()
        {
            foreach (Control button in flowLayoutPanel1.Controls)
            {
                if (button is Button)
                {
                    button.Click += (s, e) =>
                    {
                        setText(button.Text, MessageTextBox);
                    };

                    if (!button.Name.Contains("Appellation"))
                    {
                        continue;
                    }
                    else
                    {
                        string stringTableName = button.Name.Replace("button", "");
                        button.Text = "{" + DataManager.getStringTableTextRemark(stringTableName) + "}";
                    }
                }
            }
        }

        public void setText(string text, TextBox textBox)
        {
            if (text == "文字变红")
            {
                textBox.SelectedText = "<color=#FF0000>" + textBox.SelectedText + "</color>";
            }
            else
            {
                int index = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(index, text);
                textBox.SelectionStart = index + text.Length;
            }
            textBox.Focus();
            initTalkFlow();
        }

        public void readTalkInfo()
        {
            try
            {
                idTextBox.Text = talkId;
                idTextBox.Enabled = false;

                Talk talk = DataManager.getData<Talk>(talkId);

                if (talk != null)
                {

                    TalkerIdTextBox.Text = talk.TalkerId;
                    EmotionTypeComboBox.Text = EnumData.GetDisplayName(talk.EmotionType);
                    MessageTypeComboBox.Text = EnumData.GetDisplayName(talk.MessageType);
                    MessageTextBox.Text = Utils.replaceRichTextReadIn(talk.Message,flowLayoutPanel1);
                    FailTalkIdTextBox.Text = talk.FailTalkId;
                    NextTalkTypeComboBox.Text = EnumData.GetDisplayName(talk.NextTalkType);
                    NextTalkIdTextBox.Text = talk.NextTalkId;
                    AnimationTextBox.Text = talk.Animation;
                    Utils.initFlowTreeView(talk.Condition, ConditionTreeView);
                    Utils.initFlowTreeView(talk.Behaviour, BehaviourTreeView);

                    initTalkFlow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void initTalkFlow()
        {
            talkFlowTreeView.Nodes.Clear();
            TreeNode node = talkFlowTreeView.Nodes.Add("根节点");
            node.Tag = "root";
            readTalkFlow(talkId, node, "");
            talkFlowTreeView.ExpandAll();
        }

        public string getConditionStr(OutputNode condition)
        {
            string conditionStr = "";
            if (condition != null)
            {
                DescriptionAttribute description = (DescriptionAttribute)condition.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray = description.Value.Split('/');
                conditionStr = Utils.getFlowNodeStr(discriptionArray, condition, 0);
            }

            return conditionStr;
        }

        private void getAllChildNode(List<TreeNode> nodes, TreeNode node)
        {
            foreach (TreeNode thisNode in node.Nodes)
            {
                nodes.Add(thisNode);
                getAllChildNode(nodes, thisNode);
            }
        }

        public string getResultStr()
        {
            string result = idTextBox.Text + "\t" + TalkerIdTextBox.Text + "\t" + ((ComboBoxItem)EmotionTypeComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)MessageTypeComboBox.SelectedItem).key + "\t" + Utils.replaceRichTextWriteOut(MessageTextBox.Text,flowLayoutPanel1) + "\t" + FailTalkIdTextBox.Text + "\t" + ((ComboBoxItem)NextTalkTypeComboBox.SelectedItem).key + "\t" + NextTalkIdTextBox.Text + "\t" + AnimationTextBox.Text + "\t";

            if (ConditionTreeView.Nodes[0].Nodes.Count > 0)
            {
                result += "{" + Utils.BaseFlowGraphTagToStr(ConditionTreeView.Nodes[0]) + "}";
            }
            else
            {
                result += "0";
            }
            result += "\t";

            if (BehaviourTreeView.Nodes[0].Nodes.Count > 0)
            {
                result += "{" + Utils.BaseFlowGraphTagToStr(BehaviourTreeView.Nodes[0]) + "}";
            }
            else
            {
                result += "0";
            }


            return result;
        }


        private void readTalkFlow(string talkId, TreeNode parentNode, string talkIds)
        {
            if (!string.IsNullOrEmpty(talkId) && talkIds.Contains(talkId))
            {
                TreeNode node = parentNode.Nodes.Add("存在递归，跳转到" + talkId);
                node.Tag = "jumpTo-" + talkId;
                return;
            }
            Talk talk = null;
            if (talkId == this.talkId)
            {
                Type typeItemDic = typeof(CsvDataSource<>).MakeGenericType(new Type[]
                    {
                    typeof(Talk)
                    });
                string result = getResultStr();
                byte[] fileData = Encoding.UTF8.GetBytes(result);


                Dictionary<string, Talk> itemDic = (Activator.CreateInstance(typeItemDic, new object[] { fileData }) as Dictionary<string, Talk>);

                talk = itemDic[talkId];
            }
            else
            {
                talk = DataManager.getData<Talk>(talkId);
            }
            if (talk != null)
            {
                List<TreeNode> allChildNodes = new List<TreeNode>();
                getAllChildNode(allChildNodes, talkFlowTreeView.Nodes[0]);
                foreach (TreeNode node in allChildNodes)
                {
                    if (node.Text.Contains(talk.Id))
                    {
                        TreeNode talkNode = parentNode.Nodes.Add(talkId + "已存在，下略");
                        talkNode.Tag = "jumpTo-" + talkId;
                        return;
                    }
                }


                string talker = "";
                if (MessageTypeComboBox.SelectedItem == null)
                {
                    return;
                }
                MessageType messageType = talk.MessageType;
                if (messageType == MessageType.OptionOne || messageType == MessageType.OptionTwo || messageType == MessageType.OptionThree || messageType == MessageType.OptionFour)
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
                    talkNode.Tag = "TalkAction:\"" + talk.Id + "\"";
                    if (talk.Behaviour != null)
                    {
                        readBehavior((OutputNode)talk.Behaviour.Output, talkNode);
                        if (talkNode.Tag.ToString().Contains("RewardAction") || talkNode.Tag.ToString().Contains("Flag"))
                        {
                            talkNode.ForeColor = Color.Red;
                        }
                    }

                    if (!string.IsNullOrEmpty(talk.NextTalkId))
                    {
                        if (talk.NextTalkType == TalkType.Option)
                        {
                            TreeNode node = parentNode.Nodes.Add("选项");
                            string[] nextTalkIds = talk.NextTalkId.Split(',');
                            for (int i = 0; i < nextTalkIds.Length; i++)
                            {
                                readTalkFlow(nextTalkIds[i], node, talkIds + talkId + ",");
                            }
                        }
                        else if (talk.MessageType == MessageType.OptionOne || talk.MessageType == MessageType.OptionTwo || talk.MessageType == MessageType.OptionThree || talk.MessageType == MessageType.OptionFour)
                        {
                            readTalkFlow(talk.NextTalkId, talkNode, talkIds + talkId + ",");
                        }
                        else
                        {
                            readTalkFlow(talk.NextTalkId, parentNode, talkIds + talkId + ",");
                        }
                    }
                }
                else
                {
                    TreeNode node = parentNode.Nodes.Add(getConditionStr((OutputNode)talk.Condition.Output));

                    node.ForeColor = Color.Blue;
                    TreeNode successNode = node.Nodes.Add("成功");
                    TreeNode successNode1 = successNode.Nodes.Add(talker + ":(" + talkId + ")" + talk.Message);
                    successNode1.Tag = "TalkAction:\"" + talk.Id + "\"";
                    if (talk.Behaviour != null)
                    {
                        readBehavior((OutputNode)talk.Behaviour.Output, successNode1);
                        if (successNode1.Tag.ToString().Contains("RewardAction") || successNode1.Tag.ToString().Contains("Flag"))
                        {
                            successNode1.ForeColor = Color.Red;
                        }
                    }
                    if (talk.NextTalkType == TalkType.Option)
                    {
                        TreeNode node1 = successNode.Nodes.Add("选项");
                        string[] nextTalkIds = talk.NextTalkId.Split(',');
                        for (int i = 0; i < nextTalkIds.Length; i++)
                        {
                            readTalkFlow(nextTalkIds[i], node1, talkIds + talkId + ",");
                        }
                    }
                    else if (talk.MessageType == MessageType.OptionOne || talk.MessageType == MessageType.OptionTwo || talk.MessageType == MessageType.OptionThree || talk.MessageType == MessageType.OptionFour)
                    {
                        readTalkFlow(talk.NextTalkId, successNode1, talkIds + talkId + ",");
                    }
                    else
                    {
                        readTalkFlow(talk.NextTalkId, successNode, talkIds + talkId + ",");
                    }

                    if (!string.IsNullOrEmpty(talk.FailTalkId))
                    {
                        TreeNode failedNode = failedNode = node.Nodes.Add("失败");
                        readTalkFlow(talk.FailTalkId, failedNode, talkIds + talkId + ",");
                    }
                }
            }
        }

        private void readBehavior(OutputNode output, TreeNode parentNode)
        {
            MultiAction node = (MultiAction)output;
            for (int i = 0; i < node.actionListNode.Count; i++)
            {
                ActionNode actionNode = node.actionListNode[i];

                DescriptionAttribute description = (DescriptionAttribute)actionNode.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                string[] discriptionArray = description.Value.Split('/');

                parentNode.Text += "(" + Utils.getFlowNodeStr(discriptionArray, actionNode, 0) + ")";
                parentNode.Tag += ","+actionNode.GetType().Name;
            }

        }

        private void ConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ConditionTreeView);
        }
        private void addTalkNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionNodeListView, ConditionTreeView);
        }

        private void ConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionNodeListView, ConditionTreeView);
        }

        private void editTalkNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ConditionTreeView);
        }

        private void deleteTalkNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ConditionTreeView);
        }

        public bool checkInput()
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("请输入ID");
                return false;
            }
            if (string.IsNullOrEmpty(EmotionTypeComboBox.Text))
            {
                MessageBox.Show("请输入情感");
                return false;
            }
            if (string.IsNullOrEmpty(MessageTypeComboBox.Text))
            {
                MessageBox.Show("请输入讯息类型");
                return false;
            }
            if (string.IsNullOrEmpty(NextTalkTypeComboBox.Text))
            {
                MessageBox.Show("请输入下一个对话类型");
                return false;
            }
            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkInput())
                {
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Talk_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = getResultStr();

                if (content.Contains("\r\n" + idTextBox.Text + "\t"))
                {
                    string pattern = "\r\n" + idTextBox.Text + ".+?\r\n";
                    Regex rgx = new Regex(pattern);
                    content = rgx.Replace(content, "\r\n" + replacement + "\r\n");
                }
                else
                {
                    content += replacement;
                }
                while (content.StartsWith("\r\n"))
                {
                    content = content.Substring(2, content.Length - 2);
                }
                while (content.EndsWith("\r\n"))
                {
                    content = content.Substring(0, content.Length - 2);
                }

                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    sw.Write(content);
                }

                DataManager.LoadTextfile(typeof(Talk), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Talk列表
                //获得列表项
                ListViewItem lvi = DataManager.createTalkLvi(idTextBox.Text);


                

                

                if (DataManager.allTalkLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allTalkLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allTalkLvis.Add(idTextBox.Text, lvi);
                    if (MainForm.userControls.ContainsKey("Talk"))
                    {
                        TalkTabControlUserControl TalkTabControlUserControl = (TalkTabControlUserControl)MainForm.userControls["Talk"];
                        TalkTabControlUserControl.getTalkListView().Items.Add(lvi);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.createCinematicContextMenuStrip(contextMenuStrip1, BehaviourTreeView, e);
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.createCinematicContextMenuStrip(contextMenuStrip2, talkFlowTreeView, e);

            TreeNode node = talkFlowTreeView.SelectedNode;

            if (node.Tag == null)
            {
                e.Cancel = true;
                return;
            }

            string tag = node.Tag.ToString();

            if (tag.Contains("jumpTo"))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem("跳转至该节点");
                tsmi.Click += jumpToTalkToolStripMenuItem_Click;
                contextMenuStrip2.Items.Add(tsmi);
            }

            if (contextMenuStrip2.Items.Count > 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void readBuffToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string talkId = "";
            string tag = ConditionTreeView.SelectedNode.Tag.ToString();
            tag = tag.Substring(1, tag.Length - 2);
            string[] property = tag.Split(':')[1].Split(',');
            for (int i = 0; i < property.Length; i++)
            {
                string propertyStr = property[i].Trim();
                propertyStr = propertyStr.Substring(1, propertyStr.Length - 2);
                if (DataManager.dict["Talk"].Contains(propertyStr) || DataManager.dict["Talk_suc"].Contains(propertyStr))
                {
                    talkId = propertyStr;
                    break;
                }
            }


            TalkInfoForm form = new TalkInfoForm();
            form.talkId = talkId;

            /*form.readTalkInfo();
            form.idTextBox.Enabled = false;
            form.talkerIdTextBox.Enabled = false;
            form.messageTextBox.Enabled = false;
            form.emotionTypeComboBox.Enabled = false;
            form.TimesNumericUpDown.Enabled = false;
            form.overlayNumericUpDown.Enabled = false;
            form.nextTalkTypeComboBox.Enabled = false;
            form.animationTextBox.Enabled = false;
            form.addTalkNodeButton.Enabled = false;
            form.addNewTalkEventButton.Enabled = false;
            form.editTalkNodeButton.Enabled = false;
            form.deleteTalkNodeButton.Enabled = false;
            form.saveButton.Enabled = false;*/

            form.ShowDialog();
        }

        private void jumpToTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jumpToIndex = talkFlowTreeView.SelectedNode.Tag.ToString().Split('-')[1];

            TreeNode jumpNode = findNode(talkFlowTreeView.Nodes[0], "(" + jumpToIndex + ")");

            talkFlowTreeView.SelectedNode = jumpNode;
            jumpNode.Expand();
        }

        private TreeNode findNode(TreeNode node, string text)
        {
            if (node.Text.Contains(text))
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

        private void BehaviourAddMultiActionButton_Click(object sender, EventArgs e)
        {
            Utils.addMultiAction(BehaviourTreeView);
        }

        private void BehaviourAddNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cinematicNodeTabControl.SelectedIndex)
                {
                    case 0:
                        Utils.addConditionNode(CinematicNodeOpenUIListView, BehaviourTreeView);
                        break;
                    case 1:
                        Utils.addConditionNode(CinematicNodeModelAnimeListView, BehaviourTreeView);
                        break;
                    case 2:
                        Utils.addConditionNode(CinematicNodeRewardListView, BehaviourTreeView);
                        break;
                    case 3:
                        Utils.addConditionNode(CinematicNodeShowListView, BehaviourTreeView);
                        break;
                    case 4:
                        Utils.addConditionNode(CinematicNodeOtherListView, BehaviourTreeView);
                        break;
                }
                initTalkFlow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinematicNodeOpenUIListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(CinematicNodeOpenUIListView, BehaviourTreeView);
        }

        private void CinematicNodeModelAnimeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(CinematicNodeModelAnimeListView, BehaviourTreeView);
        }

        private void CinematicNodeRewardListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(CinematicNodeRewardListView, BehaviourTreeView);
        }

        private void CinematicNodeShowListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(CinematicNodeShowListView, BehaviourTreeView);
        }

        private void CinematicNodeOtherListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(CinematicNodeOtherListView, BehaviourTreeView);
        }

        private void BehaviourEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(BehaviourTreeView);
        }

        private void BehaviourDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(BehaviourTreeView);
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, TalkerIdTextBox, false);
            form.ShowDialog();
        }

        private void selectNextTalkButton_Click(object sender, EventArgs e)
        {
            SelectTalkForm form;
            if (NextTalkTypeComboBox.SelectedItem != null)
            {
                form = new SelectTalkForm(this, NextTalkIdTextBox, false, (TalkType)Enum.Parse(typeof(TalkType), ((ComboBoxItem)NextTalkTypeComboBox.SelectedItem).key));
            }
            else
            {
                form = new SelectTalkForm(this, NextTalkIdTextBox, false, TalkType.Message);
            }
            form.ShowDialog();
        }

        private void selectFailTalkButton_Click(object sender, EventArgs e)
        {
            SelectTalkForm form = new SelectTalkForm(this, FailTalkIdTextBox, false, TalkType.Message);
            form.ShowDialog();
        }

        private void updateFlowTreeButton_Click(object sender, EventArgs e)
        {
            if (!checkInput())
            {
                return;
            }
            initTalkFlow();
        }

        private void NextTalkTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
