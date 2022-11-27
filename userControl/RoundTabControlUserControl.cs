using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RoundTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public RoundTabControlUserControl()
        {
            InitializeComponent();
        }
        public RoundTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            RoundListView.Items.Clear();
            RoundListView.Items.AddRange(DataManager.allRoundLvis.Values.Where(x => (showOriginalRoundCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (RoundListView.SelectedItems.Count > 0)
            {
                RoundListView.EnsureVisible(RoundListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getRoundListView()
        {
            return RoundListView;
        }

        private void showOriginalRoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newRoundButton_Click(object sender, EventArgs e)
        {
            RoundInfoForm form = new RoundInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editRoundButton_Click(object sender, EventArgs e)
        {
            editRound();
        }

        public void editRound()
        {
            if (RoundListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = RoundListView.SelectedItems[0];

                RoundInfoForm form = new RoundInfoForm((Form)Parent);
                form.RoundId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readRoundInfo();

                form.ShowDialog();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchRound();
        }

        public void searchRound()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (RoundListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (RoundListView.SelectedItems != null && RoundListView.SelectedItems.Count != 0)
                {
                    startIndex = RoundListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == RoundListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = RoundListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            RoundListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == RoundListView.Items.Count)
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
                searchRound();
            }
        }

        private void RoundListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (RoundListView.SelectedItems.Count > 0)
            {
                selectIndex = RoundListView.Items.IndexOf(RoundListView.SelectedItems[0]);
                ListViewItem lvi = RoundListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteRoundButton.Enabled = true;
                }
                else
                {
                    deleteRoundButton.Enabled = false;
                }
            }
        }

        private void deleteRoundButton_Click(object sender, EventArgs e)
        {
            if (RoundListView.SelectedItems.Count > 0)
            {
                string RoundId = RoundListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + RoundId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + RoundId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["Round_cus"].Remove(RoundId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + RoundId + ".json"))
                        {
                            DataManager.allRoundLvis.Remove(RoundId);
                            RoundListView.Items.Remove(RoundListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Round Round = DataManager.getData<Round>(RoundId);

                            ListViewItem lvi = DataManager.createRoundLvi(RoundId);
                            if (DataManager.allRoundLvis.ContainsKey(RoundId))
                            {
                                DataManager.allRoundLvis[RoundId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalRoundCheckBox.Checked)
                            {
                                for (int i = 0; i < RoundListView.Items.Count; i++)
                                {
                                    if (RoundListView.Items[i].SubItems[1].Text == RoundId)
                                    {
                                        RoundListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                RoundListView.Items.Remove(RoundListView.SelectedItems[0]);
                            }

                        }
                        deleteRoundButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Round"))
            {
                DataManager.dict.Remove("Round");
            }
            DataManager.LoadTextfile("Round");

            DataManager.allRoundLvis.Clear();
            DataManager.allRoundLvis = DataManager.createRoundLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Round.txt";

            if (RoundListView.SelectedItems.Count > 0 && RoundListView.SelectedItems[0].SubItems[RoundListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Round.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Round.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Round.txt";

            if (RoundListView.SelectedItems.Count > 0 && RoundListView.SelectedItems[0].SubItems[RoundListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Round.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Round.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = RoundListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void RoundListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editRound();
            }
        }

        private void RoundListView_DoubleClick(object sender, EventArgs e)
        {
            editRound();
        }
    }
}
