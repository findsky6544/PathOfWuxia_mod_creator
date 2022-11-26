using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HelpDescription = Heluo.Data.HelpDescription;

namespace 侠之道mod制作器
{
    public partial class HelpDescriptionTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public HelpDescriptionTabControlUserControl()
        {
            InitializeComponent();
        }
        public HelpDescriptionTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                HelpDescriptionListView.Items.Clear();
                HelpDescriptionListView.Items.AddRange(DataManager.allHelpDescriptionLvis.Values.Where(x => (showOriginalHelpDescriptionCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (HelpDescriptionListView.SelectedItems.Count > 0)
                {
                    HelpDescriptionListView.EnsureVisible(HelpDescriptionListView.SelectedItems[0].Index);
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

        public ListView getHelpDescriptionListView()
        {
            return HelpDescriptionListView;
        }

        private void showOriginalHelpDescriptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newHelpDescriptionButton_Click(object sender, EventArgs e)
        {
            HelpDescriptionInfoForm form = new HelpDescriptionInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editHelpDescriptionButton_Click(object sender, EventArgs e)
        {
            editHelpDescription();
        }

        public void editHelpDescription()
        {
            if (HelpDescriptionListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = HelpDescriptionListView.SelectedItems[0];

                HelpDescriptionInfoForm form = new HelpDescriptionInfoForm((Form)Parent);
                form.HelpDescriptionId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readHelpDescriptionInfo();

                form.ShowDialog();
            }
        }

        private void HelpDescriptionListView_DoubleClick(object sender, EventArgs e)
        {
            editHelpDescription();
        }

        private void HelpDescriptionListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editHelpDescription();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHelpDescription();
        }

        public void searchHelpDescription()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allHelpDescriptionLvis.ContainsKey(searchText))
            {
                HelpDescription HelpDescription = DataManager.getData<HelpDescription>(searchText);
                if (HelpDescription != null)
                {
                    ListViewItem lvi = DataManager.createHelpDescriptionLvi(searchText);
                    HelpDescriptionListView.Items.Add(lvi);
                    DataManager.allHelpDescriptionLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (HelpDescriptionListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (HelpDescriptionListView.SelectedItems != null && HelpDescriptionListView.SelectedItems.Count != 0)
                {
                    startIndex = HelpDescriptionListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == HelpDescriptionListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = HelpDescriptionListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            HelpDescriptionListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == HelpDescriptionListView.Items.Count)
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
                searchHelpDescription();
            }
        }

        private void HelpDescriptionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (HelpDescriptionListView.SelectedItems.Count > 0)
            {
                selectIndex = HelpDescriptionListView.Items.IndexOf(HelpDescriptionListView.SelectedItems[0]);
                ListViewItem lvi = HelpDescriptionListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteHelpDescriptionButton.Enabled = true;
                }
                else
                {
                    deleteHelpDescriptionButton.Enabled = false;
                }
            }
        }

        private void deleteHelpDescriptionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (HelpDescriptionListView.SelectedItems.Count > 0)
                {
                    string HelpDescriptionId = HelpDescriptionListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/HelpDescription.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + HelpDescriptionId + "\t"))
                        {
                            string pattern = "\r\n" + HelpDescriptionId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(HelpDescription), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["HelpDescription"].Contains(HelpDescriptionId))
                        {
                            DataManager.allHelpDescriptionLvis.Remove(HelpDescriptionId);
                            HelpDescriptionListView.Items.Remove(HelpDescriptionListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            HelpDescription HelpDescription = DataManager.getData<HelpDescription>(HelpDescriptionId);

                            ListViewItem lvi = DataManager.createHelpDescriptionLvi(HelpDescriptionId);
                            if (DataManager.allHelpDescriptionLvis.ContainsKey(HelpDescriptionId))
                            {
                                DataManager.allHelpDescriptionLvis[HelpDescriptionId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalHelpDescriptionCheckBox.Checked)
                            {
                                for (int i = 0; i < HelpDescriptionListView.Items.Count; i++)
                                {
                                    if (HelpDescriptionListView.Items[i].SubItems[0].Text == HelpDescriptionId)
                                    {
                                        HelpDescriptionListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                HelpDescriptionListView.Items.Remove(HelpDescriptionListView.SelectedItems[0]);
                            }

                        }
                        deleteHelpDescriptionButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("HelpDescription"))
            {
                DataManager.dict.Remove("HelpDescription");
            }
            DataManager.LoadTextfile("HelpDescription");

            DataManager.allHelpDescriptionLvis.Clear();
            DataManager.allHelpDescriptionLvis = DataManager.createHelpDescriptionLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "HelpDescription.txt";

            if (HelpDescriptionListView.SelectedItems.Count > 0 && HelpDescriptionListView.SelectedItems[0].SubItems[HelpDescriptionListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "HelpDescription.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "HelpDescription.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "HelpDescription.txt";

            if (HelpDescriptionListView.SelectedItems.Count > 0 && HelpDescriptionListView.SelectedItems[0].SubItems[HelpDescriptionListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "HelpDescription.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "HelpDescription.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
