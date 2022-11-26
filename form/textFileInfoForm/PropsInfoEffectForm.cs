using Heluo.Data;
using Heluo.Flow;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PropsInfoEffectForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public PropsInfoEffectForm()
        {
            InitializeComponent();

            initTypeComboBox();
            initUpgradablePropertyPropertyComboBox();
            initBattlePropertyPropertyComboBox();
            initMethodComboBox();
            initHpMethodComboBox();
            initOrientedComboBox();
        }
        public PropsInfoEffectForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            Owner = owner;
            Text = owner.Text + Text;

            string fields = "";
            fields = lvi.Tag.ToString();

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < TypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)TypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        TypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                if (TypeComboBox.SelectedIndex != -1)
                {
                    switch ((PropsEffectType)Enum.Parse(typeof(PropsEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key))
                    {
                        case PropsEffectType.UpgradableProperty:
                            for (int i = 0; i < UpgradablePropertyPropertyComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)UpgradablePropertyPropertyComboBox.Items[i]).key == fieldsList[1].Trim())
                                {
                                    UpgradablePropertyPropertyComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            UpgradablePropertyValueNumericUpDown.Text = fieldsList[2].Trim();
                            break;
                        case PropsEffectType.BattleProperty:
                            for (int i = 0; i < BattlePropertyPropertyComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)BattlePropertyPropertyComboBox.Items[i]).key == fieldsList[1].Trim())
                                {
                                    BattlePropertyPropertyComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            BattlePropertyIsForeverCheckBox.Checked = fieldsList[2].Trim() == "True";
                            BattlePropertyValueNumericUpDown.Text = fieldsList[3].Trim();
                            break;
                        case PropsEffectType.Favorable:
                            FavorableNpcIdTextBox.Text = fieldsList[1].Trim();
                            FavorableValueNumericUpDown.Text = fieldsList[2].Trim();
                            break;
                        case PropsEffectType.Talent:
                            break;
                        case PropsEffectType.BattleBuffer:
                            BattleBufferBufferIdTextBox.Text = fieldsList[1].Trim();
                            for (int i = 0; i < BattleBufferMethodComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)BattleBufferMethodComboBox.Items[i]).key == fieldsList[2].Trim())
                                {
                                    BattleBufferMethodComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            break;
                        case PropsEffectType.Hp:
                            HpValueNumericUpDown.Text = fieldsList[1].Trim();
                            for (int i = 0; i < HpMethodComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)HpMethodComboBox.Items[i]).key == fieldsList[2].Trim())
                                {
                                    HpMethodComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            HpIsMaxCheckBox.Checked = fieldsList[3] == "True";
                            break;
                        case PropsEffectType.Mp:
                            MpValueNumericUpDown.Text = fieldsList[1].Trim();
                            for (int i = 0; i < MpMethodComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)MpMethodComboBox.Items[i]).key == fieldsList[2].Trim())
                                {
                                    MpMethodComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            MpIsMaxCheckBox.Checked = fieldsList[3] == "True";
                            break;
                        case PropsEffectType.BattleClearBuffer:
                            for (int i = 0; i < OrientedComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)OrientedComboBox.Items[i]).key == fieldsList[1].Trim())
                                {
                                    OrientedComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            CountNumericUpDown.Text = fieldsList[2].Trim();
                            break;
                    }
                }
            }
        }

        public void initTypeComboBox()
        {
            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";
            foreach (PropsEffectType temp in Enum.GetValues(typeof(PropsEffectType)))
            {
                if (temp == PropsEffectType.Talent)
                {
                    continue;
                }
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }

        public void initUpgradablePropertyPropertyComboBox()
        {
            UpgradablePropertyPropertyComboBox.DisplayMember = "value";
            UpgradablePropertyPropertyComboBox.ValueMember = "key";
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName(temp));
                UpgradablePropertyPropertyComboBox.Items.Add(cbi);
            }
        }

        public void initBattlePropertyPropertyComboBox()
        {
            BattlePropertyPropertyComboBox.DisplayMember = "value";
            BattlePropertyPropertyComboBox.ValueMember = "key";
            foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName(temp));
                BattlePropertyPropertyComboBox.Items.Add(cbi);
            }
        }

        public void initMethodComboBox()
        {
            BattleBufferMethodComboBox.DisplayMember = "value";
            BattleBufferMethodComboBox.ValueMember = "key";

            ComboBoxItem cbi = new ComboBoxItem("1", "增加");
            BattleBufferMethodComboBox.Items.Add(cbi);
            cbi = new ComboBoxItem("2", "减少");
            BattleBufferMethodComboBox.Items.Add(cbi);
        }

        public void initHpMethodComboBox()
        {
            HpMethodComboBox.DisplayMember = "value";
            HpMethodComboBox.ValueMember = "key";
            MpMethodComboBox.DisplayMember = "value";
            MpMethodComboBox.ValueMember = "key";
            foreach (Method temp in Enum.GetValues(typeof(Method)))
            {
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName(temp));
                HpMethodComboBox.Items.Add(cbi);
                MpMethodComboBox.Items.Add(cbi);
            }
        }

        public void initOrientedComboBox()
        {
            OrientedComboBox.DisplayMember = "value";
            OrientedComboBox.ValueMember = "key";
            foreach (BufferOriented temp in Enum.GetValues(typeof(BufferOriented)))
            {
                ComboBoxItem cbi = new ComboBoxItem(temp.ToString(), EnumData.GetDisplayName(temp));
                OrientedComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (TypeComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入类型");
                return;
            }
            string text = "";
            string tag = "";
            switch ((PropsEffectType)Enum.Parse(typeof(PropsEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key))
            {
                case PropsEffectType.UpgradableProperty:
                    if (UpgradablePropertyPropertyComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入属性");
                        return;
                    }
                    if (UpgradablePropertyValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入值");
                        return;
                    }
                    text = UpgradablePropertyPropertyComboBox.Text + " 经验增加 " + UpgradablePropertyValueNumericUpDown.Text;
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + ((ComboBoxItem)UpgradablePropertyPropertyComboBox.SelectedItem).key + ", " + UpgradablePropertyValueNumericUpDown.Text + ")";
                    break;
                case PropsEffectType.BattleProperty:
                    if (BattlePropertyPropertyComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入属性");
                        return;
                    }
                    if (BattlePropertyValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入值");
                        return;
                    }
                    text = BattlePropertyPropertyComboBox.Text + " " + (BattlePropertyIsForeverCheckBox.Checked ? "永久" : "临时") + " 增加 " + BattlePropertyValueNumericUpDown.Text;
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + ((ComboBoxItem)BattlePropertyPropertyComboBox.SelectedItem).key + ", " + BattlePropertyIsForeverCheckBox.Checked + ", " + BattlePropertyValueNumericUpDown.Text + ")";
                    break;
                case PropsEffectType.Favorable:
                    if (FavorableNpcIdTextBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入npc编号");
                        return;
                    }
                    if (FavorableValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入值");
                        return;
                    }
                    text = DataManager.getNpcsName(FavorableNpcIdTextBox.Text) + " 的好感增加 " + FavorableValueNumericUpDown.Text;
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + FavorableNpcIdTextBox.Text + ", " + FavorableValueNumericUpDown.Text + ")";
                    break;
                case PropsEffectType.Talent:
                    break;
                case PropsEffectType.BattleBuffer:
                    if (BattleBufferBufferIdTextBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入buffer编号");
                        return;
                    }
                    if (BattleBufferMethodComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入操作");
                        return;
                    }
                    text = BattleBufferMethodComboBox.Text + " 状态 " + DataManager.getBuffersName(BattleBufferBufferIdTextBox.Text);
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + BattleBufferBufferIdTextBox.Text + ", " + ((ComboBoxItem)BattleBufferMethodComboBox.SelectedItem).key + ")";
                    break;
                case PropsEffectType.Hp:
                    if (HpMethodComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入作用方式");
                        return;
                    }
                    if (HpValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入增加数值");
                        return;
                    }
                    text = HpMethodComboBox.Text + " HP " + (HpIsMaxCheckBox.Checked ? "最大值" : "当前值") + " " + HpValueNumericUpDown.Text;
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + HpValueNumericUpDown.Text + ", " + ((ComboBoxItem)HpMethodComboBox.SelectedItem).key + ", " + HpIsMaxCheckBox.Checked + ")";
                    break;
                case PropsEffectType.Mp:
                    if (MpMethodComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入作用方式");
                        return;
                    }
                    if (MpValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入增加数值");
                        return;
                    }
                    text = MpMethodComboBox.Text + " Mp " + (MpIsMaxCheckBox.Checked ? "最大值" : "当前值") + " " + MpValueNumericUpDown.Text;
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + MpValueNumericUpDown.Text + ", " + ((ComboBoxItem)MpMethodComboBox.SelectedItem).key + ", " + MpIsMaxCheckBox.Checked + ")";
                    break;
                case PropsEffectType.BattleClearBuffer:
                    if (OrientedComboBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入状态类型");
                        return;
                    }
                    if (CountNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入数量");
                        return;
                    }
                    text = "随机清除 " + OrientedComboBox.Text + " 的buffer " + CountNumericUpDown.Text + " 个";
                    tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + ((ComboBoxItem)OrientedComboBox.SelectedItem).key + ", " + CountNumericUpDown.Text + ")";
                    break;
            }


            lvi.Tag = tag;
            lvi.Text = text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropsEffectType type = (PropsEffectType)Enum.Parse(typeof(PropsEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key);

            UpgradablePropertyPanel.Visible = false;
            BattlePropertyPanel.Visible = false;
            FavorablePanel.Visible = false;
            TalentPanel.Visible = false;
            BattleBufferPanel.Visible = false;
            HpPanel.Visible = false;
            MpPanel.Visible = false;
            BattleClearBufferPanel.Visible = false;

            switch (type)
            {
                case PropsEffectType.UpgradableProperty:
                    UpgradablePropertyPanel.Visible = true;
                    break;
                case PropsEffectType.BattleProperty:
                    BattlePropertyPanel.Visible = true;
                    break;
                case PropsEffectType.Favorable:
                    FavorablePanel.Visible = true;
                    break;
                case PropsEffectType.Talent:
                    TalentPanel.Visible = true;
                    break;
                case PropsEffectType.BattleBuffer:
                    BattleBufferPanel.Visible = true;
                    break;
                case PropsEffectType.Hp:
                    HpPanel.Visible = true;
                    break;
                case PropsEffectType.Mp:
                    MpPanel.Visible = true;
                    break;
                case PropsEffectType.BattleClearBuffer:
                    BattleClearBufferPanel.Visible = true;
                    break;
            }
        }

        private void FavorableSelectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, FavorableNpcIdTextBox, false);
            form.ShowDialog();
        }

        private void BattleBufferSelectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, BattleBufferBufferIdTextBox, false);
            form.ShowDialog();
        }
    }
}
