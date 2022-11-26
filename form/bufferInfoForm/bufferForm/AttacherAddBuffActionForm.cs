using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttacherAddBuffActionForm : Form
    {
        public bool isAdd;
        public AttacherAddBuffActionForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public AttacherAddBuffActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                bufferIdTextBox.Text = fieldsList[0];

                countNumericUpDown.Value = int.Parse(fieldsList[1]);

                for (int i = 0; i < typeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)typeComboBox.Items[i]).key == fieldsList[2].Trim())
                    {
                        typeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initTypeComboBox()
        {
            typeComboBox.DisplayMember = "value";
            typeComboBox.ValueMember = "key";
            foreach (BufferType temp in Enum.GetValues(typeof(BufferType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                typeComboBox.Items.Add(cbi);
            }
        }

        public TextBox getBufferIdTextBox()
        {
            return bufferIdTextBox;
        }

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, bufferIdTextBox, false);
            form.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (bufferIdTextBox.Text == "")
            {
                MessageBox.Show("请选择一个buffer");
                return;
            }
            if (countNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入添加次数");
                return;
            }
            if (typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择添加类型");
                return;
            }


            BufferInfoForm bufferInfoForm = (BufferInfoForm)Owner;
            TreeView bufferNodeTreeView = bufferInfoForm.getBufferNodeTreeView();

            TreeNode currentNode = bufferNodeTreeView.SelectedNode;

            if (isAdd)
            {
                string tag = currentNode.Tag.ToString();
                while (!tag.Contains("BufferEventNode") && !tag.Contains("BufferPriorityNode") && !tag.Contains("BufferSequenceNode"))
                {
                    currentNode = currentNode.Parent;
                    tag = currentNode.Tag.ToString();
                }

                TreeNode addNode = currentNode.Nodes.Add("");
                bufferNodeTreeView.SelectedNode = addNode;

                currentNode = addNode;
            }

            currentNode.Tag = "\"AttacherAddBuffAction\" : \"" + bufferIdTextBox.Text + "\", " + countNumericUpDown.Value + ", " + ((ComboBoxItem)typeComboBox.SelectedItem).key;
            currentNode.Text = "赋予自身Buff: " + typeComboBox.Text + " " + DataManager.getBuffersName(bufferIdTextBox.Text) + " " + countNumericUpDown.Value + " 次";
            Close();
        }

        /*public string getBufferName(string bufferid)
        {
            List<ListViewItem> lvis = BufferTabControlUserControl.lvis;

            for (int i = 0; i < lvis.Count; i++)
            {
                if (bufferid == lvis[i].SubItems[1].Text)
                {
                    return lvis[i].SubItems[2].Text;
                }
            }
            return "";
        }*/

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
