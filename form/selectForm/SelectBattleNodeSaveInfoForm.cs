using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectBattleNodeSaveInfoForm : Form
    {
        public TextBox textBox;
        public SelectBattleNodeSaveInfoForm()
        {
            InitializeComponent();
        }
        public SelectBattleNodeSaveInfoForm(Form owner, TextBox textBox, bool isMultiSelect = false) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            initBufferListView();
        }

        public void initBufferListView()
        {
            if (DataManager.allBattleScheduleLvis.Count == 0)
            {
                DataManager.allBattleScheduleLvis = DataManager.createBattleScheduleLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allBattleScheduleLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            battleNodeSaveInfoListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectBattleNodeSaveInfoForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true, true);
            battleNodeSaveInfoListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = battleNodeSaveInfoListView.SelectedItems[0].SubItems[0].Text;
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = battleNodeSaveInfoListView.SelectedItems[0].SubItems[0].Text;
            Close();
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

            if (battleNodeSaveInfoListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (battleNodeSaveInfoListView.SelectedItems != null && battleNodeSaveInfoListView.SelectedItems.Count != 0)
                {
                    startIndex = battleNodeSaveInfoListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == battleNodeSaveInfoListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = battleNodeSaveInfoListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                battleNodeSaveInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                battleNodeSaveInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                battleNodeSaveInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == battleNodeSaveInfoListView.Items.Count)
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
                searchBuffer(searchTextBox.Text, false, true);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("battle/schedule", ":" + battleNodeSaveInfoListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
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
