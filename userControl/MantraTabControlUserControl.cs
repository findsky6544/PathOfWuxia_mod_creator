using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MantraTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public MantraTabControlUserControl()
        {
            InitializeComponent();
        }
        public MantraTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                MantraListView.Items.Clear();
                MantraListView.Items.AddRange(DataManager.allMantraLvis.Values.Where(x => (showOriginalMantraCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (MantraListView.SelectedItems.Count > 0)
                {
                    MantraListView.EnsureVisible(MantraListView.SelectedItems[0].Index);
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

        public ListView getMantraListView()
        {
            return MantraListView;
        }

        private void showOriginalMantraCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newMantraButton_Click(object sender, EventArgs e)
        {
            MantraInfoForm form = new MantraInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editMantraButton_Click(object sender, EventArgs e)
        {
            editMantra();
        }

        public void editMantra()
        {
            if (MantraListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = MantraListView.SelectedItems[0];

                MantraInfoForm form = new MantraInfoForm((Form)Parent);
                form.MantraId = lvi.SubItems[1].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readMantraInfo();

                form.ShowDialog();
            }
        }

        private void MantraListView_DoubleClick(object sender, EventArgs e)
        {
            editMantra();
        }

        private void MantraListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editMantra();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchMantra();
        }

        public void searchMantra()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allMantraLvis.ContainsKey(searchText))
            {
                Mantra Mantra = DataManager.getData<Mantra>(searchText);
                if (Mantra != null)
                {
                    ListViewItem lvi = DataManager.createMantraLvi(searchText);
                    MantraListView.Items.Add(lvi);
                    DataManager.allMantraLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (MantraListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (MantraListView.SelectedItems != null && MantraListView.SelectedItems.Count != 0)
                {
                    startIndex = MantraListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == MantraListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = MantraListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            MantraListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == MantraListView.Items.Count)
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
                searchMantra();
            }
        }

        private void MantraListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (MantraListView.SelectedItems.Count > 0)
            {
                selectIndex = MantraListView.Items.IndexOf(MantraListView.SelectedItems[0]);
                ListViewItem lvi = MantraListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteMantraButton.Enabled = true;
                }
                else
                {
                    deleteMantraButton.Enabled = false;
                }
            }
        }

        private void deleteMantraButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MantraListView.SelectedItems.Count > 0)
                {
                    string MantraId = MantraListView.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Mantra.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + MantraId + "\t"))
                        {
                            string pattern = "\r\n" + MantraId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Mantra), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Mantra"].Contains(MantraId))
                        {
                            DataManager.allMantraLvis.Remove(MantraId);
                            MantraListView.Items.Remove(MantraListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Mantra Mantra = DataManager.getData<Mantra>(MantraId);

                            ListViewItem lvi = DataManager.createMantraLvi(MantraId);
                            if (DataManager.allMantraLvis.ContainsKey(MantraId))
                            {
                                DataManager.allMantraLvis[MantraId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalMantraCheckBox.Checked)
                            {
                                for (int i = 0; i < MantraListView.Items.Count; i++)
                                {
                                    if (MantraListView.Items[i].SubItems[1].Text == MantraId)
                                    {
                                        MantraListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MantraListView.Items.Remove(MantraListView.SelectedItems[0]);
                            }

                        }
                        deleteMantraButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Mantra"))
            {
                DataManager.dict.Remove("Mantra");
            }
            DataManager.LoadTextfile("Mantra");

            DataManager.allMantraLvis.Clear();
            DataManager.allMantraLvis = DataManager.createMantraLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Mantra.txt";

            if (MantraListView.SelectedItems.Count > 0 && MantraListView.SelectedItems[0].SubItems[MantraListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Mantra.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Mantra.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Mantra.txt";

            if (MantraListView.SelectedItems.Count > 0 && MantraListView.SelectedItems[0].SubItems[MantraListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Mantra.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Mantra.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
