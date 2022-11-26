using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectCharacterBehaviourForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectCharacterBehaviourForm()
        {
            InitializeComponent();
        }
        public SelectCharacterBehaviourForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                CharacterBehaviourListView.CheckBoxes = true;
            }

            initCharacterBehaviourListView();
        }

        public void initCharacterBehaviourListView()
        {
            if (DataManager.allCharacterBehaviourLvis.Count == 0)
            {
                DataManager.allCharacterBehaviourLvis = DataManager.createCharacterBehaviourLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allCharacterBehaviourLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            CharacterBehaviourListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectCharacterBehaviourForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] CharacterBehavioursList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < CharacterBehavioursList.Length; i++)
                {
                    for (int j = 0; j < CharacterBehaviourListView.Items.Count; j++)
                    {
                        if (CharacterBehavioursList[i].Trim() == CharacterBehaviourListView.Items[j].Text.Trim())
                        {
                            CharacterBehaviourListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                CharacterBehaviourListView.Items[j].Selected = true;
                                CharacterBehaviourListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchCharacterBehaviour(textBox.Text, true, true);
            }

            CharacterBehaviourListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string CharacterBehavioursIds = "";
                for (int i = 0; i < CharacterBehaviourListView.Items.Count; i++)
                {
                    if (CharacterBehaviourListView.Items[i].Checked)
                    {
                        CharacterBehavioursIds += CharacterBehaviourListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (CharacterBehavioursIds.Length > 0)
                {
                    CharacterBehavioursIds = CharacterBehavioursIds.Substring(0, CharacterBehavioursIds.Length - 1);
                }
                textBox.Text = CharacterBehavioursIds;
            }
            else
            {
                textBox.Text = CharacterBehaviourListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void CharacterBehaviourListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                CharacterBehaviourListView.SelectedItems[0].Checked = !CharacterBehaviourListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = CharacterBehaviourListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterBehaviour(searchTextBox.Text, false, false);
        }

        public void searchCharacterBehaviour(string CharacterBehaviourId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(CharacterBehaviourId))
            {
                return;
            }
            bool isSearched = false;

            if (CharacterBehaviourListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (CharacterBehaviourListView.SelectedItems != null && CharacterBehaviourListView.SelectedItems.Count != 0)
                {
                    startIndex = CharacterBehaviourListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == CharacterBehaviourListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = CharacterBehaviourListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == CharacterBehaviourId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                CharacterBehaviourListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == CharacterBehaviourId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                CharacterBehaviourListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(CharacterBehaviourId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                CharacterBehaviourListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == CharacterBehaviourListView.Items.Count)
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
                searchCharacterBehaviour(searchTextBox.Text, false, false);
            }
        }
    }
}
