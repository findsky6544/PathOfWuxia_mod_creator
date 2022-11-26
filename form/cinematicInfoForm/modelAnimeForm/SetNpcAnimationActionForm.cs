using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcAnimationActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcAnimationActionForm()
        {
            InitializeComponent();
        }
        public SetNpcAnimationActionForm(object obj, bool isAdd) : this()
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
                animationTextBox.Text = fieldsList[1].Trim();
                isTurnCheckBox.Checked = fieldsList[2] == "True";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (characterBehaviourIdTextBox.Text == "")
            {
                MessageBox.Show("请输入CharacterBehaviour编号");
                return;
            }
            if (animationTextBox.Text == "")
            {
                MessageBox.Show("请输入动画名称");
                return;
            }

            string tag = "\"SetNpcAnimationAction\" : " + "\"" + characterBehaviourIdTextBox.Text + "\"" + ", " + "\"" + animationTextBox.Text + "\"" + "," + isTurnCheckBox.Checked;
            string text = Text + ":" + DataManager.getCharacterBehaviourRemark(characterBehaviourIdTextBox.Text) + " 的动画变为 " + animationTextBox.Text + " 对话时" + (isTurnCheckBox.Checked ? "" : "不") + "转身";

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
