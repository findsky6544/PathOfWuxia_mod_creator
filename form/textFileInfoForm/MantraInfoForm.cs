
using Heluo.Data;
using Heluo.Flow;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Mantra = Heluo.Data.Mantra;

namespace 侠之道mod制作器
{
    public partial class MantraInfoForm : Form
    {

        public string MantraId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public MantraInfoForm()
        {
            InitializeComponent();

            initRequireAttributeComboBox();
            initIconNameComboBox();
        }

        public MantraInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public MantraInfoForm(string MantraId) : this()
        {
            this.MantraId = MantraId;
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

        public void initIconNameComboBox()
        {
            for (int i = 0; i < MantraImageList.Images.Count; i++)
            {
                string imageName = MantraImageList.Images.Keys[i];
                if (!IconNameComboBox.Items.Contains(imageName))
                {
                    IconNameComboBox.Items.Add(imageName);
                }
            }
        }


        public void readMantraInfo()
        {
            idTextBox.Text = MantraId;
            idTextBox.Enabled = false;

            Mantra Mantra = DataManager.getData<Mantra>(MantraId);

            NameTextBox.Text = Mantra.Name;
            DescriptionTextBox.Text = Mantra.Description;
            RemarkTextBox.Text = Mantra.Remark;
            IconNameComboBox.Text = Mantra.IconName;

            for (int i = 0; i < RequireAttributeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)RequireAttributeComboBox.Items[i]).key == ((int)Mantra.RequireAttribute).ToString())
                {
                    RequireAttributeComboBox.SelectedIndex = i;
                    break;
                }
            }
            RequireValueNumericUpDown.Value = Mantra.RequireValue;

