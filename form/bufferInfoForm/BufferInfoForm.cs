using Heluo.Data;
using Heluo.Flow;
using Heluo.Flow.Battle;
using Heluo.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using Buffer = Heluo.Data.Buffer;

namespace 侠之道mod制作器
{
    public partial class BufferInfoForm : Form
    {

        public string bufferId;

        public BufferInfoForm()
        {
            InitializeComponent();

            initIconNameComboBox();
            initOrientedComboBox();
        }

        public BufferInfoForm(string bufferId,bool canEdit) : this()
        {
            this.bufferId = bufferId;

            if (!canEdit)
            {
                idTextBox.Enabled = false;
                nameTextBox.Enabled = false;
                descTextBox.Enabled = false;
                iconNameComboBox.Enabled = false;
                TimesNumericUpDown.Enabled = false;
                overlayNumericUpDown.Enabled = false;
                orientedComboBox.Enabled = false;
                remarkTextBox.Enabled = false;
                splitContainer1.Panel1.Enabled = false;
                panel4.Visible = false;
                saveButton.Visible = false;
            }

            if (!bufferId.IsNullOrEmpty())
            {
                this.readBufferInfo();
            }
        }

        public TreeView getBufferNodeTreeView()
        {
            return bufferNodeTreeView;
        }

        public void initIconNameComboBox()
        {
            for (int i = 0; i < bufferImageList.Images.Count; i++)
            {
                string imageName = bufferImageList.Images.Keys[i];
                if (!iconNameComboBox.Items.Contains(imageName))
                {
                    iconNameComboBox.Items.Add(imageName);
                }
            }
        }

        public void initOrientedComboBox()
        {
            orientedComboBox.DisplayMember = "value";
            orientedComboBox.ValueMember = "key";
            foreach (BufferOriented temp in Enum.GetValues(typeof(BufferOriented)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                orientedComboBox.Items.Add(cbi);
            }
        }

        public void readBufferInfo()
        {
            idTextBox.Text = bufferId;
            idTextBox.Enabled = false;

            Buffer buffer = DataManager.getData<Buffer>("buffer", bufferId);

            if (buffer != null)
            {
                nameTextBox.Text = string.IsNullOrEmpty(buffer.Name) ? "" : buffer.Name;
                descTextBox.Text = string.IsNullOrEmpty(buffer.Desc) ? "" : buffer.Desc;
                remarkTextBox.Text = string.IsNullOrEmpty(buffer.Remark) ? "" : buffer.Remark;
                iconNameComboBox.Text = string.IsNullOrEmpty(buffer.IconName) ? "" : buffer.IconName;
                orientedComboBox.Text = EnumData.GetDisplayName(buffer.Oriented);
                TimesNumericUpDown.Value = buffer.Times;
                overlayNumericUpDown.Value = buffer.Overlay;


                BufferRootNode rootNode = (BufferRootNode)buffer.BufferEffect.Output;

                if (rootNode != null)
                {
                    TreeNode rootTreeNode = bufferNodeTreeView.Nodes.Add("根节点");
                    rootTreeNode.Tag = "\"BufferRootNode\" : ";
                    for (int i = 0; i < rootNode.child.Count; i++)
                    {
                        readBuffersEffect(rootNode.child[i], bufferNodeTreeView.Nodes[0]);
                    }
                    bufferNodeTreeView.ExpandAll();
                }
            }

        }

        private void iconNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = iconNameComboBox.Text;
            bufferIconPictureBox.Image = bufferImageList.Images[bufferImageList.Images.IndexOfKey(text)];
        }

