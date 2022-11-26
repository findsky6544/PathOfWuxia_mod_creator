using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcCurrentTransformActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcCurrentTransformActionForm()
        {
            InitializeComponent();
        }
        public SetNpcCurrentTransformActionForm(object obj, bool isAdd) : this()
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

                npcIdTextBox.Text = fieldsList[0].Trim();
                positionTextBox.Text = "{" + fieldsList[1].Trim() + "," + fieldsList[2].Trim() + "," + fieldsList[3].Trim() + "}";
                rotationTextBox.Text = "{" + fieldsList[4].Trim() + "," + fieldsList[5].Trim() + "," + fieldsList[6].Trim() + "}";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入Npc编号");
                return;
            }
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入位置");
                return;
            }
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入旋转值");
                return;
            }

            string tag = "\"SetNpcCurrentTransformAction\" : " + "\"" + npcIdTextBox.Text + "\"" + ", " + positionTextBox.Text + ", " + positionTextBox.Text;
            string text = Text + ":" + DataManager.getNpcsName(npcIdTextBox.Text) + " 位置 " + positionTextBox.Text + " 方向 " + positionTextBox.Text;

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
            SelectNpcForm form = new SelectNpcForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
