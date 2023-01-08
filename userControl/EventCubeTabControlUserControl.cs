using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class EventCubeTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public EventCubeTabControlUserControl()
        {
            InitializeComponent();
        }
        public EventCubeTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                EventCubeListView.Items.Clear();
                EventCubeListView.Items.AddRange(DataManager.allEventCubeLvis.Values.Where(x => (showOriginalEventCubeCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (EventCubeListView.SelectedItems.Count > 0)
                {
                    EventCubeListView.EnsureVisible(EventCubeListView.SelectedItems[0].Index);
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

        public ListView getEventCubeListView()
        {
            return EventCubeListView;
        }

        private void showOriginalEventCubeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newEventCubeButton_Click(object sender, EventArgs e)
        {
            EventCubeInfoForm form = new EventCubeInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editEventCubeButton_Click(object sender, EventArgs e)
        {
            editEventCube();
        }

        public void editEventCube()
        {
            if (EventCubeListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = EventCubeListView.SelectedItems[0];

                EventCubeInfoForm form = new EventCubeInfoForm((Form)Parent);
                form.EventCubeId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readEventCubeInfo();

                form.ShowDialog();
            }
        }

        private void EventCubeListView_DoubleClick(object sender, EventArgs e)
        {
            editEventCube();
        }

        private void EventCubeListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editEventCube();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEventCube();
        }

        public void searchEventCube()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allEventCubeLvis.ContainsKey(searchText))
            {
                EventCube EventCube = DataManager.getData<EventCube>(searchText);
                if (EventCube != null)
                {
                    ListViewItem lvi = DataManager.createEventCubeLvi(searchText);
                    EventCubeListView.Items.Add(lvi);
                    DataManager.allEventCubeLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (EventCubeListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (EventCubeListView.SelectedItems != null && EventCubeListView.SelectedItems.Count != 0)
                {
                    startIndex = EventCubeListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == EventCubeListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = EventCubeListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            EventCubeListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == EventCubeListView.Items.Count)
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
                searchEventCube();
            }
        }

        private void EventCubeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (EventCubeListView.SelectedItems.Count > 0)
            {
                selectIndex = EventCubeListView.Items.IndexOf(EventCubeListView.SelectedItems[0]);
                ListViewItem lvi = EventCubeListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteEventCubeButton.Enabled = true;
                }
                else
                {
                    deleteEventCubeButton.Enabled = false;
                }
            }
        }

        private void deleteEventCubeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EventCubeListView.SelectedItems.Count > 0)
                {
                    string EventCubeId = EventCubeListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/EventCube_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + EventCubeId + "\t"))
                        {
                            string pattern = "\r\n" + EventCubeId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(EventCube), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["EventCube"].Contains(EventCubeId))
                        {
                            DataManager.allEventCubeLvis.Remove(EventCubeId);
                            EventCubeListView.Items.Remove(EventCubeListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            EventCube EventCube = DataManager.getData<EventCube>(EventCubeId);

                            ListViewItem lvi = DataManager.createEventCubeLvi(EventCubeId);
                            if (DataManager.allEventCubeLvis.ContainsKey(EventCubeId))
                            {
                                DataManager.allEventCubeLvis[EventCubeId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalEventCubeCheckBox.Checked)
                            {
                                for (int i = 0; i < EventCubeListView.Items.Count; i++)
                                {
                                    if (EventCubeListView.Items[i].SubItems[0].Text == EventCubeId)
                                    {
                                        EventCubeListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                EventCubeListView.Items.Remove(EventCubeListView.SelectedItems[0]);
                            }

                        }
                        deleteEventCubeButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("EventCube"))
            {
                DataManager.dict.Remove("EventCube");
            }
            DataManager.LoadTextfile("EventCube");

            DataManager.allEventCubeLvis.Clear();
            DataManager.allEventCubeLvis = DataManager.createEventCubeLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "EventCube.txt";

            if (EventCubeListView.SelectedItems.Count > 0 && EventCubeListView.SelectedItems[0].SubItems[EventCubeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EventCube_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EventCube_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "EventCube.txt";

            if (EventCubeListView.SelectedItems.Count > 0 && EventCubeListView.SelectedItems[0].SubItems[EventCubeListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EventCube_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EventCube_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