        public void readBuffersEffect(BufferNode output, TreeNode treeNode)
        {
            DescriptionAttribute description = (DescriptionAttribute)output.GetType().GetCustomAttribute(typeof(DescriptionAttribute));
            string[] discriptionArray = description.Value.Split('/');

            List<BufferNode> child = null;
            if (output.GetType() == typeof(BufferEventNode))
            {
                BufferEventNode bufferEventNode = (BufferEventNode)output;
                TreeNode newNode = treeNode.Nodes.Add(output.ToString());
                newNode.Tag = "\"BufferEventNode\" : " + ((int)bufferEventNode.eventType) + ", ";

                child = bufferEventNode.child;
            }
            else if (output.GetType().IsSubclassOf(typeof(BufferEventCollectionNode)))
            {
                TreeNode newNode = treeNode.Nodes.Add(discriptionArray[discriptionArray.Length - 1]);

                string[] NodeClassName = output.GetType().ToString().Split('.');
                newNode.Tag = "\"" + NodeClassName[NodeClassName.Length - 1] + "\" : ";

                child = ((BufferEventCollectionNode)output).child;
            }
            else
            {
                string nodeStr = Utils.getBufferStr(discriptionArray, output);

                TreeNode newNode = treeNode.Nodes.Add(nodeStr);

                string[] NodeClassName = output.GetType().ToString().Split('.');
                string tag = getBufferNodeTag(output, output.GetType());
                if (tag.Length > 0)
                {
                    tag = " : " + tag.Substring(0, tag.Length - 2);
                }
                newNode.Tag = "\"" + NodeClassName[NodeClassName.Length - 1] + "\"" + tag;
            }
            if (child != null)
            {
                for (int i = 0; i < child.Count; i++)
                {
                    readBuffersEffect(child[i], treeNode.LastNode);
                }
            }
        }

        public string getBufferNodeTag(BufferNode output, Type type)
        {
            string tag = "";

            if (type.BaseType != typeof(BufferNode))
            {
                tag += getBufferNodeTag(output, type.BaseType);
            }

            FieldInfo[] fields = type.GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.DeclaringType != type || fieldInfo.GetCustomAttribute<InputFieldAttribute>() == null)
                {
                    continue;
                }

