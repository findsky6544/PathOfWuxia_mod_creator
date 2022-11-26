using System;
using System.Linq;
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
            talkListView.Items.Clear();
            talkListView.Items.AddRange(DataManager.allTalkLvis.Values.Where(x => (showOriginalTalkCheckBox.Checked || x.SubItems[4].Text == "1")).ToArray());
            if (talkListView.SelectedItems.Count > 0)
            {
                talkListView.EnsureVisible(talkListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getTalkListView()
        {
            return talkListView;
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
            if (talkListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = talkListView.SelectedItems[0];

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

            if (talkListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (talkListView.SelectedItems != null && talkListView.SelectedItems.Count != 0)
                {
                    startIndex = talkListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == talkListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = talkListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            talkListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == talkListView.Items.Count)
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
            if (talkListView.SelectedItems.Count > 0)
            {
                selectIndex = talkListView.Items.IndexOf(talkListView.SelectedItems[0]);
                ListViewItem lvi = talkListView.SelectedItems[0];
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
            /*if (talkListView.SelectedItems.Count > 0)
            {
                string TalkId = talkListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + TalkId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + TalkId + ".json");

                        MainForm mainForm = (MainForm)this.Parent;

                        DataManager.dict["talk_cus"].Remove(TalkId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.talkPath + "\\" + TalkId + ".json"))
                        {
                            DataManager.allTalkLvis.Remove(TalkId);
                            talkListView.Items.Remove(talkListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            ScheduleGraph.Bundle talk = DataManager.getData<ScheduleGraph.Bundle>("talk", TalkId);

                            ListViewItem lvi = DataManager.createTalkLvi(TalkId);
                                if (DataManager.allTalkLvis.ContainsKey(TalkId))
                                {
                                DataManager.allTalkLvis[TalkId] = lvi;
                                }
                            //如果不显示则删除列表数据
                            if (showOriginalTalkCheckBox.Checked)
                            {
                                for (int i = 0; i < talkListView.Items.Count; i++)
                                {
                                    if (talkListView.Items[i].SubItems[1].Text == TalkId)
                                    {
                                        talkListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                talkListView.Items.Remove(talkListView.SelectedItems[0]);
                            }

                        }
                        deleteTalkButton.Enabled = false;
                    }
                }
            }*/
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
            /*string filePath = DataManager.talkPath + "\\" + talkListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + talkListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + talkListView.SelectedItems[0].Text + ".json" ;
            }
            System.Diagnostics.Process.Start(filePath);*/
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string filePath = DataManager.talkPath + "\\" + talkListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + talkListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTalkPath + "\\" + talkListView.SelectedItems[0].Text + ".json";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);*/
        }
    }
}
