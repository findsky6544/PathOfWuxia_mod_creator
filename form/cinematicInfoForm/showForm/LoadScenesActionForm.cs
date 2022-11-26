using Heluo.FSM.Main;
using Heluo.Manager;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class LoadScenesActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public LoadScenesActionForm()
        {
            InitializeComponent();

            initLoadTypeComboBox();
            initTimeStageComboBox();
        }
        public LoadScenesActionForm(object obj, bool isAdd) : this()
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


                mapIdTextBox.Text = fieldsList[0].Trim();
                positionTextBox.Text = "{" + fieldsList[1].Trim() + ", " + fieldsList[2].Trim() + ", " + fieldsList[3].Trim() + "}";
                rotationTextBox.Text = "{" + fieldsList[4].Trim() + ", " + fieldsList[5].Trim() + ", " + fieldsList[6].Trim() + "}";
                for (int i = 0; i < loadTypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)loadTypeComboBox.Items[i]).key == fieldsList[7].Trim())
                    {
                        loadTypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                isNextTimeCheckBox.Checked = fieldsList[8] == "True";
                for (int i = 0; i < timeStageComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)timeStageComboBox.Items[i]).key == fieldsList[9].Trim())
                    {
                        timeStageComboBox.SelectedIndex = i;
                        break;
                    }
                }
                orderMusicTextBox.Text = fieldsList[10].Trim();
                orderVolumeNumericUpDown.Text = fieldsList[11].Trim();
            }
        }

        public void initLoadTypeComboBox()
        {
            loadTypeComboBox.DisplayMember = "value";
            loadTypeComboBox.ValueMember = "key";
            foreach (LoadType temp in Enum.GetValues(typeof(LoadType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                loadTypeComboBox.Items.Add(cbi);
            }
        }


        public void initTimeStageComboBox()
        {
            timeStageComboBox.DisplayMember = "value";
            timeStageComboBox.ValueMember = "key";
            foreach (TimeStage temp in Enum.GetValues(typeof(TimeStage)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                timeStageComboBox.Items.Add(cbi);
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (mapIdTextBox.Text == "")
            {
                MessageBox.Show("请输入场景编号");
                return;
            }
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入玩家位置");
                return;
            }
            if (rotationTextBox.Text == "")
            {
                MessageBox.Show("请输入玩家旋转值");
                return;
            }
            if (loadTypeComboBox.Text == "")
            {
                MessageBox.Show("请输入载入类型");
                return;
            }
            if (timeStageComboBox.Text == "")
            {
                MessageBox.Show("请输入切换到哪个阶段");
                return;
            }
            if (orderMusicTextBox.Text == "")
            {
                MessageBox.Show("请输入指定音乐");
                return;
            }
            if (orderVolumeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入指定音乐音量");
                return;
            }


            string tag = "\"LoadScenesAction\" : " + "\"" + mapIdTextBox.Text + "\"" + ", " + positionTextBox.Text + ", " + rotationTextBox.Text + ", " + ((ComboBoxItem)loadTypeComboBox.SelectedItem).key + ", " + isNextTimeCheckBox.Checked + ", " + ((ComboBoxItem)timeStageComboBox.SelectedItem).key + "," + "\"" + orderMusicTextBox.Text + "\"" + ", " + orderVolumeNumericUpDown.Text;
            string text = Text + ":" + "场景:" + DataManager.getMapsName(mapIdTextBox.Text) + " 玩家位置:" + positionTextBox.Text + "  玩家方向:" + rotationTextBox.Text + " 载入类型:" + loadTypeComboBox.Text + " " + (isNextTimeCheckBox.Checked ? "" : "不") + "切换日夜" + " 切换阶段:" + timeStageComboBox.Text + " 音乐:" + orderMusicTextBox.Text + " 音量:" + orderVolumeNumericUpDown.Text;

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

        private void selectMapButton_Click(object sender, EventArgs e)
        {
            SelectMapForm form = new SelectMapForm(this, mapIdTextBox, false);
            form.ShowDialog();
        }
    }
}
