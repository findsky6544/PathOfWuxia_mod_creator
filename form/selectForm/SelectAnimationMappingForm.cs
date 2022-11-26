using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectAnimationMappingForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectAnimationMappingForm()
        {
            InitializeComponent();
        }
        public SelectAnimationMappingForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                AnimationMappingListView.CheckBoxes = true;
            }

            initAnimationMappingListView();
        }

        public void initAnimationMappingListView()
        {
            if (DataManager.allAnimationMappingLvis.Count == 0)
            {
                DataManager.allAnimationMappingLvis = DataManager.createAnimationMappingLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allAnimationMappingLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            AnimationMappingListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectAnimationMappingForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] AnimationMappingsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < AnimationMappingsList.Length; i++)
                {
                    for (int j = 0; j < AnimationMappingListView.Items.Count; j++)
                    {
                        if (AnimationMappingsList[i].Trim() == AnimationMappingListView.Items[j].Text.Trim())
                        {
                            AnimationMappingListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                AnimationMappingListView.Items[j].Selected = true;
                                AnimationMappingListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchAnimationMapping(textBox.Text, true, true);
            }

            AnimationMappingListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string AnimationMappingsIds = "";
                for (int i = 0; i < AnimationMappingListView.Items.Count; i++)
                {
                    if (AnimationMappingListView.Items[i].Checked)
                    {
                        AnimationMappingsIds += AnimationMappingListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (AnimationMappingsIds.Length > 0)
                {
                    AnimationMappingsIds = AnimationMappingsIds.Substring(0, AnimationMappingsIds.Length - 1);
                }
                textBox.Text = AnimationMappingsIds;
            }
            else
            {
                textBox.Text = AnimationMappingListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void AnimationMappingListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                AnimationMappingListView.SelectedItems[0].Checked = !AnimationMappingListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = AnimationMappingListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAnimationMapping(searchTextBox.Text, false, false);
        }

        public void searchAnimationMapping(string AnimationMappingId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(AnimationMappingId))
            {
                return;
            }
            bool isSearched = false;

            if (AnimationMappingListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (AnimationMappingListView.SelectedItems != null && AnimationMappingListView.SelectedItems.Count != 0)
                {
                    startIndex = AnimationMappingListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == AnimationMappingListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = AnimationMappingListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == AnimationMappingId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AnimationMappingListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == AnimationMappingId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AnimationMappingListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(AnimationMappingId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AnimationMappingListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == AnimationMappingListView.Items.Count)
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
                searchAnimationMapping(searchTextBox.Text, false, false);
            }
        }
    }
}
