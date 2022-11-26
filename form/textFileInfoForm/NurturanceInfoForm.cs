
using Heluo.Data;
using Heluo.Utility;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Nurturance = Heluo.Data.Nurturance;

namespace 侠之道mod制作器
{
    public partial class NurturanceInfoForm : Form
    {

        public string NurturanceId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public NurturanceInfoForm()
        {
            InitializeComponent();

            initNurturanceFunctionComboBox();
            initOpenUITypeComboBox();
            initIconNameComboBox();
            initBackGroundComboBox();
        }

        public NurturanceInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public NurturanceInfoForm(string NurturanceId) : this()
        {
            this.NurturanceId = NurturanceId;
        }

        public void initNurturanceFunctionComboBox()
        {
            FuctionComboBox.DisplayMember = "value";
            FuctionComboBox.ValueMember = "key";


            foreach (NurturanceFunction temp in Enum.GetValues(typeof(NurturanceFunction)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                FuctionComboBox.Items.Add(cbi);
            }
        }

        public void initOpenUITypeComboBox()
        {
            UITypeComboBox.DisplayMember = "value";
            UITypeComboBox.ValueMember = "key";


            foreach (OpenUIType temp in Enum.GetValues(typeof(OpenUIType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                UITypeComboBox.Items.Add(cbi);
            }
        }

        public void initIconNameComboBox()
        {
            for (int i = 0; i < NurturanceImageList.Images.Count; i++)
            {
                string imageName = NurturanceImageList.Images.Keys[i];
                if (!IconNameComboBox.Items.Contains(imageName))
                {
                    IconNameComboBox.Items.Add(imageName);
                }
            }
        }

        public void initBackGroundComboBox()
        {
            for (int i = 0; i < backImageList.Images.Count; i++)
            {
                string imageName = backImageList.Images.Keys[i];
                imageName = imageName.Substring(0, imageName.LastIndexOf('_'));
                if (!BackGroundComboBox.Items.Contains(imageName))
                {
                    BackGroundComboBox.Items.Add(imageName);
                }
            }
        }

        public void readNurturanceInfo()
        {
            idTextBox.Text = NurturanceId;
            idTextBox.Enabled = false;

            Nurturance Nurturance = DataManager.getData<Nurturance>(NurturanceId);

            NameTextBox.Text = Nurturance.Name;
            DescriptionTextBox.Text = Nurturance.Description;
            for (int i = 0; i < FuctionComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)FuctionComboBox.Items[i]).key == ((int)Nurturance.Fuction).ToString())
                {
                    FuctionComboBox.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < UITypeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)UITypeComboBox.Items[i]).key == ((int)Nurturance.UIType).ToString())
                {
                    UITypeComboBox.SelectedIndex = i;
                    break;
                }
            }
            EmotionNumericUpDown.Value = Nurturance.Emotion;

            Utils.initFlowTreeView(Nurturance.ShowCondition, ShowConditionTreeView);
            Utils.initFlowTreeView(Nurturance.OpenCondition, OpenConditionTreeView);
            Utils.initFlowTreeView(Nurturance.AdditionCondition, AdditionConditionTreeView);
            AdditionValueNumericUpDown.Text = Nurturance.AdditionValue.ToString();
            AdditionTipTextBox.Text = Nurturance.AdditionTip;
            BackGroundComboBox.Text = Nurturance.BackGround;
            IconNameComboBox.Text = Nurturance.IconName;
            MovieNumberTextBox.Text = Nurturance.MovieNumber;
            NotOpenTipTextBox.Text = Nurturance.NotOpenTip;
            OtherTipTextBox.Text = Nurturance.OtherTip;
            FacilityTipTextBox.Text = Nurturance.FacilityTip;

