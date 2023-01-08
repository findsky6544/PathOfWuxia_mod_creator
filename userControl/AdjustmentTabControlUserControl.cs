using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AdjustmentTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public AdjustmentTabControlUserControl()
        {
            InitializeComponent();
        }
        public AdjustmentTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            AdjustmentListView.Items.Clear();
            AdjustmentListView.Items.AddRange(DataManager.allAdjustmentLvis.Values.Where(x => (showOriginalAdjustmentCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
            if (AdjustmentListView.SelectedItems.Count > 0)
            {
                AdjustmentListView.EnsureVisible(AdjustmentListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getAdjustmentListView()
        {
            return AdjustmentListView;
        }

        private void showOriginalAdjustmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newAdjustmentButton_Click(object sender, EventArgs e)
        {
            AdjustmentInfoForm form = new AdjustmentInfoForm(null,true);
            form.ShowDialog();
        }

        private void editAdjustmentButton_Click(object sender, EventArgs e)
        {
            editAdjustment();
        }

        public void editAdjustment()
        {
            if (AdjustmentListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = AdjustmentListView.SelectedItems[0];

                AdjustmentInfoForm form = new AdjustmentInfoForm(lvi.SubItems[0].Text,true);

                form.ShowDialog();
            }
        }

        private void adjustmentListView_DoubleClick(object sender, EventArgs e)
        {
            editAdjustment();
        }

        private void adjustmentListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editAdjustment();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAdjustment();
        }

        public void searchAdjustment()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allAdjustmentLvis.ContainsKey(searchText))
            {
                Adjustment Adjustment = DataManager.getData<Adjustment>(searchText);
                if (Adjustment != null)
                {
                    ListViewItem lvi = DataManager.createAdjustmentLvi(searchText);
                    AdjustmentListView.Items.Add(lvi);
                    DataManager.allAdjustmentLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (AdjustmentListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (AdjustmentListView.SelectedItems != null && AdjustmentListView.SelectedItems.Count != 0)
                {
                    startIndex = AdjustmentListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == AdjustmentListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = AdjustmentListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            AdjustmentListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == AdjustmentListView.Items.Count)
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
                searchAdjustment();
            }
        }

        private void adjustmentListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (AdjustmentListView.SelectedItems.Count > 0)
            {
                selectIndex = AdjustmentListView.Items.IndexOf(AdjustmentListView.SelectedItems[0]);
                ListViewItem lvi = AdjustmentListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteAdjustmentButton.Enabled = true;
                }
                else
                {
                    deleteAdjustmentButton.Enabled = false;
                }
            }
        }

        private void deleteAdjustmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdjustmentListView.SelectedItems.Count > 0)
                {
                    string AdjustmentId = AdjustmentListView.SelectedItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Adjustment_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + AdjustmentId + "\t"))
                        {
                            string pattern = "\r\n" + AdjustmentId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Adjustment), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Adjustment"].Contains(AdjustmentId))
                        {
                            DataManager.allAdjustmentLvis.Remove(AdjustmentId);
                            AdjustmentListView.Items.Remove(AdjustmentListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Adjustment Adjustment = DataManager.getData<Adjustment>(AdjustmentId);

                            ListViewItem lvi = DataManager.createAdjustmentLvi(AdjustmentId);
                            if (DataManager.allAdjustmentLvis.ContainsKey(AdjustmentId))
                            {
                                DataManager.allAdjustmentLvis[AdjustmentId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalAdjustmentCheckBox.Checked)
                            {
                                for (int i = 0; i < AdjustmentListView.Items.Count; i++)
                                {
                                    if (AdjustmentListView.Items[i].Text == AdjustmentId)
                                    {
                                        AdjustmentListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                AdjustmentListView.Items.Remove(AdjustmentListView.SelectedItems[0]);
                            }

                        }
                        deleteAdjustmentButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Adjustment"))
            {
                DataManager.dict.Remove("Adjustment");
            }
            DataManager.LoadTextfile("Adjustment");

            DataManager.allAdjustmentLvis.Clear();
            DataManager.allAdjustmentLvis = DataManager.createAdjustmentLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Adjustment.txt";

            if (AdjustmentListView.SelectedItems.Count > 0 && AdjustmentListView.SelectedItems[0].SubItems[AdjustmentListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Adjustment_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Adjustment_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Adjustment.txt";

            if (AdjustmentListView.SelectedItems.Count > 0 && AdjustmentListView.SelectedItems[0].SubItems[AdjustmentListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Adjustment_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Adjustment_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
