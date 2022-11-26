using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleAreaTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public BattleAreaTabControlUserControl()
        {
            InitializeComponent();
        }
        public BattleAreaTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                BattleAreaListView.Items.Clear();
                BattleAreaListView.Items.AddRange(DataManager.allBattleAreaLvis.Values.Where(x => (showOriginalBattleAreaCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (BattleAreaListView.SelectedItems.Count > 0)
                {
                    BattleAreaListView.EnsureVisible(BattleAreaListView.SelectedItems[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getBattleAreaListView()
        {
            return BattleAreaListView;
        }

        private void showOriginalBattleAreaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newBattleAreaButton_Click(object sender, EventArgs e)
        {
            BattleAreaInfoForm form = new BattleAreaInfoForm(null,true);
            form.ShowDialog();
        }

        private void editBattleAreaButton_Click(object sender, EventArgs e)
        {
            editBattleArea();
        }

        public void editBattleArea()
        {
            if (BattleAreaListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = BattleAreaListView.SelectedItems[0];

                BattleAreaInfoForm form = new BattleAreaInfoForm(lvi.SubItems[0].Text, true);

                form.ShowDialog();
            }
        }

        private void battleAreaListView_DoubleClick(object sender, EventArgs e)
        {
            editBattleArea();
        }

        private void battleAreaListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editBattleArea();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBattleArea();
        }

        public void searchBattleArea()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allBattleAreaLvis.ContainsKey(searchText))
            {
                BattleArea battleArea = DataManager.getData<BattleArea>(searchText);
                if (battleArea != null)
                {
                    ListViewItem lvi = DataManager.createBattleAreaLvi(searchText);
                    BattleAreaListView.Items.Add(lvi);
                    DataManager.allBattleAreaLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (BattleAreaListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BattleAreaListView.SelectedItems != null && BattleAreaListView.SelectedItems.Count != 0)
                {
                    startIndex = BattleAreaListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BattleAreaListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BattleAreaListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            BattleAreaListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BattleAreaListView.Items.Count)
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
                searchBattleArea();
            }
        }

        private void battleAreaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (BattleAreaListView.SelectedItems.Count > 0)
            {
                selectIndex = BattleAreaListView.Items.IndexOf(BattleAreaListView.SelectedItems[0]);
                ListViewItem lvi = BattleAreaListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteBattleAreaButton.Enabled = true;
                }
                else
                {
                    deleteBattleAreaButton.Enabled = false;
                }
            }
        }

        private void deleteBattleAreaButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BattleAreaListView.SelectedItems.Count > 0)
                {
                    string BattleAreaId = BattleAreaListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "/BattleArea.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + BattleAreaId + "\t"))
                        {
                            string pattern = "\r\n" + BattleAreaId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(BattleArea), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["BattleArea"].Contains(BattleAreaId))
                        {
                            DataManager.allBattleAreaLvis.Remove(BattleAreaId);
                            BattleAreaListView.Items.Remove(BattleAreaListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            BattleArea BattleArea = DataManager.getData<BattleArea>(BattleAreaId);

                            ListViewItem lvi = DataManager.createBattleAreaLvi(BattleAreaId);
                            if (DataManager.allBattleAreaLvis.ContainsKey(BattleAreaId))
                            {
                                DataManager.allBattleAreaLvis[BattleAreaId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalBattleAreaCheckBox.Checked)
                            {
                                for (int i = 0; i < BattleAreaListView.Items.Count; i++)
                                {
                                    if (BattleAreaListView.Items[i].Text == BattleAreaId)
                                    {
                                        BattleAreaListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                BattleAreaListView.Items.Remove(BattleAreaListView.SelectedItems[0]);
                            }

                        }
                        deleteBattleAreaButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            MainForm mainForm = (MainForm)Parent;

            if (DataManager.dict.ContainsKey("battleArea"))
            {
                DataManager.dict.Remove("battleArea");
            }
            DataManager.LoadTextfile("BattleArea");

            DataManager.allBattleAreaLvis.Clear();
            DataManager.allBattleAreaLvis = DataManager.createBattleAreaLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleArea.txt";

            if (BattleAreaListView.SelectedItems.Count > 0 && BattleAreaListView.SelectedItems[0].SubItems[BattleAreaListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleArea.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleArea.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleArea.txt";

            if (BattleAreaListView.SelectedItems.Count > 0 && BattleAreaListView.SelectedItems[0].SubItems[BattleAreaListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleArea.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleArea.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