                if (fieldInfo.FieldType.IsSubclassOf(typeof(Enum)))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(float))
                {
                    tag += ((float)fieldInfo.GetValue(output)).ToString("0.00000") + ", ";
                }
                else if (fieldInfo.FieldType == typeof(int))
                {
                    tag += (int)fieldInfo.GetValue(output) + ", ";
                }
                else if (fieldInfo.FieldType == typeof(string))
                {
                    tag += "\"" + fieldInfo.GetValue(output) + "\", ";
                }
                else if (fieldInfo.FieldType == typeof(bool))
                {
                    tag += "" + fieldInfo.GetValue(output) + ", ";
                }
            }

            return tag;
        }

        private void addNewBufferEventButton_Click(object sender, EventArgs e)
        {

            if (bufferNodeTreeView.SelectedNode == null)
            {
                MessageBox.Show("请选择要添加到的节点");
                return;
            }

            BufferEventNodeForm form = new BufferEventNodeForm(":", true, this);
            form.ShowDialog();

            if (bufferNodeTreeView.SelectedNode.Parent != null)
            {
                bufferNodeTreeView.SelectedNode.Parent.Expand();
            }
        }

        private void editBufferNodeButton_Click(object sender, EventArgs e)
        {
            editOpenBufferNodeInfoForm();
        }

        private void deleteBufferNodeButton_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = bufferNodeTreeView.SelectedNode;
            if (currentNode == null)
            {
                MessageBox.Show("请选择要删除的节点");
                return;
            }
            if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bufferNodeTreeView.Nodes.Remove(bufferNodeTreeView.SelectedNode);
            }
        }
        private void addBufferNodeButton_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = bufferNodeTreeView.SelectedNode;
            if (currentNode == null)
            {
                MessageBox.Show("请选择要添加至的节点");
                return;
            }
            if (currentNode.Text == "根节点")
            {
                MessageBox.Show("不可添加至根节点");
                return;
            }
            string tag = currentNode.Tag.ToString();

            TreeNode addNode = null;

            switch (bufferNodeTabControl.SelectedIndex)
            {
                case 0:
                    if (BufferNodeFlowListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要添加的节点");
                        return;
                    }
                    while (!tag.Contains("BufferEventNode"))
                    {
                        currentNode = currentNode.Parent;
                        tag = currentNode.Tag.ToString();
                    }

                    addNode = currentNode.Nodes.Add(BufferNodeFlowListView.SelectedItems[0].Text);
                    addNode.Tag = "\"" + BufferNodeFlowListView.SelectedItems[0].SubItems[1].Text + "\" : ";
                    break;
                case 1:
                    if (BufferNodeConditionListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要添加的节点");
                        return;
                    }
                    while (!tag.Contains("BufferEventNode") && !tag.Contains("BufferPriorityNode") && !tag.Contains("BufferSequenceNode"))
                    {
                        currentNode = currentNode.Parent;
                        tag = currentNode.Tag.ToString();
                    }

                    if (BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text == "BufferAttackCondition")
                    {
                        addNode = currentNode.Nodes.Add(BufferNodeConditionListView.SelectedItems[0].Text + ":是");
                        addNode.Tag = "\"" + BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text + "\"";
                    }
                    else if (BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text == "BufferDefenderCondition")
                    {
                        addNode = currentNode.Nodes.Add(BufferNodeConditionListView.SelectedItems[0].Text + ":是");
                        addNode.Tag = "\"" + BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text + "\"";
                    }
                    else if (BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text == "IsLethalCondition")
                    {
                        addNode = currentNode.Nodes.Add(BufferNodeConditionListView.SelectedItems[0].Text + ":是");
                        addNode.Tag = "\"" + BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text + "\"";
                    }
                    else
                    {
                        string className = "侠之道mod制作器." + BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { BufferNodeConditionListView.SelectedItems[0].SubItems[1].Text + ":", true, this });

                            MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                            method.Invoke(obj, new object[] { });
                        }
                        else
                        {
                            MessageBox.Show("---未完成---");
                        }

                    }
                    break;
                case 2:
                    if (BufferNodePropertyListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要添加的节点");
                        return;
                    }

                    if (false)
                    {

                    }
                    else
                    {
                        string className = "侠之道mod制作器." + BufferNodePropertyListView.SelectedItems[0].SubItems[1].Text + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { BufferNodePropertyListView.SelectedItems[0].SubItems[1].Text + ":", true, this });

                            MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                            method.Invoke(obj, new object[] { });
                        }
                        else
                        {
                            MessageBox.Show("---未完成---");
                        }

                    }
                    break;
                case 3:
                    if (BufferNodeBufferListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要添加的节点");
                        return;
                    }
                    if (false)
                    {

                    }
                    else
                    {
                        string className = "侠之道mod制作器." + BufferNodeBufferListView.SelectedItems[0].SubItems[1].Text + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { BufferNodeBufferListView.SelectedItems[0].SubItems[1].Text + ":", true, this });

                            MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                            method.Invoke(obj, new object[] { });
                        }
                        else
                        {
                            MessageBox.Show("---未完成---");
                        }

                    }
                    break;
                case 4:
                    if (BufferNodeOtherListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要添加的节点");
                        return;
                    }

                    while (!tag.Contains("BufferEventNode") && !tag.Contains("BufferPriorityNode") && !tag.Contains("BufferSequenceNode"))
                    {
                        currentNode = currentNode.Parent;
                        tag = currentNode.Tag.ToString();
                    }
                    if (BufferNodeOtherListView.SelectedItems[0].SubItems[1].Text == "EncourageAction")
                    {
                        addNode = currentNode.Nodes.Add(BufferNodeOtherListView.SelectedItems[0].Text);
                        addNode.Tag = "\"" + BufferNodeOtherListView.SelectedItems[0].SubItems[1].Text + "\"";
                    }
                    else
                    {
                        string className = "侠之道mod制作器." + BufferNodeOtherListView.SelectedItems[0].SubItems[1].Text + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { BufferNodeOtherListView.SelectedItems[0].SubItems[1].Text + ":", true, this });

                            MethodInfo method = clazz.GetMethod("ShowDialog", new Type[] { });

                            method.Invoke(obj, new object[] { });
                        }
                        else
                        {
                            MessageBox.Show("---未完成---");
                        }

                    }
                    break;
            }

            if (addNode != null)
            {
                bufferNodeTreeView.SelectedNode = addNode;
            }
        }

        private void BufferNodeFlowListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            addBufferNodeButton_Click(sender, e);
        }

        private void BufferNodeConditionListView_DoubleClick(object sender, EventArgs e)
        {
            addBufferNodeButton_Click(sender, e);
        }

        private void BufferNodePropertyListView_DoubleClick(object sender, EventArgs e)
        {
            addBufferNodeButton_Click(sender, e);
        }

        private void BufferNodeBufferListView_DoubleClick(object sender, EventArgs e)
        {
            addBufferNodeButton_Click(sender, e);
        }

        private void BufferNodeOtherListView_DoubleClick(object sender, EventArgs e)
        {
            addBufferNodeButton_Click(sender, e);
        }



        public void editOpenBufferNodeInfoForm()
        {
            try
            {

                TreeNode treeNode = bufferNodeTreeView.SelectedNode;
                if (treeNode == null)
                {
                    MessageBox.Show("请选择要添加到的节点");
                    return;
                }
                if (treeNode != null && treeNode.Tag != null)
                {
                    string tag = treeNode.Tag.ToString().Split(':')[0];
                    tag = tag.Substring(1, tag.Length - 2);
                    if (tag.EndsWith("\""))
                    {
                        tag = tag.Substring(0, tag.Length - 1);
                    }
                    if (tag == "BufferEventNode")
                    {
                        BufferEventNodeForm form = new BufferEventNodeForm(treeNode.Text, false, this);
                        form.ShowDialog();
                    }
                    else if (tag == "BufferRootNode" || tag == "BufferPriorityNode" || tag == "BufferSequenceNode"
                        || tag == "BufferAttackCondition" || tag == "BufferDefenderCondition" || tag == "IsLethalCondition" || tag == "EncourageAction")
                    {
                        MessageBox.Show("该节点无需修改");
                        return;
                    }
                    else
                    {
                        string className = "侠之道mod制作器." + tag + "Form";
                        Type clazz = Type.GetType(className);

                        if (clazz != null)
                        {
                            object obj = Activator.CreateInstance(clazz, new object[] { treeNode.Tag.ToString(), false, this });

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("请输入ID");
                return;
            }
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("请输入名称");
                return;
            }
            if (orientedComboBox.SelectedItem == null)
            {
                MessageBox.Show("请选择效果面向");
                return;
            }

            //写文件
            string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + idTextBox.Text + ".json";

            using (StreamWriter sw = new StreamWriter(savePath))
            {
                string result = "";
                result = idTextBox.Text + "\t" + nameTextBox.Text + "\t" + descTextBox.Text + "\t" + remarkTextBox.Text + "\t" + iconNameComboBox.Text + "\t"
                    + (BufferOriented)int.Parse(((ComboBoxItem)orientedComboBox.SelectedItem).key) + "\t" + TimesNumericUpDown.Value + "\t" + overlayNumericUpDown.Value + "\t"
                    + getOutputStr(bufferNodeTreeView.Nodes[0]);

                sw.Write(result);
            }
            //禁止修改id
            idTextBox.Enabled = false;

            //刷新buff列表
            //获得列表项
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");


            if (DataManager.allBufferLvis.ContainsKey(idTextBox.Text))
            {
                lvi = DataManager.allBufferLvis[idTextBox.Text];
            }

            lvi.ImageKey = iconNameComboBox.Text;
            lvi.Text = iconNameComboBox.Text;
            lvi.SubItems[1].Text = idTextBox.Text;
            lvi.SubItems[2].Text = nameTextBox.Text;
            lvi.SubItems[3].Text = descTextBox.Text;
            lvi.SubItems[4].Text = remarkTextBox.Text;
            lvi.SubItems[5].Text = (BufferOriented)int.Parse(((ComboBoxItem)orientedComboBox.SelectedItem).key) + "(" + orientedComboBox.Text + ")";
            lvi.SubItems[6].Text = TimesNumericUpDown.Text;
            lvi.SubItems[7].Text = overlayNumericUpDown.Text;
            lvi.SubItems[8].Text = getOutputStr(bufferNodeTreeView.Nodes[0]);
            lvi.SubItems[9].Text = "1";

            Buffer buffer = DataManager.loadData<Buffer>(MainForm.savePath + MainForm.modName + "\\" +DataManager.modBufferPath, idTextBox.Text + ".json");

            if (DataManager.dict["buffer_cus"].Contains(idTextBox.Text))
            {
                DataManager.dict["buffer_cus"][idTextBox.Text] = buffer;
            }
            else
            {
                DataManager.dict["buffer_cus"].Add(idTextBox.Text, buffer);
            }

            if (DataManager.allBufferLvis.ContainsKey(lvi.SubItems[1].Text))
            {
                ListViewItem oldLvi = DataManager.allBufferLvis[idTextBox.Text];
                for (int i = 0; i < oldLvi.SubItems.Count; i++)
                {
                    oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                }
            }
            else
            {
                DataManager.allBufferLvis.Add(idTextBox.Text, lvi);
                if (MainForm.userControls.ContainsKey("buffer"))
                {
                    BufferTabControlUserControl bufferTabControlUserControl = (BufferTabControlUserControl)MainForm.userControls["buffer"];
                    bufferTabControlUserControl.getBufferListView().Items.Add(lvi);
                }
            }
        }

        private string getOutputStr(TreeNode node)
        {
            string outputStr = "";

            outputStr += "{ " + node.Tag.ToString();

            if (node.Tag.ToString().Contains("BufferRootNode")
                || node.Tag.ToString().Contains("BufferEventNode")
                || node.Tag.ToString().Contains("BufferPriorityNode")
                || node.Tag.ToString().Contains("BufferSequenceNode"))
            {
                outputStr += "[ ";
                string outputChildStr = "";
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    outputChildStr += getOutputStr(node.Nodes[i]) + ", ";
                }
                if (outputChildStr.Length > 0)
                {
                    outputChildStr = outputChildStr.Substring(0, outputChildStr.Length - 2);
                }
                outputStr += outputChildStr + "]";
            }

            outputStr += "}  ";

            return outputStr;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            TreeNode node = bufferNodeTreeView.SelectedNode;

            if (node.Tag == null)
            {
                return;
            }
            if (node.Tag.ToString().Contains("AuraPromoteAction")
                || node.Tag.ToString().Contains("SingleAuraPromoteAction")
                || node.Tag.ToString().Contains("AddBuffAction")
                || node.Tag.ToString().Contains("AttacherClearBuffAction")
                || node.Tag.ToString().Contains("RandomBuffAction")
                || node.Tag.ToString().Contains("AddBuffWithUnitIdAction")
                || node.Tag.ToString().Contains("RemoveBuffWithUnitIdAction")
                || node.Tag.ToString().Contains("AssignAuraPromoteAction")
                || node.Tag.ToString().Contains("AttackerElementAddBuff")
                || node.Tag.ToString().Contains("DefenderElementAddBuff")
                || node.Tag.ToString().Contains("DefenderClearBuffAction")
                || node.Tag.ToString().Contains("AttackerHasBufferCondition")
                || node.Tag.ToString().Contains("DefendeHasBufferCondition")
                || node.Tag.ToString().Contains("IsHasBufferCondition")
                || node.Tag.ToString().Contains("BufferOverlayPromoteAction"))
            {
                Utils.addToolStripMenuItem("buffer", node.Tag.ToString(), contextMenuStrip1);
            }
            if(contextMenuStrip1.Items.Count > 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
