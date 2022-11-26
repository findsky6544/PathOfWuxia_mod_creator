using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ReplacePlayerSpecialForm : Form
    {
        public bool isAdd;
        public object obj;
        public ReplacePlayerSpecialForm()
        {
            InitializeComponent();
        }
        public ReplacePlayerSpecialForm(object obj, bool isAdd) : this()
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
                NewIDTextBox.Text = fieldsList[0].Trim();
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (NewIDTextBox.Text == "")
            {
                MessageBox.Show("请输入新的技能编号");
                return;
            }

            string tag = "\"ReplacePlayerSpecial\" : " + "\"" + NewIDTextBox.Text + "\"";
            string text = Text + ":" + "特技取代成 " + DataManager.getSkillsName(NewIDTextBox.Text);

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

        private void selectNewSpecialButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, NewIDTextBox, false, SelectSkillForm.selectSkillType.special);
            form.ShowDialog();
        }
    }
}
