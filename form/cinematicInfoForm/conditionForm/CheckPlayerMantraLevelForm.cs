using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerMantraLevelForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerMantraLevelForm()
        {
            InitializeComponent();

            initOpComboBox();
        }
        public CheckPlayerMantraLevelForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < opComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)opComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        opComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
                mantra_IdTextBox.Text = fieldsList[2].Trim();
            }

            this.isAdd = isAdd;
        }

        public void initOpComboBox()
        {
            opComboBox.DisplayMember = "value";
            opComboBox.ValueMember = "key";
            foreach (Operator temp in Enum.GetValues(typeof(Operator)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                opComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (mantra_IdTextBox.Text == "")
            {
                MessageBox.Show("请输入心法编号");
                return;
            }
            if (opComboBox.Text == "")
            {
                MessageBox.Show("请选择比较方式");
                return;
            }
            if (opComboBox.Text == "")
            {
                MessageBox.Show("请输入值");
                return;
            }

            currentNode.Tag = "\"CheckPlayerMantraLevel\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Text + ", \"" + mantra_IdTextBox.Text + "\"";
            currentNode.Text = Text + ":" + DataManager.getMantraName(mantra_IdTextBox.Text) + " 的等级 " + opComboBox.Text + " " + valueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, mantra_IdTextBox, false);
            form.ShowDialog();
        }
    }
}
