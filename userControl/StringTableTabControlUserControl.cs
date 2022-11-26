using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class StringTableTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public StringTableTabControlUserControl()
        {
            InitializeComponent();
        }
        public StringTableTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            StringTableListView.Items.Clear();
            StringTableListView.Items.AddRange(DataManager.allStringTableLvis.Values.Where(x => (showOriginalStringTableCheckBox.Checked || x.SubItems[4].Text == "1")).ToArray());
            if (StringTableListView.SelectedItems.Count > 0)
            {
                StringTableListView.EnsureVisible(StringTableListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getStringTableListView()
        {
            return StringTableListView;
        }

        private void showOriginalStringTableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newStringTableButton_Click(object sender, EventArgs e)
        {
            StringTableInfoForm form = new StringTableInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editStringTableButton_Click(object sender, EventArgs e)
        {
            editStringTable();
        }

        public void editStringTable()
        {
            if (StringTableListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = StringTableListView.SelectedItems[0];

                StringTableInfoForm form = new StringTableInfoForm((Form)Parent);
                form.StringTableId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readStringTableInfo();

                form.ShowDialog();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchStringTable();
        }

        public void searchStringTable()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (StringTableListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (StringTableListView.SelectedItems != null && StringTableListView.SelectedItems.Count != 0)
                {
                    startIndex = StringTableListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == StringTableListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = StringTableListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            StringTableListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == StringTableListView.Items.Count)
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
                searchStringTable();
            }
        }

        private void StringTableListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (StringTableListView.SelectedItems.Count > 0)
            {
                selectIndex = StringTableListView.Items.IndexOf(StringTableListView.SelectedItems[0]);
                ListViewItem lvi = StringTableListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteStringTableButton.Enabled = true;
                }
                else
                {
                    deleteStringTableButton.Enabled = false;
                }
            }
        }

        private void deleteStringTableButton_Click(object sender, EventArgs e)
        {
            if (StringTableListView.SelectedItems.Count > 0)
            {
                string StringTableId = StringTableListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + StringTableId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + StringTableId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["StringTable_cus"].Remove(StringTableId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + StringTableId + ".json"))
                        {
                            DataManager.allStringTableLvis.Remove(StringTableId);
                            StringTableListView.Items.Remove(StringTableListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            StringTable StringTable = DataManager.getData<StringTable>(StringTableId);

                            ListViewItem lvi = DataManager.createStringTableLvi(StringTableId);
                            if (DataManager.allStringTableLvis.ContainsKey(StringTableId))
                            {
                                DataManager.allStringTableLvis[StringTableId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalStringTableCheckBox.Checked)
                            {
                                for (int i = 0; i < StringTableListView.Items.Count; i++)
                                {
                                    if (StringTableListView.Items[i].SubItems[1].Text == StringTableId)
                                    {
                                        StringTableListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                StringTableListView.Items.Remove(StringTableListView.SelectedItems[0]);
                            }

                        }
                        deleteStringTableButton.Enabled = false;
                    }
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            MainForm mainForm = (MainForm)Parent;

            if (DataManager.dict.ContainsKey("StringTable"))
            {
                DataManager.dict.Remove("StringTable");
            }
            DataManager.LoadTextfile("StringTable");

            DataManager.allStringTableLvis.Clear();
            DataManager.allStringTableLvis = DataManager.createStringTableLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "StringTable.txt";

            if (StringTableListView.SelectedItems.Count > 0 && StringTableListView.SelectedItems[0].SubItems[StringTableListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "StringTable.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "StringTable.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "StringTable.txt";

            if (StringTableListView.SelectedItems.Count > 0 && StringTableListView.SelectedItems[0].SubItems[StringTableListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "StringTable.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "StringTable.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = StringTableListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void StringTableListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editStringTable();
            }
        }

        private void StringTableListView_DoubleClick(object sender, EventArgs e)
        {
            editStringTable();
        }
    }
}
