using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NpcTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public NpcTabControlUserControl()
        {
            InitializeComponent();
        }
        public NpcTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                NpcListView.Items.Clear();
                NpcListView.Items.AddRange(DataManager.allNpcLvis.Values.Where(x => (showOriginalNpcCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (NpcListView.SelectedItems.Count > 0)
                {
                    NpcListView.EnsureVisible(NpcListView.SelectedItems[0].Index);
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

        public ListView getNpcListView()
        {
            return NpcListView;
        }

        private void showOriginalNpcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newNpcButton_Click(object sender, EventArgs e)
        {
            NpcInfoForm form = new NpcInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editNpcButton_Click(object sender, EventArgs e)
        {
            editNpc();
        }

        public void editNpc()
        {
            if (NpcListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = NpcListView.SelectedItems[0];

                NpcInfoForm form = new NpcInfoForm((Form)Parent);
                form.NpcId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readNpcInfo();

                form.ShowDialog();
            }
        }

        private void NpcListView_DoubleClick(object sender, EventArgs e)
        {
            editNpc();
        }

        private void NpcListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editNpc();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchNpc();
        }

        public void searchNpc()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allNpcLvis.ContainsKey(searchText))
            {
                Npc Npc = DataManager.getData<Npc>(searchText);
                if (Npc != null)
                {
                    ListViewItem lvi = DataManager.createNpcLvi(searchText);
                    NpcListView.Items.Add(lvi);
                    DataManager.allNpcLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (NpcListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (NpcListView.SelectedItems != null && NpcListView.SelectedItems.Count != 0)
                {
                    startIndex = NpcListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == NpcListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = NpcListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            NpcListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == NpcListView.Items.Count)
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
                searchNpc();
            }
        }

        private void NpcListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (NpcListView.SelectedItems.Count > 0)
            {
                selectIndex = NpcListView.Items.IndexOf(NpcListView.SelectedItems[0]);
                ListViewItem lvi = NpcListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteNpcButton.Enabled = true;
                }
                else
                {
                    deleteNpcButton.Enabled = false;
                }
            }
        }

        private void deleteNpcButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NpcListView.SelectedItems.Count > 0)
                {
                    string NpcId = NpcListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Npc_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + NpcId + "\t"))
                        {
                            string pattern = "\r\n" + NpcId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Npc), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Npc"].Contains(NpcId))
                        {
                            DataManager.allNpcLvis.Remove(NpcId);
                            NpcListView.Items.Remove(NpcListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Npc Npc = DataManager.getData<Npc>(NpcId);

                            ListViewItem lvi = DataManager.createNpcLvi(NpcId);
                            if (DataManager.allNpcLvis.ContainsKey(NpcId))
                            {
                                DataManager.allNpcLvis[NpcId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalNpcCheckBox.Checked)
                            {
                                for (int i = 0; i < NpcListView.Items.Count; i++)
                                {
                                    if (NpcListView.Items[i].SubItems[0].Text == NpcId)
                                    {
                                        NpcListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                NpcListView.Items.Remove(NpcListView.SelectedItems[0]);
                            }

                        }
                        deleteNpcButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Npc"))
            {
                DataManager.dict.Remove("Npc");
            }
            DataManager.LoadTextfile("Npc");

            DataManager.allNpcLvis.Clear();
            DataManager.allNpcLvis = DataManager.createNpcLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Npc.txt";

            if (NpcListView.SelectedItems.Count > 0 && NpcListView.SelectedItems[0].SubItems[NpcListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Npc_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Npc_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Npc.txt";

            if (NpcListView.SelectedItems.Count > 0 && NpcListView.SelectedItems[0].SubItems[NpcListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Npc_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Npc_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
