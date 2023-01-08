using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RegistrationBonusTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public RegistrationBonusTabControlUserControl()
        {
            InitializeComponent();
        }
        public RegistrationBonusTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                RegistrationBonusListView.Items.Clear();
                RegistrationBonusListView.Items.AddRange(DataManager.allRegistrationBonusLvis.Values.Where(x => (showOriginalRegistrationBonusCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (RegistrationBonusListView.SelectedItems.Count > 0)
                {
                    RegistrationBonusListView.EnsureVisible(RegistrationBonusListView.SelectedItems[0].Index);
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

        public ListView getRegistrationBonusListView()
        {
            return RegistrationBonusListView;
        }

        private void showOriginalRegistrationBonusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newRegistrationBonusButton_Click(object sender, EventArgs e)
        {
            RegistrationBonusInfoForm form = new RegistrationBonusInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editRegistrationBonusButton_Click(object sender, EventArgs e)
        {
            editRegistrationBonus();
        }

        public void editRegistrationBonus()
        {
            if (RegistrationBonusListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = RegistrationBonusListView.SelectedItems[0];

                RegistrationBonusInfoForm form = new RegistrationBonusInfoForm((Form)Parent);
                form.RegistrationBonusId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readRegistrationBonusInfo();

                form.ShowDialog();
            }
        }

        private void RegistrationBonusListView_DoubleClick(object sender, EventArgs e)
        {
            editRegistrationBonus();
        }

        private void RegistrationBonusListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editRegistrationBonus();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchRegistrationBonus();
        }

        public void searchRegistrationBonus()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allRegistrationBonusLvis.ContainsKey(searchText))
            {
                RegistrationBonus RegistrationBonus = DataManager.getData<RegistrationBonus>(searchText);
                if (RegistrationBonus != null)
                {
                    ListViewItem lvi = DataManager.createRegistrationBonusLvi(searchText);
                    RegistrationBonusListView.Items.Add(lvi);
                    DataManager.allRegistrationBonusLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (RegistrationBonusListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (RegistrationBonusListView.SelectedItems != null && RegistrationBonusListView.SelectedItems.Count != 0)
                {
                    startIndex = RegistrationBonusListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == RegistrationBonusListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = RegistrationBonusListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            RegistrationBonusListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == RegistrationBonusListView.Items.Count)
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
                searchRegistrationBonus();
            }
        }

        private void RegistrationBonusListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (RegistrationBonusListView.SelectedItems.Count > 0)
            {
                selectIndex = RegistrationBonusListView.Items.IndexOf(RegistrationBonusListView.SelectedItems[0]);
                ListViewItem lvi = RegistrationBonusListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteRegistrationBonusButton.Enabled = true;
                }
                else
                {
                    deleteRegistrationBonusButton.Enabled = false;
                }
            }
        }

        private void deleteRegistrationBonusButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RegistrationBonusListView.SelectedItems.Count > 0)
                {
                    string RegistrationBonusId = RegistrationBonusListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/RegistrationBonus_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + RegistrationBonusId + "\t"))
                        {
                            string pattern = "\r\n" + RegistrationBonusId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(RegistrationBonus), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["RegistrationBonus"].Contains(RegistrationBonusId))
                        {
                            DataManager.allRegistrationBonusLvis.Remove(RegistrationBonusId);
                            RegistrationBonusListView.Items.Remove(RegistrationBonusListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            RegistrationBonus RegistrationBonus = DataManager.getData<RegistrationBonus>(RegistrationBonusId);

                            ListViewItem lvi = DataManager.createRegistrationBonusLvi(RegistrationBonusId);
                            if (DataManager.allRegistrationBonusLvis.ContainsKey(RegistrationBonusId))
                            {
                                DataManager.allRegistrationBonusLvis[RegistrationBonusId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalRegistrationBonusCheckBox.Checked)
                            {
                                for (int i = 0; i < RegistrationBonusListView.Items.Count; i++)
                                {
                                    if (RegistrationBonusListView.Items[i].SubItems[0].Text == RegistrationBonusId)
                                    {
                                        RegistrationBonusListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                RegistrationBonusListView.Items.Remove(RegistrationBonusListView.SelectedItems[0]);
                            }

                        }
                        deleteRegistrationBonusButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("RegistrationBonus"))
            {
                DataManager.dict.Remove("RegistrationBonus");
            }
            DataManager.LoadTextfile("RegistrationBonus");

            DataManager.allRegistrationBonusLvis.Clear();
            DataManager.allRegistrationBonusLvis = DataManager.createRegistrationBonusLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "RegistrationBonus.txt";

            if (RegistrationBonusListView.SelectedItems.Count > 0 && RegistrationBonusListView.SelectedItems[0].SubItems[RegistrationBonusListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "RegistrationBonus_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "RegistrationBonus_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "RegistrationBonus.txt";

            if (RegistrationBonusListView.SelectedItems.Count > 0 && RegistrationBonusListView.SelectedItems[0].SubItems[RegistrationBonusListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "RegistrationBonus_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "RegistrationBonus_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
