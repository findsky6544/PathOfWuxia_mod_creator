using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckMapIdForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckMapIdForm()
        {
            InitializeComponent();
        }
        public CheckMapIdForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                mapIdTextBox.Text = fieldsList[0].Trim();
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (mapIdTextBox.Text == "")
            {
                MessageBox.Show("请输入地图编号");
                return;
            }

            currentNode.Tag = "\"CheckMapId\" : \"" + mapIdTextBox.Text + "\"";
            currentNode.Text = Text + "符合 " + DataManager.getMapsName(mapIdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMapButton_Click(object sender, EventArgs e)
        {
            SelectMapForm form = new SelectMapForm(this, mapIdTextBox, true);
            form.ShowDialog();
        }
    }
}
