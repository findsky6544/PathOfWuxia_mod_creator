using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class QuestTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public QuestTabControlUserControl()
        {
            InitializeComponent();
        }
        public QuestTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            QuestListView.Items.Clear();
            QuestListView.Items.AddRange(DataManager.allQuestLvis.Values.Where(x => (showOriginalQuestCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (QuestListView.SelectedItems.Count > 0)
            {
                QuestListView.EnsureVisible(QuestListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getQuestListView()
        {
            return QuestListView;
        }

        private void showOriginalQuestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newQuestButton_Click(object sender, EventArgs e)
        {
            QuestInfoForm form = new QuestInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editQuestButton_Click(object sender, EventArgs e)
        {
            editQuest();
        }

        public void editQuest()
        {
            if (QuestListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = QuestListView.SelectedItems[0];

                QuestInfoForm form = new QuestInfoForm((Form)Parent);
                form.questId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readQuestInfo();

                form.ShowDialog();
            }
        }

        private void questListView_DoubleClick(object sender, EventArgs e)
        {
            editQuest();
        }

        private void questListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editQuest();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchQuest();
        }

        public void searchQuest()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (QuestListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (QuestListView.SelectedItems != null && QuestListView.SelectedItems.Count != 0)
                {
                    startIndex = QuestListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == QuestListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = QuestListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            QuestListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == QuestListView.Items.Count)
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
                searchQuest();
            }
        }

        private void questListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (QuestListView.SelectedItems.Count > 0)
            {
                selectIndex = QuestListView.Items.IndexOf(QuestListView.SelectedItems[0]);
                ListViewItem lvi = QuestListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteQuestButton.Enabled = true;
                }
                else
                {
                    deleteQuestButton.Enabled = false;
                }
            }
        }

        private void deleteQuestButton_Click(object sender, EventArgs e)
        {
            if (QuestListView.SelectedItems.Count > 0)
            {
                string QuestId = QuestListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + QuestId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + QuestId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["quest_cus"].Remove(QuestId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + QuestId + ".json"))
                        {
                            DataManager.allQuestLvis.Remove(QuestId);
                            QuestListView.Items.Remove(QuestListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Quest quest = DataManager.getData<Quest>(QuestId);

                            ListViewItem lvi = DataManager.createQuestLvi(QuestId);
                            if (DataManager.allQuestLvis.ContainsKey(QuestId))
                            {
                                DataManager.allQuestLvis[QuestId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalQuestCheckBox.Checked)
                            {
                                for (int i = 0; i < QuestListView.Items.Count; i++)
                                {
                                    if (QuestListView.Items[i].SubItems[1].Text == QuestId)
                                    {
                                        QuestListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                QuestListView.Items.Remove(QuestListView.SelectedItems[0]);
                            }

                        }
                        deleteQuestButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Quest"))
            {
                DataManager.dict.Remove("Quest");
            }
            DataManager.LoadTextfile("Quest");

            DataManager.allQuestLvis.Clear();
            DataManager.allQuestLvis = DataManager.createQuestLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Quest.txt";

            if (QuestListView.SelectedItems.Count > 0 && QuestListView.SelectedItems[0].SubItems[QuestListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Quest.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Quest.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Quest.txt";

            if (QuestListView.SelectedItems.Count > 0 && QuestListView.SelectedItems[0].SubItems[QuestListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Quest.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Quest.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = QuestListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }
    }
}
