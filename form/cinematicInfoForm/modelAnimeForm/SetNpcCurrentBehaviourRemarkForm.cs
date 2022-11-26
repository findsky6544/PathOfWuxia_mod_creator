using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcCurrentBehaviourRemarkForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcCurrentBehaviourRemarkForm()
        {
            InitializeComponent();
        }
        public SetNpcCurrentBehaviourRemarkForm(object obj, bool isAdd) : this()
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

                characterBehaviourIdTextBox.Text = fieldsList[0].Trim();
                remarksTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (characterBehaviourIdTextBox.Text == "")
            {
                MessageBox.Show("请输入行为编号");
                return;
            }
            if (remarksTextBox.Text == "")
            {
                MessageBox.Show("请输入互动名称");
                return;
            }

            string tag = "\"SetNpcCurrentBehaviourRemark\" : " + "\"" + characterBehaviourIdTextBox.Text + "\"" + ", " + "\"" + remarksTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterBehaviourRemark(characterBehaviourIdTextBox.Text) + " 的行为互动名称变为 " + remarksTextBox.Text;

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

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectCharacterBehaviourForm form = new SelectCharacterBehaviourForm(this, characterBehaviourIdTextBox, false);
            form.ShowDialog();
        }
    }
}
