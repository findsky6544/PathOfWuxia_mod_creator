
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EventCube = Heluo.Data.EventCube;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class EventCubeInfoForm : Form
    {

        public string EventCubeId;

        public string currentCell = "";
        public int selectCellNumber = -1;
        public EventCubeInfoForm()
        {
            InitializeComponent();

            initClickTypeComboBox();
        }

        public EventCubeInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public EventCubeInfoForm(string EventCubeId) : this()
        {
            this.EventCubeId = EventCubeId;
        }

        public void initClickTypeComboBox()
        {
            ClickTypeComboBox.DisplayMember = "value";
            ClickTypeComboBox.ValueMember = "key";


            foreach (ClickType temp in Enum.GetValues(typeof(ClickType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ClickTypeComboBox.Items.Add(cbi);
            }
        }

        public void readEventCubeInfo()
        {
            idTextBox.Text = EventCubeId;
            idTextBox.Enabled = false;

            EventCube EventCube = DataManager.getData<EventCube>(EventCubeId);

            NameTextBox.Text = EventCube.Name;
            PrefabNameTextBox.Text = EventCube.PrefabName;
            IsRepeatCheckBox.Checked = EventCube.IsRepeat;
            PositionTextBox.Text = EventCube.Position.ToString();
            RotationTextBox.Text = EventCube.Rotation.ToString();
            ScaleTextBox.Text = EventCube.Scale.ToString();
            ColliderSizeTextBox.Text = EventCube.ColliderSize.ToString();
            IsOnTerrainCheckBox.Checked = EventCube.IsOnTerrain;
            IsTriggerCheckBox.Checked = EventCube.IsTrigger;
            ClickTypeComboBox.Text = EnumData.GetDisplayName(EventCube.ClickType);
            RemarksTextBox.Text = EventCube.Remarks;
            InteractiveHeightNumericUpDown.Text = EventCube.InteractiveHeight.ToString();
            Utils.initFlowTreeView(EventCube.InteractiveEvent, InteractiveEventTreeView);
            Utils.initFlowTreeView(EventCube.CreateCondition, CreateConditionTreeView);
            Utils.initFlowTreeView(EventCube.AppearCondition, AppearConditionTreeView);
            IsShowLightPointCheckBox.Checked = EventCube.IsShowLightPoint;
            CenterTextBox.Text = EventCube.Center.ToString();
        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("请输入ID");
                    return;
                }
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入名称");
                    return;
                }
                if (string.IsNullOrEmpty(PrefabNameTextBox.Text))
                {
                    MessageBox.Show("请输入Prefab名称");
                    return;
                }
                if (string.IsNullOrEmpty(PositionTextBox.Text))
                {
                    MessageBox.Show("请输入位置");
                    return;
                }
                if (string.IsNullOrEmpty(RotationTextBox.Text))
                {
                    MessageBox.Show("请输入旋转值");
                    return;
                }
                if (string.IsNullOrEmpty(ScaleTextBox.Text))
                {
                    MessageBox.Show("请输入物件大小");
                    return;
                }
                if (string.IsNullOrEmpty(ColliderSizeTextBox.Text))
                {
                    MessageBox.Show("请输入碰撞体大小");
                    return;
                }
                if (string.IsNullOrEmpty(ClickTypeComboBox.Text))
                {
                    MessageBox.Show("请输入点击的类型");
                    return;
                }
                if (string.IsNullOrEmpty(CenterTextBox.Text))
                {
                    MessageBox.Show("请输入中心点");
                    return;
                }
                if (string.IsNullOrEmpty(RemarksTextBox.Text))
                {
                    MessageBox.Show("请输入备注（互动用）");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\EventCube.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + PrefabNameTextBox.Text + "\t" + IsRepeatCheckBox.Checked + "\t" + PositionTextBox.Text.Trim().Substring(1, PositionTextBox.Text.Trim().Length - 2) + "\t" + RotationTextBox.Text.Trim().Substring(1, RotationTextBox.Text.Trim().Length - 2) + "\t" + ScaleTextBox.Text.Trim().Substring(1, ScaleTextBox.Text.Trim().Length - 2) + "\t" + ColliderSizeTextBox.Text.Trim().Substring(1, ColliderSizeTextBox.Text.Trim().Length - 2) + "\t" + IsOnTerrainCheckBox.Checked + "\t" + IsTriggerCheckBox.Checked + "\t" + ((ComboBoxItem)ClickTypeComboBox.SelectedItem).key + "\t" + RemarksTextBox.Text + "\t" + InteractiveHeightNumericUpDown.Text + "\t";

                if (InteractiveEventTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(InteractiveEventTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";
                if (CreateConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(CreateConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";
                if (AppearConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(AppearConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + IsShowLightPointCheckBox.Checked + "\t" + CenterTextBox.Text.Trim().Substring(1, CenterTextBox.Text.Trim().Length - 2);


                if (content.Contains("\r\n" + idTextBox.Text + "\t"))
                {
                    string pattern = "\r\n" + idTextBox.Text + ".+?\r\n";
                    Regex rgx = new Regex(pattern);
                    content = rgx.Replace(content, "\r\n" + replacement + "\r\n");
                }
                else
                {
                    content += replacement;
                }
                while (content.StartsWith("\r\n"))
                {
                    content = content.Substring(2, content.Length - 2);
                }
                while (content.EndsWith("\r\n"))
                {
                    content = content.Substring(0, content.Length - 2);
                }

                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    sw.Write(content);
                }

                DataManager.LoadTextfile(typeof(EventCube), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新EventCube列表
                //获得列表项
                ListViewItem lvi = DataManager.createEventCubeLvi(idTextBox.Text);


                

                EventCubeTabControlUserControl EventCubeTabControlUserControl = (EventCubeTabControlUserControl)MainForm.userControls["EventCube"];

                if (DataManager.allEventCubeLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allEventCubeLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allEventCubeLvis.Add(idTextBox.Text, lvi);
                    EventCubeTabControlUserControl.getEventCubeListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(CreateConditionTreeView);
        }

        private void addReadConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ReadConditionNodeListView, CreateConditionTreeView);
        }

        private void readConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(CreateConditionTreeView);
        }

        private void readConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(CreateConditionTreeView);
        }

        private void showConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(AppearConditionTreeView);
        }

        private void addShowConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, AppearConditionTreeView);
        }

        private void showConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(AppearConditionTreeView);
        }

        private void showConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(AppearConditionTreeView);
        }

        private void InteractiveEventAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(InteractiveEventTreeView);
        }

        private void addInteractiveEventNodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (InteractiveEventTabControl.SelectedIndex)
                {
                    case 0:
                        Utils.addConditionNode(InteractiveEventNodeTriggerListView, InteractiveEventTreeView);

                        break;
                    case 1:
                        Utils.addConditionNode(InteractiveEventNodeOpenUIListView, InteractiveEventTreeView);

                        break;
                    case 2:
                        Utils.addConditionNode(InteractiveEventNodeModelAnimeListView, InteractiveEventTreeView);
                        break;
                    case 3:
                        Utils.addConditionNode(InteractiveEventNodeRewardListView, InteractiveEventTreeView);

                        break;
                    case 4:
                        Utils.addConditionNode(InteractiveEventNodeShowListView, InteractiveEventTreeView);

                        break;
                    case 5:
                        Utils.addConditionNode(InteractiveEventNodeOtherListView, InteractiveEventTreeView);

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InteractiveEventEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(InteractiveEventTreeView);
        }

        private void InteractiveEventDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(InteractiveEventTreeView);
        }

        private void addMultiLogicaActionButton_Click(object sender, EventArgs e)
        {
            Utils.addMultiAction(InteractiveEventTreeView);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.createCinematicContextMenuStrip(contextMenuStrip1, InteractiveEventTreeView, e);
        }
    }

}
