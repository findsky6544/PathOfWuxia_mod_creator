using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectUnitForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectUnitForm()
        {
            InitializeComponent();
        }
        public SelectUnitForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                unitListView.CheckBoxes = true;
            }

            initUnitListView();
        }

        public void initUnitListView()
        {

            if (DataManager.allUnitLvis.Count == 0)
            {
                DataManager.allUnitLvis = DataManager.createUnitLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allUnitLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            unitListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < unitListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == unitListView.Items[j].Text.Trim())
                        {
                            unitListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                unitListView.Items[j].Selected = true;
                                unitListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBuffer(textBox.Text, true);
            }

            unitListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < unitListView.Items.Count; i++)
                {
                    if (unitListView.Items[i].Checked)
                    {
                        npcsIds += unitListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = unitListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                unitListView.SelectedItems[0].Checked = !unitListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = unitListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
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

            if (unitListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (unitListView.SelectedItems != null && unitListView.SelectedItems.Count != 0)
                {
                    startIndex = unitListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == unitListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = unitListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                unitListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                unitListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == unitListView.Items.Count)
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
