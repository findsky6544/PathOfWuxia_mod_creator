using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public CharacterInfoTabControlUserControl()
        {
            InitializeComponent();
        }
        public CharacterInfoTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                CharacterInfoListView.Items.Clear();
                CharacterInfoListView.Items.AddRange(DataManager.allCharacterInfoLvis.Values.Where(x => (showOriginalCharacterInfoCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (CharacterInfoListView.SelectedItems.Count > 0)
                {
                    CharacterInfoListView.EnsureVisible(CharacterInfoListView.SelectedItems[0].Index);
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

        public ListView getCharacterInfoListView()
        {
            return CharacterInfoListView;
        }

        private void showOriginalCharacterInfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newCharacterInfoButton_Click(object sender, EventArgs e)
        {
            CharacterInfoInfoForm form = new CharacterInfoInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editCharacterInfoButton_Click(object sender, EventArgs e)
        {
            editCharacterInfo();
        }

        public void editCharacterInfo()
        {
            if (CharacterInfoListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = CharacterInfoListView.SelectedItems[0];

                CharacterInfoInfoForm form = new CharacterInfoInfoForm((Form)Parent);
                form.CharacterInfoId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readCharacterInfoInfo();

                form.ShowDialog();
            }
        }

        private void CharacterInfoListView_DoubleClick(object sender, EventArgs e)
        {
            editCharacterInfo();
        }

        private void CharacterInfoListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editCharacterInfo();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterInfo();
        }

        public void searchCharacterInfo()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allCharacterInfoLvis.ContainsKey(searchText))
            {
                CharacterInfo CharacterInfo = DataManager.getData<CharacterInfo>(searchText);
                if (CharacterInfo != null)
                {
                    ListViewItem lvi = DataManager.createCharacterInfoLvi(searchText);
                    CharacterInfoListView.Items.Add(lvi);
                    DataManager.allCharacterInfoLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (CharacterInfoListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (CharacterInfoListView.SelectedItems != null && CharacterInfoListView.SelectedItems.Count != 0)
                {
                    startIndex = CharacterInfoListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == CharacterInfoListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = CharacterInfoListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            CharacterInfoListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == CharacterInfoListView.Items.Count)
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
                searchCharacterInfo();
            }
        }

        private void CharacterInfoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (CharacterInfoListView.SelectedItems.Count > 0)
            {
                selectIndex = CharacterInfoListView.Items.IndexOf(CharacterInfoListView.SelectedItems[0]);
                ListViewItem lvi = CharacterInfoListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteCharacterInfoButton.Enabled = true;
                }
                else
                {
                    deleteCharacterInfoButton.Enabled = false;
                }
            }
        }

        private void deleteCharacterInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CharacterInfoListView.SelectedItems.Count > 0)
                {
                    string CharacterInfoId = CharacterInfoListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/CharacterInfo_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + CharacterInfoId + "\t"))
                        {
                            string pattern = "\r\n" + CharacterInfoId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(CharacterInfo), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["CharacterInfo"].Contains(CharacterInfoId))
                        {
                            DataManager.allCharacterInfoLvis.Remove(CharacterInfoId);
                            CharacterInfoListView.Items.Remove(CharacterInfoListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            CharacterInfo CharacterInfo = DataManager.getData<CharacterInfo>(CharacterInfoId);

                            ListViewItem lvi = DataManager.createCharacterInfoLvi(CharacterInfoId);
                            if (DataManager.allCharacterInfoLvis.ContainsKey(CharacterInfoId))
                            {
                                DataManager.allCharacterInfoLvis[CharacterInfoId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalCharacterInfoCheckBox.Checked)
                            {
                                for (int i = 0; i < CharacterInfoListView.Items.Count; i++)
                                {
                                    if (CharacterInfoListView.Items[i].SubItems[0].Text == CharacterInfoId)
                                    {
                                        CharacterInfoListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                CharacterInfoListView.Items.Remove(CharacterInfoListView.SelectedItems[0]);
                            }

                        }
                        deleteCharacterInfoButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("CharacterInfo"))
            {
                DataManager.dict.Remove("CharacterInfo");
            }
            DataManager.LoadTextfile("CharacterInfo");

            DataManager.allCharacterInfoLvis.Clear();
            DataManager.allCharacterInfoLvis = DataManager.createCharacterInfoLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterInfo.txt";

            if (CharacterInfoListView.SelectedItems.Count > 0 && CharacterInfoListView.SelectedItems[0].SubItems[CharacterInfoListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterInfo_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterInfo_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterInfo.txt";

            if (CharacterInfoListView.SelectedItems.Count > 0 && CharacterInfoListView.SelectedItems[0].SubItems[CharacterInfoListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterInfo_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterInfo_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
