using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ForgeTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public ForgeTabControlUserControl()
        {
            InitializeComponent();
        }
        public ForgeTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                ForgeListView.Items.Clear();
                ForgeListView.Items.AddRange(DataManager.allForgeLvis.Values.Where(x => (showOriginalForgeCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (ForgeListView.SelectedItems.Count > 0)
                {
                    ForgeListView.EnsureVisible(ForgeListView.SelectedItems[0].Index);
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

        public ListView getForgeListView()
        {
            return ForgeListView;
        }

        private void showOriginalForgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newForgeButton_Click(object sender, EventArgs e)
        {
            ForgeInfoForm form = new ForgeInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editForgeButton_Click(object sender, EventArgs e)
        {
            editForge();
        }

        public void editForge()
        {
            if (ForgeListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = ForgeListView.SelectedItems[0];

                ForgeInfoForm form = new ForgeInfoForm((Form)Parent);
                form.ForgeId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readForgeInfo();

                form.ShowDialog();
            }
        }

        private void ForgeListView_DoubleClick(object sender, EventArgs e)
        {
            editForge();
        }

        private void ForgeListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editForge();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchForge();
        }

        public void searchForge()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allForgeLvis.ContainsKey(searchText))
            {
                Forge Forge = DataManager.getData<Forge>(searchText);
                if (Forge != null)
                {
                    ListViewItem lvi = DataManager.createForgeLvi(searchText);
                    ForgeListView.Items.Add(lvi);
                    DataManager.allForgeLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (ForgeListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (ForgeListView.SelectedItems != null && ForgeListView.SelectedItems.Count != 0)
                {
                    startIndex = ForgeListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == ForgeListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = ForgeListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            ForgeListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == ForgeListView.Items.Count)
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
                searchForge();
            }
        }

        private void ForgeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (ForgeListView.SelectedItems.Count > 0)
            {
                selectIndex = ForgeListView.Items.IndexOf(ForgeListView.SelectedItems[0]);
                ListViewItem lvi = ForgeListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteForgeButton.Enabled = true;
                }
                else
                {
                    deleteForgeButton.Enabled = false;
                }
            }
        }

        private void deleteForgeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ForgeListView.SelectedItems.Count > 0)
                {
                    string ForgeId = ForgeListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Forge.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + ForgeId + "\t"))
                        {
                            string pattern = "\r\n" + ForgeId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Forge), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Forge"].Contains(ForgeId))
                        {
                            DataManager.allForgeLvis.Remove(ForgeId);
                            ForgeListView.Items.Remove(ForgeListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Forge Forge = DataManager.getData<Forge>(ForgeId);

                            ListViewItem lvi = DataManager.createForgeLvi(ForgeId);
                            if (DataManager.allForgeLvis.ContainsKey(ForgeId))
                            {
                                DataManager.allForgeLvis[ForgeId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalForgeCheckBox.Checked)
                            {
                                for (int i = 0; i < ForgeListView.Items.Count; i++)
                                {
                                    if (ForgeListView.Items[i].SubItems[0].Text == ForgeId)
                                    {
                                        ForgeListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ForgeListView.Items.Remove(ForgeListView.SelectedItems[0]);
                            }

                        }
                        deleteForgeButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Forge"))
            {
                DataManager.dict.Remove("Forge");
            }
            DataManager.LoadTextfile("Forge");

            DataManager.allForgeLvis.Clear();
            DataManager.allForgeLvis = DataManager.createForgeLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Forge.txt";

            if (ForgeListView.SelectedItems.Count > 0 && ForgeListView.SelectedItems[0].SubItems[ForgeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Forge.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Forge.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Forge.txt";

            if (ForgeListView.SelectedItems.Count > 0 && ForgeListView.SelectedItems[0].SubItems[ForgeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Forge.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Forge.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
