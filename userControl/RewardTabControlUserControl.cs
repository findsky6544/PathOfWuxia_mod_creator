using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RewardTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public RewardTabControlUserControl()
        {
            InitializeComponent();
        }
        public RewardTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            RewardListView.Items.Clear();
            RewardListView.Items.AddRange(DataManager.allRewardLvis.Values.Where(x => (showOriginalRewardCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (RewardListView.SelectedItems.Count > 0)
            {
                RewardListView.EnsureVisible(RewardListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getRewardListView()
        {
            return RewardListView;
        }

        private void showOriginalRewardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newRewardButton_Click(object sender, EventArgs e)
        {
            RewardInfoForm form = new RewardInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editRewardButton_Click(object sender, EventArgs e)
        {
            editReward();
        }

        public void editReward()
        {
            if (RewardListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = RewardListView.SelectedItems[0];

                RewardInfoForm form = new RewardInfoForm((Form)Parent);
                form.rewardId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readRewardInfo();

                form.ShowDialog();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchReward();
        }

        public void searchReward()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (RewardListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (RewardListView.SelectedItems != null && RewardListView.SelectedItems.Count != 0)
                {
                    startIndex = RewardListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == RewardListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = RewardListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            RewardListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == RewardListView.Items.Count)
                    {
                        index = 0;
                    }
                } while (index != startIndex);
            }
            if (!isSearched)
            {
                MessageBox.Show("未找到该数据");
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchReward();
            }
        }

        private void rewardListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (RewardListView.SelectedItems.Count > 0)
            {
                selectIndex = RewardListView.Items.IndexOf(RewardListView.SelectedItems[0]);
                ListViewItem lvi = RewardListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteRewardButton.Enabled = true;
                }
                else
                {
                    deleteRewardButton.Enabled = false;
                }
            }
        }

        private void deleteRewardButton_Click(object sender, EventArgs e)
        {
            if (RewardListView.SelectedItems.Count > 0)
            {
                string RewardId = RewardListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + RewardId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + RewardId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["reward_cus"].Remove(RewardId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + RewardId + ".json"))
                        {
                            DataManager.allRewardLvis.Remove(RewardId);
                            RewardListView.Items.Remove(RewardListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Reward reward = DataManager.getData<Reward>(RewardId);

                            ListViewItem lvi = DataManager.createRewardLvi(RewardId);
                            if (DataManager.allRewardLvis.ContainsKey(RewardId))
                            {
                                DataManager.allRewardLvis[RewardId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalRewardCheckBox.Checked)
                            {
                                for (int i = 0; i < RewardListView.Items.Count; i++)
                                {
                                    if (RewardListView.Items[i].SubItems[1].Text == RewardId)
                                    {
                                        RewardListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                RewardListView.Items.Remove(RewardListView.SelectedItems[0]);
                            }

                        }
                        deleteRewardButton.Enabled = false;
                    }
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            MainForm mainForm = (MainForm)Parent;

            if (DataManager.dict.ContainsKey("Reward"))
            {
                DataManager.dict.Remove("Reward");
            }
            DataManager.LoadTextfile("Reward");

            DataManager.allRewardLvis.Clear();
            DataManager.allRewardLvis = DataManager.createRewardLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Reward.txt";

            if (RewardListView.SelectedItems.Count > 0 && RewardListView.SelectedItems[0].SubItems[RewardListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Reward.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Reward.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Reward.txt";

            if (RewardListView.SelectedItems.Count > 0 && RewardListView.SelectedItems[0].SubItems[RewardListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Reward.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Reward.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = RewardListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void rewardListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editReward();
            }
        }

        private void rewardListView_DoubleClick(object sender, EventArgs e)
        {
            editReward();
        }
    }
}
