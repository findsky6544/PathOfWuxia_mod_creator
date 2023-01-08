using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleGridTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public BattleGridTabControlUserControl()
        {
            InitializeComponent();
        }
        public BattleGridTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                BattleGridListView.Items.Clear();
                BattleGridListView.Items.AddRange(DataManager.allBattleGridLvis.Values.Where(x => (showOriginalBattleGridCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (BattleGridListView.SelectedItems.Count > 0)
                {
                    BattleGridListView.EnsureVisible(BattleGridListView.SelectedItems[0].Index);
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

        public ListView getBattleGridListView()
        {
            return BattleGridListView;
        }

        private void showOriginalBattleGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newBattleGridButton_Click(object sender, EventArgs e)
        {
            BattleGridInfoForm form = new BattleGridInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editBattleGridButton_Click(object sender, EventArgs e)
        {
            editBattleGrid();
        }

        public void editBattleGrid()
        {
            if (BattleGridListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = BattleGridListView.SelectedItems[0];

                BattleGridInfoForm form = new BattleGridInfoForm((Form)Parent);
                form.battleGridId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readBattleGridInfo();

                form.ShowDialog();
            }
        }

        private void battleGridListView_DoubleClick(object sender, EventArgs e)
        {
            editBattleGrid();
        }

        private void battleGridListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editBattleGrid();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBattleGrid();
        }

        public void searchBattleGrid()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allBattleGridLvis.ContainsKey(searchText))
            {
                BattleGrid battleGrid = DataManager.getData<BattleGrid>(searchText);
                if (battleGrid != null)
                {
                    ListViewItem lvi = DataManager.createBattleGridLvi(searchText);
                    BattleGridListView.Items.Add(lvi);
                    DataManager.allBattleGridLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (BattleGridListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BattleGridListView.SelectedItems != null && BattleGridListView.SelectedItems.Count != 0)
                {
                    startIndex = BattleGridListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BattleGridListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BattleGridListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            BattleGridListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BattleGridListView.Items.Count)
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
                searchBattleGrid();
            }
        }

        private void battleGridListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (BattleGridListView.SelectedItems.Count > 0)
            {
                selectIndex = BattleGridListView.Items.IndexOf(BattleGridListView.SelectedItems[0]);
                ListViewItem lvi = BattleGridListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteBattleGridButton.Enabled = true;
                }
                else
                {
                    deleteBattleGridButton.Enabled = false;
                }
            }
        }

        private void deleteBattleGridButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BattleGridListView.SelectedItems.Count > 0)
                {
                    string BattleGridId = BattleGridListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/BattleGrid_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + BattleGridId + "\t"))
                        {
                            string pattern = "\r\n" + BattleGridId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(BattleGrid), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["BattleGrid"].Contains(BattleGridId))
                        {
                            DataManager.allBattleGridLvis.Remove(BattleGridId);
                            BattleGridListView.Items.Remove(BattleGridListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            BattleGrid BattleGrid = DataManager.getData<BattleGrid>(BattleGridId);

                            ListViewItem lvi = DataManager.createBattleGridLvi(BattleGridId);
                            if (DataManager.allBattleGridLvis.ContainsKey(BattleGridId))
                            {
                                DataManager.allBattleGridLvis[BattleGridId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalBattleGridCheckBox.Checked)
                            {
                                for (int i = 0; i < BattleGridListView.Items.Count; i++)
                                {
                                    if (BattleGridListView.Items[i].Text == BattleGridId)
                                    {
                                        BattleGridListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                BattleGridListView.Items.Remove(BattleGridListView.SelectedItems[0]);
                            }

                        }
                        deleteBattleGridButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("battleGrid"))
            {
                DataManager.dict.Remove("battleGrid");
            }
            DataManager.LoadTextfile("BattleGrid");

            DataManager.allBattleGridLvis.Clear();
            DataManager.allBattleGridLvis = DataManager.createBattleGridLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleGrid.txt";

            if (BattleGridListView.SelectedItems.Count > 0 && BattleGridListView.SelectedItems[0].SubItems[BattleGridListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleGrid_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleGrid_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleGrid.txt";

            if (BattleGridListView.SelectedItems.Count > 0 && BattleGridListView.SelectedItems[0].SubItems[BattleGridListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleGrid_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleGrid_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
