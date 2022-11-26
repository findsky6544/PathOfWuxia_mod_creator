using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectNurturanceForm : Form
    {
        public TextBox textBox;

        public bool isMultiSelect = false;
        public SelectNurturanceForm()
        {
            InitializeComponent();
        }
        public SelectNurturanceForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                NurturanceListView.CheckBoxes = true;
            }

            initNurturanceListView();
        }

        public void initNurturanceListView()
        {
            if (DataManager.allNurturanceLvis.Count == 0)
            {
                DataManager.allNurturanceLvis = DataManager.createNurturanceLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allNurturanceLvis)
            {
                lvis.Add((ListViewItem)kv.Value.Clone());
            }

            NurturanceListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNurturanceForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] NurturancesList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < NurturancesList.Length; i++)
                {
                    for (int j = 0; j < NurturanceListView.Items.Count; j++)
                    {
                        if (NurturancesList[i].Trim() == NurturanceListView.Items[j].SubItems[1].Text.Trim())
                        {
                            NurturanceListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                NurturanceListView.Items[j].Selected = true;
                                NurturanceListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchNurturance(textBox.Text, true);
            }

            NurturanceListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string NurturancesIds = "";
                for (int i = 0; i < NurturanceListView.Items.Count; i++)
                {
                    if (NurturanceListView.Items[i].Checked)
                    {
                        NurturancesIds += NurturanceListView.Items[i].SubItems[1].Text + ",";
                    }
                }
                if (NurturancesIds.Length > 0)
                {
                    NurturancesIds = NurturancesIds.Substring(0, NurturancesIds.Length - 1);
                }
                textBox.Text = NurturancesIds;
            }
            else
            {
                textBox.Text = NurturanceListView.SelectedItems[0].SubItems[1].Text;
            }
            Close();
        }

        private void NurturanceListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                NurturanceListView.SelectedItems[0].Checked = !NurturanceListView.SelectedItems[1].Checked;
            }
            else
            {
                textBox.Text = NurturanceListView.SelectedItems[0].SubItems[1].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchNurturance(searchTextBox.Text, false);
        }

        public void searchNurturance(string NurturanceId, bool isEqual)
        {
            if (string.IsNullOrEmpty(NurturanceId))
            {
                return;
            }
            bool isSearched = false;

            if (NurturanceListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (NurturanceListView.SelectedItems != null && NurturanceListView.SelectedItems.Count != 0)
                {
                    startIndex = NurturanceListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == NurturanceListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = NurturanceListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == NurturanceId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                NurturanceListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(NurturanceId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                NurturanceListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == NurturanceListView.Items.Count)
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
                searchNurturance(searchTextBox.Text, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string cinematicId = NurturanceListView.SelectedItems[0].SubItems[13].Text;
            if (string.IsNullOrEmpty(cinematicId))
            {
                readCinematicToolStripMenuItem.Enabled = false;
            }
            else
            {
                readCinematicToolStripMenuItem.Enabled = true;
            }
        }

        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CinematicInfoForm form = new CinematicInfoForm();
            form.cinematicId = NurturanceListView.SelectedItems[0].SubItems[13].Text;

            form.readCinematicInfo();
            form.idTextBox.Enabled = false;
            form.nameTextBox.Enabled = false;
            form.entryIndexNumericUpDown.Enabled = false;
            form.saveButton.Enabled = false;

            form.Show();
        }
    }
}
