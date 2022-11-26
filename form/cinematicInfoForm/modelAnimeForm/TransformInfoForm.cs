using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TransformInfoForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public TransformInfoForm()
        {
            InitializeComponent();
        }
        public TransformInfoForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            Text = owner.Text + Text;
            this.lvi = lvi;

            if (!isAdd)
            {
                string fields = lvi.Tag.ToString();
                if (!string.IsNullOrEmpty(fields))
                {
                    string[] fieldsList = Utils.getFieldsList(fields);

                    npcIdTextBox.Text = fieldsList[0].Trim();
                    positionTextBox.Text = "{" + fieldsList[1] + "," + fieldsList[2] + "," + fieldsList[3] + "}";
                    rotationTextBox.Text = "{" + fieldsList[4] + "," + fieldsList[5] + "," + fieldsList[6] + "}";
                }
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入位置");
                return;
            }
            if (rotationTextBox.Text == "")
            {
                MessageBox.Show("请输入旋转");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入npc编号");
                return;
            }

            lvi.Text = DataManager.getNpcsName(npcIdTextBox.Text);
            lvi.SubItems[1].Text = positionTextBox.Text;
            lvi.SubItems[2].Text = rotationTextBox.Text;

            lvi.Tag = "{ \"" + npcIdTextBox.Text + "\", " + positionTextBox.Text + ", " + rotationTextBox.Text + " }";

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
