using Heluo.Flow;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CinematicTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public CinematicTabControlUserControl()
        {
            InitializeComponent();
        }
        public CinematicTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            cinematicListView.Items.Clear();
            cinematicListView.Items.AddRange(DataManager.allCinematicLvis.Values.Where(x => (showOriginalCinematicCheckBox.Checked || x.SubItems[4].Text == "1")).ToArray());
            if (cinematicListView.SelectedItems.Count > 0)
            {
                cinematicListView.EnsureVisible(cinematicListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getCinematicListView()
        {
            return cinematicListView;
        }

        private void showOriginalCinematicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newCinematicButton_Click(object sender, EventArgs e)
        {
            CinematicInfoForm form = new CinematicInfoForm(null,true);
            form.ShowDialog();
        }

        private void editCinematicButton_Click(object sender, EventArgs e)
        {
            editCinematic();
        }

        public void editCinematic()
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = cinematicListView.SelectedItems[0];

                CinematicInfoForm form = new CinematicInfoForm(lvi.SubItems[0].Text, true);
                form.Text = "Cinematic信息";

                form.ShowDialog();
            }
        }

        private void cinematicListView_DoubleClick(object sender, EventArgs e)
        {
            editCinematic();
        }

        private void cinematicListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editCinematic();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCinematic();
        }

        public void searchCinematic()
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
                searchCinematic();
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
                    deleteCinematicButton.Enabled = true;
                }
                else
                {
                    deleteCinematicButton.Enabled = false;
                }
            }
        }

        private void deleteCinematicButton_Click(object sender, EventArgs e)
        {
            if (cinematicListView.SelectedItems.Count > 0)
            {
                string CinematicId = cinematicListView.SelectedItems[0].SubItems[0].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + CinematicId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + CinematicId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["cinematic_cus"].Remove(CinematicId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.cinematicPath + "\\" + CinematicId + ".json"))
                        {
                            DataManager.allCinematicLvis.Remove(CinematicId);
                            cinematicListView.Items.Remove(cinematicListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            ScheduleGraph.Bundle cinematic = DataManager.getData<ScheduleGraph.Bundle>("cinematic", CinematicId);

                            ListViewItem lvi = DataManager.createCinematicLvi(CinematicId);
                            if (DataManager.allCinematicLvis.ContainsKey(CinematicId))
                            {
                                DataManager.allCinematicLvis[CinematicId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalCinematicCheckBox.Checked)
                            {
                                for (int i = 0; i < cinematicListView.Items.Count; i++)
                                {
                                    if (cinematicListView.Items[i].SubItems[1].Text == CinematicId)
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
                        deleteCinematicButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("cinematic"))
            {
                DataManager.dict.Remove("cinematic");
            }
            DataManager.LoadCinematic(true);

            DataManager.allCinematicLvis.Clear();
            DataManager.allCinematicLvis = DataManager.createCinematicLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.cinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.cinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + cinematicListView.SelectedItems[0].Text + ".json";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
