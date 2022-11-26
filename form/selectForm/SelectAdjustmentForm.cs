using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectAdjustmentForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectAdjustmentForm()
        {
            InitializeComponent();
        }
        public SelectAdjustmentForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                adjustmentListView.CheckBoxes = true;
            }

            initAdjustmentListView();
        }

        public void initAdjustmentListView()
        {
            if (DataManager.allAdjustmentLvis.Count == 0)
            {
                DataManager.allAdjustmentLvis = DataManager.createAdjustmentLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allAdjustmentLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            adjustmentListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectAdjustmentForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] adjustmentsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < adjustmentsList.Length; i++)
                {
                    for (int j = 0; j < adjustmentListView.Items.Count; j++)
                    {
                        if (adjustmentsList[i].Trim() == adjustmentListView.Items[j].Text.Trim())
                        {
                            adjustmentListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                adjustmentListView.Items[j].Selected = true;
                                adjustmentListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchAdjustment(textBox.Text, true, true);
            }

            adjustmentListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string adjustmentsIds = "";
                for (int i = 0; i < adjustmentListView.Items.Count; i++)
                {
                    if (adjustmentListView.Items[i].Checked)
                    {
                        adjustmentsIds += adjustmentListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (adjustmentsIds.Length > 0)
                {
                    adjustmentsIds = adjustmentsIds.Substring(0, adjustmentsIds.Length - 1);
                }
                textBox.Text = adjustmentsIds;
            }
            else
            {
                textBox.Text = adjustmentListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void adjustmentListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                adjustmentListView.SelectedItems[0].Checked = !adjustmentListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = adjustmentListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAdjustment(searchTextBox.Text, false, false);
        }

        public void searchAdjustment(string adjustmentId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(adjustmentId))
            {
                return;
            }
            bool isSearched = false;

            if (adjustmentListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (adjustmentListView.SelectedItems != null && adjustmentListView.SelectedItems.Count != 0)
                {
                    startIndex = adjustmentListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == adjustmentListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = adjustmentListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == adjustmentId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                adjustmentListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == adjustmentId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                adjustmentListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(adjustmentId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                adjustmentListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == adjustmentListView.Items.Count)
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
                searchAdjustment(searchTextBox.Text, false, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("Adjustment", ":" + adjustmentListView.SelectedItems[0].SubItems[0].Text,contextMenuStrip1);
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
