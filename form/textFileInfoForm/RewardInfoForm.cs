using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Reward = Heluo.Data.Reward;

namespace 侠之道mod制作器
{
    public partial class RewardInfoForm : Form
    {

        public string rewardId;

        public RewardInfoForm()
        {
            InitializeComponent();

        }

        public RewardInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public RewardInfoForm(string rewardId) : this()
        {
            this.rewardId = rewardId;
        }

        public TreeView getRewardNodeTreeView()
        {
            return RewardsTreeView;
        }

        public void readRewardInfo()
        {
            idTextBox.Text = rewardId;
            idTextBox.Enabled = false;

            Reward reward = DataManager.getData<Reward>(rewardId);

            if (reward != null)
            {

                RemarkTextBox.Text = reward.Remark;
                IsShowMessageCheckBox.Checked = reward.IsShowMessage;
                DescriptionTextBox.Text = reward.Description;

                Utils.initFlowTreeView(reward.Rewards, RewardsTreeView);
            }

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

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Reward_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + IsShowMessageCheckBox.Checked + "\t" + DescriptionTextBox.Text + "\t";

                if (RewardsTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(RewardsTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }


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

                DataManager.LoadTextfile(typeof(Reward), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Reward列表
                //获得列表项
                ListViewItem lvi = DataManager.createRewardLvi(idTextBox.Text);


                

                RewardTabControlUserControl RewardTabControlUserControl = (RewardTabControlUserControl)MainForm.userControls["Reward"];

                if (DataManager.allRewardLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allRewardLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allRewardLvis.Add(idTextBox.Text, lvi);
                    RewardTabControlUserControl.getRewardListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RewardsAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(RewardsTreeView);
        }

        private void RewardsAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardsNodeListView, RewardsTreeView);
        }

        private void RewardsNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardsNodeListView, RewardsTreeView);
        }

        private void RewardsEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(RewardsTreeView);
        }

        private void RewardsDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(RewardsTreeView);
        }
    }
}
