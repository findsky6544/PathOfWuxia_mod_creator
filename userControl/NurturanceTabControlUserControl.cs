using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NurturanceTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public NurturanceTabControlUserControl()
        {
            InitializeComponent();
        }
        public NurturanceTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                NurturanceListView.Items.Clear();
                NurturanceListView.Items.AddRange(DataManager.allNurturanceLvis.Values.Where(x => (showOriginalNurturanceCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (NurturanceListView.SelectedItems.Count > 0)
                {
                    NurturanceListView.EnsureVisible(NurturanceListView.SelectedItems[0].Index);
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

        public ListView getNurturanceListView()
        {
            return NurturanceListView;
        }

        private void showOriginalNurturanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newNurturanceButton_Click(object sender, EventArgs e)
        {
            NurturanceInfoForm form = new NurturanceInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editNurturanceButton_Click(object sender, EventArgs e)
        {
            editNurturance();
        }

        public void editNurturance()
        {
            if (NurturanceListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = NurturanceListView.SelectedItems[0];

                NurturanceInfoForm form = new NurturanceInfoForm((Form)Parent);
                form.NurturanceId = lvi.SubItems[1].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readNurturanceInfo();

                form.ShowDialog();
            }
        }

        private void NurturanceListView_DoubleClick(object sender, EventArgs e)
        {
            editNurturance();
        }

        private void NurturanceListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editNurturance();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchNurturance();
        }

        public void searchNurturance()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allNurturanceLvis.ContainsKey(searchText))
            {
                Nurturance Nurturance = DataManager.getData<Nurturance>(searchText);
                if (Nurturance != null)
                {
                    ListViewItem lvi = DataManager.createNurturanceLvi(searchText);
                    NurturanceListView.Items.Add(lvi);
                    DataManager.allNurturanceLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (NurturanceListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (NurturanceListView.SelectedItems != null && NurturanceListView.SelectedItems.Count != 0)
                {
                    startIndex = NurturanceListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == NurturanceListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = NurturanceListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            NurturanceListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == NurturanceListView.Items.Count)
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
                searchNurturance();
            }
        }

        private void NurturanceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (NurturanceListView.SelectedItems.Count > 0)
            {
                selectIndex = NurturanceListView.Items.IndexOf(NurturanceListView.SelectedItems[0]);
                ListViewItem lvi = NurturanceListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteNurturanceButton.Enabled = true;
                }
                else
                {
                    deleteNurturanceButton.Enabled = false;
                }
            }
        }

        private void deleteNurturanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NurturanceListView.SelectedItems.Count > 0)
                {
                    string NurturanceId = NurturanceListView.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Nurturance_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + NurturanceId + "\t"))
                        {
                            string pattern = "\r\n" + NurturanceId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Nurturance), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Nurturance"].Contains(NurturanceId))
                        {
                            DataManager.allNurturanceLvis.Remove(NurturanceId);
                            NurturanceListView.Items.Remove(NurturanceListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Nurturance Nurturance = DataManager.getData<Nurturance>(NurturanceId);

                            ListViewItem lvi = DataManager.createNurturanceLvi(NurturanceId);
                            if (DataManager.allNurturanceLvis.ContainsKey(NurturanceId))
                            {
                                DataManager.allNurturanceLvis[NurturanceId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalNurturanceCheckBox.Checked)
                            {
                                for (int i = 0; i < NurturanceListView.Items.Count; i++)
                                {
                                    if (NurturanceListView.Items[i].SubItems[1].Text == NurturanceId)
                                    {
                                        NurturanceListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                NurturanceListView.Items.Remove(NurturanceListView.SelectedItems[0]);
                            }

                        }
                        deleteNurturanceButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Nurturance"))
            {
                DataManager.dict.Remove("Nurturance");
            }
            DataManager.LoadTextfile("Nurturance");

            DataManager.allNurturanceLvis.Clear();
            DataManager.allNurturanceLvis = DataManager.createNurturanceLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Nurturance.txt";

            if (NurturanceListView.SelectedItems.Count > 0 && NurturanceListView.SelectedItems[0].SubItems[NurturanceListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Nurturance_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Nurturance_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Nurturance.txt";

            if (NurturanceListView.SelectedItems.Count > 0 && NurturanceListView.SelectedItems[0].SubItems[NurturanceListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Nurturance_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Nurturance_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
