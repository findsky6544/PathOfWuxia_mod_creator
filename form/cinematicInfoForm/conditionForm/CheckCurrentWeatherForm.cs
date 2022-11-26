using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckCurrentWeatherForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckCurrentWeatherForm()
        {
            InitializeComponent();

            initWeatherComboBox();
        }
        public CheckCurrentWeatherForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < timeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)timeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        timeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initWeatherComboBox()
        {
            timeComboBox.DisplayMember = "value";
            timeComboBox.ValueMember = "key";
            foreach (WeatherType temp in Enum.GetValues(typeof(WeatherType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                timeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (timeComboBox.Text == "")
            {
                MessageBox.Show("请选择时间");
                return;
            }

            currentNode.Tag = "\"CheckCurrentWeather\" : " + ((ComboBoxItem)timeComboBox.SelectedItem).key;
            currentNode.Text = Text + ":" + "符合 " + timeComboBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
