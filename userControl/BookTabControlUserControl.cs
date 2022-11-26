using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BookTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public BookTabControlUserControl()
        {
            InitializeComponent();
        }
        public BookTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                BookListView.Items.Clear();
                BookListView.Items.AddRange(DataManager.allBookLvis.Values.Where(x => (showOriginalBookCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (BookListView.SelectedItems.Count > 0)
                {
                    BookListView.EnsureVisible(BookListView.SelectedItems[0].Index);
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

        public ListView getBookListView()
        {
            return BookListView;
        }

        private void showOriginalBookCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newBookButton_Click(object sender, EventArgs e)
        {
            BookInfoForm form = new BookInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editBookButton_Click(object sender, EventArgs e)
        {
            editBook();
        }

        public void editBook()
        {
            if (BookListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = BookListView.SelectedItems[0];

                BookInfoForm form = new BookInfoForm((Form)Parent);
                form.BookId = lvi.SubItems[1].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readBookInfo();

                form.ShowDialog();
            }
        }

        private void BookListView_DoubleClick(object sender, EventArgs e)
        {
            editBook();
        }

        private void BookListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editBook();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBook();
        }

        public void searchBook()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allBookLvis.ContainsKey(searchText))
            {
                Book Book = DataManager.getData<Book>(searchText);
                if (Book != null)
                {
                    ListViewItem lvi = DataManager.createBookLvi(searchText);
                    BookListView.Items.Add(lvi);
                    DataManager.allBookLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (BookListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BookListView.SelectedItems != null && BookListView.SelectedItems.Count != 0)
                {
                    startIndex = BookListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BookListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BookListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            BookListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BookListView.Items.Count)
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
                searchBook();
            }
        }

        private void BookListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (BookListView.SelectedItems.Count > 0)
            {
                selectIndex = BookListView.Items.IndexOf(BookListView.SelectedItems[0]);
                ListViewItem lvi = BookListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteBookButton.Enabled = true;
                }
                else
                {
                    deleteBookButton.Enabled = false;
                }
            }
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (BookListView.SelectedItems.Count > 0)
                {
                    string BookId = BookListView.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Book.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + BookId + "\t"))
                        {
                            string pattern = "\r\n" + BookId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Book), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Book"].Contains(BookId))
                        {
                            DataManager.allBookLvis.Remove(BookId);
                            BookListView.Items.Remove(BookListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Book Book = DataManager.getData<Book>(BookId);

                            ListViewItem lvi = DataManager.createBookLvi(BookId);
                            if (DataManager.allBookLvis.ContainsKey(BookId))
                            {
                                DataManager.allBookLvis[BookId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalBookCheckBox.Checked)
                            {
                                for (int i = 0; i < BookListView.Items.Count; i++)
                                {
                                    if (BookListView.Items[i].SubItems[1].Text == BookId)
                                    {
                                        BookListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                BookListView.Items.Remove(BookListView.SelectedItems[0]);
                            }

                        }
                        deleteBookButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Book"))
            {
                DataManager.dict.Remove("Book");
            }
            DataManager.LoadTextfile("Book");

            DataManager.allBookLvis.Clear();
            DataManager.allBookLvis = DataManager.createBookLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Book.txt";

            if (BookListView.SelectedItems.Count > 0 && BookListView.SelectedItems[0].SubItems[BookListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Book.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Book.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Book.txt";

            if (BookListView.SelectedItems.Count > 0 && BookListView.SelectedItems[0].SubItems[BookListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Book.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Book.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
