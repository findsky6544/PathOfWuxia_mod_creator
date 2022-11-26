using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class LearnForgeActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public LearnForgeActionForm()
        {
            InitializeComponent();
        }
        public LearnForgeActionForm(object obj, bool isAdd) : this()
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

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入锻造编号");
                return;
            }

            string tag = "\"LearnForgeAction\" : " + "\"" + idTextBox.Text + "\"";
            string text = Text + ":" + " " + DataManager.getForgesRemark(idTextBox.Text);

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

        private void selectForgeButton_Click(object sender, EventArgs e)
        {
            SelectForgeForm form = new SelectForgeForm(this, idTextBox, true);
            form.ShowDialog();
        }
    }
}
