using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class OpenUIAdjustmentActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public OpenUIAdjustmentActionForm()
        {
            InitializeComponent();
        }
        public OpenUIAdjustmentActionForm(object obj, bool isAdd) : this()
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

                adjustmentIdTextBox.Text = fieldsList[0].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (adjustmentIdTextBox.Text == "")
            {
                MessageBox.Show("请输入整备编号");
                return;
            }

            string tag = "\"OpenUIAdjustmentAction\" : \"" + adjustmentIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getAdjustmentName(adjustmentIdTextBox.Text);

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

        private void selectAdjustmentButton_Click(object sender, EventArgs e)
        {
            SelectAdjustmentForm selectAdjustmentForm = new SelectAdjustmentForm(this, adjustmentIdTextBox, false);
            selectAdjustmentForm.ShowDialog();
        }
    }
}
