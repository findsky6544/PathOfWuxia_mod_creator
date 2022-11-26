
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Skill = Heluo.Data.Skill;

namespace 侠之道mod制作器
{
    public partial class SkillInfoForm : Form
    {

        public string SkillId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public SkillInfoForm()
        {
            InitializeComponent();

            initRequireAttributeComboBox();
            initIconNameComboBox();
            //initTypeComboBox();

            Utils.initComboBox(TypeComboBox, typeof(PropsCategory));
            Utils.initComboBox(DamageTypeComboBox, typeof(DamageType));
            Utils.initComboBox(TargetTypeComboBox, typeof(TargetType));
            Utils.initComboBox(TargetAreaComboBox, typeof(TargetArea));
            Utils.initComboBox(AlgorithmComboBox, typeof(Algorithm));

        }

        public SkillInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public SkillInfoForm(string SkillId) : this()
        {
            this.SkillId = SkillId;
        }

        public void initRequireAttributeComboBox()
        {
            RequireAttributeComboBox.DisplayMember = "value";
            RequireAttributeComboBox.ValueMember = "key";


            foreach (CharacterUpgradablePropertyTable temp in Enum.GetValues(typeof(CharacterUpgradablePropertyTable)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                RequireAttributeComboBox.Items.Add(cbi);
            }
        }

        public void initTypeComboBox()
        {
            Utils.initComboBox(TypeComboBox, typeof(PropsCategory));

            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";


            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }

        public void initIconNameComboBox()
        {
            for (int i = 0; i < SkillImageList.Images.Count; i++)
            {
                string imageName = SkillImageList.Images.Keys[i];
                if (!IconNameComboBox.Items.Contains(imageName))
                {
                    IconNameComboBox.Items.Add(imageName);
                }
            }
        }


        public void readSkillInfo()
        {
            idTextBox.Text = SkillId;
            idTextBox.Enabled = false;

            Skill Skill = DataManager.getData<Skill>(SkillId);

            NameTextBox.Text = Skill.Name;
            DescriptionTextBox.Text = Skill.Description;
            RemarkTextBox.Text = Skill.Remark;
            RankNumericUpDown.Value = Skill.Rank;
            RequireAttributeComboBox.Text = EnumData.GetDisplayName(Skill.RequireAttribute);
            RequireValueNumericUpDown.Value = Skill.RequireValue;
            IconNameComboBox.Text = Skill.IconName;
            TypeComboBox.Text = EnumData.GetDisplayName(Skill.Type);
            DamageTypeComboBox.Text = EnumData.GetDisplayName(Skill.DamageType);
            TargetTypeComboBox.Text = EnumData.GetDisplayName(Skill.TargetType);
            TargetAreaComboBox.Text = EnumData.GetDisplayName(Skill.TargetArea);
            MaxRangeNumericUpDown.Value = Skill.MaxRange;
            MinRangeNumericUpDown.Value = Skill.MinRange;
            AOENumericUpDown.Value = Skill.AOE;
            AlgorithmComboBox.Text = EnumData.GetDisplayName(Skill.Algorithm);
            RequestMPNumericUpDown.Value = Skill.RequestMP;
            MaxCDNumericUpDown.Value = Skill.MaxCD;
            TargetBuffListTextBox.Text = Utils.stringListToString(Skill.TargetBuffList);
            SelfBuffListTextBox.Text = Utils.stringListToString(Skill.SelfBuffList);
            EffectTextBox.Text = Skill.Effect;
            PushDistanceNumericUpDown.Value = Skill.PushDistance;
            SummonidTextBox.Text = Skill.Summonid;
            Utils.initFlowTreeView(Skill.Rewards, RewardsTreeView);
            DamageTextBox.Text = Skill.Damage;
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
                if (string.IsNullOrEmpty(RequireAttributeComboBox.Text))
                {
                    MessageBox.Show("请输入基本功需求四维");
                    return;
                }
                if (string.IsNullOrEmpty(RequireValueNumericUpDown.Text))
                {
                    MessageBox.Show("请输入基本功需求值");
                    return;
                }
                if (string.IsNullOrEmpty(IconNameComboBox.Text))
                {
                    MessageBox.Show("请输入图标");
                    return;
                }
                if (string.IsNullOrEmpty(TypeComboBox.Text))
                {
                    MessageBox.Show("请输入武器类型");
                    return;
                }
                if (string.IsNullOrEmpty(DamageTypeComboBox.Text))
                {
                    MessageBox.Show("请输入伤害类型");
                    return;
                }
                if (string.IsNullOrEmpty(TargetTypeComboBox.Text))
                {
                    MessageBox.Show("请输入目标种类");
                    return;
                }
                if (string.IsNullOrEmpty(TargetAreaComboBox.Text))
                {
                    MessageBox.Show("请输入目标区域");
                    return;
                }
                if (string.IsNullOrEmpty(MaxRangeNumericUpDown.Text))
                {
                    MessageBox.Show("请输入最大距离");
                    return;
                }
                if (string.IsNullOrEmpty(MinRangeNumericUpDown.Text))
                {
                    MessageBox.Show("请输入最小距离");
                    return;
                }
                if (string.IsNullOrEmpty(AOENumericUpDown.Text))
                {
                    MessageBox.Show("请输入溅射范围");
                    return;
                }
                if (string.IsNullOrEmpty(AlgorithmComboBox.Text))
                {
                    MessageBox.Show("请输入系数算法");
                    return;
                }
                if (string.IsNullOrEmpty(RequestMPNumericUpDown.Text))
                {
                    MessageBox.Show("请输入需求内力");
                    return;
                }
                if (string.IsNullOrEmpty(MaxCDNumericUpDown.Text))
                {
                    MessageBox.Show("请输入冷却时间");
                    return;
                }
                if (string.IsNullOrEmpty(EffectTextBox.Text))
                {
                    MessageBox.Show("请输入技能特效编号");
                    return;
                }
                if (string.IsNullOrEmpty(PushDistanceNumericUpDown.Text))
                {
                    MessageBox.Show("请输入位移距离");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Skill.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + RankNumericUpDown.Text + "\t" + Enum.Parse(typeof(CharacterUpgradablePropertyTable), ((ComboBoxItem)RequireAttributeComboBox.SelectedItem).key) + "\t" + RequireValueNumericUpDown.Text + "\t" + IconNameComboBox.Text + "\t" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)DamageTypeComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)TargetTypeComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)TargetAreaComboBox.SelectedItem).key + "\t" + MaxRangeNumericUpDown.Value + "\t" + MinRangeNumericUpDown.Value + "\t" + AOENumericUpDown.Value + "\t" + DamageTextBox.Text + "\t" + ((ComboBoxItem)AlgorithmComboBox.SelectedItem).key + "\t" + RequestMPNumericUpDown.Value + "\t" + MaxCDNumericUpDown.Value + "\t" + TargetBuffListTextBox.Text + "\t" + SelfBuffListTextBox.Text + "\t" + EffectTextBox.Text + "\t" + PushDistanceNumericUpDown.Value + "\t" + SummonidTextBox.Text + "\t";

