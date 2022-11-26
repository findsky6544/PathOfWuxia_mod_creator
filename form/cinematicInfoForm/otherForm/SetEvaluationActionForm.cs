using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetEvaluationActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetEvaluationActionForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public SetEvaluationActionForm(object obj, bool isAdd) : this()
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


                idTextBox.Text = fieldsList[0].Trim();
                for (int i = 0; i < evaluationPointComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)evaluationPointComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        evaluationPointComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public void initTypeComboBox()
        {
            evaluationPointComboBox.DisplayMember = "value";
            evaluationPointComboBox.ValueMember = "key";
            foreach (EvaluationPoint temp in Enum.GetValues(typeof(EvaluationPoint)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                evaluationPointComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入评价编号");
                return;
            }
            if (evaluationPointComboBox.Text == "")
            {
                MessageBox.Show("请输入评价点");
                return;
            }


            string tag = "\"SetEvaluationAction\" : " + "\"" + idTextBox.Text + "\"" + ", " + ((ComboBoxItem)evaluationPointComboBox.SelectedItem).key;
            string text = Text + ":" + DataManager.getEvaluationName(idTextBox.Text) + " " + evaluationPointComboBox.Text + " 评价点 " + DataManager.getEvaluationPointInfo(idTextBox.Text, (EvaluationPoint)Enum.Parse(typeof(EvaluationPoint), ((ComboBoxItem)evaluationPointComboBox.SelectedItem).key)) + " 通过";

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


        private void selectExteriorButton_Click(object sender, EventArgs e)
        {
            SelectEvaluationForm form = new SelectEvaluationForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
