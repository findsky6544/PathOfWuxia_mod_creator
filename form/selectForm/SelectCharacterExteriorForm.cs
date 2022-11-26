using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectCharacterExteriorForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectCharacterExteriorForm()
        {
            InitializeComponent();
        }
        public SelectCharacterExteriorForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                characterExteriorListView.CheckBoxes = true;
            }

            initCharacterExteriorListView();
        }

        public void initCharacterExteriorListView()
        {
            if (DataManager.allCharacterExteriorLvis.Count == 0)
            {
                DataManager.allCharacterExteriorLvis = DataManager.createCharacterExteriorLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Player";
            lvi.SubItems.Add("玩家");
            lvis.Add(lvi);
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allCharacterExteriorLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            characterExteriorListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectCharacterExteriorForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] characterExteriorsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < characterExteriorsList.Length; i++)
                {
                    for (int j = 0; j < characterExteriorListView.Items.Count; j++)
                    {
                        if (characterExteriorsList[i].Trim() == characterExteriorListView.Items[j].Text.Trim())
                        {
                            characterExteriorListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                characterExteriorListView.Items[j].Selected = true;
                                characterExteriorListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchCharacterExterior(textBox.Text, true, true);
            }

            characterExteriorListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string characterExteriorsIds = "";
                for (int i = 0; i < characterExteriorListView.Items.Count; i++)
                {
                    if (characterExteriorListView.Items[i].Checked)
                    {
                        characterExteriorsIds += characterExteriorListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (characterExteriorsIds.Length > 0)
                {
                    characterExteriorsIds = characterExteriorsIds.Substring(0, characterExteriorsIds.Length - 1);
                }
                textBox.Text = characterExteriorsIds;
            }
            else
            {
                textBox.Text = characterExteriorListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void characterExteriorListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                characterExteriorListView.SelectedItems[0].Checked = !characterExteriorListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = characterExteriorListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterExterior(searchTextBox.Text, false, false);
        }

        public void searchCharacterExterior(string characterExteriorId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(characterExteriorId))
            {
                return;
            }
            bool isSearched = false;

            if (characterExteriorListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (characterExteriorListView.SelectedItems != null && characterExteriorListView.SelectedItems.Count != 0)
                {
                    startIndex = characterExteriorListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == characterExteriorListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = characterExteriorListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == characterExteriorId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterExteriorListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == characterExteriorId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterExteriorListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(characterExteriorId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterExteriorListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == characterExteriorListView.Items.Count)
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
                searchCharacterExterior(searchTextBox.Text, false, false);
            }
        }
    }
}
