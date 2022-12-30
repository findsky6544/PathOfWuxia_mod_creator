using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MantraEffectDescriptionForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public string type;
        public MantraEffectDescriptionForm()
        {
            InitializeComponent();
        }
        public MantraEffectDescriptionForm(ListViewItem lvi, bool isAdd, Form owner,string type) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            Owner = owner;
            Text = owner.Text + Text;
            this.type = type;

            string fields = "";
            fields = lvi.Tag.ToString();

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                MartraLevelNumericUpDown.Text = fieldsList[0].Trim();
                EffectDescriptionTextBox.Text = fieldsList[1].Trim();
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (MartraLevelNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入内功需求等级");
                return;
            }
            if (EffectDescriptionTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入内功效果叙述");
                return;
            }
            if(type == "RunEffectDescription" && !EffectDescriptionTextBox.Text.Contains("："))
            {
                MessageBox.Show("内功效果叙述需包含一个中文冒号");
                return;
            }

            lvi.Tag = "(" + MartraLevelNumericUpDown.Text + ", " + EffectDescriptionTextBox.Text + ")";
            lvi.Text = MartraLevelNumericUpDown.Text;
            lvi.SubItems[1].Text = EffectDescriptionTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
