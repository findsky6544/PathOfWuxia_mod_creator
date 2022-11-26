using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MantraBufferEffectForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public MantraBufferEffectForm()
        {
            InitializeComponent();
        }
        public MantraBufferEffectForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            Owner = owner;
            Text = owner.Text + Text;

            string fields = "";
            fields = lvi.Tag.ToString();

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                MartraLevelNumericUpDown.Text = fieldsList[0].Trim();
                BufferIdTextBox.Text = fieldsList[1].Trim();
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (MartraLevelNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入内功需求等级");
                return;
            }
            if (BufferIdTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入buffer编号");
                return;
            }


            lvi.Tag = "(" + MartraLevelNumericUpDown.Text + ", " + BufferIdTextBox.Text + ")";
            lvi.Text = MartraLevelNumericUpDown.Text;
            lvi.SubItems[1].Text = DataManager.getBuffersName(BufferIdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, BufferIdTextBox, false);
            form.ShowDialog();
        }
    }
}
