using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class DropPropsForm : Form
    {
        public bool isAdd;
        public DropPropsForm()
        {
            InitializeComponent();
        }
        public DropPropsForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = "";
            if (lvi.Tag != null)
            {
                fields = lvi.Tag.ToString();
            }

            if (!isAdd && !string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                propsIdTextBox.Text = fieldsList[0].Trim();
                valueNumericUpDown.Text = lvi.SubItems[1].Text;
            }


            this.isAdd = isAdd;

            Text = owner.Text + Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (propsIdTextBox.Text == "")
            {
                MessageBox.Show("请输入道具编号");
                return;
            }
            if (valueNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入数量");
                return;
            }
            ListView propsListView = null;

            BattleAreaInfoForm infoForm = (BattleAreaInfoForm)Owner;
            propsListView = infoForm.getDropPropsListView();

            ListViewItem lvi = null;
            if (isAdd)
            {
                lvi = new ListViewItem();
                lvi.SubItems.Add("");
                propsListView.Items.Add(lvi);
            }
            else
            {
                lvi = propsListView.SelectedItems[0];
            }

            lvi.Tag = "(" + propsIdTextBox.Text + "," + valueNumericUpDown.Text + ")";
            lvi.Text = DataManager.getPropssName(propsIdTextBox.Text);
            lvi.SubItems[1].Text = valueNumericUpDown.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }
    }
}
