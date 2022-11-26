using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectEventCubeForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectEventCubeForm()
        {
            InitializeComponent();
        }
        public SelectEventCubeForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                eventCubeListView.CheckBoxes = true;
            }

            initEventCubeListView();
        }

        public void initEventCubeListView()
        {
            if (DataManager.allEventCubeLvis.Count == 0)
            {
                DataManager.allEventCubeLvis = DataManager.createEventCubeLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allEventCubeLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            eventCubeListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectEventCubeForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] eventCubesList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < eventCubesList.Length; i++)
                {
                    for (int j = 0; j < eventCubeListView.Items.Count; j++)
                    {
                        if (eventCubesList[i].Trim() == eventCubeListView.Items[j].Text.Trim())
                        {
                            eventCubeListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                eventCubeListView.Items[j].Selected = true;
                                eventCubeListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchEventCube(textBox.Text, true);
            }

            eventCubeListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string eventCubesIds = "";
                for (int i = 0; i < eventCubeListView.Items.Count; i++)
                {
                    if (eventCubeListView.Items[i].Checked)
                    {
                        eventCubesIds += eventCubeListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (eventCubesIds.Length > 0)
                {
                    eventCubesIds = eventCubesIds.Substring(0, eventCubesIds.Length - 1);
                }
                textBox.Text = eventCubesIds;
            }
            else
            {
                textBox.Text = eventCubeListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void eventCubeListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                eventCubeListView.SelectedItems[0].Checked = !eventCubeListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = eventCubeListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEventCube(searchTextBox.Text, false);
        }

        public void searchEventCube(string eventCubeId, bool isEqual)
        {
            if (string.IsNullOrEmpty(eventCubeId))
            {
                return;
            }
            bool isSearched = false;

            if (eventCubeListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (eventCubeListView.SelectedItems != null && eventCubeListView.SelectedItems.Count != 0)
                {
                    startIndex = eventCubeListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == eventCubeListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = eventCubeListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == eventCubeId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                eventCubeListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(eventCubeId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                eventCubeListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == eventCubeListView.Items.Count)
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
                searchEventCube(searchTextBox.Text, false);
            }
        }
    }
}
