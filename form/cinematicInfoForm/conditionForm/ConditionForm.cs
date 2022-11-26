using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ConditionForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public string[] fieldsList;

        public virtual void InitComponent()
        {
        }
        public ConditionForm()
        {
            InitializeComponent();

            InitComponent();
        }

        public virtual void initFields()
        {

        }

        public ConditionForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                initFields();
            }

            this.isAdd = isAdd;
        }

        public virtual bool checkMustInput()
        {
            return true;
        }

        public virtual void setTextAndTag()
        {

        }

        public void okButton_Click(object sender, EventArgs e)
        {
            checkMustInput();

            setTextAndTag();

            DialogResult = DialogResult.OK;

            Close();
        }

        public void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
