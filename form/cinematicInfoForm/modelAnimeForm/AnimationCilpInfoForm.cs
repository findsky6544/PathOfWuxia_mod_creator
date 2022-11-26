using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AnimationCilpInfoForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public AnimationCilpInfoForm()
        {
            InitializeComponent();

            initPlayTypeComboBox();
        }
        public AnimationCilpInfoForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;
            Text = owner.Text + Text;

            if (!isAdd)
            {
                string fields = lvi.Tag.ToString();
                if (!string.IsNullOrEmpty(fields))
                {
                    string[] fieldsList = Utils.getFieldsList(fields);

                    for (int i = 0; i < PlayTypeComboBox.Items.Count; i++)
                    {
                        if (((ComboBoxItem)PlayTypeComboBox.Items[i]).key == fieldsList[0].Trim())
                        {
                            PlayTypeComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                    ClipNameTextBox.Text = fieldsList[1].ToString();
                    ValueNumericUpDown.Text = fieldsList[2].ToString();
                }
            }

            this.isAdd = isAdd;
        }

        public void initPlayTypeComboBox()
        {
            PlayTypeComboBox.DisplayMember = "value";
            PlayTypeComboBox.ValueMember = "key";
            foreach (AnimationPlayType temp in Enum.GetValues(typeof(AnimationPlayType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                PlayTypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (PlayTypeComboBox.Text == "")
            {
                MessageBox.Show("请选择播放类型");
                return;
            }
            if (ClipNameTextBox.Text == "")
            {
                MessageBox.Show("请输入动画名称");
                return;
            }
            if (ValueNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入值");
                return;
            }

            lvi.Text = PlayTypeComboBox.Text;
            lvi.SubItems[1].Text = ClipNameTextBox.Text;
            lvi.SubItems[2].Text = ValueNumericUpDown.Text;

            lvi.Tag = "{ " + ((ComboBoxItem)PlayTypeComboBox.SelectedItem).key + ", " + "\"" + ClipNameTextBox.Text + "\"" + ", " + ValueNumericUpDown.Text + " }";
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
