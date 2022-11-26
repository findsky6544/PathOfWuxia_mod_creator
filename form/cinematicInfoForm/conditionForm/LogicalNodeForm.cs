using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class LogicalNodeForm : Form
    {
        public bool isAdd;
        public TreeNode node;
        public LogicalNodeForm()
        {
            InitializeComponent();
            initScheduleTiming();
        }
        public LogicalNodeForm(TreeNode node, bool isAdd) : this()
        {
            this.node = node;

            string fields = node.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < opComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)opComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        opComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;

            if (isAdd)
            {
                Text = "添加复数逻辑判断";
            }
            else
            {
                Text = "修改复数逻辑判断";
            }

        }


        public void initScheduleTiming()
        {
            opComboBox.DisplayMember = "value";
            opComboBox.ValueMember = "key";
            foreach (LogicalOperator temp in Enum.GetValues(typeof(LogicalOperator)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                opComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (opComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择条件");
                return;
            }


            node.Tag = "\"LogicalNode\" : $ ," + ((ComboBoxItem)opComboBox.SelectedItem).key;
            node.Text = "复数逻辑判断:" + opComboBox.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
