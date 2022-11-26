using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcEquipForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcEquipForm()
        {
            InitializeComponent();

        }
        public SetNpcEquipForm(object obj, bool isAdd) : this()
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
                propsIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }
            if (propsIdTextBox.Text == "")
            {
                MessageBox.Show("请输入道具编号");
                return;
            }

            string tag = "\"SetNpcEquip\" : " + "\"" + npcIdTextBox.Text + "\"" + ", " + "\"" + propsIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getNpcsName(npcIdTextBox.Text) + " 使用 " + DataManager.getPropssName(propsIdTextBox.Text);

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
            SelectPropsForm form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
