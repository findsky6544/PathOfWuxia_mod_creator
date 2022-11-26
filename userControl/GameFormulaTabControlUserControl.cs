using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class GameFormulaTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public GameFormulaTabControlUserControl()
        {
            InitializeComponent();
        }
        public GameFormulaTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                GameFormulaListView.Items.Clear();
                GameFormulaListView.Items.AddRange(DataManager.allGameFormulaLvis.Values.Where(x => (showOriginalGameFormulaCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (GameFormulaListView.SelectedItems.Count > 0)
                {
                    GameFormulaListView.EnsureVisible(GameFormulaListView.SelectedItems[0].Index);
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

        public ListView getGameFormulaListView()
        {
            return GameFormulaListView;
        }

        private void showOriginalGameFormulaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newGameFormulaButton_Click(object sender, EventArgs e)
        {
            GameFormulaInfoForm form = new GameFormulaInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editGameFormulaButton_Click(object sender, EventArgs e)
        {
            editGameFormula();
        }

        public void editGameFormula()
        {
            if (GameFormulaListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = GameFormulaListView.SelectedItems[0];

                GameFormulaInfoForm form = new GameFormulaInfoForm((Form)Parent);
                form.GameFormulaId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readGameFormulaInfo();

                form.ShowDialog();
            }
        }

        private void GameFormulaListView_DoubleClick(object sender, EventArgs e)
        {
            editGameFormula();
        }

        private void GameFormulaListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editGameFormula();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchGameFormula();
        }

        public void searchGameFormula()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allGameFormulaLvis.ContainsKey(searchText))
            {
                GameFormula GameFormula = DataManager.getData<GameFormula>(searchText);
                if (GameFormula != null)
                {
                    ListViewItem lvi = DataManager.createGameFormulaLvi(searchText);
                    GameFormulaListView.Items.Add(lvi);
                    DataManager.allGameFormulaLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (GameFormulaListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (GameFormulaListView.SelectedItems != null && GameFormulaListView.SelectedItems.Count != 0)
                {
                    startIndex = GameFormulaListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == GameFormulaListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = GameFormulaListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            GameFormulaListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == GameFormulaListView.Items.Count)
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
                searchGameFormula();
            }
        }

        private void GameFormulaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (GameFormulaListView.SelectedItems.Count > 0)
            {
                selectIndex = GameFormulaListView.Items.IndexOf(GameFormulaListView.SelectedItems[0]);
                ListViewItem lvi = GameFormulaListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteGameFormulaButton.Enabled = true;
                }
                else
                {
                    deleteGameFormulaButton.Enabled = false;
                }
            }
        }

        private void deleteGameFormulaButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameFormulaListView.SelectedItems.Count > 0)
                {
                    string GameFormulaId = GameFormulaListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/GameFormula.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + GameFormulaId + "\t"))
                        {
                            string pattern = "\r\n" + GameFormulaId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(GameFormula), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["GameFormula"].Contains(GameFormulaId))
                        {
                            DataManager.allGameFormulaLvis.Remove(GameFormulaId);
                            GameFormulaListView.Items.Remove(GameFormulaListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            GameFormula GameFormula = DataManager.getData<GameFormula>(GameFormulaId);

                            ListViewItem lvi = DataManager.createGameFormulaLvi(GameFormulaId);
                            if (DataManager.allGameFormulaLvis.ContainsKey(GameFormulaId))
                            {
                                DataManager.allGameFormulaLvis[GameFormulaId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalGameFormulaCheckBox.Checked)
                            {
                                for (int i = 0; i < GameFormulaListView.Items.Count; i++)
                                {
                                    if (GameFormulaListView.Items[i].SubItems[0].Text == GameFormulaId)
                                    {
                                        GameFormulaListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                GameFormulaListView.Items.Remove(GameFormulaListView.SelectedItems[0]);
                            }

                        }
                        deleteGameFormulaButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("GameFormula"))
            {
                DataManager.dict.Remove("GameFormula");
            }
            DataManager.LoadTextfile("GameFormula");

            DataManager.allGameFormulaLvis.Clear();
            DataManager.allGameFormulaLvis = DataManager.createGameFormulaLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "GameFormula.txt";

            if (GameFormulaListView.SelectedItems.Count > 0 && GameFormulaListView.SelectedItems[0].SubItems[GameFormulaListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "GameFormula.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "GameFormula.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "GameFormula.txt";

            if (GameFormulaListView.SelectedItems.Count > 0 && GameFormulaListView.SelectedItems[0].SubItems[GameFormulaListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "GameFormula.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "GameFormula.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
