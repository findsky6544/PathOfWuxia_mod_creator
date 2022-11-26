using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectSkillForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;

        selectSkillType selectType = selectSkillType.all;

        public enum selectSkillType
        {
            all,
            normal,
            special
        }

        public SelectSkillForm()
        {
            InitializeComponent();
        }
        public SelectSkillForm(Form owner, TextBox textBox, bool isMultiSelect, selectSkillType selectType = selectSkillType.all) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                SkillListView.CheckBoxes = true;
            }

            this.selectType = selectType;

            initSkillListView();
        }

        public void initSkillListView()
        {
            if (DataManager.allSkillLvis.Count == 0)
            {
                DataManager.allSkillLvis = DataManager.createSkillLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allSkillLvis)
            {
                if ((selectType == selectSkillType.normal && !kv.Value.SubItems[1].Text.Contains("special"))
                    || (selectType == selectSkillType.special && kv.Value.SubItems[1].Text.Contains("special"))
                     || selectType == selectSkillType.all)
                {
                    lvis.Add((ListViewItem)kv.Value.Clone());
                }
            }

            SkillListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectSkillForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < SkillListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == SkillListView.Items[j].SubItems[1].Text.Trim())
                        {
                            SkillListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                SkillListView.Items[j].Selected = true;
                                SkillListView.EnsureVisible(j);
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

            SkillListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < SkillListView.Items.Count; i++)
                {
                    if (SkillListView.Items[i].Checked)
                    {
                        npcsIds += SkillListView.Items[i].SubItems[1].Text + ",";
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
                textBox.Text = SkillListView.SelectedItems[0].SubItems[1].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                SkillListView.SelectedItems[0].Checked = !SkillListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = SkillListView.SelectedItems[0].SubItems[1].Text;
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

            if (SkillListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (SkillListView.SelectedItems != null && SkillListView.SelectedItems.Count != 0)
                {
                    startIndex = SkillListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == SkillListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = SkillListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.SubItems[1].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                SkillListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                SkillListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                SkillListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == SkillListView.Items.Count)
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
    }
}
