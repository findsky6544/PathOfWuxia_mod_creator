using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectPropsCategoryForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectPropsCategoryForm()
        {
            InitializeComponent();
        }
        public SelectPropsCategoryForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                PropsCategoryListView.CheckBoxes = true;
            }

            initPropsCategoryListView();
        }

        public void initPropsCategoryListView()
        {
            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = ((int)temp).ToString();
                lvi.SubItems.Add(EnumData.GetDisplayName(temp));
                PropsCategoryListView.Items.Add(lvi);
            }
        }

        private void SelectPropsCategoryForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] PropsCategorysList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < PropsCategorysList.Length; i++)
                {
                    for (int j = 0; j < PropsCategoryListView.Items.Count; j++)
                    {
                        if (PropsCategorysList[i].Trim() == PropsCategoryListView.Items[j].Text.Trim())
                        {
                            PropsCategoryListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                PropsCategoryListView.Items[j].Selected = true;
                                PropsCategoryListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchPropsCategory(textBox.Text, true);
            }

            PropsCategoryListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string PropsCategorysIds = "";
                for (int i = 0; i < PropsCategoryListView.Items.Count; i++)
                {
                    if (PropsCategoryListView.Items[i].Checked)
                    {
                        PropsCategorysIds += PropsCategoryListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (PropsCategorysIds.Length > 0)
                {
                    PropsCategorysIds = PropsCategorysIds.Substring(0, PropsCategorysIds.Length - 1);
                }
                textBox.Text = PropsCategorysIds;
            }
            else
            {
                textBox.Text = PropsCategoryListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void PropsCategoryListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                PropsCategoryListView.SelectedItems[0].Checked = !PropsCategoryListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = PropsCategoryListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchPropsCategory(searchTextBox.Text, false);
        }

        public void searchPropsCategory(string PropsCategoryId, bool isEqual)
        {
            if (string.IsNullOrEmpty(PropsCategoryId))
            {
                return;
            }
            bool isSearched = false;

            if (PropsCategoryListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (PropsCategoryListView.SelectedItems != null && PropsCategoryListView.SelectedItems.Count != 0)
                {
                    startIndex = PropsCategoryListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == PropsCategoryListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = PropsCategoryListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == PropsCategoryId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                PropsCategoryListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(PropsCategoryId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                PropsCategoryListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == PropsCategoryListView.Items.Count)
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
                searchPropsCategory(searchTextBox.Text, false);
            }
        }
    }
}
