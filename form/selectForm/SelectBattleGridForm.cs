using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectBattleGridForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectBattleGridForm()
        {
            InitializeComponent();
        }
        public SelectBattleGridForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                BattleGridListView.CheckBoxes = true;
            }

            initBattleGridListView();
        }

        public void initBattleGridListView()
        {
            if (DataManager.allBattleGridLvis.Count == 0)
            {
                DataManager.allBattleGridLvis = DataManager.createBattleGridLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allBattleGridLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            BattleGridListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectBattleGridForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] BattleGridsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < BattleGridsList.Length; i++)
                {
                    for (int j = 0; j < BattleGridListView.Items.Count; j++)
                    {
                        if (BattleGridsList[i].Trim() == BattleGridListView.Items[j].Text.Trim())
                        {
                            BattleGridListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                BattleGridListView.Items[j].Selected = true;
                                BattleGridListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBattleGrid(textBox.Text, true, true);
            }

            BattleGridListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string BattleGridsIds = "";
                for (int i = 0; i < BattleGridListView.Items.Count; i++)
                {
                    if (BattleGridListView.Items[i].Checked)
                    {
                        BattleGridsIds += BattleGridListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (BattleGridsIds.Length > 0)
                {
                    BattleGridsIds = BattleGridsIds.Substring(0, BattleGridsIds.Length - 1);
                }
                textBox.Text = BattleGridsIds;
            }
            else
            {
                textBox.Text = BattleGridListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void BattleGridListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                BattleGridListView.SelectedItems[0].Checked = !BattleGridListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = BattleGridListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBattleGrid(searchTextBox.Text, false, false);
        }

        public void searchBattleGrid(string BattleGridId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(BattleGridId))
            {
                return;
            }
            bool isSearched = false;

            if (BattleGridListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (BattleGridListView.SelectedItems != null && BattleGridListView.SelectedItems.Count != 0)
                {
                    startIndex = BattleGridListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == BattleGridListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = BattleGridListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == BattleGridId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleGridListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == BattleGridId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleGridListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(BattleGridId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                BattleGridListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == BattleGridListView.Items.Count)
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
                searchBattleGrid(searchTextBox.Text, false, false);
            }
        }
    }
}
