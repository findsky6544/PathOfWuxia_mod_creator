using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectCharacterInfoForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectCharacterInfoForm()
        {
            InitializeComponent();
        }
        public SelectCharacterInfoForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                characterInfoListView.CheckBoxes = true;
            }

            initCharacterInfoListView();
        }

        public void initCharacterInfoListView()
        {
            if (DataManager.allCharacterInfoLvis.Count == 0)
            {
                DataManager.allCharacterInfoLvis = DataManager.createCharacterInfoLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Player";
            lvi.SubItems.Add("玩家");
            lvis.Add(lvi);
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allCharacterInfoLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            characterInfoListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectCharacterInfoForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] characterInfosList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < characterInfosList.Length; i++)
                {
                    for (int j = 0; j < characterInfoListView.Items.Count; j++)
                    {
                        if (characterInfosList[i].Trim() == characterInfoListView.Items[j].Text.Trim())
                        {
                            characterInfoListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                characterInfoListView.Items[j].Selected = true;
                                characterInfoListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchCharacterInfo(textBox.Text, true, true);
            }

            characterInfoListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string characterInfosIds = "";
                for (int i = 0; i < characterInfoListView.Items.Count; i++)
                {
                    if (characterInfoListView.Items[i].Checked)
                    {
                        characterInfosIds += characterInfoListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (characterInfosIds.Length > 0)
                {
                    characterInfosIds = characterInfosIds.Substring(0, characterInfosIds.Length - 1);
                }
                textBox.Text = characterInfosIds;
            }
            else
            {
                textBox.Text = characterInfoListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void characterInfoListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                characterInfoListView.SelectedItems[0].Checked = !characterInfoListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = characterInfoListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchCharacterInfo(searchTextBox.Text, false, false);
        }

        public void searchCharacterInfo(string characterInfoId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(characterInfoId))
            {
                return;
            }
            bool isSearched = false;

            if (characterInfoListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (characterInfoListView.SelectedItems != null && characterInfoListView.SelectedItems.Count != 0)
                {
                    startIndex = characterInfoListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == characterInfoListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = characterInfoListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == characterInfoId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == characterInfoId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(characterInfoId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                characterInfoListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == characterInfoListView.Items.Count)
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
                searchCharacterInfo(searchTextBox.Text, false, false);
            }
        }
    }
}
