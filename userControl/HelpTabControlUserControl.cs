using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Help = Heluo.Data.Help;

namespace 侠之道mod制作器
{
    public partial class HelpTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public HelpTabControlUserControl()
        {
            InitializeComponent();
        }
        public HelpTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                HelpListView.Items.Clear();
                HelpListView.Items.AddRange(DataManager.allHelpLvis.Values.Where(x => (showOriginalHelpCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (HelpListView.SelectedItems.Count > 0)
                {
                    HelpListView.EnsureVisible(HelpListView.SelectedItems[0].Index);
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

        public ListView getHelpListView()
        {
            return HelpListView;
        }

        private void showOriginalHelpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newHelpButton_Click(object sender, EventArgs e)
        {
            HelpInfoForm form = new HelpInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editHelpButton_Click(object sender, EventArgs e)
        {
            editHelp();
        }

        public void editHelp()
        {
            if (HelpListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = HelpListView.SelectedItems[0];

                HelpInfoForm form = new HelpInfoForm((Form)Parent);
                form.HelpId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readHelpInfo();

                form.ShowDialog();
            }
        }

        private void HelpListView_DoubleClick(object sender, EventArgs e)
        {
            editHelp();
        }

        private void HelpListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editHelp();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHelp();
        }

        public void searchHelp()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allHelpLvis.ContainsKey(searchText))
            {
                Help Help = DataManager.getData<Help>(searchText);
                if (Help != null)
                {
                    ListViewItem lvi = DataManager.createHelpLvi(searchText);
                    HelpListView.Items.Add(lvi);
                    DataManager.allHelpLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (HelpListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (HelpListView.SelectedItems != null && HelpListView.SelectedItems.Count != 0)
                {
                    startIndex = HelpListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == HelpListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = HelpListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            HelpListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == HelpListView.Items.Count)
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
                searchHelp();
            }
        }

        private void HelpListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (HelpListView.SelectedItems.Count > 0)
            {
                selectIndex = HelpListView.Items.IndexOf(HelpListView.SelectedItems[0]);
                ListViewItem lvi = HelpListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteHelpButton.Enabled = true;
                }
                else
                {
                    deleteHelpButton.Enabled = false;
                }
            }
        }

        private void deleteHelpButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (HelpListView.SelectedItems.Count > 0)
                {
                    string HelpId = HelpListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Help.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + HelpId + "\t"))
                        {
                            string pattern = "\r\n" + HelpId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Help), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Help"].Contains(HelpId))
                        {
                            DataManager.allHelpLvis.Remove(HelpId);
                            HelpListView.Items.Remove(HelpListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Help Help = DataManager.getData<Help>(HelpId);

                            ListViewItem lvi = DataManager.createHelpLvi(HelpId);
                            if (DataManager.allHelpLvis.ContainsKey(HelpId))
                            {
                                DataManager.allHelpLvis[HelpId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalHelpCheckBox.Checked)
                            {
                                for (int i = 0; i < HelpListView.Items.Count; i++)
                                {
                                    if (HelpListView.Items[i].SubItems[0].Text == HelpId)
                                    {
                                        HelpListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                HelpListView.Items.Remove(HelpListView.SelectedItems[0]);
                            }

                        }
                        deleteHelpButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Help"))
            {
                DataManager.dict.Remove("Help");
            }
            DataManager.LoadTextfile("Help");

            DataManager.allHelpLvis.Clear();
            DataManager.allHelpLvis = DataManager.createHelpLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Help.txt";

            if (HelpListView.SelectedItems.Count > 0 && HelpListView.SelectedItems[0].SubItems[HelpListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Help.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Help.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Help.txt";

            if (HelpListView.SelectedItems.Count > 0 && HelpListView.SelectedItems[0].SubItems[HelpListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Help.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Help.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
