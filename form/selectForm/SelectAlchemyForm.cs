using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectAlchemyForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectAlchemyForm()
        {
            InitializeComponent();
        }
        public SelectAlchemyForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                AlchemyListView.CheckBoxes = true;
            }

            initAlchemyListView();
        }

        public void initAlchemyListView()
        {
            if (DataManager.allAlchemyLvis.Count == 0)
            {
                DataManager.allAlchemyLvis = DataManager.createAlchemyLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allAlchemyLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            AlchemyListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectAlchemyForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] AlchemysList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < AlchemysList.Length; i++)
                {
                    for (int j = 0; j < AlchemyListView.Items.Count; j++)
                    {
                        if (AlchemysList[i].Trim() == AlchemyListView.Items[j].Text.Trim())
                        {
                            AlchemyListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                AlchemyListView.Items[j].Selected = true;
                                AlchemyListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchAlchemy(textBox.Text, true, true);
            }

            AlchemyListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string AlchemysIds = "";
                for (int i = 0; i < AlchemyListView.Items.Count; i++)
                {
                    if (AlchemyListView.Items[i].Checked)
                    {
                        AlchemysIds += AlchemyListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (AlchemysIds.Length > 0)
                {
                    AlchemysIds = AlchemysIds.Substring(0, AlchemysIds.Length - 1);
                }
                textBox.Text = AlchemysIds;
            }
            else
            {
                textBox.Text = AlchemyListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void AlchemyListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                AlchemyListView.SelectedItems[0].Checked = !AlchemyListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = AlchemyListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchAlchemy(searchTextBox.Text, false, false);
        }

        public void searchAlchemy(string AlchemyId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(AlchemyId))
            {
                return;
            }
            bool isSearched = false;

            if (AlchemyListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (AlchemyListView.SelectedItems != null && AlchemyListView.SelectedItems.Count != 0)
                {
                    startIndex = AlchemyListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == AlchemyListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = AlchemyListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == AlchemyId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AlchemyListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == AlchemyId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AlchemyListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(AlchemyId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                AlchemyListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == AlchemyListView.Items.Count)
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
                searchAlchemy(searchTextBox.Text, false, false);
            }
        }
    }
}