            if (Nurturance.Rewards != null && Nurturance.Rewards.Count > 0)
            {
                for (int i = 0; i < Nurturance.Rewards.Count; i++)
                {
                    NurturanceReward reward = Nurturance.Rewards[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = EnumData.GetDisplayName(reward.Type);
                    switch (reward.Type)
                    {
                        case NurturanceRewardType.UpgradableProperty:
                            NurturanceRewardUpgradableProperty reward1 = (NurturanceRewardUpgradableProperty)reward;
                            lvi.SubItems.Add(EnumData.GetDisplayName(reward1.Prop));
                            lvi.Tag = "(" + (int)reward.Type + "," + (int)reward1.Prop + "," + reward.Value + ")";
                            break;
                        case NurturanceRewardType.CharacterProperty:

                            NurturanceRewardCharacterProperty reward2 = (NurturanceRewardCharacterProperty)reward;
                            lvi.SubItems.Add(EnumData.GetDisplayName(reward2.Prop));
                            lvi.Tag = "(" + (int)reward.Type + "," + (int)reward2.Prop + "," + reward.Value + ")";
                            break;
                        case NurturanceRewardType.Money:
                            lvi.SubItems.Add("");
                            lvi.Tag = "(" + (int)reward.Type + ",0," + reward.Value + ")";
                            break;
                    }
                    lvi.SubItems.Add(reward.Value.ToString());
                    RewardsListView.Items.Add(lvi);
                }
            }
        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void selectCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, MovieNumberTextBox, false);
            form.ShowDialog();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, MovieNumberTextBox, false);
            form.ShowDialog();
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, MovieNumberTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }

        private void selectRewardsButton_Click(object sender, EventArgs e)
        {
            SelectRewardForm form = new SelectRewardForm(this, AdditionTipTextBox, true);
            form.ShowDialog();
        }

        private void selectNotReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, NotOpenTipTextBox, false);
            form.ShowDialog();
        }

        private void selectReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, OtherTipTextBox, false);
            form.ShowDialog();
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
                    MessageBox.Show("请输入指令名称");
                    return;
                }
                if (string.IsNullOrEmpty(FuctionComboBox.Text))
                {
                    MessageBox.Show("请输入指令功能");
                    return;
                }
                if (string.IsNullOrEmpty(UITypeComboBox.Text))
                {
                    MessageBox.Show("请输入开启的界面");
                    return;
                }
                if (string.IsNullOrEmpty(EmotionNumericUpDown.Text))
                {
                    MessageBox.Show("请输入增加的疲惫值");
                    return;
                }
                if (string.IsNullOrEmpty(AdditionValueNumericUpDown.Text))
                {
                    MessageBox.Show("请输入加成数值");
                    return;
                }
                if (string.IsNullOrEmpty(IconNameComboBox.Text))
                {
                    MessageBox.Show("请输入图标");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Nurturance.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + ((ComboBoxItem)FuctionComboBox.SelectedItem).key + "\t";

                string UIType = "-1";

                if (UITypeComboBox.SelectedItem != null)
                {
                    UIType = ((ComboBoxItem)UITypeComboBox.SelectedItem).key;
                }
                replacement += UIType + "\t" + EmotionNumericUpDown.Text + "\t";

                if (ShowConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ShowConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";

                if (OpenConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(OpenConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";

                if (AdditionConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(AdditionConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";

                replacement += AdditionValueNumericUpDown.Text + "\t" + AdditionTipTextBox.Text + "\t" + BackGroundComboBox.Text + "\t" + IconNameComboBox.Text + "\t" + MovieNumberTextBox.Text + "\t" + NotOpenTipTextBox.Text + "\t" + OtherTipTextBox.Text + "\t" + FacilityTipTextBox.Text + "\t";

                for (int i = 0; i < RewardsListView.Items.Count; i++)
                {
                    replacement += RewardsListView.Items[i].Tag;
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

                DataManager.LoadTextfile(typeof(Nurturance), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Nurturance列表
                //获得列表项
                ListViewItem lvi = DataManager.createNurturanceLvi(idTextBox.Text);


                

                NurturanceTabControlUserControl NurturanceTabControlUserControl = (NurturanceTabControlUserControl)MainForm.userControls["Nurturance"];

                if (DataManager.allNurturanceLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allNurturanceLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allNurturanceLvis.Add(idTextBox.Text, lvi);
                    NurturanceTabControlUserControl.getNurturanceListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IconNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = IconNameComboBox.Text;
            if (!text.IsNullOrEmpty())
            {
                if ((NurturanceFunction)Enum.Parse(typeof(NurturanceFunction), ((ComboBoxItem)FuctionComboBox.SelectedItem).key) == NurturanceFunction.Firend)
                {
                    IconPictureBox.Image = HeadProtraitImageList.Images[HeadProtraitImageList.Images.IndexOfKey(text)];
                }
                else
                {
                    IconPictureBox.Image = NurturanceImageList.Images[NurturanceImageList.Images.IndexOfKey(text)];
                }
            }
            else
            {
                IconPictureBox.Image = null;
            }
        }

        private void changeRedButton_Click(object sender, EventArgs e)
        {
            FacilityTipTextBox.SelectedText = "<color=#FF0000>" + FacilityTipTextBox.SelectedText + "</color>";
        }

        private void readConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(OpenConditionTreeView);
        }

        private void addReadConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(OpenConditionNodeListView, OpenConditionTreeView);
        }

        private void readConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(OpenConditionTreeView);
        }

        private void readConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(OpenConditionTreeView);
        }

        private void showConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ShowConditionTreeView);
        }

        private void addShowConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void showConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ShowConditionTreeView);
        }

        private void showConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ShowConditionTreeView);
        }

        private void BackGroundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = BackGroundComboBox.Text + "_Day";
            dayPictureBox.Image = backImageList.Images[backImageList.Images.IndexOfKey(text)];
            text = BackGroundComboBox.Text + "_Night";
            nightPictureBox.Image = backImageList.Images[backImageList.Images.IndexOfKey(text)];
        }

        private void AdditionConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(AdditionConditionNodeListView, AdditionConditionTreeView);
        }

        private void AdditionConditionAddNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(AdditionConditionNodeListView, AdditionConditionTreeView);
        }

        private void AdditionConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(AdditionConditionTreeView);
        }

        private void AdditionConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(AdditionConditionTreeView);
        }

        private void AdditionConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(AdditionConditionTreeView);
        }

        private void addRewardButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Tag = "(,,0)";
            NurturanceInfoRewardForm form = new NurturanceInfoRewardForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RewardsListView.Items.Add(lvi);
            }
        }

        private void editRewardButton_Click(object sender, EventArgs e)
        {
            if (RewardsListView.SelectedItems.Count > 0)
            {
                NurturanceInfoRewardForm form = new NurturanceInfoRewardForm(RewardsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteRewardButton_Click(object sender, EventArgs e)
        {
            if (RewardsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    RewardsListView.Items.Remove(RewardsListView.SelectedItems[0]);
                }
            }
        }

        private void FuctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((NurturanceFunction)Enum.Parse(typeof(NurturanceFunction), ((ComboBoxItem)FuctionComboBox.SelectedItem).key) == NurturanceFunction.Firend)
            {
                IconNameComboBox.Items.Clear();
                for (int i = 0; i < HeadProtraitImageList.Images.Count; i++)
                {
                    string imageName = HeadProtraitImageList.Images.Keys[i];
                    if (!IconNameComboBox.Items.Contains(imageName))
                    {
                        IconNameComboBox.Items.Add(imageName);
                    }
                }
                IconNameComboBox.Text = "";
                IconPictureBox.Image = null;
            }
            else
            {
                IconNameComboBox.Items.Clear();
                for (int i = 0; i < NurturanceImageList.Images.Count; i++)
                {
                    string imageName = NurturanceImageList.Images.Keys[i];
                    if (!IconNameComboBox.Items.Contains(imageName))
                    {
                        IconNameComboBox.Items.Add(imageName);
                    }
                }
                IconNameComboBox.Text = "";
                IconPictureBox.Image = null;
            }
        }
    }

}
