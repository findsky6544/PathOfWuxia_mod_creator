using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectTraitForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;
        public SelectTraitForm()
        {
            InitializeComponent();
        }
        public SelectTraitForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;

            if (isMultiSelect)
            {
                traitListView.CheckBoxes = true;
            }

            initTraitListView();
        }

        public void initTraitListView()
        {

            if (DataManager.allTraitLvis.Count == 0)
            {
                DataManager.allTraitLvis = DataManager.createTraitLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allTraitLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            traitListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectTraitForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < traitListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == traitListView.Items[j].Text.Trim())
                        {
                            traitListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                traitListView.Items[j].Selected = true;
                                traitListView.EnsureVisible(j);
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

            traitListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < traitListView.Items.Count; i++)
                {
                    if (traitListView.Items[i].Checked)
                    {
                        npcsIds += traitListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = traitListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                traitListView.SelectedItems[0].Checked = !traitListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = traitListView.SelectedItems[0].SubItems[0].Text;
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

            if (traitListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (traitListView.SelectedItems != null && traitListView.SelectedItems.Count != 0)
                {
                    startIndex = traitListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == traitListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = traitListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                traitListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                traitListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                traitListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == traitListView.Items.Count)
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
