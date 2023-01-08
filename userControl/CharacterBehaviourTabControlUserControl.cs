using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterBehaviourTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public CharacterBehaviourTabControlUserControl()
        {
            InitializeComponent();
        }
        public CharacterBehaviourTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                CharacterBehaviourListView.Items.Clear();
                CharacterBehaviourListView.Items.AddRange(DataManager.allCharacterBehaviourLvis.Values.Where(x => (showOriginalCharacterBehaviourCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (CharacterBehaviourListView.SelectedItems.Count > 0)
                {
                    CharacterBehaviourListView.EnsureVisible(CharacterBehaviourListView.SelectedItems[0].Index);
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

        public ListView getCharacterBehaviourListView()
        {
            return CharacterBehaviourListView;
        }

        private void showOriginalCharacterBehaviourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newCharacterBehaviourButton_Click(object sender, EventArgs e)
        {
            CharacterBehaviourInfoForm form = new CharacterBehaviourInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editCharacterBehaviourButton_Click(object sender, EventArgs e)
        {
            editCharacterBehaviour();
        }

        public void editCharacterBehaviour()
        {
            if (CharacterBehaviourListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = CharacterBehaviourListView.SelectedItems[0];

                CharacterBehaviourInfoForm form = new CharacterBehaviourInfoForm((Form)Parent);
                form.CharacterBehaviourId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readCharacterBehaviourInfo();

                form.ShowDialog();
            }
        }

        private void CharacterBehaviourListView_DoubleClick(object sender, EventArgs e)
        {
            editCharacterBehaviour();
        }

        private void CharacterBehaviourListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editCharacterBehaviour();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterBehaviour();
        }

        public void searchCharacterBehaviour()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allCharacterBehaviourLvis.ContainsKey(searchText))
            {
                CharacterBehaviour CharacterBehaviour = DataManager.getData<CharacterBehaviour>(searchText);
                if (CharacterBehaviour != null)
                {
                    ListViewItem lvi = DataManager.createCharacterBehaviourLvi(searchText);
                    CharacterBehaviourListView.Items.Add(lvi);
                    DataManager.allCharacterBehaviourLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (CharacterBehaviourListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (CharacterBehaviourListView.SelectedItems != null && CharacterBehaviourListView.SelectedItems.Count != 0)
                {
                    startIndex = CharacterBehaviourListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == CharacterBehaviourListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = CharacterBehaviourListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            CharacterBehaviourListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == CharacterBehaviourListView.Items.Count)
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
                searchCharacterBehaviour();
            }
        }

        private void CharacterBehaviourListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (CharacterBehaviourListView.SelectedItems.Count > 0)
            {
                selectIndex = CharacterBehaviourListView.Items.IndexOf(CharacterBehaviourListView.SelectedItems[0]);
                ListViewItem lvi = CharacterBehaviourListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteCharacterBehaviourButton.Enabled = true;
                }
                else
                {
                    deleteCharacterBehaviourButton.Enabled = false;
                }
            }
        }

        private void deleteCharacterBehaviourButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CharacterBehaviourListView.SelectedItems.Count > 0)
                {
                    string CharacterBehaviourId = CharacterBehaviourListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/CharacterBehaviour_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + CharacterBehaviourId + "\t"))
                        {
                            string pattern = "\r\n" + CharacterBehaviourId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(CharacterBehaviour), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["CharacterBehaviour"].Contains(CharacterBehaviourId))
                        {
                            DataManager.allCharacterBehaviourLvis.Remove(CharacterBehaviourId);
                            CharacterBehaviourListView.Items.Remove(CharacterBehaviourListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            CharacterBehaviour CharacterBehaviour = DataManager.getData<CharacterBehaviour>(CharacterBehaviourId);

                            ListViewItem lvi = DataManager.createCharacterBehaviourLvi(CharacterBehaviourId);
                            if (DataManager.allCharacterBehaviourLvis.ContainsKey(CharacterBehaviourId))
                            {
                                DataManager.allCharacterBehaviourLvis[CharacterBehaviourId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalCharacterBehaviourCheckBox.Checked)
                            {
                                for (int i = 0; i < CharacterBehaviourListView.Items.Count; i++)
                                {
                                    if (CharacterBehaviourListView.Items[i].SubItems[0].Text == CharacterBehaviourId)
                                    {
                                        CharacterBehaviourListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                CharacterBehaviourListView.Items.Remove(CharacterBehaviourListView.SelectedItems[0]);
                            }

                        }
                        deleteCharacterBehaviourButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("CharacterBehaviour"))
            {
                DataManager.dict.Remove("CharacterBehaviour");
            }
            DataManager.LoadTextfile("CharacterBehaviour");

            DataManager.allCharacterBehaviourLvis.Clear();
            DataManager.allCharacterBehaviourLvis = DataManager.createCharacterBehaviourLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterBehaviour.txt";

            if (CharacterBehaviourListView.SelectedItems.Count > 0 && CharacterBehaviourListView.SelectedItems[0].SubItems[CharacterBehaviourListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterBehaviour_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterBehaviour_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "CharacterBehaviour.txt";

            if (CharacterBehaviourListView.SelectedItems.Count > 0 && CharacterBehaviourListView.SelectedItems[0].SubItems[CharacterBehaviourListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterBehaviour_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "CharacterBehaviour_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
