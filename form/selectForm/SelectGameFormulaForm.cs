using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectGameFormulaForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectGameFormulaForm()
        {
            InitializeComponent();
        }
        public SelectGameFormulaForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                GameFormulaListView.CheckBoxes = true;
            }

            initGameFormulaListView();
        }

        public void initGameFormulaListView()
        {
            Form form = Owner;
            while (!(form is MainForm))
            {
                form = form.Owner;
            }

            if (DataManager.allGameFormulaLvis.Count == 0)
            {
                DataManager.allGameFormulaLvis = DataManager.createGameFormulaLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allGameFormulaLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            GameFormulaListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectGameFormulaForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] GameFormulasList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < GameFormulasList.Length; i++)
                {
                    for (int j = 0; j < GameFormulaListView.Items.Count; j++)
                    {
                        if (GameFormulasList[i].Trim() == GameFormulaListView.Items[j].Text.Trim())
                        {
                            GameFormulaListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                GameFormulaListView.Items[j].Selected = true;
                                GameFormulaListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchGameFormula(textBox.Text, true);
            }

            GameFormulaListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string GameFormulasIds = "";
                for (int i = 0; i < GameFormulaListView.Items.Count; i++)
                {
                    if (GameFormulaListView.Items[i].Checked)
                    {
                        GameFormulasIds += GameFormulaListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (GameFormulasIds.Length > 0)
                {
                    GameFormulasIds = GameFormulasIds.Substring(0, GameFormulasIds.Length - 1);
                }
                textBox.Text = GameFormulasIds;
            }
            else
            {
                textBox.Text = GameFormulaListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void GameFormulaListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                GameFormulaListView.SelectedItems[0].Checked = !GameFormulaListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = GameFormulaListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchGameFormula(searchTextBox.Text, false);
        }

        public void searchGameFormula(string GameFormulaId, bool isEqual)
        {
            if (string.IsNullOrEmpty(GameFormulaId))
            {
                return;
            }
            bool isSearched = false;

            if (GameFormulaListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (GameFormulaListView.SelectedItems != null && GameFormulaListView.SelectedItems.Count != 0)
                {
                    startIndex = GameFormulaListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == GameFormulaListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = GameFormulaListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == GameFormulaId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                GameFormulaListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(GameFormulaId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                GameFormulaListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == GameFormulaListView.Items.Count)
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
                searchGameFormula(searchTextBox.Text, false);
            }
        }
    }
}
