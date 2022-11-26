using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PropsTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public PropsTabControlUserControl()
        {
            InitializeComponent();
        }
        public PropsTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                PropsListView.Items.Clear();
                PropsListView.Items.AddRange(DataManager.allPropsLvis.Values.Where(x => (showOriginalPropsCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (PropsListView.SelectedItems.Count > 0)
                {
                    PropsListView.EnsureVisible(PropsListView.SelectedItems[0].Index);
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

        public ListView getPropsListView()
        {
            return PropsListView;
        }

        private void showOriginalPropsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newPropsButton_Click(object sender, EventArgs e)
        {
            PropsInfoForm form = new PropsInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editPropsButton_Click(object sender, EventArgs e)
        {
            editProps();
        }

        public void editProps()
        {
            if (PropsListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = PropsListView.SelectedItems[0];

                PropsInfoForm form = new PropsInfoForm((Form)Parent);
                form.PropsId = lvi.SubItems[1].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readPropsInfo();

                form.ShowDialog();
            }
        }

        private void PropsListView_DoubleClick(object sender, EventArgs e)
        {
            editProps();
        }

        private void PropsListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editProps();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchProps();
        }

        public void searchProps()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allPropsLvis.ContainsKey(searchText))
            {
                Props Props = DataManager.getData<Props>(searchText);
                if (Props != null)
                {
                    ListViewItem lvi = DataManager.createPropsLvi(searchText);
                    PropsListView.Items.Add(lvi);
                    DataManager.allPropsLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (PropsListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (PropsListView.SelectedItems != null && PropsListView.SelectedItems.Count != 0)
                {
                    startIndex = PropsListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == PropsListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = PropsListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            PropsListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == PropsListView.Items.Count)
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
                searchProps();
            }
        }

        private void PropsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (PropsListView.SelectedItems.Count > 0)
            {
                selectIndex = PropsListView.Items.IndexOf(PropsListView.SelectedItems[0]);
                ListViewItem lvi = PropsListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deletePropsButton.Enabled = true;
                }
                else
                {
                    deletePropsButton.Enabled = false;
                }
            }
        }

        private void deletePropsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PropsListView.SelectedItems.Count > 0)
                {
                    string PropsId = PropsListView.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Props.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + PropsId + "\t"))
                        {
                            string pattern = "\r\n" + PropsId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Props), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Props"].Contains(PropsId))
                        {
                            DataManager.allPropsLvis.Remove(PropsId);
                            PropsListView.Items.Remove(PropsListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Props Props = DataManager.getData<Props>(PropsId);

                            ListViewItem lvi = DataManager.createPropsLvi(PropsId);
                            if (DataManager.allPropsLvis.ContainsKey(PropsId))
                            {
                                DataManager.allPropsLvis[PropsId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalPropsCheckBox.Checked)
                            {
                                for (int i = 0; i < PropsListView.Items.Count; i++)
                                {
                                    if (PropsListView.Items[i].SubItems[1].Text == PropsId)
                                    {
                                        PropsListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                PropsListView.Items.Remove(PropsListView.SelectedItems[0]);
                            }

                        }
                        deletePropsButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Props"))
            {
                DataManager.dict.Remove("Props");
            }
            DataManager.LoadTextfile("Props");

            DataManager.allPropsLvis.Clear();
            DataManager.allPropsLvis = DataManager.createPropsLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Props.txt";

            if (PropsListView.SelectedItems.Count > 0 && PropsListView.SelectedItems[0].SubItems[PropsListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Props.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Props.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Props.txt";

            if (PropsListView.SelectedItems.Count > 0 && PropsListView.SelectedItems[0].SubItems[PropsListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Props.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Props.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
