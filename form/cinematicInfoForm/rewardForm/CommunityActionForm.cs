using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CommunityActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public CommunityActionForm()
        {
            InitializeComponent();
        }
        public CommunityActionForm(object obj, bool isAdd) : this()
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
                isAddCheckBox.Checked = fieldsList[1].Trim() == "True";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }

            string tag = "\"CommunityAction\" : " + "\"" + idTextBox.Text + "\"" + "," + isAddCheckBox.Checked;
            string text = Text + ":" + (isAddCheckBox.Checked ? "增加" : "移除") + " " + DataManager.getNpcsName(idTextBox.Text);

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

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
