using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectBattleAreaForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectBattleAreaForm()
        {
            InitializeComponent();
        }
        public SelectBattleAreaForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                BattleAreaListView.CheckBoxes = true;
            }

            initBattleAreaListView();
        }

        public void initBattleAreaListView()
        {
            if (DataManager.allBattleAreaLvis.Count == 0)
            {
                DataManager.allBattleAreaLvis = DataManager.createBattleAreaLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allBattleAreaLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            BattleAreaListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectBattleAreaForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] BattleAreasList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < BattleAreasList.Length; i++)
                {
                    for (int j = 0; j < BattleAreaListView.Items.Count; j++)
                    {
                        if (BattleAreasList[i].Trim() == BattleAreaListView.Items[j].Text.Trim())
                        {
                            BattleAreaListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                BattleAreaListView.Items[j].Selected = true;
                                BattleAreaListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBattleArea(textBox.Text, true, true);
            }

            BattleAreaListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string BattleAreasIds = "";
                for (int i = 0; i < BattleAreaListView.Items.Count; i++)
                {
                    if (BattleAreaListView.Items[i].Checked)
                    {
                        BattleAreasIds += BattleAreaListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (BattleAreasIds.Length > 0)
                {
                    BattleAreasIds = BattleAreasIds.Substring(0, BattleAreasIds.Length - 1);
                }
                textBox.Text = BattleAreasIds;
            }
            else
            {
                textBox.Text = BattleAreaListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void BattleAreaListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                BattleAreaListView.SelectedItems[0].Checked = !BattleAreaListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = BattleAreaListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBattleArea(searchTextBox.Text, false, false);
        }

        public void searchBattleArea(string BattleAreaId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(BattleAreaId))
            {
                return;
            }
            bool isSearched = false;

            if (BattleAreaListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BattleAreaListView.SelectedItems != null && BattleAreaListView.SelectedItems.Count != 0)
                {
                    startIndex = BattleAreaListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BattleAreaListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BattleAreaListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == BattleAreaId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleAreaListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == BattleAreaId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleAreaListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(BattleAreaId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleAreaListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BattleAreaListView.Items.Count)
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
                searchBattleArea(searchTextBox.Text, false, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("BattleArea", ":" + BattleAreaListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
            if (contextMenuStrip1.Items.Count > 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
