using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class FavorabilityTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public FavorabilityTabControlUserControl()
        {
            InitializeComponent();
        }
        public FavorabilityTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                FavorabilityListView.Items.Clear();
                FavorabilityListView.Items.AddRange(DataManager.allFavorabilityLvis.Values.Where(x => (showOriginalFavorabilityCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (FavorabilityListView.SelectedItems.Count > 0)
                {
                    FavorabilityListView.EnsureVisible(FavorabilityListView.SelectedItems[0].Index);
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

        public ListView getFavorabilityListView()
        {
            return FavorabilityListView;
        }

        private void showOriginalFavorabilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newFavorabilityButton_Click(object sender, EventArgs e)
        {
            FavorabilityInfoForm form = new FavorabilityInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editFavorabilityButton_Click(object sender, EventArgs e)
        {
            editFavorability();
        }

        public void editFavorability()
        {
            if (FavorabilityListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = FavorabilityListView.SelectedItems[0];

                FavorabilityInfoForm form = new FavorabilityInfoForm((Form)Parent);
                form.FavorabilityId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readFavorabilityInfo();

                form.ShowDialog();
            }
        }

        private void FavorabilityListView_DoubleClick(object sender, EventArgs e)
        {
            editFavorability();
        }

        private void FavorabilityListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editFavorability();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchFavorability();
        }

        public void searchFavorability()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allFavorabilityLvis.ContainsKey(searchText))
            {
                Favorability Favorability = DataManager.getData<Favorability>(searchText);
                if (Favorability != null)
                {
                    ListViewItem lvi = DataManager.createFavorabilityLvi(searchText);
                    FavorabilityListView.Items.Add(lvi);
                    DataManager.allFavorabilityLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (FavorabilityListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (FavorabilityListView.SelectedItems != null && FavorabilityListView.SelectedItems.Count != 0)
                {
                    startIndex = FavorabilityListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == FavorabilityListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = FavorabilityListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            FavorabilityListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == FavorabilityListView.Items.Count)
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
                searchFavorability();
            }
        }

        private void FavorabilityListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (FavorabilityListView.SelectedItems.Count > 0)
            {
                selectIndex = FavorabilityListView.Items.IndexOf(FavorabilityListView.SelectedItems[0]);
                ListViewItem lvi = FavorabilityListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteFavorabilityButton.Enabled = true;
                }
                else
                {
                    deleteFavorabilityButton.Enabled = false;
                }
            }
        }

        private void deleteFavorabilityButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FavorabilityListView.SelectedItems.Count > 0)
                {
                    string FavorabilityId = FavorabilityListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Favorability.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + FavorabilityId + "\t"))
                        {
                            string pattern = "\r\n" + FavorabilityId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Favorability), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Favorability"].Contains(FavorabilityId))
                        {
                            DataManager.allFavorabilityLvis.Remove(FavorabilityId);
                            FavorabilityListView.Items.Remove(FavorabilityListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Favorability Favorability = DataManager.getData<Favorability>(FavorabilityId);

                            ListViewItem lvi = DataManager.createFavorabilityLvi(FavorabilityId);
                            if (DataManager.allFavorabilityLvis.ContainsKey(FavorabilityId))
                            {
                                DataManager.allFavorabilityLvis[FavorabilityId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalFavorabilityCheckBox.Checked)
                            {
                                for (int i = 0; i < FavorabilityListView.Items.Count; i++)
                                {
                                    if (FavorabilityListView.Items[i].SubItems[0].Text == FavorabilityId)
                                    {
                                        FavorabilityListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                FavorabilityListView.Items.Remove(FavorabilityListView.SelectedItems[0]);
                            }

                        }
                        deleteFavorabilityButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Favorability"))
            {
                DataManager.dict.Remove("Favorability");
            }
            DataManager.LoadTextfile("Favorability");

            DataManager.allFavorabilityLvis.Clear();
            DataManager.allFavorabilityLvis = DataManager.createFavorabilityLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Favorability.txt";

            if (FavorabilityListView.SelectedItems.Count > 0 && FavorabilityListView.SelectedItems[0].SubItems[FavorabilityListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Favorability.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Favorability.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Favorability.txt";

            if (FavorabilityListView.SelectedItems.Count > 0 && FavorabilityListView.SelectedItems[0].SubItems[FavorabilityListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Favorability.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Favorability.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