                if (RewardsTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(RewardsTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t";

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

                DataManager.LoadTextfile(typeof(Skill), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Skill列表
                //获得列表项
                ListViewItem lvi = DataManager.createSkillLvi(idTextBox.Text);


                

                SkillTabControlUserControl SkillTabControlUserControl = (SkillTabControlUserControl)MainForm.userControls["Skill"];

                if (DataManager.allSkillLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allSkillLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allSkillLvis.Add(idTextBox.Text, lvi);
                    SkillTabControlUserControl.getSkillListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IconNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = IconNameComboBox.Text;
            IconPictureBox.Image = SkillImageList.Images[SkillImageList.Images.IndexOfKey(text)];
        }

        private void RewardsAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(RewardsTreeView);
        }

        private void addMultiLogicaActionButton_Click(object sender, EventArgs e)
        {
            Utils.addMultiLogicaAction(RewardsTreeView);
        }

        private void addConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionListView, RewardsTreeView);
        }

        private void ConditionListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionListView, RewardsTreeView);
        }

        private void addRewardButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardNodeListView, RewardsTreeView);
        }

        private void RewardNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardNodeListView, RewardsTreeView);
        }

        private void EditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(RewardsTreeView);
        }

        private void DeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(RewardsTreeView);
        }

        private void selectFormulaButton_Click(object sender, EventArgs e)
        {
            SelectGameFormulaForm form = new SelectGameFormulaForm(this, DamageTextBox, false);
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, SummonidTextBox, true);
            form.ShowDialog();
        }

        private void selectSelfBuffButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, SelfBuffListTextBox, true);
            form.ShowDialog();
        }

        private void selectTargetBuffButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, TargetBuffListTextBox, true);
            form.ShowDialog();
        }
    }

}