            if (Mantra.MantraRunEffectDescription != null && Mantra.MantraRunEffectDescription.Count > 0)
            {
                for (int i = 0; i < Mantra.MantraRunEffectDescription.Count; i++)
                {
                    MantraEffectDescription MantraEffectDescription = Mantra.MantraRunEffectDescription[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = MantraEffectDescription.MartraLevel.ToString();
                    lvi.SubItems.Add(MantraEffectDescription.EffectDescription);
                    lvi.Tag = "(" + MantraEffectDescription.MartraLevel.ToString() + ", " + MantraEffectDescription.EffectDescription + ")";
                    MantraRunEffectDescriptionsListView.Items.Add(lvi);
                }
            }
            if (Mantra.MantraPracticeEffectDescription != null && Mantra.MantraPracticeEffectDescription.Count > 0)
            {
                for (int i = 0; i < Mantra.MantraPracticeEffectDescription.Count; i++)
                {
                    MantraEffectDescription MantraPracticeEffectDescription = Mantra.MantraPracticeEffectDescription[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = MantraPracticeEffectDescription.MartraLevel.ToString();
                    lvi.SubItems.Add(MantraPracticeEffectDescription.EffectDescription);
                    lvi.Tag = "(" + MantraPracticeEffectDescription.MartraLevel.ToString() + ", " + MantraPracticeEffectDescription.EffectDescription + ")";
                    MantraPracticeEffectDescriptionsListView.Items.Add(lvi);
                }
            }
            if (Mantra.MantraPropertyEffects != null && Mantra.MantraPropertyEffects.Count > 0)
            {
                for (int i = 0; i < Mantra.MantraPropertyEffects.Count; i++)
                {
                    MantraPropertyEffect MantraPropertyEffect = Mantra.MantraPropertyEffects[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = MantraPropertyEffect.MartraLevel.ToString();
                    lvi.SubItems.Add(EnumData.GetDisplayName(MantraPropertyEffect.Property));
                    lvi.SubItems.Add(EnumData.GetDisplayName(MantraPropertyEffect.Method));
                    lvi.SubItems.Add(MantraPropertyEffect.MaxValue.ToString());
                    lvi.Tag = "(" + MantraPropertyEffect.MartraLevel.ToString() + ", " + MantraPropertyEffect.Property + ", " + MantraPropertyEffect.Method + ", " + MantraPropertyEffect.MaxValue + ")";
                    MantraPropertyEffectsListView.Items.Add(lvi);
                }
            }
            if (Mantra.BufferEffects != null && Mantra.BufferEffects.Count > 0)
            {
                for (int i = 0; i < Mantra.BufferEffects.Count; i++)
                {
                    MantraBufferEffect MantraBufferEffect = Mantra.BufferEffects[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = MantraBufferEffect.MartraLevel.ToString();
                    lvi.SubItems.Add(DataManager.getBuffersName(MantraBufferEffect.BufferId));
                    lvi.Tag = "(" + MantraBufferEffect.MartraLevel.ToString() + ", " + MantraBufferEffect.BufferId + ")";
                    BufferEffectsListView.Items.Add(lvi);
                }
            }

            Utils.initFlowTreeView(Mantra.LevelUpRewards, LevelUpRewardsTreeView);
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
                if (string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    MessageBox.Show("请输入描述");
                    return;
                }
                if (string.IsNullOrEmpty(RequireAttributeComboBox.Text))
                {
                    MessageBox.Show("请输入基本功需求四维");
                    return;
                }
                if (string.IsNullOrEmpty(IconNameComboBox.Text))
                {
                    MessageBox.Show("请输入图标");
                    return;
                }
                if (string.IsNullOrEmpty(RequireValueNumericUpDown.Text))
                {
                    MessageBox.Show("请输入基本功需求值");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Mantra_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + IconNameComboBox.Text + "\t" + Enum.Parse(typeof(CharacterUpgradablePropertyTable), ((ComboBoxItem)RequireAttributeComboBox.SelectedItem).key) + "\t" + RequireValueNumericUpDown.Text + "\t";

                for (int i = 0; i < MantraRunEffectDescriptionsListView.Items.Count; i++)
                {
                    replacement += MantraRunEffectDescriptionsListView.Items[i].Tag.ToString();
                }
                replacement += "\t";
                for (int i = 0; i < MantraPracticeEffectDescriptionsListView.Items.Count; i++)
                {
                    replacement += MantraPracticeEffectDescriptionsListView.Items[i].Tag.ToString();
                }
                replacement += "\t";
                for (int i = 0; i < MantraPropertyEffectsListView.Items.Count; i++)
                {
                    replacement += MantraPropertyEffectsListView.Items[i].Tag.ToString();
                }
                replacement += "\t";
                for (int i = 0; i < BufferEffectsListView.Items.Count; i++)
                {
                    replacement += BufferEffectsListView.Items[i].Tag.ToString();
                }
                replacement += "\t";
                if (LevelUpRewardsTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(LevelUpRewardsTreeView.Nodes[0]) + "}";
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

                DataManager.LoadTextfile(typeof(Mantra), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Mantra列表
                //获得列表项
                ListViewItem lvi = DataManager.createMantraLvi(idTextBox.Text);


                

                MantraTabControlUserControl MantraTabControlUserControl = (MantraTabControlUserControl)MainForm.userControls["Mantra"];

                if (DataManager.allMantraLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allMantraLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allMantraLvis.Add(idTextBox.Text, lvi);
                    MantraTabControlUserControl.getMantraListView().Items.Add(lvi);
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
            IconPictureBox.Image = MantraImageList.Images[MantraImageList.Images.IndexOfKey(text)];
        }

        private void changeRedButton_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.SelectedText = "<color=#FF0000>" + DescriptionTextBox.SelectedText + "</color>";
        }


        private void LevelUpRewardsAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(LevelUpRewardsTreeView);
        }

        private void addMultiLogicaActionButton_Click(object sender, EventArgs e)
        {
            Utils.addMultiLogicaAction(LevelUpRewardsTreeView);
        }

        private void addConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionListView, LevelUpRewardsTreeView);
        }

        private void ConditionListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionListView, LevelUpRewardsTreeView);
        }

        private void addRewardButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardNodeListView, LevelUpRewardsTreeView);
        }

        private void RewardNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(RewardNodeListView, LevelUpRewardsTreeView);
        }

        private void EditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(LevelUpRewardsTreeView);
        }

        private void DeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(LevelUpRewardsTreeView);
        }

        private void addMantraRunEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.Tag = "(0,)";
            MantraEffectDescriptionForm form = new MantraEffectDescriptionForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MantraRunEffectDescriptionsListView.Items.Add(lvi);
            }
        }

        private void editMantraRunEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            if (MantraRunEffectDescriptionsListView.SelectedItems.Count > 0)
            {
                MantraEffectDescriptionForm form = new MantraEffectDescriptionForm(MantraRunEffectDescriptionsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteMantraRunEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            if (MantraRunEffectDescriptionsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MantraRunEffectDescriptionsListView.Items.Remove(MantraRunEffectDescriptionsListView.SelectedItems[0]);
                }
            }
        }

        private void addMantraPracticeEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.Tag = "(0,)";
            MantraEffectDescriptionForm form = new MantraEffectDescriptionForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MantraPracticeEffectDescriptionsListView.Items.Add(lvi);
            }
        }

        private void editMantraPracticeEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            if (MantraPracticeEffectDescriptionsListView.SelectedItems.Count > 0)
            {
                MantraEffectDescriptionForm form = new MantraEffectDescriptionForm(MantraPracticeEffectDescriptionsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteMantraPracticeEffectDescriptionButton_Click(object sender, EventArgs e)
        {
            if (MantraPracticeEffectDescriptionsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MantraPracticeEffectDescriptionsListView.Items.Remove(MantraPracticeEffectDescriptionsListView.SelectedItems[0]);
                }
            }
        }

        private void addMantraPropertyEffectsButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Tag = "(0,\"\",\"\",0)";
            MantraPropertyEffectForm form = new MantraPropertyEffectForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MantraPropertyEffectsListView.Items.Add(lvi);
            }
        }

        private void editMantraPropertyEffectsButton_Click(object sender, EventArgs e)
        {
            if (MantraPropertyEffectsListView.SelectedItems.Count > 0)
            {
                MantraPropertyEffectForm form = new MantraPropertyEffectForm(MantraPropertyEffectsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteMantraPropertyEffectsButton_Click(object sender, EventArgs e)
        {
            if (MantraPropertyEffectsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MantraPropertyEffectsListView.Items.Remove(MantraPropertyEffectsListView.SelectedItems[0]);
                }
            }
        }

        private void addBufferEffectsButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.Tag = "(0,)";
            MantraBufferEffectForm form = new MantraBufferEffectForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                BufferEffectsListView.Items.Add(lvi);
            }
        }

        private void editBufferEffectsButton_Click(object sender, EventArgs e)
        {
            if (BufferEffectsListView.SelectedItems.Count > 0)
            {
                MantraBufferEffectForm form = new MantraBufferEffectForm(BufferEffectsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteBufferEffectsButton_Click(object sender, EventArgs e)
        {
            if (BufferEffectsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BufferEffectsListView.Items.Remove(BufferEffectsListView.SelectedItems[0]);
                }
            }
        }
    }

}
