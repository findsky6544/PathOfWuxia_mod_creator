using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ShopTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public ShopTabControlUserControl()
        {
            InitializeComponent();
        }
        public ShopTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            ShopListView.Items.Clear();
            ShopListView.Items.AddRange(DataManager.allShopLvis.Values.Where(x => (showOriginalShopCheckBox.Checked || x.SubItems[4].Text == "1")).ToArray());
            if (ShopListView.SelectedItems.Count > 0)
            {
                ShopListView.EnsureVisible(ShopListView.SelectedItems[0].Index);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getShopListView()
        {
            return ShopListView;
        }

        private void showOriginalShopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newShopButton_Click(object sender, EventArgs e)
        {
            ShopInfoForm form = new ShopInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editShopButton_Click(object sender, EventArgs e)
        {
            editShop();
        }

        public void editShop()
        {
            if (ShopListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = ShopListView.SelectedItems[0];

                ShopInfoForm form = new ShopInfoForm((Form)Parent);
                form.ShopId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readShopInfo();

                form.ShowDialog();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchShop();
        }

        public void searchShop()
        {
            string searchText = searchTextBox.Text;
            bool isSearched = false;

            if (ShopListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (ShopListView.SelectedItems != null && ShopListView.SelectedItems.Count != 0)
                {
                    startIndex = ShopListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == ShopListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = ShopListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            ShopListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == ShopListView.Items.Count)
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
                searchShop();
            }
        }

        private void ShopListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (ShopListView.SelectedItems.Count > 0)
            {
                selectIndex = ShopListView.Items.IndexOf(ShopListView.SelectedItems[0]);
                ListViewItem lvi = ShopListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteShopButton.Enabled = true;
                }
                else
                {
                    deleteShopButton.Enabled = false;
                }
            }
        }

        private void deleteShopButton_Click(object sender, EventArgs e)
        {
            if (ShopListView.SelectedItems.Count > 0)
            {
                string ShopId = ShopListView.SelectedItems[0].SubItems[1].Text;

                if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + ShopId + ".json"))
                {
                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //删除文件
                        File.Delete(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + ShopId + ".json");

                        MainForm mainForm = (MainForm)Parent;

                        DataManager.dict["Shop_cus"].Remove(ShopId);
                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!File.Exists(DataManager.textFilePath + "\\" + ShopId + ".json"))
                        {
                            DataManager.allShopLvis.Remove(ShopId);
                            ShopListView.Items.Remove(ShopListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Shop Shop = DataManager.getData<Shop>(ShopId);

                            ListViewItem lvi = DataManager.createShopLvi(ShopId);
                            if (DataManager.allShopLvis.ContainsKey(ShopId))
                            {
                                DataManager.allShopLvis[ShopId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalShopCheckBox.Checked)
                            {
                                for (int i = 0; i < ShopListView.Items.Count; i++)
                                {
                                    if (ShopListView.Items[i].SubItems[1].Text == ShopId)
                                    {
                                        ShopListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ShopListView.Items.Remove(ShopListView.SelectedItems[0]);
                            }

                        }
                        deleteShopButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Shop"))
            {
                DataManager.dict.Remove("Shop");
            }
            DataManager.LoadTextfile("Shop");

            DataManager.allShopLvis.Clear();
            DataManager.allShopLvis = DataManager.createShopLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Shop.txt";

            if (ShopListView.SelectedItems.Count > 0 && ShopListView.SelectedItems[0].SubItems[ShopListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Shop.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Shop.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Shop.txt";

            if (ShopListView.SelectedItems.Count > 0 && ShopListView.SelectedItems[0].SubItems[ShopListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Shop.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Shop.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cinematicId = ShopListView.SelectedItems[0].Text.Replace('q', 'm');

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = cinematicId;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }

        private void ShopListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editShop();
            }
        }

        private void ShopListView_DoubleClick(object sender, EventArgs e)
        {
            editShop();
        }
    }
}
