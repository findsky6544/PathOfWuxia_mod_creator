using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectNpcForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectNpcForm()
        {
            InitializeComponent();
        }
        public SelectNpcForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                npcListView.CheckBoxes = true;
            }

            initNpcListView();
        }

        public void initNpcListView()
        {
            if (DataManager.allNpcLvis.Count == 0)
            {
                DataManager.allNpcLvis = DataManager.createNpcLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Player";
            lvi.SubItems.Add("玩家");
            lvis.Add(lvi);

            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allNpcLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            npcListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < npcListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == npcListView.Items[j].Text.Trim())
                        {
                            npcListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                npcListView.Items[j].Selected = true;
                                npcListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchNpc(textBox.Text, true);
            }

            npcListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < npcListView.Items.Count; i++)
                {
                    if (npcListView.Items[i].Checked)
                    {
                        npcsIds += npcListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = npcListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void npcListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                npcListView.SelectedItems[0].Checked = !npcListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = npcListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchNpc(searchTextBox.Text, false);
        }

        public void searchNpc(string npcId, bool isEqual)
        {
            if (string.IsNullOrEmpty(npcId))
            {
                return;
            }
            bool isSearched = false;

            if (npcListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (npcListView.SelectedItems != null && npcListView.SelectedItems.Count != 0)
                {
                    startIndex = npcListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == npcListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = npcListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == npcId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                npcListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(npcId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                npcListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == npcListView.Items.Count)
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
                searchNpc(searchTextBox.Text, false);
            }
        }
    }
}
