using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoMantraForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoMantraForm()
        {
            InitializeComponent();
        }
        public CharacterInfoMantraForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            Owner = owner;
            Text = owner.Text + Text;

            string fields = "";
            fields = lvi.Tag.ToString();

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                IdTextBox.Text = fieldsList[0].Trim();
                LevelNumericUpDown.Text = fieldsList[1].Trim();
                isWorkCheckBox.Checked = fieldsList[2].Trim() == "True";
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (IdTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入心法编号");
                return;
            }
            if (LevelNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入目前等级");
                return;
            }


            lvi.Tag = "(" + IdTextBox.Text + "," + LevelNumericUpDown.Text + "," + isWorkCheckBox.Checked + ")";
            lvi.Text = DataManager.getMantraName(IdTextBox.Text);
            lvi.SubItems[1].Text = LevelNumericUpDown.Text;
            lvi.SubItems[2].Text = isWorkCheckBox.Checked.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, IdTextBox, false);
            form.ShowDialog();
        }
    }
}
