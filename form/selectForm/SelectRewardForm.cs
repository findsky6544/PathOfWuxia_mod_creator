using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectRewardForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectRewardForm()
        {
            InitializeComponent();
        }
        public SelectRewardForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                rewardListView.CheckBoxes = true;
            }

            initRewardListView();
        }

        public void initRewardListView()
        {
            if (DataManager.allRewardLvis.Count == 0)
            {
                DataManager.allRewardLvis = DataManager.createRewardLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allRewardLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            rewardListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < rewardListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == rewardListView.Items[j].Text.Trim())
                        {
                            rewardListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                rewardListView.Items[j].Selected = true;
                                rewardListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBuffer(textBox.Text, true, true);
            }

            rewardListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < rewardListView.Items.Count; i++)
                {
                    if (rewardListView.Items[i].Checked)
                    {
                        npcsIds += rewardListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (npcsIds.Length > 0)
                {
                    npcsIds = npcsIds.Substring(0, npcsIds.Length - 1);
                }
                textBox.Text = npcsIds;
            }
            else
            {
                textBox.Text = rewardListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                rewardListView.SelectedItems[0].Checked = !rewardListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = rewardListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer(searchTextBox.Text, false, false);
        }

        public void searchBuffer(string bufferId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(bufferId))
            {
                return;
            }
            bool isSearched = false;

            if (rewardListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (rewardListView.SelectedItems != null && rewardListView.SelectedItems.Count != 0)
                {
                    startIndex = rewardListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == rewardListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = rewardListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                rewardListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                rewardListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                rewardListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == rewardListView.Items.Count)
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
                searchBuffer(searchTextBox.Text, false, false);
            }
        }
    }
}
