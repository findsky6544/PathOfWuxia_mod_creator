using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterExteriorTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public CharacterExteriorTabControlUserControl()
        {
            InitializeComponent();
        }
        public CharacterExteriorTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                CharacterExteriorListView.Items.Clear();
                CharacterExteriorListView.Items.AddRange(DataManager.allCharacterExteriorLvis.Values.Where(x => (showOriginalCharacterExteriorCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (CharacterExteriorListView.SelectedItems.Count > 0)
                {
                    CharacterExteriorListView.EnsureVisible(CharacterExteriorListView.SelectedItems[0].Index);
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

        public ListView getCharacterExteriorListView()
        {
            return CharacterExteriorListView;
        }

        private void showOriginalCharacterExteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newCharacterExteriorButton_Click(object sender, EventArgs e)
        {
            CharacterExteriorInfoForm form = new CharacterExteriorInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editCharacterExteriorButton_Click(object sender, EventArgs e)
        {
            editCharacterExterior();
        }

        public void editCharacterExterior()
        {
            if (CharacterExteriorListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = CharacterExteriorListView.SelectedItems[0];

                CharacterExteriorInfoForm form = new CharacterExteriorInfoForm((Form)Parent);
                form.CharacterExteriorId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readCharacterExteriorInfo();

                form.ShowDialog();
            }
        }

        private void CharacterExteriorListView_DoubleClick(object sender, EventArgs e)
        {
            editCharacterExterior();
        }

        private void CharacterExteriorListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editCharacterExterior();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterExterior();
        }

        public void searchCharacterExterior()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allCharacterExteriorLvis.ContainsKey(searchText))
            {
                CharacterExterior CharacterExterior = DataManager.getData<CharacterExterior>(searchText);
                if (CharacterExterior != null)
                {
                    ListViewItem lvi = DataManager.createCharacterExteriorLvi(searchText);
                    CharacterExteriorListView.Items.Add(lvi);
                    DataManager.allCharacterExteriorLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (CharacterExteriorListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (CharacterExteriorListView.SelectedItems != null && CharacterExteriorListView.SelectedItems.Count != 0)
                {
                    startIndex = CharacterExteriorListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == CharacterExteriorListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = CharacterExteriorListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            CharacterExteriorListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == CharacterExteriorListView.Items.Count)
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
                searchCharacterExterior();
            }
        }

        private void CharacterExteriorListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (CharacterExteriorListView.SelectedItems.Count > 0)
            {
                selectIndex = CharacterExteriorListView.Items.IndexOf(CharacterExteriorListView.SelectedItems[0]);
                ListViewItem lvi = CharacterExteriorListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteCharacterExteriorButton.Enabled = true;
                }
                else
                {
                    deleteCharacterExteriorButton.Enabled = false;
                }
            }
        }

        private void deleteCharacterExteriorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CharacterExteriorListView.SelectedItems.Count > 0)
                {
                    string CharacterExteriorId = CharacterExteriorListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/CharacterExterior.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + CharacterExteriorId + "\t"))
                        {
                            string pattern = "\r\n" + CharacterExteriorId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(CharacterExterior), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["CharacterExterior"].Contains(CharacterExteriorId))
                        {
                            DataManager.allCharacterExteriorLvis.Remove(CharacterExteriorId);
                            CharacterExteriorListView.Items.Remove(CharacterExteriorListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            CharacterExterior CharacterExterior = DataManager.getData<CharacterExterior>(CharacterExteriorId);

                            ListViewItem lvi = DataManager.createCharacterExteriorLvi(CharacterExteriorId);
                            if (DataManager.allCharacterExteriorLvis.ContainsKey(CharacterExteriorId))
                            {
                                DataManager.allCharacterExteriorLvis[CharacterExteriorId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalCharacterExteriorCheckBox.Checked)
                            {
                                for (int i = 0; i < CharacterExteriorListView.Items.Count; i++)
                                {
                                    if (CharacterExteriorListView.Items[i].SubItems[0].Text == CharacterExteriorId)
                                    {
                                        CharacterExteriorListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                CharacterExteriorListView.Items.Remove(CharacterExteriorListView.SelectedItems[0]);
                            }

                        }
                        deleteCharacterExteriorButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("CharacterExterior"))
            {
                DataManager.dict.Remove("CharacterExterior");
            }
            DataManager.LoadTextfile("CharacterExterior");

            DataManager.allCharacterExteriorLvis.Clear();
            DataManager.allCharacterExteriorLvis = DataManager.createCharacterExteriorLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterExterior.txt";

            if (CharacterExteriorListView.SelectedItems.Count > 0 && CharacterExteriorListView.SelectedItems[0].SubItems[CharacterExteriorListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterExterior.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterExterior.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterExterior.txt";

            if (CharacterExteriorListView.SelectedItems.Count > 0 && CharacterExteriorListView.SelectedItems[0].SubItems[CharacterExteriorListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterExterior.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterExterior.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
