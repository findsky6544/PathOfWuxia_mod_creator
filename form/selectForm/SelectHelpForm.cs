using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectHelpForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectHelpForm()
        {
            InitializeComponent();
        }
        public SelectHelpForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                HelpListView.CheckBoxes = true;
            }

            initHelpListView();
        }

        public void initHelpListView()
        {
            Form form = Owner;
            while (!(form is MainForm))
            {
                form = form.Owner;
            }

            if (DataManager.allHelpLvis.Count == 0)
            {
                DataManager.allHelpLvis = DataManager.createHelpLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allHelpLvis)
            {
                if (kv.Value.SubItems[2].Text == "True")
                {
                    lvis.Add((ListViewItem)kv.Value.Clone());
                }
            }

            HelpListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < HelpListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == HelpListView.Items[j].Text.Trim())
                        {
                            HelpListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                HelpListView.Items[j].Selected = true;
                                HelpListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchHelp(textBox.Text, true, true);
            }

            HelpListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < HelpListView.Items.Count; i++)
                {
                    if (HelpListView.Items[i].Checked)
                    {
                        npcsIds += HelpListView.Items[i].SubItems[0].Text + ",";
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
                textBox.Text = HelpListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void HelpListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                HelpListView.SelectedItems[0].Checked = !HelpListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = HelpListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchHelp(searchTextBox.Text, false, false);
        }

        public void searchHelp(string HelpId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(HelpId))
            {
                return;
            }
            bool isSearched = false;

            if (HelpListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (HelpListView.SelectedItems != null && HelpListView.SelectedItems.Count != 0)
                {
                    startIndex = HelpListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == HelpListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = HelpListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == HelpId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == HelpId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(HelpId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                HelpListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == HelpListView.Items.Count)
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
                searchHelp(searchTextBox.Text, false, false);
            }
        }
    }
}
