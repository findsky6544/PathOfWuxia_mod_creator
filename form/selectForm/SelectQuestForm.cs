using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectQuestForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;
        public SelectQuestForm()
        {
            InitializeComponent();
        }
        public SelectQuestForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;

            initQuestListView();
        }

        public void initQuestListView()
        {
            if (DataManager.allQuestLvis.Count == 0)
            {
                DataManager.allQuestLvis = DataManager.createQuestLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allQuestLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            questListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectQuestForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true);
            questListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = questListView.SelectedItems[0].Text;
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = questListView.SelectedItems[0].Text;
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

            if (questListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (questListView.SelectedItems != null && questListView.SelectedItems.Count != 0)
                {
                    startIndex = questListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == questListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = questListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                questListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                questListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == questListView.Items.Count)
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
