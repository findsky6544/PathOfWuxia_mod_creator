using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectBufferForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectBufferForm()
        {
            InitializeComponent();
        }
        public SelectBufferForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                bufferListView.CheckBoxes = true;
            }

            initBufferListView();
        }

        public void initBufferListView()
        {
            if (DataManager.allBufferLvis.Count == 0)
            {
                DataManager.allBufferLvis = DataManager.createBufferLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();

            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allBufferLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            bufferListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectBufferForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] buffersList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < buffersList.Length; i++)
                {
                    for (int j = 0; j < bufferListView.Items.Count; j++)
                    {
                        if (buffersList[i].Trim() == bufferListView.Items[j].SubItems[1].Text.Trim())
                        {
                            bufferListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                bufferListView.Items[j].Selected = true;
                                bufferListView.EnsureVisible(j);
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
            bufferListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string bufferIds = "";
                for (int i = 0; i < bufferListView.Items.Count; i++)
                {
                    if (bufferListView.Items[i].Checked)
                    {
                        bufferIds += bufferListView.Items[i].SubItems[1].Text + ",";
                    }
                }
                if (bufferIds.Length > 0)
                {
                    bufferIds = bufferIds.Substring(0, bufferIds.Length - 1);
                }
                textBox.Text = bufferIds;
            }
            else
            {
                textBox.Text = bufferListView.SelectedItems[0].SubItems[1].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bufferListView.SelectedItems[0].Checked = !bufferListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = bufferListView.SelectedItems[0].SubItems[1].Text;
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

            if (bufferListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (bufferListView.SelectedItems != null && bufferListView.SelectedItems.Count != 0)
                {
                    startIndex = bufferListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == bufferListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = bufferListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.SubItems[1].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                bufferListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                bufferListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                bufferListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == bufferListView.Items.Count)
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

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("buffer", ":" + bufferListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
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
