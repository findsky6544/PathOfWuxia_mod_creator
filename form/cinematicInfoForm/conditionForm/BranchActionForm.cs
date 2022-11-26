using Heluo.Data.Converter;
using Heluo.Flow;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BranchActionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        BranchAction node = null;
        public BranchActionForm()
        {
            InitializeComponent();
        }

        public TreeView getBranchActionTreeView()
        {
            return branchActionTreeView;
        }

        public BranchActionForm(ListViewItem lvi, bool isAdd, Form Owner) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            this.Owner = Owner;


            TreeNode rootNode = branchActionTreeView.Nodes.Add("根节点");
            rootNode.Tag = "rootNode";

            if (!isAdd)
            {
                string tagStr = "{" + lvi.Tag.ToString() + "}";
                tagStr = tagStr.Replace("\"", "\\\"");
                tagStr = "{ \"EntryIndex\": 0,\"Nodes\": [ {\"Node\": \"" + tagStr + " \",\"Next\": -1,\"Prallel\": -1}],\"Name\": \"\"}";
                ScheduleGraph.Bundle tempCimenatic = JsonConvert.DeserializeObject<ScheduleGraph.Bundle>(tagStr, new JsonConverter[] { new OutputNodeJsonConverter() });
                node = (BranchAction)tempCimenatic.Nodes[0].Node;

                Utils.readBaseFlowGraphTree(rootNode, node.conditionNode);
            }

            branchActionTreeView.ExpandAll();

            trueNodeIndexNumericUpDown.Text = lvi.SubItems[4].Text;
            falseNodeIndexNumericUpDown.Text = lvi.SubItems[5].Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (branchActionTreeView.Nodes[0].Nodes.Count == 0)
            {
                MessageBox.Show("请至少添加一个节点");
                return;
            }
            if (string.IsNullOrEmpty(trueNodeIndexNumericUpDown.Text))
            {
                MessageBox.Show("请选择成功节点");
                return;
            }
            if (string.IsNullOrEmpty(falseNodeIndexNumericUpDown.Text))
            {
                MessageBox.Show("请选择失败节点");
                return;
            }

            CinematicInfoForm cinematicInfoForm = (CinematicInfoForm)Owner;
            ListView cinematicListView = cinematicInfoForm.getCinematicListView();
            ListViewItem lvi = null;
            if (isAdd)
            {
                lvi = new ListViewItem();
                lvi.Text = cinematicListView.Items.Count.ToString();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("-1");
                lvi.SubItems.Add("-1");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                cinematicListView.Items.Add(lvi);
            }
            else
            {
                lvi = cinematicListView.SelectedItems[0];
            }
            lvi.SubItems[1].Text = Text + ":" + getTextStr(branchActionTreeView.Nodes[0]);
            lvi.SubItems[4].Text = trueNodeIndexNumericUpDown.Text;
            lvi.SubItems[5].Text = falseNodeIndexNumericUpDown.Text;


            lvi.Tag = "\"BranchAction\" : {" + Utils.BaseFlowGraphTagToStr(branchActionTreeView.Nodes[0]) + "}, " + trueNodeIndexNumericUpDown.Text + ", " + falseNodeIndexNumericUpDown.Text;

            lvi.Selected = true;
            cinematicListView.EnsureVisible(lvi.Index);

            DialogResult = DialogResult.OK;

            Close();
        }

        private string getTextStr(TreeNode actionNode)
        {
            string TextStr = "";

            if (actionNode.Tag.ToString() == "rootNode")
            {
                if (actionNode.Nodes.Count != 0)
                {
                    TextStr = getTextStr(actionNode.Nodes[0]);
                }
            }
            else if (actionNode.Tag.ToString().Contains("LogicalNode"))
            {
                string op = actionNode.Text.ToString().Split(':')[1].Trim();
                string childTagStr = "(";
                for (int i = 0; i < actionNode.Nodes.Count; i++)
                {
                    childTagStr += getTextStr(actionNode.Nodes[i]) + " " + (op == "And" ? "且 " : "或 ");
                }
                if (childTagStr.Length > 1)
                {
                    childTagStr = childTagStr.Substring(0, childTagStr.Length - 2);
                }
                childTagStr += ")";
                TextStr += childTagStr;
            }
            else
            {
                return actionNode.Text.ToString();
            }

            return TextStr;
        }

        private void selectTrueNodeButton_Click(object sender, EventArgs e)
        {
            SelectCinematicNodeForm form = new SelectCinematicNodeForm(this, trueNodeIndexNumericUpDown);
            form.ShowDialog();
        }

        private void selectFalseNodeButton_Click(object sender, EventArgs e)
        {
            SelectCinematicNodeForm form = new SelectCinematicNodeForm(this, falseNodeIndexNumericUpDown);
            form.ShowDialog();
        }

        private void AddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(branchActionTreeView);
        }

        private void editNodeButton_Click(object sender, EventArgs e)
        {
            editOpenBranchActionNodeInfoForm();
        }

        private void deleteNodeButton_Click(object sender, EventArgs e)
        {
            if (branchActionTreeView.SelectedNode != null)
            {
                if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    branchActionTreeView.Nodes.Remove(branchActionTreeView.SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个节点");
            }
        }

        public void editOpenBranchActionNodeInfoForm()
        {
            try
            {
                TreeNode treeNode = branchActionTreeView.SelectedNode;
                if (treeNode != null && treeNode.Tag != null)
                {
                    string tag = treeNode.Tag.ToString().Split(':')[0];
                    if (tag == "rootNode")
                    {
                        MessageBox.Show("该节点无需修改");
                        return;
                    }
                    tag = tag.Substring(1, tag.Length - 2);
                    if (tag.EndsWith("\""))
                    {
                        tag = tag.Substring(0, tag.Length - 1);
                    }
                    if (tag == "LogicalNode")
                    {
                        LogicalNodeForm form = new LogicalNodeForm(treeNode, false);
                        form.ShowDialog();
                    }
                    else
                    {
                        string className = "侠之道mod制作器." + tag + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { treeNode, false });

                            MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                            method.Invoke(obj, new object[] { });
                        }
                        else
                        {
                            MessageBox.Show("---未完成---");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addCinematicNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode currentNode = branchActionTreeView.SelectedNode;
                if (currentNode == null)
                {
                    MessageBox.Show("请选择要添加至的节点");
                    return;
                }

                while (!currentNode.Tag.ToString().Contains("MultiAction") && !currentNode.Tag.ToString().Contains("LogicalNode") && currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                }

                if (currentNode.Text == "根节点")
                {
                    MessageBox.Show("不可添加至根节点");
                    return;
                }

                if (CinematicNodeConditionListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要添加的节点");
                    return;
                }

                bool isAdd = false;
                TreeNode node = new TreeNode(CinematicNodeConditionListView.SelectedItems[0].Text);
                node.Tag = ":";

                string className = "侠之道mod制作器." + CinematicNodeConditionListView.SelectedItems[0].SubItems[1].Text + "Form";
                Type clazz = Type.GetType(className);

                if (clazz != null)
                {
                    object obj = Activator.CreateInstance(clazz, new object[] { node, true });

                    MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                    if ((DialogResult)method.Invoke(obj, new object[] { }) == DialogResult.OK)
                    {
                        isAdd = true;
                    }
                }
                else
                {
                    MessageBox.Show("---未完成---");
                }

                if (isAdd)
                {
                    currentNode.Nodes.Add(node);
                    currentNode.Expand();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CinematicNodeConditionListView_DoubleClick(object sender, EventArgs e)
        {
            addCinematicNodeButton_Click(sender, e);
        }
    }
}
