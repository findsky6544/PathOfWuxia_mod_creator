
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static 侠之道mod制作器.SelectSkillForm;
using CharacterInfo = Heluo.Data.CharacterInfo;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoInfoForm : Form
    {

        public string CharacterInfoId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public CharacterInfoInfoForm()
        {
            InitializeComponent();

            initElementComboBox();
            initListView();
        }

        public CharacterInfoInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public CharacterInfoInfoForm(string CharacterInfoId) : this()
        {
            this.CharacterInfoId = CharacterInfoId;
        }

        public void initElementComboBox()
        {
            ElementComboBox.DisplayMember = "value";
            ElementComboBox.ValueMember = "key";


            foreach (Element temp in Enum.GetValues(typeof(Element)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ElementComboBox.Items.Add(cbi);
            }
        }

        public void initListView()
        {
            foreach (EquipType temp in Enum.GetValues(typeof(EquipType)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string equip = "";
                lvi.Tag = "(" + (int)temp + "," + equip + ")";
                lvi.SubItems.Add(DataManager.getPropssName(equip));
                EquipListView.Items.Add(lvi);
            }
            foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string property = "0";
                lvi.Tag = "(" + (int)temp + "," + property + ")";
                lvi.SubItems.Add(property);
                PropertyListView.Items.Add(lvi);
            }
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string upgradableProperty = "0";
                lvi.Tag = "(" + (int)temp + "," + upgradableProperty + ")";
                lvi.SubItems.Add(upgradableProperty);
                UpgradeablePropertyListView.Items.Add(lvi);
            }
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string min = "0";
                string max = "0";
                lvi.Tag = "[" + (int)temp + ",(" + min + "," + max + ")]";
                lvi.SubItems.Add(min);
                lvi.SubItems.Add(max);
                GrowPropertyListView.Items.Add(lvi);
            }
        }

        public void readCharacterInfoInfo()
        {
            idTextBox.Text = CharacterInfoId;
            idTextBox.Enabled = false;

            CharacterInfo CharacterInfo = DataManager.getData<CharacterInfo>(CharacterInfoId);

            RemarkTextBox.Text = CharacterInfo.Remark;
            LevelNumericUpDown.Text = CharacterInfo.Level.ToString();
            for (int i = 0; i < ElementComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)ElementComboBox.Items[i]).key == ((int)CharacterInfo.Element).ToString())
                {
                    ElementComboBox.SelectedIndex = i;
                    break;
                }
            }
            CanChangeElementCheckBox.Checked = CharacterInfo.CanChangeElement;
            EquipListView.Items.Clear();
            foreach (EquipType temp in Enum.GetValues(typeof(EquipType)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string equip = "";
                if (CharacterInfo.Equip != null && CharacterInfo.Equip[temp] != null)
                {
                    equip = CharacterInfo.Equip[temp];
                }
                lvi.Tag = "(" + (int)temp + "," + equip + ")";
                lvi.SubItems.Add(DataManager.getPropssName(equip));
                EquipListView.Items.Add(lvi);
            }
            PropertyListView.Items.Clear();
            foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string property = "0";
                if (CharacterInfo.Property != null && CharacterInfo.Property[temp] != 0)
                {
                    property = CharacterInfo.Property[temp].ToString();
                }
                lvi.Tag = "(" + (int)temp + "," + property + ")";
                lvi.SubItems.Add(property);
                PropertyListView.Items.Add(lvi);
            }
            UpgradeablePropertyListView.Items.Clear();
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string upgradableProperty = "0";
                if (CharacterInfo.UpgradeableProperty != null && CharacterInfo.UpgradeableProperty[temp] != 0)
                {
                    upgradableProperty = CharacterInfo.UpgradeableProperty[temp].ToString();
                }
                lvi.Tag = "(" + (int)temp + "," + upgradableProperty + ")";
                lvi.SubItems.Add(upgradableProperty);
                UpgradeablePropertyListView.Items.Add(lvi);
            }
            GrowPropertyListView.Items.Clear();
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string min = "0";
                string max = "0";
                if (CharacterInfo.GrowProperty != null && CharacterInfo.GrowProperty[temp] != null)
                {
                    min = CharacterInfo.GrowProperty[temp].Min.ToString();
                    max = CharacterInfo.GrowProperty[temp].Max.ToString();
                }
                lvi.Tag = "[" + (int)temp + ",(" + min + "," + max + ")]";
                lvi.SubItems.Add(min);
                lvi.SubItems.Add(max);
                GrowPropertyListView.Items.Add(lvi);
            }
            GrowthFactorNumericUpDown.Text = CharacterInfo.GrowthFactor.ToString();
            string Talents = "";
            if (CharacterInfo.Talents != null && CharacterInfo.Talents.Count > 0)
            {
                for (int i = 0; i < CharacterInfo.Talents.Count; i++)
                {
                    Talents += CharacterInfo.Talents[i] + ",";
                }
                Talents = Talents.Substring(0, Talents.Length - 1);
            }
            TalentsTextBox.Text = Talents;
            if (CharacterInfo.Skills != null && CharacterInfo.Skills.Count > 0)
            {
                for (int i = 0; i < CharacterInfo.Skills.Count; i++)
                {
                    CharacterSkill Skill = CharacterInfo.Skills[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = EnumData.GetDisplayName(Skill.Column);
                    lvi.SubItems.Add(DataManager.getSkillsName(Skill.Id));
                    lvi.SubItems.Add(Skill.Level.ToString());
                    lvi.Tag = "(" + (int)Skill.Column + "," + Skill.Id + "," + Skill.Level + ")";
                    SkillsListView.Items.Add(lvi);
                }
            }
            if (CharacterInfo.Mantras != null && CharacterInfo.Mantras.Count > 0)
            {
                for (int i = 0; i < CharacterInfo.Mantras.Count; i++)
                {
                    CharacterMantra mantra = CharacterInfo.Mantras[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DataManager.getMantraName(mantra.Id);
                    lvi.SubItems.Add(mantra.Level.ToString());
                    lvi.SubItems.Add(mantra.IsWork.ToString());
                    lvi.Tag = "(" + mantra.Id + "," + mantra.Level + "," + mantra.IsWork + ")";
                    MantrasListView.Items.Add(lvi);
                }
            }
            SpecialTextBox.Text = CharacterInfo.Special;
            string dropRewards = "";
            if (CharacterInfo.DropRewards != null && CharacterInfo.DropRewards.Count > 0)
            {
                for (int i = 0; i < CharacterInfo.DropRewards.Count; i++)
                {
                    dropRewards += CharacterInfo.DropRewards[i] + ",";
                }
                dropRewards = dropRewards.Substring(0, dropRewards.Length - 1);
            }
            DropRewardsTextBox.Text = dropRewards;
        }

        private void selectTalentsButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, TalentsTextBox, true);
            form.ShowDialog();
        }

        private void selectSpecialButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, SpecialTextBox, false, selectSkillType.special);
            form.ShowDialog();
        }

        private void selectRewardButton_Click(object sender, EventArgs e)
        {
            SelectRewardForm form = new SelectRewardForm(this, DropRewardsTextBox, true);
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
                if (string.IsNullOrEmpty(LevelNumericUpDown.Text))
                {
                    MessageBox.Show("请输入等级");
                    return;
                }
                if (string.IsNullOrEmpty(ElementComboBox.Text))
                {
                    MessageBox.Show("请输入功体");
                    return;
                }
                if (string.IsNullOrEmpty(GrowthFactorNumericUpDown.Text))
                {
                    MessageBox.Show("请输入人物成长因子");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\CharacterInfo_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + LevelNumericUpDown.Text + "\t" + ((ComboBoxItem)ElementComboBox.SelectedItem).key + "\t" + CanChangeElementCheckBox.Checked + "\t";

                if (EquipListView.Items.Count > 0)
                {
                    for (int i = 0; i < EquipListView.Items.Count; i++)
                    {
                        if (EquipListView.Items[i].SubItems[1].Text != "(空)")
                        {
                            replacement += EquipListView.Items[i].Tag.ToString();
                        }
                    }
                }
                replacement += "\t";
                if (PropertyListView.Items.Count > 0)
                {
                    for (int i = 0; i < PropertyListView.Items.Count; i++)
                    {
                        if (PropertyListView.Items[i].SubItems[1].Text != "0")
                        {
                            replacement += PropertyListView.Items[i].Tag.ToString();
                        }
                    }
                }
                replacement += "\t";
                if (UpgradeablePropertyListView.Items.Count > 0)
                {
                    for (int i = 0; i < UpgradeablePropertyListView.Items.Count; i++)
                    {
                        if (UpgradeablePropertyListView.Items[i].SubItems[1].Text != "0")
                        {
                            replacement += UpgradeablePropertyListView.Items[i].Tag.ToString();
                        }
                    }
                }
                replacement += "\t";
                if (GrowPropertyListView.Items.Count > 0)
                {
                    for (int i = 0; i < GrowPropertyListView.Items.Count; i++)
                    {
                        if (GrowPropertyListView.Items[i].SubItems[1].Text != "0" && GrowPropertyListView.Items[i].SubItems[2].Text != "0")
                        {
                            replacement += GrowPropertyListView.Items[i].Tag.ToString();
                        }
                    }
                }
                replacement += "\t";
                replacement += GrowthFactorNumericUpDown.Text + "\t" + TalentsTextBox.Text + "\t";
                if (SkillsListView.Items.Count > 0)
                {
                    for (int i = 0; i < SkillsListView.Items.Count; i++)
                    {
                        replacement += SkillsListView.Items[i].Tag.ToString();
                    }
                }
                replacement += "\t";
                if (MantrasListView.Items.Count > 0)
                {
                    for (int i = 0; i < MantrasListView.Items.Count; i++)
                    {
                        replacement += MantrasListView.Items[i].Tag.ToString();
                    }
                }
                replacement += "\t";
                replacement += SpecialTextBox.Text + "\t" + DropRewardsTextBox.Text;



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

                DataManager.LoadTextfile(typeof(CharacterInfo), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新CharacterInfo列表
                //获得列表项
                ListViewItem lvi = DataManager.createCharacterInfoLvi(idTextBox.Text);


                

                CharacterInfoTabControlUserControl CharacterInfoTabControlUserControl = (CharacterInfoTabControlUserControl)MainForm.userControls["CharacterInfo"];

                if (DataManager.allCharacterInfoLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allCharacterInfoLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allCharacterInfoLvis.Add(idTextBox.Text, lvi);
                    CharacterInfoTabControlUserControl.getCharacterInfoListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editEquipButton_Click(object sender, EventArgs e)
        {
            if (EquipListView.SelectedItems.Count > 0)
            {
                CharacterInfoEquipForm form = new CharacterInfoEquipForm(EquipListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void editPropertyButton_Click(object sender, EventArgs e)
        {
            if (PropertyListView.SelectedItems.Count > 0)
            {
                CharacterInfoPropertyForm form = new CharacterInfoPropertyForm(PropertyListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void editUpgradeablePropertyButton_Click(object sender, EventArgs e)
        {
            if (UpgradeablePropertyListView.SelectedItems.Count > 0)
            {
                CharacterInfoUpgradeablePropertyForm form = new CharacterInfoUpgradeablePropertyForm(UpgradeablePropertyListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void editGrowPropertyButton_Click(object sender, EventArgs e)
        {
            if (GrowPropertyListView.SelectedItems.Count > 0)
            {
                CharacterInfoGrowPropertyForm form = new CharacterInfoGrowPropertyForm(GrowPropertyListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Tag = "(-1,,0)";
            CharacterInfoSkillForm form = new CharacterInfoSkillForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                SkillsListView.Items.Add(lvi);
            }
        }

        private void editSkillButton_Click(object sender, EventArgs e)
        {
            if (SkillsListView.SelectedItems.Count > 0)
            {
                CharacterInfoSkillForm form = new CharacterInfoSkillForm(SkillsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteSkillButton_Click(object sender, EventArgs e)
        {
            if (SkillsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SkillsListView.Items.Remove(SkillsListView.SelectedItems[0]);
                }
            }
        }

        private void addMantraButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Tag = "(,0,false)";
            CharacterInfoMantraForm form = new CharacterInfoMantraForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                MantrasListView.Items.Add(lvi);
            }
        }

        private void editMantraButton_Click(object sender, EventArgs e)
        {
            if (MantrasListView.SelectedItems.Count > 0)
            {
                CharacterInfoMantraForm form = new CharacterInfoMantraForm(MantrasListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteMantraButton_Click(object sender, EventArgs e)
        {
            if (MantrasListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    MantrasListView.Items.Remove(MantrasListView.SelectedItems[0]);
                }
            }
        }
    }

}
