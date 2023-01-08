using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TalkTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public TalkTabControlUserControl()
        {
            InitializeComponent();
        }
        public TalkTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            TalkListView.Items.Clear();
            TalkListView.Items.AddRange(DataManager.allTalkLvis.Values.Where(x => (showOriginalTalkCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (TalkListView.SelectedItems.Count > 0)
            {
                TalkListView.EnsureVisible(TalkListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getTalkListView()
        {
            return TalkListView;
        }

        private void showOriginalTalkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newTalkButton_Click(object sender, EventArgs e)
        {
            TalkInfoForm form = new TalkInfoForm(null,true);
            form.ShowDialog();
        }

        private void editTalkButton_Click(object sender, EventArgs e)
        {
            editTalk();
        }

        public void editTalk()
        {
            if (TalkListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = TalkListView.SelectedItems[0];

                TalkInfoForm form = new TalkInfoForm(lvi.SubItems[0].Text,true);

                form.ShowDialog();
            }
        }

        private void talkListView_DoubleClick(object sender, EventArgs e)
        {
            editTalk();
        }

        private void talkListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editTalk();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchTalk();
        }

        public void searchTalk()
        {
            string searchText = searchTextBox.Text;
            /*if (!DataManager.allTalkLvis.ContainsKey(searchText))
            {
                Talk talk = DataManager.getData<Talk>(searchText);
                if (talk != null)
                {
                    ListViewItem lvi = DataManager.createTalkLvi(searchText);
                    talkListView.Items.Add(lvi);
                    DataManager.allTalkLvis.Add(searchText, lvi);
                }
            }*/
            bool isSearched = false;

            if (TalkListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (TalkListView.SelectedItems != null && TalkListView.SelectedItems.Count != 0)
                {
                    startIndex = TalkListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == TalkListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = TalkListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            TalkListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == TalkListView.Items.Count)
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
                searchTalk();
            }
        }

        private void talkListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (TalkListView.SelectedItems.Count > 0)
            {
                selectIndex = TalkListView.Items.IndexOf(TalkListView.SelectedItems[0]);
                ListViewItem lvi = TalkListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteTalkButton.Enabled = true;
                }
                else
                {
                    deleteTalkButton.Enabled = false;
                }
            }
        }

        private void deleteTalkButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TalkListView.SelectedItems.Count > 0)
                {
                    string TalkId = TalkListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "/Talk_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + TalkId + "\t"))
                        {
                            string pattern = "\r\n" + TalkId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Talk), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Talk"].Contains(TalkId))
                        {
                            DataManager.allTalkLvis.Remove(TalkId);
                            TalkListView.Items.Remove(TalkListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Talk Talk = DataManager.getData<Talk>(TalkId);

                            ListViewItem lvi = DataManager.createTalkLvi(TalkId);
                            if (DataManager.allTalkLvis.ContainsKey(TalkId))
                            {
                                DataManager.allTalkLvis[TalkId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalTalkCheckBox.Checked)
                            {
                                for (int i = 0; i < TalkListView.Items.Count; i++)
                                {
                                    if (TalkListView.Items[i].SubItems[0].Text == TalkId)
                                    {
                                        TalkListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                TalkListView.Items.Remove(TalkListView.SelectedItems[0]);
                            }

                        }
                        deleteTalkButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("talk"))
            {
                DataManager.dict.Remove("talk");
            }
            DataManager.LoadTextfile("Talk");

            DataManager.allTalkLvis.Clear();
            //DataManager.allTalkLvis = DataManager.createTalkLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Talk.txt";

            if (TalkListView.SelectedItems.Count > 0 && TalkListView.SelectedItems[0].SubItems[TalkListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Talk_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Talk_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Talk.txt";

            if (TalkListView.SelectedItems.Count > 0 && TalkListView.SelectedItems[0].SubItems[TalkListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Talk_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Talk_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
