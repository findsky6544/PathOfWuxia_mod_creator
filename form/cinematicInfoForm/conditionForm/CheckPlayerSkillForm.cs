using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerSkillForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerSkillForm()
        {
            InitializeComponent();
        }
        public CheckPlayerSkillForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                Skill_IdTextBox.Text = fieldsList[0].Trim();
                isContainsCheckBox.Checked = fieldsList[1].Trim() == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Skill_IdTextBox.Text == "")
            {
                MessageBox.Show("请输入技能编号");
                return;
            }

            currentNode.Tag = "\"CheckPlayerSkill\" : \"" + Skill_IdTextBox.Text + "\", " + isContainsCheckBox.Checked;
            currentNode.Text = Text + ":" + (isContainsCheckBox.Checked ? "具备" : "不具备") + "技能 " + DataManager.getSkillsName(Skill_IdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, Skill_IdTextBox, false, SelectSkillForm.selectSkillType.all);
            form.ShowDialog();
        }
    }
}
