using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AlchemyTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public AlchemyTabControlUserControl()
        {
            InitializeComponent();
        }
        public AlchemyTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                AlchemyListView.Items.Clear();
                AlchemyListView.Items.AddRange(DataManager.allAlchemyLvis.Values.Where(x => (showOriginalAlchemyCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (AlchemyListView.SelectedItems.Count > 0)
                {
                    AlchemyListView.EnsureVisible(AlchemyListView.SelectedItems[0].Index);
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

        public ListView getAlchemyListView()
        {
            return AlchemyListView;
        }

        private void showOriginalAlchemyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newAlchemyButton_Click(object sender, EventArgs e)
        {
            AlchemyInfoForm form = new AlchemyInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editAlchemyButton_Click(object sender, EventArgs e)
        {
            editAlchemy();
        }

        public void editAlchemy()
        {
            if (AlchemyListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = AlchemyListView.SelectedItems[0];

                AlchemyInfoForm form = new AlchemyInfoForm((Form)Parent);
                form.AlchemyId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readAlchemyInfo();

                form.ShowDialog();
            }
        }

        private void AlchemyListView_DoubleClick(object sender, EventArgs e)
        {
            editAlchemy();
        }

        private void AlchemyListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editAlchemy();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAlchemy();
        }

        public void searchAlchemy()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allAlchemyLvis.ContainsKey(searchText))
            {
                Alchemy Alchemy = DataManager.getData<Alchemy>(searchText);
                if (Alchemy != null)
                {
                    ListViewItem lvi = DataManager.createAlchemyLvi(searchText);
                    AlchemyListView.Items.Add(lvi);
                    DataManager.allAlchemyLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (AlchemyListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (AlchemyListView.SelectedItems != null && AlchemyListView.SelectedItems.Count != 0)
                {
                    startIndex = AlchemyListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == AlchemyListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = AlchemyListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            AlchemyListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == AlchemyListView.Items.Count)
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
                searchAlchemy();
            }
        }

        private void AlchemyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (AlchemyListView.SelectedItems.Count > 0)
            {
                selectIndex = AlchemyListView.Items.IndexOf(AlchemyListView.SelectedItems[0]);
                ListViewItem lvi = AlchemyListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteAlchemyButton.Enabled = true;
                }
                else
                {
                    deleteAlchemyButton.Enabled = false;
                }
            }
        }

        private void deleteAlchemyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AlchemyListView.SelectedItems.Count > 0)
                {
                    string AlchemyId = AlchemyListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Alchemy_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + AlchemyId + "\t"))
                        {
                            string pattern = "\r\n" + AlchemyId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Alchemy), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Alchemy"].Contains(AlchemyId))
                        {
                            DataManager.allAlchemyLvis.Remove(AlchemyId);
                            AlchemyListView.Items.Remove(AlchemyListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Alchemy Alchemy = DataManager.getData<Alchemy>(AlchemyId);

                            ListViewItem lvi = DataManager.createAlchemyLvi(AlchemyId);
                            if (DataManager.allAlchemyLvis.ContainsKey(AlchemyId))
                            {
                                DataManager.allAlchemyLvis[AlchemyId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalAlchemyCheckBox.Checked)
                            {
                                for (int i = 0; i < AlchemyListView.Items.Count; i++)
                                {
                                    if (AlchemyListView.Items[i].Text == AlchemyId)
                                    {
                                        AlchemyListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                AlchemyListView.Items.Remove(AlchemyListView.SelectedItems[0]);
                            }

                        }
                        deleteAlchemyButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Alchemy"))
            {
                DataManager.dict.Remove("Alchemy");
            }
            DataManager.LoadTextfile("Alchemy");

            DataManager.allAlchemyLvis.Clear();
            DataManager.allAlchemyLvis = DataManager.createAlchemyLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Alchemy.txt";

            if (AlchemyListView.SelectedItems.Count > 0 && AlchemyListView.SelectedItems[0].SubItems[AlchemyListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Alchemy_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Alchemy_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Alchemy.txt";

            if (AlchemyListView.SelectedItems.Count > 0 && AlchemyListView.SelectedItems[0].SubItems[AlchemyListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Alchemy_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Alchemy_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
