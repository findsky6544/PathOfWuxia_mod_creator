using Heluo;
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Quest = Heluo.Data.Quest;

namespace 侠之道mod制作器
{
    public partial class QuestInfoForm : Form
    {

        public string questId;

        public QuestInfoForm()
        {
            InitializeComponent();

            initTypeComboBox();
            initscheduleComboBox();
            initListView();
        }

        public QuestInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public QuestInfoForm(string questId) : this()
        {
            this.questId = questId;
        }

        public TreeView getQuestNodeTreeView()
        {
            return ShowConditionTreeView;
        }

        public void initTypeComboBox()
        {
            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";
            foreach (QuestType temp in Enum.GetValues(typeof(QuestType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }

        public void initscheduleComboBox()
        {
            ScheduleComboBox.DisplayMember = "value";
            ScheduleComboBox.ValueMember = "key";
            foreach (Schedule temp in Enum.GetValues(typeof(Schedule)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ScheduleComboBox.Items.Add(cbi);
            }
        }

        public void initListView()
        {
            foreach (EvaluationLevel temp in Enum.GetValues(typeof(EvaluationLevel)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string id = "";
                string count = "0";
                lvi.SubItems.Add(DataManager.getPropssName(id));
                lvi.SubItems.Add(count);
                lvi.Tag = "[" + (int)temp + ",(" + id + "," + count + ")]";
                EvaluationRewardListView.Items.Add(lvi);
            }
        }

        public void readQuestInfo()
        {
            idTextBox.Text = questId;
            idTextBox.Enabled = false;

            Quest quest = DataManager.getData<Quest>(questId);

            if (quest != null)
            {

                NameTextBox.Text = quest.Name;
                ConsignorIdTextBox.Text = quest.ConsignorId;
                RemarkTextBox.Text = quest.Remark;
                TypeComboBox.Text = EnumData.GetDisplayName(quest.Type);
                BriefTextBox.Text = quest.Brief;
                DescriptionTextBox.Text = quest.Description;
                IsShowHintCheckBox.Checked = quest.IsShowHint;
                Utils.initFlowTreeView(quest.ShowCondition, ShowConditionTreeView);
                Utils.initFlowTreeView(quest.PickUpCondition, PickUpConditionTreeView);
                PickUpConditionDescriptionTextBox.Text = quest.PickUpConditionDescription;
                DeadLineTextBox.Text = quest.DeadLine;
                ScheduleComboBox.Text = EnumData.GetDisplayName((Schedule)quest.Schedule);

                EvaluationRewardListView.Items.Clear();
                foreach (EvaluationLevel temp in Enum.GetValues(typeof(EvaluationLevel)))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = EnumData.GetDisplayName(temp);
                    string id = "";
                    string count = "0";
                    if (quest.EvaluationReward != null && quest.EvaluationReward[temp] != null)
                    {
                        id = quest.EvaluationReward[temp].Id.Trim();
                        count = quest.EvaluationReward[temp].Count.ToString();
                    }
                    lvi.SubItems.Add(DataManager.getPropssName(id));
                    lvi.SubItems.Add(count);
                    lvi.Tag = "[" + (int)temp + ",(" + id + "," + count + ")]";
                    EvaluationRewardListView.Items.Add(lvi);
                }
                IsRepeatCheckBox.Checked = quest.IsRepeat;
                NextQuestIdTextBox.Text = quest.NextQuestId;
                FailQuestIdTextBox.Text = quest.FailQuestId;
                AdjustmentIdTextBox.Text = quest.AdjustmentId;


            }

        }

        private void ShowConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ShowConditionTreeView);
        }
        private void addQuestNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void ShowConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void editQuestNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ShowConditionTreeView);
        }

        private void deleteQuestNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ShowConditionTreeView);
        }

        private void PickUpConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(PickUpConditionTreeView);
        }

        private void PickUpConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(PickUpConditionNodeListView, PickUpConditionTreeView);
        }

        private void PickUpConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(PickUpConditionNodeListView, PickUpConditionTreeView);
        }

        private void PickUpConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(PickUpConditionTreeView);
        }

        private void PickUpConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(PickUpConditionTreeView);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("请输入ID");
                    return;
                }
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入名称");
                    return;
                }
                if (string.IsNullOrEmpty(TypeComboBox.Text))
                {
                    MessageBox.Show("请输入类型");
                    return;
                }
                if (string.IsNullOrEmpty(ScheduleComboBox.Text))
                {
                    MessageBox.Show("请输入所需日程");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Quest.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + ConsignorIdTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + "\t" + BriefTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + NextQuestIdTextBox.Text + "\t" + FailQuestIdTextBox.Text + "\t" + AdjustmentIdTextBox.Text + "\t" + IsShowHintCheckBox.Checked + "\t";

                if (ShowConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ShowConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";

                if (PickUpConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(PickUpConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + PickUpConditionDescriptionTextBox.Text + "\t" + DeadLineTextBox.Text + "\t" + ((ComboBoxItem)ScheduleComboBox.SelectedItem).key + "\t";

                string EvaluationReward = "";
                for (int i = 0; i < EvaluationRewardListView.Items.Count; i++)
                {
                    EvaluationReward += EvaluationRewardListView.Items[i].Tag;
                }
                replacement += EvaluationReward + "\t" + IsRepeatCheckBox.Checked + "\t" + "";

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

                DataManager.LoadTextfile(typeof(Quest), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Quest列表
                //获得列表项
                ListViewItem lvi = DataManager.createQuestLvi(idTextBox.Text);


                

                QuestTabControlUserControl QuestTabControlUserControl = (QuestTabControlUserControl)MainForm.userControls["Quest"];

                if (DataManager.allQuestLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allQuestLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allQuestLvis.Add(idTextBox.Text, lvi);
                    QuestTabControlUserControl.getQuestListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, ConsignorIdTextBox, false);
            form.ShowDialog();
        }

        private void selectNextQuestButton_Click(object sender, EventArgs e)
        {
            SelectQuestForm form = new SelectQuestForm(this, NextQuestIdTextBox, false);
            form.ShowDialog();
        }

        private void selectFailQuestButton_Click(object sender, EventArgs e)
        {
            SelectQuestForm form = new SelectQuestForm(this, FailQuestIdTextBox, false);
            form.ShowDialog();
        }

        private void selectAdjustmentButton_Click(object sender, EventArgs e)
        {
            SelectAdjustmentForm form = new SelectAdjustmentForm(this, AdjustmentIdTextBox, false);
            form.ShowDialog();
        }

        private void editRewardButton_Click(object sender, EventArgs e)
        {
            if (EvaluationRewardListView.SelectedItems.Count > 0)
            {
                EvaluationLevelForm form = new EvaluationLevelForm(EvaluationRewardListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }
    }

    public enum Schedule
    {
        [DisplayName("半日")]
        HalfDay,
        [DisplayName("一日")]
        FullDay,
        [DisplayName("不耗")]
        None
    }
}
