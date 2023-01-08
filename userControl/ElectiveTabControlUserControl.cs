using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ElectiveTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public ElectiveTabControlUserControl()
        {
            InitializeComponent();
        }
        public ElectiveTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                ElectiveListView.Items.Clear();
                ElectiveListView.Items.AddRange(DataManager.allElectiveLvis.Values.Where(x => (showOriginalElectiveCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (ElectiveListView.SelectedItems.Count > 0)
                {
                    ElectiveListView.EnsureVisible(ElectiveListView.SelectedItems[0].Index);
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

        public ListView getElectiveListView()
        {
            return ElectiveListView;
        }

        private void showOriginalElectiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newElectiveButton_Click(object sender, EventArgs e)
        {
            ElectiveInfoForm form = new ElectiveInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editElectiveButton_Click(object sender, EventArgs e)
        {
            editElective();
        }

        public void editElective()
        {
            if (ElectiveListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = ElectiveListView.SelectedItems[0];

                ElectiveInfoForm form = new ElectiveInfoForm((Form)Parent);
                form.ElectiveId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readElectiveInfo();

                form.ShowDialog();
            }
        }

        private void ElectiveListView_DoubleClick(object sender, EventArgs e)
        {
            editElective();
        }

        private void ElectiveListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editElective();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchElective();
        }

        public void searchElective()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allElectiveLvis.ContainsKey(searchText))
            {
                Elective Elective = DataManager.getData<Elective>(searchText);
                if (Elective != null)
                {
                    ListViewItem lvi = DataManager.createElectiveLvi(searchText);
                    ElectiveListView.Items.Add(lvi);
                    DataManager.allElectiveLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (ElectiveListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (ElectiveListView.SelectedItems != null && ElectiveListView.SelectedItems.Count != 0)
                {
                    startIndex = ElectiveListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == ElectiveListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = ElectiveListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            ElectiveListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == ElectiveListView.Items.Count)
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
                searchElective();
            }
        }

        private void ElectiveListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (ElectiveListView.SelectedItems.Count > 0)
            {
                selectIndex = ElectiveListView.Items.IndexOf(ElectiveListView.SelectedItems[0]);
                ListViewItem lvi = ElectiveListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteElectiveButton.Enabled = true;
                }
                else
                {
                    deleteElectiveButton.Enabled = false;
                }
            }
        }

        private void deleteElectiveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ElectiveListView.SelectedItems.Count > 0)
                {
                    string ElectiveId = ElectiveListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Elective_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + ElectiveId + "\t"))
                        {
                            string pattern = "\r\n" + ElectiveId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Elective), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Elective"].Contains(ElectiveId))
                        {
                            DataManager.allElectiveLvis.Remove(ElectiveId);
                            ElectiveListView.Items.Remove(ElectiveListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Elective Elective = DataManager.getData<Elective>(ElectiveId);

                            ListViewItem lvi = DataManager.createElectiveLvi(ElectiveId);
                            if (DataManager.allElectiveLvis.ContainsKey(ElectiveId))
                            {
                                DataManager.allElectiveLvis[ElectiveId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalElectiveCheckBox.Checked)
                            {
                                for (int i = 0; i < ElectiveListView.Items.Count; i++)
                                {
                                    if (ElectiveListView.Items[i].SubItems[0].Text == ElectiveId)
                                    {
                                        ElectiveListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ElectiveListView.Items.Remove(ElectiveListView.SelectedItems[0]);
                            }

                        }
                        deleteElectiveButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Elective"))
            {
                DataManager.dict.Remove("Elective");
            }
            DataManager.LoadTextfile("Elective");

            DataManager.allElectiveLvis.Clear();
            DataManager.allElectiveLvis = DataManager.createElectiveLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Elective.txt";

            if (ElectiveListView.SelectedItems.Count > 0 && ElectiveListView.SelectedItems[0].SubItems[ElectiveListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Elective_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Elective_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Elective.txt";

            if (ElectiveListView.SelectedItems.Count > 0 && ElectiveListView.SelectedItems[0].SubItems[ElectiveListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Elective_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Elective_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
