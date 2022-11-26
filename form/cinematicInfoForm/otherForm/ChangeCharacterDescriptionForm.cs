using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ChangeCharacterDescriptionForm : Form
    {
        public bool isAdd;
        public object obj;
        public ChangeCharacterDescriptionForm()
        {
            InitializeComponent();
        }
        public ChangeCharacterDescriptionForm(object obj, bool isAdd) : this()
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
                descriptionTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入Exterior编号");
                return;
            }
            if (descriptionTextBox.Text == "")
            {
                MessageBox.Show("请输入描述");
                return;
            }

            string tag = "\"ChangeCharacterDescription\" : " + "\"" + idTextBox.Text + "\"" + ", " + "\"" + descriptionTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterExteriorName(idTextBox.Text) + " 的描述变更为 " + descriptionTextBox.Text;

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

        private void selectExteriorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
