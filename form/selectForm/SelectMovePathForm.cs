using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectMovePathForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;
        public SelectMovePathForm()
        {
            InitializeComponent();
        }
        public SelectMovePathForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;

            initMovePathListView();
        }

        public void initMovePathListView()
        {
            if (DataManager.allMovePathLvis.Count == 0)
            {
                DataManager.allMovePathLvis = DataManager.createMovePathLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allMovePathLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            movePathListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectMovePathForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true);
            movePathListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = movePathListView.SelectedItems[0].Text;
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = movePathListView.SelectedItems[0].Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer(searchTextBox.Text, false);
        }

        public void searchBuffer(string bufferId, bool isEqual)
        {
            if (string.IsNullOrEmpty(bufferId))
            {
                return;
            }
            bool isSearched = false;

            if (movePathListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (movePathListView.SelectedItems != null && movePathListView.SelectedItems.Count != 0)
                {
                    startIndex = movePathListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == movePathListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = movePathListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                movePathListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                movePathListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == movePathListView.Items.Count)
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
                searchBuffer(searchTextBox.Text, false);
            }
        }
    }
}
