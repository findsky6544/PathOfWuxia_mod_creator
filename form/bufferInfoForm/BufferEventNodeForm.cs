using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferEventNodeForm : Form
    {
        public bool isAdd;
        public BufferEventNodeForm()
        {
            InitializeComponent();
            initBufferTiming();
        }
        public BufferEventNodeForm(string bufferTiming, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            bufferTimingComboBox.Text = bufferTiming.Split(':')[0].Trim();

            this.isAdd = isAdd;

            if (isAdd)
            {
                Text = "添加新时点";
            }
            else
            {
                Text = "修改时点";
            }
        }


        public void initBufferTiming()
        {
            bufferTimingComboBox.DisplayMember = "value";
            bufferTimingComboBox.ValueMember = "key";
            foreach (BufferTiming temp in Enum.GetValues(typeof(BufferTiming)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                bufferTimingComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (bufferTimingComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择时点");
                return;
            }
            BufferInfoForm bufferInfoForm = (BufferInfoForm)Owner;
            TreeView bufferNodeTreeView = bufferInfoForm.getBufferNodeTreeView();
            TreeNode bufferEventNode = null;
            if (Text == "添加新时点")
            {
                TreeNode rootNode = bufferNodeTreeView.Nodes[0];
                bufferEventNode = rootNode.Nodes.Add(bufferTimingComboBox.Text);
            }
            else
            {
                bufferEventNode = bufferNodeTreeView.SelectedNode;
            }
            bufferEventNode.Tag = "\"BufferEventNode\" : " + ((ComboBoxItem)bufferTimingComboBox.SelectedItem).key + ", ";
            bufferEventNode.Text = bufferTimingComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
