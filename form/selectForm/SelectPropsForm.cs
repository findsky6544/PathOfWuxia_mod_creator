using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectPropsForm : Form
    {
        public TextBox textBox;

        bool isMultiSelect = false;
        string[] propsType;
        string[] propsCategory;
        public SelectPropsForm()
        {
            InitializeComponent();
        }
        public SelectPropsForm(Form owner, TextBox textBox, bool isMultiSelect, string[] propsType, string[] propsCategory) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            this.propsType = propsType;
            this.propsCategory = propsCategory;

            if (isMultiSelect)
            {
                propsListView.CheckBoxes = true;
            }

            initPropsListView();
        }

        public void initPropsListView()
        {

            if (DataManager.allPropsLvis.Count == 0)
            {
                DataManager.allPropsLvis = DataManager.createPropsLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();

            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("Money");
            lvi.SubItems.Add("金钱");
            lvis.Add(lvi);

            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allPropsLvis)
            {
                for (int i = 0; i < propsType.Length; i++)
                {
                    for (int j = 0; j < propsCategory.Length; j++)
                    {
                        if ((propsType[i] == "all" || kv.Value.SubItems[5].Text == propsType[i]) && (propsCategory[j] == "all" || kv.Value.SubItems[6].Text == propsCategory[j]))
                        {
                            lvis.Add((ListViewItem)kv.Value.Clone());
                        }
                    }
                }
            }

            propsListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectPropsForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] PropsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < PropsList.Length; i++)
                {
                    for (int j = 0; j < propsListView.Items.Count; j++)
                    {
                        if (PropsList[i].Trim() == propsListView.Items[j].SubItems[1].Text.Trim())
                        {
                            propsListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                propsListView.Items[j].Selected = true;
                                propsListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchProps(textBox.Text, true);
            }

            propsListView.Focus();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string PropsIds = "";
                for (int i = 0; i < propsListView.Items.Count; i++)
                {
                    if (propsListView.Items[i].Checked)
                    {
                        PropsIds += propsListView.Items[i].SubItems[1].Text + ",";
                    }
                }
                if (PropsIds.Length > 0)
                {
                    PropsIds = PropsIds.Substring(0, PropsIds.Length - 1);
                }
                textBox.Text = PropsIds;
            }
            else
            {
                textBox.Text = propsListView.SelectedItems[0].SubItems[1].Text;
            }
            Close();
        }

        private void propsListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                propsListView.SelectedItems[0].Checked = !propsListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = propsListView.SelectedItems[0].SubItems[1].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchProps(searchTextBox.Text, false);
        }

        public void searchProps(string propsId, bool isEqual)
        {
            if (string.IsNullOrEmpty(propsId))
            {
                return;
            }
            bool isSearched = false;

            if (propsListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (propsListView.SelectedItems != null && propsListView.SelectedItems.Count != 0)
                {
                    startIndex = propsListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == propsListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = propsListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == propsId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                propsListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(propsId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                propsListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == propsListView.Items.Count)
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
                searchProps(searchTextBox.Text, false);
            }
        }
    }
}
