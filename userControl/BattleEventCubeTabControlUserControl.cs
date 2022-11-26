using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleEventCubeTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public BattleEventCubeTabControlUserControl()
        {
            InitializeComponent();
        }
        public BattleEventCubeTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                BattleEventCubeListView.Items.Clear();
                BattleEventCubeListView.Items.AddRange(DataManager.allBattleEventCubeLvis.Values.Where(x => (showOriginalBattleEventCubeCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (BattleEventCubeListView.SelectedItems.Count > 0)
                {
                    BattleEventCubeListView.EnsureVisible(BattleEventCubeListView.SelectedItems[0].Index);
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

        public ListView getBattleEventCubeListView()
        {
            return BattleEventCubeListView;
        }

        private void showOriginalBattleEventCubeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newBattleEventCubeButton_Click(object sender, EventArgs e)
        {
            BattleEventCubeInfoForm form = new BattleEventCubeInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editBattleEventCubeButton_Click(object sender, EventArgs e)
        {
            editBattleEventCube();
        }

        public void editBattleEventCube()
        {
            if (BattleEventCubeListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = BattleEventCubeListView.SelectedItems[0];

                BattleEventCubeInfoForm form = new BattleEventCubeInfoForm((Form)Parent);
                form.battleEventCubeId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readBattleEventCubeInfo();

                form.ShowDialog();
            }
        }

        private void battleEventCubeListView_DoubleClick(object sender, EventArgs e)
        {
            editBattleEventCube();
        }

        private void battleEventCubeListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editBattleEventCube();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBattleEventCube();
        }

        public void searchBattleEventCube()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allBattleEventCubeLvis.ContainsKey(searchText))
            {
                BattleEventCube battleEventCube = DataManager.getData<BattleEventCube>(searchText);
                if (battleEventCube != null)
                {
                    ListViewItem lvi = DataManager.createBattleEventCubeLvi(searchText);
                    BattleEventCubeListView.Items.Add(lvi);
                    DataManager.allBattleEventCubeLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (BattleEventCubeListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BattleEventCubeListView.SelectedItems != null && BattleEventCubeListView.SelectedItems.Count != 0)
                {
                    startIndex = BattleEventCubeListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BattleEventCubeListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BattleEventCubeListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            BattleEventCubeListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BattleEventCubeListView.Items.Count)
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
                searchBattleEventCube();
            }
        }

        private void battleEventCubeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (BattleEventCubeListView.SelectedItems.Count > 0)
            {
                selectIndex = BattleEventCubeListView.Items.IndexOf(BattleEventCubeListView.SelectedItems[0]);
                ListViewItem lvi = BattleEventCubeListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteBattleEventCubeButton.Enabled = true;
                }
                else
                {
                    deleteBattleEventCubeButton.Enabled = false;
                }
            }
        }

        private void deleteBattleEventCubeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BattleEventCubeListView.SelectedItems.Count > 0)
                {
                    string BattleEventCubeId = BattleEventCubeListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\BattleEventCube.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + BattleEventCubeId + "\t"))
                        {
                            string pattern = "\r\n" + BattleEventCubeId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(BattleEventCube), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["BattleEventCube"].Contains(BattleEventCubeId))
                        {
                            DataManager.allBattleEventCubeLvis.Remove(BattleEventCubeId);
                            BattleEventCubeListView.Items.Remove(BattleEventCubeListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            BattleEventCube BattleEventCube = DataManager.getData<BattleEventCube>(BattleEventCubeId);

                            ListViewItem lvi = DataManager.createBattleEventCubeLvi(BattleEventCubeId);
                            if (DataManager.allBattleEventCubeLvis.ContainsKey(BattleEventCubeId))
                            {
                                DataManager.allBattleEventCubeLvis[BattleEventCubeId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalBattleEventCubeCheckBox.Checked)
                            {
                                for (int i = 0; i < BattleEventCubeListView.Items.Count; i++)
                                {
                                    if (BattleEventCubeListView.Items[i].Text == BattleEventCubeId)
                                    {
                                        BattleEventCubeListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                BattleEventCubeListView.Items.Remove(BattleEventCubeListView.SelectedItems[0]);
                            }

                        }
                        deleteBattleEventCubeButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("battleEventCube"))
            {
                DataManager.dict.Remove("battleEventCube");
            }
            DataManager.LoadTextfile("BattleEventCube");

            DataManager.allBattleEventCubeLvis.Clear();
            DataManager.allBattleEventCubeLvis = DataManager.createBattleEventCubeLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleEventCube.txt";

            if (BattleEventCubeListView.SelectedItems.Count > 0 && BattleEventCubeListView.SelectedItems[0].SubItems[BattleEventCubeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleEventCube.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleEventCube.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "BattleEventCube.txt";

            if (BattleEventCubeListView.SelectedItems.Count > 0 && BattleEventCubeListView.SelectedItems[0].SubItems[BattleEventCubeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleEventCube.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "BattleEventCube.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
