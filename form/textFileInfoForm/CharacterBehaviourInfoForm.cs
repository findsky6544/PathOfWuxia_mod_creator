
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CharacterBehaviour = Heluo.Data.CharacterBehaviour;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class CharacterBehaviourInfoForm : Form
    {

        public string CharacterBehaviourId;

        public string currentCell = "";
        public int selectCellNumber = -1;
        public CharacterBehaviourInfoForm()
        {
            InitializeComponent();

            initClickTypeComboBox();
        }

        public CharacterBehaviourInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public CharacterBehaviourInfoForm(string CharacterBehaviourId) : this()
        {
            this.CharacterBehaviourId = CharacterBehaviourId;
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

        public void readCharacterBehaviourInfo()
        {
            idTextBox.Text = CharacterBehaviourId;
            idTextBox.Enabled = false;

            CharacterBehaviour CharacterBehaviour = DataManager.getData<CharacterBehaviour>(CharacterBehaviourId);

            RemarkTextBox.Text = CharacterBehaviour.Remark;
            PositionTextBox.Text = CharacterBehaviour.Position.ToString();
            RotationTextBox.Text = CharacterBehaviour.Rotation.ToString();
            IsTuenCheckBox.Checked = CharacterBehaviour.IsTuen;
            TalkIdTextBox.Text = CharacterBehaviour.TalkId;
            AnimationTextBox.Text = CharacterBehaviour.Animation;
            SchedulerIdTextBox.Text = CharacterBehaviour.SchedulerId;
            ClickTypeComboBox.Text = EnumData.GetDisplayName(CharacterBehaviour.ClickType);
            InteractiveNameTextBox.Text = CharacterBehaviour.InteractiveName;
            Utils.initFlowTreeView(CharacterBehaviour.InteractiveEvent, InteractiveEventTreeView);
            Utils.initFlowTreeView(CharacterBehaviour.CreateCondition, CreateConditionTreeView);
            Utils.initFlowTreeView(CharacterBehaviour.AppearCondition, AppearConditionTreeView);
        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void selectReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectConfigScheduleForm form = new SelectConfigScheduleForm(this, SchedulerIdTextBox, false);
            form.ShowDialog();
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
                if (string.IsNullOrEmpty(TalkIdTextBox.Text))
                {
                    MessageBox.Show("请输入对话编号");
                    return;
                }
                if (string.IsNullOrEmpty(AnimationTextBox.Text))
                {
                    MessageBox.Show("请输入动画名称");
                    return;
                }
                if (string.IsNullOrEmpty(ClickTypeComboBox.Text))
                {
                    MessageBox.Show("请输入点击的类型");
                    return;
                }
                if (string.IsNullOrEmpty(InteractiveNameTextBox.Text))
                {
                    MessageBox.Show("请输入互动名称");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\CharacterBehaviour_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + PositionTextBox.Text.Trim().Substring(1, PositionTextBox.Text.Trim().Length - 2) + "\t" + RotationTextBox.Text.Trim().Substring(1, RotationTextBox.Text.Trim().Length - 2) + "\t" + IsTuenCheckBox.Checked + "\t" + TalkIdTextBox.Text + "\t" + AnimationTextBox.Text + "\t" + SchedulerIdTextBox.Text + "\t" + ((ComboBoxItem)ClickTypeComboBox.SelectedItem).key + "\t" + InteractiveNameTextBox.Text + "\t";

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

                DataManager.LoadTextfile(typeof(CharacterBehaviour), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新CharacterBehaviour列表
                //获得列表项
                ListViewItem lvi = DataManager.createCharacterBehaviourLvi(idTextBox.Text);


                

                CharacterBehaviourTabControlUserControl CharacterBehaviourTabControlUserControl = (CharacterBehaviourTabControlUserControl)MainForm.userControls["CharacterBehaviour"];

                if (DataManager.allCharacterBehaviourLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allCharacterBehaviourLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allCharacterBehaviourLvis.Add(idTextBox.Text, lvi);
                    CharacterBehaviourTabControlUserControl.getCharacterBehaviourListView().Items.Add(lvi);
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

        private void addMultiActionButton_Click(object sender, EventArgs e)
        {
            Utils.addMultiAction(InteractiveEventTreeView);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Utils.createCinematicContextMenuStrip(contextMenuStrip1, InteractiveEventTreeView, e);
        }
    }

}
