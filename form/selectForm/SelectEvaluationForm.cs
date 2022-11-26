using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectEvaluationForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectEvaluationForm()
        {
            InitializeComponent();
        }
        public SelectEvaluationForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                evaluationListView.CheckBoxes = true;
            }

            initEvaluationListView();
        }

        public void initEvaluationListView()
        {
            if (DataManager.allEvaluationLvis.Count == 0)
            {
                DataManager.allEvaluationLvis = DataManager.createEvaluationLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allEvaluationLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            evaluationListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectEvaluationForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] evaluationsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < evaluationsList.Length; i++)
                {
                    for (int j = 0; j < evaluationListView.Items.Count; j++)
                    {
                        if (evaluationsList[i].Trim() == evaluationListView.Items[j].Text.Trim())
                        {
                            evaluationListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                evaluationListView.Items[j].Selected = true;
                                evaluationListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchEvaluation(textBox.Text, true);
            }

            evaluationListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string evaluationsIds = "";
                for (int i = 0; i < evaluationListView.Items.Count; i++)
                {
                    if (evaluationListView.Items[i].Checked)
                    {
                        evaluationsIds += evaluationListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (evaluationsIds.Length > 0)
                {
                    evaluationsIds = evaluationsIds.Substring(0, evaluationsIds.Length - 1);
                }
                textBox.Text = evaluationsIds;
            }
            else
            {
                textBox.Text = evaluationListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void evaluationListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                evaluationListView.SelectedItems[0].Checked = !evaluationListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = evaluationListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEvaluation(searchTextBox.Text, false);
        }

        public void searchEvaluation(string evaluationId, bool isEqual)
        {
            if (string.IsNullOrEmpty(evaluationId))
            {
                return;
            }
            bool isSearched = false;

            if (evaluationListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (evaluationListView.SelectedItems != null && evaluationListView.SelectedItems.Count != 0)
                {
                    startIndex = evaluationListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == evaluationListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = evaluationListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == evaluationId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                evaluationListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(evaluationId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                evaluationListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == evaluationListView.Items.Count)
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
                searchEvaluation(searchTextBox.Text, false);
            }
        }
    }
}
