using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferTabControlUserControl : UserControl
    {
        public int selectIndex = -1;

        //public Dictionary<string, Buffer> bufferDict = null;
        public BufferTabControlUserControl()
        {
            InitializeComponent();
        }
        public BufferTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            bufferListView.Items.Clear();
            bufferListView.Items.AddRange(DataManager.allBufferLvis.Values.Where(x => (showOriginalBufferCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (bufferListView.SelectedItems.Count > 0)
            {
                bufferListView.EnsureVisible(bufferListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getBufferListView()
        {
            return bufferListView;
        }
        private void showOriginalBufferCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newBufferButton_Click(object sender, EventArgs e)
        {
            BufferInfoForm form = new BufferInfoForm(null,true);
            TreeNode rootTreeNode = form.getBufferNodeTreeView().Nodes.Add("根节点");
            rootTreeNode.Tag = "\"BufferRootNode\" : ";
            form.ShowDialog();
        }

        private void editBufferButton_Click(object sender, EventArgs e)
        {
            editBuffer();
        }

        public void editBuffer()
        {
            if (bufferListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = bufferListView.SelectedItems[0];

                BufferInfoForm form = new BufferInfoForm(lvi.SubItems[1].Text,true);
                form.ShowDialog();
            }
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            editBuffer();
        }

        private void bufferListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editBuffer();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer();
        }

        public void searchBuffer()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (bufferListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (bufferListView.SelectedItems != null && bufferListView.SelectedItems.Count != 0)
                {
                    startIndex = bufferListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == bufferListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = bufferListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            bufferListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == bufferListView.Items.Count)
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
                searchBuffer();
            }
        }

        private void bufferListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (bufferListView.SelectedItems.Count > 0)
            {
                selectIndex = bufferListView.Items.IndexOf(bufferListView.SelectedItems[0]);
                ListViewItem lvi = bufferListView.SelectedItems[0];
                if (lvi.SubItems[9].Text == "1")
                {
                    deleteBufferButton.Enabled = true;
                }
                else
                {
                    deleteBufferButton.Enabled = false;
                }
            }
        }

        private void deleteBufferButton_Click(object sender, EventArgs e)
        {
            if (bufferListView.SelectedItems.Count > 0)
            {
                string BufferId = bufferListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + BufferId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + BufferId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["buffer_cus"].Remove(BufferId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.bufferPath + "\\" + BufferId + ".json"))
                        {
                            DataManager.allBufferLvis.Remove(bufferListView.SelectedItems[0].SubItems[1].Text);
                            bufferListView.Items.Remove(bufferListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            ListViewItem lvi = DataManager.createBufferLvi(BufferId);
                            if (DataManager.allBufferLvis.ContainsKey(BufferId))
                            {
                                DataManager.allBufferLvis[BufferId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalBufferCheckBox.Checked)
                            {
                                for (int i = 0; i < bufferListView.Items.Count; i++)
                                {
                                    if (bufferListView.Items[i].SubItems[1].Text == BufferId)
                                    {
                                        bufferListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                bufferListView.Items.Remove(bufferListView.SelectedItems[0]);
                            }

                        }
                        deleteBufferButton.Enabled = false;
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
            Thread loadDataFormThread = new Thread(new ThreadStart(mainForm.showLoadDataForm));
            loadDataFormThread.Start();

            if (DataManager.dict.ContainsKey("buffer"))
            {
                DataManager.dict.Remove("buffer");
            }
            DataManager.LoadBuffer(true);

            DataManager.allBufferLvis.Clear();
            DataManager.allBufferLvis = DataManager.createBufferLvis();

            refrashListView();
            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.bufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.bufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json";

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + bufferListView.SelectedItems[0].SubItems[1].Text + ".json";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
