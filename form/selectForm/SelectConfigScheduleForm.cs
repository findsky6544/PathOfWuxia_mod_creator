using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectConfigScheduleForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectConfigScheduleForm()
        {
            InitializeComponent();
        }
        public SelectConfigScheduleForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                ConfigScheduleListView.CheckBoxes = true;
            }

            initConfigScheduleListView();
        }

        public void initConfigScheduleListView()
        {
            if (DataManager.allConfigScheduleLvis.Count == 0)
            {
                DataManager.allConfigScheduleLvis = DataManager.createConfigScheduleLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allConfigScheduleLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            ConfigScheduleListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectConfigScheduleForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] ConfigSchedulesList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < ConfigSchedulesList.Length; i++)
                {
                    for (int j = 0; j < ConfigScheduleListView.Items.Count; j++)
                    {
                        if (ConfigSchedulesList[i].Trim() == ConfigScheduleListView.Items[j].Text.Trim())
                        {
                            ConfigScheduleListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                ConfigScheduleListView.Items[j].Selected = true;
                                ConfigScheduleListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchConfigSchedule(textBox.Text, true);
            }

            ConfigScheduleListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string ConfigSchedulesIds = "";
                for (int i = 0; i < ConfigScheduleListView.Items.Count; i++)
                {
                    if (ConfigScheduleListView.Items[i].Checked)
                    {
                        ConfigSchedulesIds += ConfigScheduleListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (ConfigSchedulesIds.Length > 0)
                {
                    ConfigSchedulesIds = ConfigSchedulesIds.Substring(0, ConfigSchedulesIds.Length - 1);
                }
                textBox.Text = ConfigSchedulesIds;
            }
            else
            {
                textBox.Text = ConfigScheduleListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void ConfigScheduleListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                ConfigScheduleListView.SelectedItems[0].Checked = !ConfigScheduleListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = ConfigScheduleListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchConfigSchedule(searchTextBox.Text, false);
        }

        public void searchConfigSchedule(string ConfigScheduleId, bool isEqual)
        {
            if (string.IsNullOrEmpty(ConfigScheduleId))
            {
                return;
            }
            bool isSearched = false;

            if (ConfigScheduleListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (ConfigScheduleListView.SelectedItems != null && ConfigScheduleListView.SelectedItems.Count != 0)
                {
                    startIndex = ConfigScheduleListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == ConfigScheduleListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = ConfigScheduleListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == ConfigScheduleId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                ConfigScheduleListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(ConfigScheduleId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                ConfigScheduleListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == ConfigScheduleListView.Items.Count)
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
                searchConfigSchedule(searchTextBox.Text, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("config/schedule", ":" + ConfigScheduleListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
            if(contextMenuStrip1.Items.Count > 0)
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
