using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectCinematicForm : Form
    {
        public TextBox textBox;
        public SelectCinematicForm()
        {
            InitializeComponent();
        }
        public SelectCinematicForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            initCinematicListView();
        }

        public void initCinematicListView()
        {
            if (DataManager.allCinematicLvis.Count == 0)
            {
                DataManager.allCinematicLvis = DataManager.createCinematicLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allCinematicLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            cinematicListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectScheduleGraphBundleForm_Shown(object sender, EventArgs e)
        {
            searchCinematic(textBox.Text, true);
            cinematicListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = cinematicListView.SelectedItems[0].Text;
            Close();
        }

        private void cinematicListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = cinematicListView.SelectedItems[0].Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCinematic(searchTextBox.Text, false);
        }

        public void searchCinematic(string cinematicId, bool isEqual)
        {
            if (string.IsNullOrEmpty(cinematicId))
            {
                return;
            }
            bool isSearched = false;

            if (cinematicListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (cinematicListView.SelectedItems != null && cinematicListView.SelectedItems.Count != 0)
                {
                    startIndex = cinematicListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == cinematicListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = cinematicListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == cinematicId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                cinematicListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(cinematicId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                cinematicListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == cinematicListView.Items.Count)
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
                searchCinematic(searchTextBox.Text, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("cinematic", ":" + cinematicListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
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
