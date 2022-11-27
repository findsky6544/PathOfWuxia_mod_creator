using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ConfigScheduleTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public ConfigScheduleTabControlUserControl()
        {
            InitializeComponent();
        }
        public ConfigScheduleTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            cinematicListView.Items.Clear();
            cinematicListView.Items.AddRange(DataManager.allConfigScheduleLvis.Values.Where(x => (showOriginalScheduleCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (cinematicListView.SelectedItems.Count > 0)
            {
                cinematicListView.EnsureVisible(cinematicListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getScheduleListView()
        {
            return cinematicListView;
        }
        private void showOriginalScheduleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newScheduleButton_Click(object sender, EventArgs e)
        {
            CinematicInfoForm form = new CinematicInfoForm(null,true);
            form.Text = "config/schedule信息";
            form.ShowDialog();
        }

        private void editScheduleButton_Click(object sender, EventArgs e)
        {
            editSchedule();
        }

        public void editSchedule()
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = cinematicListView.SelectedItems[0];

                CinematicInfoForm form = new CinematicInfoForm(lvi.SubItems[0].Text, true);
                form.Text = "Config/Schedule信息";

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

            if (cinematicListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (cinematicListView.SelectedItems != null && cinematicListView.SelectedItems.Count != 0)
                {
                    startIndex = cinematicListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == cinematicListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = cinematicListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            cinematicListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == cinematicListView.Items.Count)
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
            if (cinematicListView.SelectedItems.Count > 0)
            {
                selectIndex = cinematicListView.Items.IndexOf(cinematicListView.SelectedItems[0]);
                ListViewItem lvi = cinematicListView.SelectedItems[0];
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
            if (cinematicListView.SelectedItems.Count > 0)
            {
                string ScheduleId = cinematicListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + ScheduleId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + ScheduleId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["config/schedule_cus"].Remove(ScheduleId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.configSchedulePath + "\\" + ScheduleId + ".json"))
                        {
                            DataManager.allConfigScheduleLvis.Remove(ScheduleId);
                            cinematicListView.Items.Remove(cinematicListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            ListViewItem lvi = DataManager.createConfigScheduleLvi(ScheduleId);
                            if (DataManager.allConfigScheduleLvis.ContainsKey(ScheduleId))
                            {
                                DataManager.allConfigScheduleLvis[ScheduleId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalScheduleCheckBox.Checked)
                            {
                                for (int i = 0; i < cinematicListView.Items.Count; i++)
                                {
                                    if (cinematicListView.Items[i].SubItems[1].Text == ScheduleId)
                                    {
                                        cinematicListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                cinematicListView.Items.Remove(cinematicListView.SelectedItems[0]);
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
            DataManager.LoadConfigSchedule(true);

            DataManager.allConfigScheduleLvis.Clear();
            DataManager.allConfigScheduleLvis = DataManager.createConfigScheduleLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.configSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.configSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void cinematicListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editSchedule();
            }
        }

        private void cinematicListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (cinematicListView.SelectedItems.Count > 0)
            {
                selectIndex = cinematicListView.Items.IndexOf(cinematicListView.SelectedItems[0]);
                ListViewItem lvi = cinematicListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteScheduleButton.Enabled = true;
                }
                else
                {
                    deleteScheduleButton.Enabled = false;
                }
            }
        }
    }
}
