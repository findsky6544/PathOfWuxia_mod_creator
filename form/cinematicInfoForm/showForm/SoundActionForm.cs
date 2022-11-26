using System;
using System.Windows.Forms;
using static Heluo.Flow.SoundAction;

namespace 侠之道mod制作器
{
    public partial class SoundActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SoundActionForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public SoundActionForm(object obj, bool isAdd) : this()
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


                for (int i = 0; i < TypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)TypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        TypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                SoundNameTextBox.Text = fieldsList[1].Trim();
                DelayNumericUpDown.Text = fieldsList[2].Trim();
                VolumeNumericUpDown.Text = fieldsList[3].Trim();
            }
        }

        public void initTypeComboBox()
        {
            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";
            foreach (SoundType temp in Enum.GetValues(typeof(SoundType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (TypeComboBox.Text == "")
            {
                MessageBox.Show("请输入音效类型");
                return;
            }
            if (SoundNameTextBox.Text == "")
            {
                MessageBox.Show("请输入音效档名");
                return;
            }
            if (DelayNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入延迟");
                return;
            }
            if (VolumeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入音量大小");
                return;
            }

            string tag = "\"SoundAction\" : " + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + "\"" + SoundNameTextBox.Text + "\"" + ", " + DelayNumericUpDown.Text + ", " + VolumeNumericUpDown.Text;
            string text = Text + ":" + SoundNameTextBox.Text + " 类型:" + TypeComboBox.Text + " 延迟:" + DelayNumericUpDown.Text + " 秒" + " 音量;" + VolumeNumericUpDown.Text;

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
    }
}
