using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class LearnRefiningActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public LearnRefiningActionForm()
        {
            InitializeComponent();
        }
        public LearnRefiningActionForm(object obj, bool isAdd) : this()
        {
            this.obj = obj;
            this.isAdd = isAdd;

            string fields = "";
            if (obj is ListViewItem)
            {
                fields = (obj as ListViewItem).Tag.ToString().Split(':')[1];
            }
            else
            {
                fields = (obj as TreeNode).Tag.ToString().Split(':')[1];
            }

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                idTextBox.Text = fieldsList[0].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入炼药编号");
                return;
            }

            string tag = "\"LearnRefiningAction\" : " + "\"" + idTextBox.Text + "\"";
            string text = Text + ":" + " " + DataManager.getAlchemysRemark(idTextBox.Text);

            if (obj is ListViewItem)
            {
                ListViewItem lvi = obj as ListViewItem;
                lvi.Tag = tag;
                lvi.SubItems[1].Text = text;
            }
            else
            {
                TreeNode node = obj as TreeNode;
                node.Tag = tag;
                node.Text = text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectAdjustmentButton_Click(object sender, EventArgs e)
        {
            SelectAlchemyForm form = new SelectAlchemyForm(this, idTextBox, true);
            form.ShowDialog();
        }
    }
}
