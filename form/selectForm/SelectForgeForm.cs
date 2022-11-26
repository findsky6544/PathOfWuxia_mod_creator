using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectForgeForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectForgeForm()
        {
            InitializeComponent();
        }
        public SelectForgeForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                ForgeListView.CheckBoxes = true;
            }

            initForgeListView();
        }

        public void initForgeListView()
        {

            if (DataManager.allForgeLvis.Count == 0)
            {
                DataManager.allForgeLvis = DataManager.createForgeLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allForgeLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            ForgeListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectForgeForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] ForgesList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < ForgesList.Length; i++)
                {
                    for (int j = 0; j < ForgeListView.Items.Count; j++)
                    {
                        if (ForgesList[i].Trim() == ForgeListView.Items[j].Text.Trim())
                        {
                            ForgeListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                ForgeListView.Items[j].Selected = true;
                                ForgeListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchForge(textBox.Text, true);
            }

            ForgeListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string ForgesIds = "";
                for (int i = 0; i < ForgeListView.Items.Count; i++)
                {
                    if (ForgeListView.Items[i].Checked)
                    {
                        ForgesIds += ForgeListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (ForgesIds.Length > 0)
                {
                    ForgesIds = ForgesIds.Substring(0, ForgesIds.Length - 1);
                }
                textBox.Text = ForgesIds;
            }
            else
            {
                textBox.Text = ForgeListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void ForgeListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                ForgeListView.SelectedItems[0].Checked = !ForgeListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = ForgeListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchForge(searchTextBox.Text, false);
        }

        public void searchForge(string ForgeId, bool isEqual)
        {
            if (string.IsNullOrEmpty(ForgeId))
            {
                return;
            }
            bool isSearched = false;

            if (ForgeListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (ForgeListView.SelectedItems != null && ForgeListView.SelectedItems.Count != 0)
                {
                    startIndex = ForgeListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == ForgeListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = ForgeListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == ForgeId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                ForgeListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(ForgeId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                ForgeListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == ForgeListView.Items.Count)
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
                searchForge(searchTextBox.Text, false);
            }
        }
    }
}
