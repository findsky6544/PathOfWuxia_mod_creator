using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ReplacePlayerSkillForm : Form
    {
        public bool isAdd;
        public object obj;
        public ReplacePlayerSkillForm()
        {
            InitializeComponent();
        }
        public ReplacePlayerSkillForm(object obj, bool isAdd) : this()
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
                OldIDTextBox.Text = fieldsList[0].Trim();
                NewIDTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (OldIDTextBox.Text == "")
            {
                MessageBox.Show("请输入旧的技能编号");
                return;
            }
            if (NewIDTextBox.Text == "")
            {
                MessageBox.Show("请输入新的技能编号");
                return;
            }

            string tag = "\"ReplacePlayerSkill\" : " + "\"" + OldIDTextBox.Text + "\"" + ", " + "\"" + NewIDTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getSkillsName(OldIDTextBox.Text) + " 取代成 " + DataManager.getSkillsName(NewIDTextBox.Text);

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

        private void selectNewSkillButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, NewIDTextBox, false, SelectSkillForm.selectSkillType.normal);
            form.ShowDialog();
        }

        private void selectOldSkillButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, OldIDTextBox, false, SelectSkillForm.selectSkillType.normal);
            form.ShowDialog();
        }
    }
}
