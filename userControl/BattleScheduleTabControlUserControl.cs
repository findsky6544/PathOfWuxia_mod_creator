using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleScheduleTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public BattleScheduleTabControlUserControl()
        {
            InitializeComponent();
        }
        public BattleScheduleTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            scheduleListView.Items.Clear();
            scheduleListView.Items.AddRange(DataManager.allBattleScheduleLvis.Values.Where(x => (showOriginalScheduleCheckBox.Checked || x.SubItems[6].Text == "1")).ToArray());
            if (scheduleListView.SelectedItems.Count > 0)
            {
                scheduleListView.EnsureVisible(scheduleListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getScheduleListView()
        {
            return scheduleListView;
        }

        private void showOriginalScheduleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newScheduleButton_Click(object sender, EventArgs e)
        {
            ScheduleInfoForm form = new ScheduleInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editScheduleButton_Click(object sender, EventArgs e)
        {
            editSchedule();
        }

        public void editSchedule()
        {
            if (scheduleListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = scheduleListView.SelectedItems[0];

                ScheduleInfoForm form = new ScheduleInfoForm((Form)Parent);
                form.scheduleId = lvi.SubItems[0].Text;


                MainForm mainForm = (MainForm)ParentForm;

                form.readScheduleInfo();
                form.ShowDialog();


            }
        }

        private void scheduleListView_DoubleClick(object sender, EventArgs e)
        {
            editSchedule();
        }

        private void scheduleListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editSchedule();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchSchedule();
        }

        public void searchSchedule()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (scheduleListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (scheduleListView.SelectedItems != null && scheduleListView.SelectedItems.Count != 0)
                {
                    startIndex = scheduleListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == scheduleListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = scheduleListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            scheduleListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == scheduleListView.Items.Count)
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
                searchSchedule();
            }
        }

        private void scheduleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (scheduleListView.SelectedItems.Count > 0)
            {
                selectIndex = scheduleListView.Items.IndexOf(scheduleListView.SelectedItems[0]);
                ListViewItem lvi = scheduleListView.SelectedItems[0];
                if (lvi.SubItems[6].Text == "1")
                {
                    deleteScheduleButton.Enabled = true;
                }
                else
                {
                    deleteScheduleButton.Enabled = false;
                }
            }
        }

        private void deleteScheduleButton_Click(object sender, EventArgs e)
        {
            if (scheduleListView.SelectedItems.Count > 0)
            {
                string ScheduleId = scheduleListView.SelectedItems[0].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + ScheduleId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + ScheduleId + ".json");


                        DataManager.dict["battle/schedule_cus"].Remove(ScheduleId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.battleSchedulePath + "\\" + ScheduleId + ".json"))
                        {
                            DataManager.allBattleScheduleLvis.Remove(ScheduleId);
                            scheduleListView.Items.Remove(scheduleListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {

                            ListViewItem lvi = DataManager.createBattleScheduleLvi(ScheduleId);
                            if (DataManager.allBattleScheduleLvis.ContainsKey(ScheduleId))
                            {
                                DataManager.allBattleScheduleLvis[ScheduleId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalScheduleCheckBox.Checked)
                            {
                                for (int i = 0; i < scheduleListView.Items.Count; i++)
                                {
                                    if (scheduleListView.Items[i].Text == ScheduleId)
                                    {
                                        scheduleListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                scheduleListView.Items.Remove(scheduleListView.SelectedItems[0]);
                            }

                        }
                        deleteScheduleButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("schedule"))
            {
                DataManager.dict.Remove("schedule");
            }
            DataManager.LoadBattleSchedule(true);

            DataManager.allBattleScheduleLvis.Clear();
            DataManager.allBattleScheduleLvis = DataManager.createBattleScheduleLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.battleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.battleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + scheduleListView.SelectedItems[0].Text + ".json";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
