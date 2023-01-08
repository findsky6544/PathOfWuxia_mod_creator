using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class EndingMovieTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public EndingMovieTabControlUserControl()
        {
            InitializeComponent();
        }
        public EndingMovieTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                EndingMovieListView.Items.Clear();
                EndingMovieListView.Items.AddRange(DataManager.allEndingMovieLvis.Values.Where(x => (showOriginalEndingMovieCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (EndingMovieListView.SelectedItems.Count > 0)
                {
                    EndingMovieListView.EnsureVisible(EndingMovieListView.SelectedItems[0].Index);
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

        public ListView getEndingMovieListView()
        {
            return EndingMovieListView;
        }

        private void showOriginalEndingMovieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newEndingMovieButton_Click(object sender, EventArgs e)
        {
            EndingMovieInfoForm form = new EndingMovieInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editEndingMovieButton_Click(object sender, EventArgs e)
        {
            editEndingMovie();
        }

        public void editEndingMovie()
        {
            if (EndingMovieListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = EndingMovieListView.SelectedItems[0];

                EndingMovieInfoForm form = new EndingMovieInfoForm((Form)Parent);
                form.EndingMovieId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readEndingMovieInfo();

                form.ShowDialog();
            }
        }

        private void EndingMovieListView_DoubleClick(object sender, EventArgs e)
        {
            editEndingMovie();
        }

        private void EndingMovieListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editEndingMovie();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEndingMovie();
        }

        public void searchEndingMovie()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allEndingMovieLvis.ContainsKey(searchText))
            {
                EndingMovie EndingMovie = DataManager.getData<EndingMovie>(searchText);
                if (EndingMovie != null)
                {
                    ListViewItem lvi = DataManager.createEndingMovieLvi(searchText);
                    EndingMovieListView.Items.Add(lvi);
                    DataManager.allEndingMovieLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (EndingMovieListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (EndingMovieListView.SelectedItems != null && EndingMovieListView.SelectedItems.Count != 0)
                {
                    startIndex = EndingMovieListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == EndingMovieListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = EndingMovieListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            EndingMovieListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == EndingMovieListView.Items.Count)
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
                searchEndingMovie();
            }
        }

        private void EndingMovieListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (EndingMovieListView.SelectedItems.Count > 0)
            {
                selectIndex = EndingMovieListView.Items.IndexOf(EndingMovieListView.SelectedItems[0]);
                ListViewItem lvi = EndingMovieListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteEndingMovieButton.Enabled = true;
                }
                else
                {
                    deleteEndingMovieButton.Enabled = false;
                }
            }
        }

        private void deleteEndingMovieButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EndingMovieListView.SelectedItems.Count > 0)
                {
                    string EndingMovieId = EndingMovieListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/EndingMovie_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + EndingMovieId + "\t"))
                        {
                            string pattern = "\r\n" + EndingMovieId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(EndingMovie), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["EndingMovie"].Contains(EndingMovieId))
                        {
                            DataManager.allEndingMovieLvis.Remove(EndingMovieId);
                            EndingMovieListView.Items.Remove(EndingMovieListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            EndingMovie EndingMovie = DataManager.getData<EndingMovie>(EndingMovieId);

                            ListViewItem lvi = DataManager.createEndingMovieLvi(EndingMovieId);
                            if (DataManager.allEndingMovieLvis.ContainsKey(EndingMovieId))
                            {
                                DataManager.allEndingMovieLvis[EndingMovieId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalEndingMovieCheckBox.Checked)
                            {
                                for (int i = 0; i < EndingMovieListView.Items.Count; i++)
                                {
                                    if (EndingMovieListView.Items[i].SubItems[0].Text == EndingMovieId)
                                    {
                                        EndingMovieListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                EndingMovieListView.Items.Remove(EndingMovieListView.SelectedItems[0]);
                            }

                        }
                        deleteEndingMovieButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("EndingMovie"))
            {
                DataManager.dict.Remove("EndingMovie");
            }
            DataManager.LoadTextfile("EndingMovie");

            DataManager.allEndingMovieLvis.Clear();
            DataManager.allEndingMovieLvis = DataManager.createEndingMovieLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "EndingMovie.txt";

            if (EndingMovieListView.SelectedItems.Count > 0 && EndingMovieListView.SelectedItems[0].SubItems[EndingMovieListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EndingMovie_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EndingMovie_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "EndingMovie.txt";

            if (EndingMovieListView.SelectedItems.Count > 0 && EndingMovieListView.SelectedItems[0].SubItems[EndingMovieListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EndingMovie_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "EndingMovie_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
