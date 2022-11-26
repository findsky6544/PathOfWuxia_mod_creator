using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectMapForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectMapForm()
        {
            InitializeComponent();
        }
        public SelectMapForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                mapListView.CheckBoxes = true;
            }

            initMapListView();
        }

        public void initMapListView()
        {
            if (DataManager.allMapLvis.Count == 0)
            {
                DataManager.allMapLvis = DataManager.createMapLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allMapLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            mapListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < mapListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == mapListView.Items[j].Text.Trim())
                        {
                            mapListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                mapListView.Items[j].Selected = true;
                                mapListView.EnsureVisible(j);
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

            mapListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < mapListView.Items.Count; i++)
                {
                    if (mapListView.Items[i].Checked)
                    {
                        npcsIds += mapListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = mapListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                mapListView.SelectedItems[0].Checked = !mapListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = mapListView.SelectedItems[0].SubItems[0].Text;
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

            if (mapListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (mapListView.SelectedItems != null && mapListView.SelectedItems.Count != 0)
                {
                    startIndex = mapListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == mapListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = mapListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                mapListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                mapListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                mapListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == mapListView.Items.Count)
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
