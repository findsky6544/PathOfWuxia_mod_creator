using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ShopPeriodForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public ShopPeriodForm()
        {
            InitializeComponent();
        }
        public ShopPeriodForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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

                OpenRoundNumericUpDown.Text = fieldsList[0];
                CloseRoundNumericUpDown.Text = fieldsList[1];
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (OpenRoundNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入开放回合");
                return;
            }
            if (CloseRoundNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入关闭回合");
                return;
            }

            lvi.Tag = "(" + OpenRoundNumericUpDown.Value + "," + CloseRoundNumericUpDown.Value + ")";

            lvi.Text = DataManager.getRoundStr(int.Parse(OpenRoundNumericUpDown.Value.ToString()));
            lvi.SubItems[1].Text = DataManager.getRoundStr(int.Parse(CloseRoundNumericUpDown.Value.ToString()));

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
