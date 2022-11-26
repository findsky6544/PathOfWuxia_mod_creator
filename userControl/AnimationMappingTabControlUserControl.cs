using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AnimationMappingTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public AnimationMappingTabControlUserControl()
        {
            InitializeComponent();
        }
        public AnimationMappingTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            AnimationMappingListView.Items.Clear();
            AnimationMappingListView.Items.AddRange(DataManager.allAnimationMappingLvis.Values.Where(x => (showOriginalAnimationMappingCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (AnimationMappingListView.SelectedItems.Count > 0)
            {
                AnimationMappingListView.EnsureVisible(AnimationMappingListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getAnimationMappingListView()
        {
            return AnimationMappingListView;
        }

        private void showOriginalAnimationMappingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newAnimationMappingButton_Click(object sender, EventArgs e)
        {
            AnimationMappingInfoForm form = new AnimationMappingInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editAnimationMappingButton_Click(object sender, EventArgs e)
        {
            editAnimationMapping();
        }

        public void editAnimationMapping()
        {
            if (AnimationMappingListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = AnimationMappingListView.SelectedItems[0];

                AnimationMappingInfoForm form = new AnimationMappingInfoForm((Form)Parent);
                form.AnimationMappingId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readAnimationMappingInfo();

                form.ShowDialog();
            }
        }

        private void AnimationMappingListView_DoubleClick(object sender, EventArgs e)
        {
            editAnimationMapping();
        }

        private void AnimationMappingListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editAnimationMapping();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAnimationMapping();
        }

        public void searchAnimationMapping()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allAnimationMappingLvis.ContainsKey(searchText))
            {
                AnimationMapping AnimationMapping = DataManager.getData<AnimationMapping>(searchText);
                if (AnimationMapping != null)
                {
                    ListViewItem lvi = DataManager.createAnimationMappingLvi(searchText);
                    AnimationMappingListView.Items.Add(lvi);
                    DataManager.allAnimationMappingLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (AnimationMappingListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (AnimationMappingListView.SelectedItems != null && AnimationMappingListView.SelectedItems.Count != 0)
                {
                    startIndex = AnimationMappingListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == AnimationMappingListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = AnimationMappingListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            AnimationMappingListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == AnimationMappingListView.Items.Count)
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
                searchAnimationMapping();
            }
        }

        private void AnimationMappingListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (AnimationMappingListView.SelectedItems.Count > 0)
            {
                selectIndex = AnimationMappingListView.Items.IndexOf(AnimationMappingListView.SelectedItems[0]);
                ListViewItem lvi = AnimationMappingListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteAnimationMappingButton.Enabled = true;
                }
                else
                {
                    deleteAnimationMappingButton.Enabled = false;
                }
            }
        }

        private void deleteAnimationMappingButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AnimationMappingListView.SelectedItems.Count > 0)
                {
                    string AnimationMappingId = AnimationMappingListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/AnimationMapping.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + AnimationMappingId + "\t"))
                        {
                            string pattern = "\r\n" + AnimationMappingId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(AnimationMapping), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["AnimationMapping"].Contains(AnimationMappingId))
                        {
                            DataManager.allAnimationMappingLvis.Remove(AnimationMappingId);
                            AnimationMappingListView.Items.Remove(AnimationMappingListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            AnimationMapping AnimationMapping = DataManager.getData<AnimationMapping>(AnimationMappingId);

                            ListViewItem lvi = DataManager.createAnimationMappingLvi(AnimationMappingId);
                            if (DataManager.allAnimationMappingLvis.ContainsKey(AnimationMappingId))
                            {
                                DataManager.allAnimationMappingLvis[AnimationMappingId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalAnimationMappingCheckBox.Checked)
                            {
                                for (int i = 0; i < AnimationMappingListView.Items.Count; i++)
                                {
                                    if (AnimationMappingListView.Items[i].Text == AnimationMappingId)
                                    {
                                        AnimationMappingListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                AnimationMappingListView.Items.Remove(AnimationMappingListView.SelectedItems[0]);
                            }

                        }
                        deleteAnimationMappingButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("AnimationMapping"))
            {
                DataManager.dict.Remove("AnimationMapping");
            }
            DataManager.LoadTextfile("AnimationMapping");

            DataManager.allAnimationMappingLvis.Clear();
            DataManager.allAnimationMappingLvis = DataManager.createAnimationMappingLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "AnimationMapping.txt";

            if (AnimationMappingListView.SelectedItems.Count > 0 && AnimationMappingListView.SelectedItems[0].SubItems[AnimationMappingListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "AnimationMapping.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "AnimationMapping.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "AnimationMapping.txt";

            if (AnimationMappingListView.SelectedItems.Count > 0 && AnimationMappingListView.SelectedItems[0].SubItems[AnimationMappingListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "AnimationMapping.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "AnimationMapping.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
