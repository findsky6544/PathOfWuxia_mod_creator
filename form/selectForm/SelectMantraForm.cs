using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectMantraForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;
        public SelectMantraForm()
        {
            InitializeComponent();
        }
        public SelectMantraForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;

            initMantraListView();
        }

        public void initMantraListView()
        {
            if (DataManager.allMantraLvis.Count == 0)
            {
                DataManager.allMantraLvis = DataManager.createMantraLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allMantraLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            mantraListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectMantraForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true);
            mantraListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = mantraListView.SelectedItems[0].SubItems[1].Text;
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = mantraListView.SelectedItems[0].SubItems[1].Text;
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

            if (mantraListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (mantraListView.SelectedItems != null && mantraListView.SelectedItems.Count != 0)
                {
                    startIndex = mantraListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == mantraListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = mantraListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                mantraListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                mantraListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == mantraListView.Items.Count)
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
