using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TraitTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public TraitTabControlUserControl()
        {
            InitializeComponent();
        }
        public TraitTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            TraitListView.Items.Clear();
            TraitListView.Items.AddRange(DataManager.allTraitLvis.Values.Where(x => (showOriginalTraitCheckBox.Checked || x.SubItems[4].Text == "1")).ToArray());
            if (TraitListView.SelectedItems.Count > 0)
            {
                TraitListView.EnsureVisible(TraitListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getTraitListView()
        {
            return TraitListView;
        }

        private void showOriginalTraitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newTraitButton_Click(object sender, EventArgs e)
        {
            TraitInfoForm form = new TraitInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editTraitButton_Click(object sender, EventArgs e)
        {
            editTrait();
        }

        public void editTrait()
        {
            if (TraitListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = TraitListView.SelectedItems[0];

                TraitInfoForm form = new TraitInfoForm((Form)Parent);
                form.TraitId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readTraitInfo();

                form.ShowDialog();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchTrait();
        }

        public void searchTrait()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (TraitListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (TraitListView.SelectedItems != null && TraitListView.SelectedItems.Count != 0)
                {
                    startIndex = TraitListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == TraitListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = TraitListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            TraitListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == TraitListView.Items.Count)
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
                searchTrait();
            }
        }

        private void TraitListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (TraitListView.SelectedItems.Count > 0)
            {
                selectIndex = TraitListView.Items.IndexOf(TraitListView.SelectedItems[0]);
                ListViewItem lvi = TraitListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteTraitButton.Enabled = true;
                }
                else
                {
                    deleteTraitButton.Enabled = false;
                }
            }
        }

        private void deleteTraitButton_Click(object sender, EventArgs e)
        {
            if (TraitListView.SelectedItems.Count > 0)
            {
                string TraitId = TraitListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + TraitId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + TraitId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["Trait_cus"].Remove(TraitId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + TraitId + ".json"))
                        {
                            DataManager.allTraitLvis.Remove(TraitId);
                            TraitListView.Items.Remove(TraitListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Trait Trait = DataManager.getData<Trait>(TraitId);

                            ListViewItem lvi = DataManager.createTraitLvi(TraitId);
                            if (DataManager.allTraitLvis.ContainsKey(TraitId))
                            {
                                DataManager.allTraitLvis[TraitId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalTraitCheckBox.Checked)
                            {
                                for (int i = 0; i < TraitListView.Items.Count; i++)
                                {
                                    if (TraitListView.Items[i].SubItems[1].Text == TraitId)
                                    {
                                        TraitListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                TraitListView.Items.Remove(TraitListView.SelectedItems[0]);
                            }

                        }
                        deleteTraitButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Trait"))
            {
                DataManager.dict.Remove("Trait");
            }
            DataManager.LoadTextfile("Trait");

            DataManager.allTraitLvis.Clear();
            DataManager.allTraitLvis = DataManager.createTraitLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Trait.txt";

            if (TraitListView.SelectedItems.Count > 0 && TraitListView.SelectedItems[0].SubItems[TraitListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Trait.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Trait.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Trait.txt";

            if (TraitListView.SelectedItems.Count > 0 && TraitListView.SelectedItems[0].SubItems[TraitListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Trait.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Trait.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = TraitListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void TraitListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editTrait();
            }
        }

        private void TraitListView_DoubleClick(object sender, EventArgs e)
        {
            editTrait();
        }
    }
}
