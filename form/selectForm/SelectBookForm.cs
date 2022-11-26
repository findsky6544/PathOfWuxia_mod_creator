using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectBookForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectBookForm()
        {
            InitializeComponent();
        }
        public SelectBookForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                BookListView.CheckBoxes = true;
            }

            initBookListView();
        }

        public void initBookListView()
        {
            if (DataManager.allBookLvis.Count == 0)
            {
                DataManager.allBookLvis = DataManager.createBookLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allBookLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            BookListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectBookForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] BooksList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < BooksList.Length; i++)
                {
                    for (int j = 0; j < BookListView.Items.Count; j++)
                    {
                        if (BooksList[i].Trim() == BookListView.Items[j].SubItems[1].Text.Trim())
                        {
                            BookListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                BookListView.Items[j].Selected = true;
                                BookListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBook(textBox.Text, true, true);
            }

            BookListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string BooksIds = "";
                for (int i = 0; i < BookListView.Items.Count; i++)
                {
                    if (BookListView.Items[i].Checked)
                    {
                        BooksIds += BookListView.Items[i].SubItems[1].Text + ",";
                    }
                }
                if (BooksIds.Length > 0)
                {
                    BooksIds = BooksIds.Substring(0, BooksIds.Length - 1);
                }
                textBox.Text = BooksIds;
            }
            else
            {
                textBox.Text = BookListView.SelectedItems[0].SubItems[1].Text;
            }
            Close();
        }

        private void BookListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                BookListView.SelectedItems[0].Checked = !BookListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = BookListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBook(searchTextBox.Text, false, false);
        }

        public void searchBook(string BookId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(BookId))
            {
                return;
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
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == BookId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BookListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == BookId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BookListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(BookId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BookListView.EnsureVisible(lvi.Index);
                                break;
                            }
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
                searchBook(searchTextBox.Text, false, false);
            }
        }
    }
}
