using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MapTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public MapTabControlUserControl()
        {
            InitializeComponent();
        }
        public MapTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                MapListView.Items.Clear();
                MapListView.Items.AddRange(DataManager.allMapLvis.Values.Where(x => (showOriginalMapCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (MapListView.SelectedItems.Count > 0)
                {
                    MapListView.EnsureVisible(MapListView.SelectedItems[0].Index);
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

        public ListView getMapListView()
        {
            return MapListView;
        }

        private void showOriginalMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newMapButton_Click(object sender, EventArgs e)
        {
            MapInfoForm form = new MapInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editMapButton_Click(object sender, EventArgs e)
        {
            editMap();
        }

        public void editMap()
        {
            if (MapListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = MapListView.SelectedItems[0];

                MapInfoForm form = new MapInfoForm((Form)Parent);
                form.MapId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readMapInfo();

                form.ShowDialog();
            }
        }

        private void MapListView_DoubleClick(object sender, EventArgs e)
        {
            editMap();
        }

        private void MapListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editMap();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchMap();
        }

        public void searchMap()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allMapLvis.ContainsKey(searchText))
            {
                Map Map = DataManager.getData<Map>(searchText);
                if (Map != null)
                {
                    ListViewItem lvi = DataManager.createMapLvi(searchText);
                    MapListView.Items.Add(lvi);
                    DataManager.allMapLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (MapListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (MapListView.SelectedItems != null && MapListView.SelectedItems.Count != 0)
                {
                    startIndex = MapListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == MapListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = MapListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            MapListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == MapListView.Items.Count)
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
                searchMap();
            }
        }

        private void MapListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (MapListView.SelectedItems.Count > 0)
            {
                selectIndex = MapListView.Items.IndexOf(MapListView.SelectedItems[0]);
                ListViewItem lvi = MapListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteMapButton.Enabled = true;
                }
                else
                {
                    deleteMapButton.Enabled = false;
                }
            }
        }

        private void deleteMapButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MapListView.SelectedItems.Count > 0)
                {
                    string MapId = MapListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Map_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + MapId + "\t"))
                        {
                            string pattern = "\r\n" + MapId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Map), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Map"].Contains(MapId))
                        {
                            DataManager.allMapLvis.Remove(MapId);
                            MapListView.Items.Remove(MapListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Map Map = DataManager.getData<Map>(MapId);

                            ListViewItem lvi = DataManager.createMapLvi(MapId);
                            if (DataManager.allMapLvis.ContainsKey(MapId))
                            {
                                DataManager.allMapLvis[MapId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalMapCheckBox.Checked)
                            {
                                for (int i = 0; i < MapListView.Items.Count; i++)
                                {
                                    if (MapListView.Items[i].SubItems[0].Text == MapId)
                                    {
                                        MapListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MapListView.Items.Remove(MapListView.SelectedItems[0]);
                            }

                        }
                        deleteMapButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Map"))
            {
                DataManager.dict.Remove("Map");
            }
            DataManager.LoadTextfile("Map");

            DataManager.allMapLvis.Clear();
            DataManager.allMapLvis = DataManager.createMapLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Map.txt";

            if (MapListView.SelectedItems.Count > 0 && MapListView.SelectedItems[0].SubItems[MapListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Map_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Map_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Map.txt";

            if (MapListView.SelectedItems.Count > 0 && MapListView.SelectedItems[0].SubItems[MapListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Map_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Map_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
