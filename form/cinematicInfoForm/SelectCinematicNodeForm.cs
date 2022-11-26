using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectCinematicNodeForm : Form
    {
        public NumericUpDown textBox;
        public SelectCinematicNodeForm()
        {
            InitializeComponent();
        }
        public SelectCinematicNodeForm(Form owner, NumericUpDown textBox) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            initCinematicListView();
        }

        public void initCinematicListView()
        {
            Form form = Owner;
            while (!(form is CinematicInfoForm))
            {
                form = form.Owner;
            }

            CinematicInfoForm form1 = form as CinematicInfoForm;

            List<ListViewItem> lvis = new List<ListViewItem>();

            for (int i = 0; i < form1.getCinematicListView().Items.Count; i++)
            {
                ListViewItem lvi = form1.getCinematicListView().Items[i];
                if (!lvi.Tag.ToString().Contains("BattleEventNode"))
                {
                    lvis.Add((ListViewItem)lvi.Clone());
                }
            }

            cinematicListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectCinematicNodeForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true);
            cinematicListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = cinematicListView.SelectedItems[0].Text;
            Close();
        }

        private void cinematicListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = cinematicListView.SelectedItems[0].Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer(searchTextBox.Text, false);
        }

        public void searchBuffer(string bufferId, bool isEqual)
        {
            if (string.IsNullOrEmpty(bufferId))
            {
                return;
            }
            bool isSearched = false;

            if (cinematicListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (cinematicListView.SelectedItems != null && cinematicListView.SelectedItems.Count != 0)
                {
                    startIndex = cinematicListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == cinematicListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = cinematicListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                cinematicListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                cinematicListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == cinematicListView.Items.Count)
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
                searchBuffer(searchTextBox.Text, false);
            }
        }
    }
}
