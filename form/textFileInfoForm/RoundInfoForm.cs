using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Round = Heluo.Data.Round;

namespace 侠之道mod制作器
{
    public partial class RoundInfoForm : Form
    {

        public string RoundId;

        public RoundInfoForm()
        {
            InitializeComponent();

            initWeatherTypeComboBox();
        }

        public RoundInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public RoundInfoForm(string RoundId) : this()
        {
            this.RoundId = RoundId;
        }

        public void initWeatherTypeComboBox()
        {
            WeatherTypeComboBox.DisplayMember = "value";
            WeatherTypeComboBox.ValueMember = "key";
            foreach (WeatherType temp in Enum.GetValues(typeof(WeatherType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                WeatherTypeComboBox.Items.Add(cbi);
            }
            WeatherTypeComboBox.SelectedIndex = 0;
        }

        public void readRoundInfo()
        {
            idTextBox.Text = RoundId;
            idTextBox.Enabled = false;

            Round Round = DataManager.getData<Round>(RoundId);

            if (Round != null)
            {
                NameTextBox.Text = Round.Name;
                Utils.initFlowTreeView(Round.EventNameCondition, EventNameConditionTreeView);
                EventNameTextBox.Text = Round.EventName;
                RemarkTextBox.Text = Round.Remark;
                WeatherTypeComboBox.Text = EnumData.GetDisplayName(Round.WeatherType);
                IsGroupPracticeCheckBox.Checked = Round.IsGroupPractice;
                IsInternalPracticeCheckBox.Checked = Round.IsInternalPractice;
                BeginMapIdTextBox.Text = Round.BeginMapId;
                BeginCinematicIdTextBox.Text = Round.BeginCinematicId;
                ForceMapIdTextBox.Text = Round.ForceMapId;
                ForceCinematicIdTextBox.Text = Round.ForceCinematicId;
                Utils.initFlowTreeView(Round.BeginCondition, BeginConditionTreeView);
                FriendMessagingIdTextBox.Text = Round.FriendMessagingId;
                ToolManMessagingIdTextBox.Text = Round.ToolManMessagingId;

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
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入名称");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Round_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t";

                if (EventNameConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(EventNameConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }

                replacement += "\t" + EventNameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + ((ComboBoxItem)WeatherTypeComboBox.SelectedItem).key + "\t" + FriendMessagingIdTextBox.Text + "\t" + ToolManMessagingIdTextBox.Text + "\t" + IsGroupPracticeCheckBox.Checked + "\t" + IsInternalPracticeCheckBox.Checked + "\t" + BeginMapIdTextBox.Text + "\t" + BeginCinematicIdTextBox.Text + "\t" + ForceMapIdTextBox.Text + "\t" + ForceCinematicIdTextBox.Text + "\t";

                if (BeginConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(BeginConditionTreeView.Nodes[0]) + "}";
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

                DataManager.LoadTextfile(typeof(Round), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Round列表
                //获得列表项
                ListViewItem lvi = DataManager.createRoundLvi(idTextBox.Text);


                

                RoundTabControlUserControl RoundTabControlUserControl = (RoundTabControlUserControl)MainForm.userControls["Round"];

                if (DataManager.allRoundLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allRoundLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allRoundLvis.Add(idTextBox.Text, lvi);
                    RoundTabControlUserControl.getRoundListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectBeginMapButton_Click(object sender, EventArgs e)
        {
            SelectMapForm form = new SelectMapForm(this, BeginMapIdTextBox, false);
            form.ShowDialog();
        }

        private void selectBeginCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, BeginCinematicIdTextBox, false);
            form.ShowDialog();
        }

        private void selectForceMapButton_Click(object sender, EventArgs e)
        {
            SelectMapForm form = new SelectMapForm(this, ForceMapIdTextBox, false);
            form.ShowDialog();
        }

        private void selectForceCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, ForceCinematicIdTextBox, false);
            form.ShowDialog();
        }

        private void EventNameConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(EventNameConditionTreeView);
        }

        private void EventNameConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(EventNameConditionNodeListView, EventNameConditionTreeView);
        }

        private void EventNameConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(EventNameConditionNodeListView, EventNameConditionTreeView);
        }

        private void EventNameConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(EventNameConditionTreeView);
        }

        private void EventNameConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(EventNameConditionTreeView);
        }

        private void BeginConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(BeginConditionTreeView);
        }

        private void BeginConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(BeginConditionNodeListView, BeginConditionTreeView);
        }

        private void BeginConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(BeginConditionNodeListView, BeginConditionTreeView);
        }

        private void BeginConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(BeginConditionTreeView);
        }

        private void BeginConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(BeginConditionTreeView);
        }
    }
}
