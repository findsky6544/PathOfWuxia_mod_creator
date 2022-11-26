using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectHelpDescriptionForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectHelpDescriptionForm()
        {
            InitializeComponent();
        }
        public SelectHelpDescriptionForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                HelpDescriptionListView.CheckBoxes = true;
            }

            initHelpDescriptionListView();
        }

        public void initHelpDescriptionListView()
        {
            Form form = Owner;
            while (!(form is MainForm))
            {
                form = form.Owner;
            }

            if (DataManager.allHelpDescriptionLvis.Count == 0)
            {
                DataManager.allHelpDescriptionLvis = DataManager.createHelpDescriptionLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allHelpDescriptionLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            HelpDescriptionListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < HelpDescriptionListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == HelpDescriptionListView.Items[j].Text.Trim())
                        {
                            HelpDescriptionListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                HelpDescriptionListView.Items[j].Selected = true;
                                HelpDescriptionListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchHelpDescription(textBox.Text, true, true);
            }

            HelpDescriptionListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < HelpDescriptionListView.Items.Count; i++)
                {
                    if (HelpDescriptionListView.Items[i].Checked)
                    {
                        npcsIds += HelpDescriptionListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = HelpDescriptionListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void HelpDescriptionListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                HelpDescriptionListView.SelectedItems[0].Checked = !HelpDescriptionListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = HelpDescriptionListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHelpDescription(searchTextBox.Text, false, false);
        }

        public void searchHelpDescription(string HelpDescriptionId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(HelpDescriptionId))
            {
                return;
            }
            bool isSearched = false;

            if (HelpDescriptionListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (HelpDescriptionListView.SelectedItems != null && HelpDescriptionListView.SelectedItems.Count != 0)
                {
                    startIndex = HelpDescriptionListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == HelpDescriptionListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = HelpDescriptionListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == HelpDescriptionId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpDescriptionListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == HelpDescriptionId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpDescriptionListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(HelpDescriptionId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpDescriptionListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == HelpDescriptionListView.Items.Count)
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
                searchHelpDescription(searchTextBox.Text, false, false);
            }
        }
    }
}
