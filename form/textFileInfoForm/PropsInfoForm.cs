
using Heluo.Data;
using Heluo.Utility;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Props = Heluo.Data.Props;

namespace 侠之道mod制作器
{
    public partial class PropsInfoForm : Form
    {

        public string PropsId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public PropsInfoForm()
        {
            InitializeComponent();

            initPropsTypeComboBox();
            initUseTimeComboBox();
        }

        public PropsInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public PropsInfoForm(string PropsId) : this()
        {
            this.PropsId = PropsId;
        }

        public void initPropsTypeComboBox()
        {
            PropsTypeComboBox.DisplayMember = "value";
            PropsTypeComboBox.ValueMember = "key";


            foreach (PropsType temp in Enum.GetValues(typeof(PropsType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                PropsTypeComboBox.Items.Add(cbi);
            }
        }

        public void initUseTimeComboBox()
        {
            UseTimeComboBox.DisplayMember = "value";
            UseTimeComboBox.ValueMember = "key";


            foreach (PropsUseTime temp in Enum.GetValues(typeof(PropsUseTime)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                UseTimeComboBox.Items.Add(cbi);
            }
        }

        public void readPropsInfo()
        {
            idTextBox.Text = PropsId;
            idTextBox.Enabled = false;

            Props Props = DataManager.getData<Props>(PropsId);

            NameTextBox.Text = Props.Name;
            RemarkTextBox.Text = Props.Remark;
            DescriptionTextBox.Text = Props.Description;
            for (int i = 0; i < PropsTypeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)PropsTypeComboBox.Items[i]).key == ((int)Props.PropsType).ToString())
                {
                    PropsTypeComboBox.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < PropsCategoryComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)PropsCategoryComboBox.Items[i]).key == ((int)Props.PropsCategory).ToString())
                {
                    PropsCategoryComboBox.SelectedIndex = i;
                    break;
                }
            }
            ModelTextBox.Text = Props.Model;
            PriceNumericUpDown.Value = Props.Price;
            for (int i = 0; i < UseTimeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)UseTimeComboBox.Items[i]).key == ((int)Props.UseTime).ToString())
                {
                    UseTimeComboBox.SelectedIndex = i;
                    break;
                }
            }
            CanDealsCheckBox.Checked = Props.CanDeals;
            IsShowCheckBox.Checked = Props.IsShow;
            string BuffList = "";
            if (Props.BuffList != null && Props.BuffList.Count > 0)
            {
                for (int i = 0; i < Props.BuffList.Count; i++)
                {
                    BuffList += Props.BuffList[i] + ",";
                }
                BuffList = BuffList.Substring(0, BuffList.Length - 1);
            }
            BuffListTextBox.Text = BuffList;
            Utils.initFlowTreeView(Props.Condition, ConditionTreeView);
            ConditionDescriptionTextBox.Text = Props.ConditionDescription;

            if (Props.PropsEffect != null && Props.PropsEffect.Count > 0)
            {
                for (int i = 0; i < Props.PropsEffect.Count; i++)
                {
                    PropsEffect PropsEffect = Props.PropsEffect[i];
                    ListViewItem lvi = new ListViewItem();
                    switch (PropsEffect.Type)
                    {
                        case PropsEffectType.UpgradableProperty:
                            PropsUpgradableProperty PropsEffect1 = (PropsUpgradableProperty)PropsEffect;
                            lvi.Text = EnumData.GetDisplayName(PropsEffect1.Property) + " 经验增加 " + PropsEffect1.Value;
                            lvi.Tag = "(" + PropsEffect.Type + ", " + PropsEffect1.Property + ", " + PropsEffect1.Value + ")";
                            break;
                        case PropsEffectType.BattleProperty:
                            PropsBattleProperty PropsEffect2 = (PropsBattleProperty)PropsEffect;
                            lvi.Text = EnumData.GetDisplayName(PropsEffect2.Property) + " " + (PropsEffect2.isForever ? "永久" : "临时") + " 增加 " + PropsEffect2.Value;
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect2.Property + ", " + PropsEffect2.isForever + ", " + PropsEffect2.Value + ")";
                            break;
                        case PropsEffectType.Favorable:
                            PropsFavorable PropsEffect3 = (PropsFavorable)PropsEffect;
                            lvi.Text = DataManager.getNpcsName(PropsEffect3.Npcid) + " 的好感增加 " + PropsEffect3.Value;
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect3.Npcid + "," + PropsEffect3.Value + ")";
                            break;
                        case PropsEffectType.Talent:
                            PropsTalent PropsEffect4 = (PropsTalent)PropsEffect;
                            lvi.Text = (PropsEffect4.Method == 1 ? "增加" : "减少") + " " + DataManager.getSkillsName(PropsEffect4.SkillId);
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect4.SkillId + "," + PropsEffect4.Method + ")";
                            break;
                        case PropsEffectType.BattleBuffer:
                            PropsBuffer PropsEffect5 = (PropsBuffer)PropsEffect;
                            lvi.Text = (PropsEffect5.Method == 1 ? "增加" : "减少") + " 状态 " + DataManager.getBuffersName(PropsEffect5.BufferId);
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect5.BufferId + "," + PropsEffect5.Method + ")";
                            break;
                        case PropsEffectType.Hp:
                            PropsHp PropsEffect6 = (PropsHp)PropsEffect;
                            lvi.Text = EnumData.GetDisplayName(PropsEffect6.Method) + " HP " + (PropsEffect6.IsMax ? "最大值" : "当前值") + " " + PropsEffect6.Value;
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect6.Value + "," + PropsEffect6.Method + ", " + PropsEffect6.IsMax + ")";
                            break;
                        case PropsEffectType.Mp:
                            PropsMp PropsEffect7 = (PropsMp)PropsEffect;
                            lvi.Text = EnumData.GetDisplayName(PropsEffect7.Method) + " Mp " + (PropsEffect7.IsMax ? "最大值" : "当前值") + " " + PropsEffect7.Value;
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect7.Value + "," + PropsEffect7.Method + ", " + PropsEffect7.IsMax + ")";
                            break;
                        case PropsEffectType.BattleClearBuffer:
                            PropsClearBuffer PropsEffect8 = (PropsClearBuffer)PropsEffect;
                            lvi.Text = "随机清除 " + EnumData.GetDisplayName(PropsEffect8.Oriented) + " 的buffer " + PropsEffect8.Count + " 个";
                            lvi.Tag = "(" + PropsEffect.Type + "," + PropsEffect8.Oriented + "," + PropsEffect8.Count + ")";
                            break;
                    }
                    PropsEffectListView.Items.Add(lvi);
                }
            }
            PropsEffectDescriptionTextBox.Text = Props.PropsEffectDescription;
            string canUseId = "";
            if (Props.CanUseID != null && Props.CanUseID.Count > 0)
            {
                for (int i = 0; i < Props.CanUseID.Count; i++)
                {
                    canUseId += Props.CanUseID[i] + ",";
                }
                canUseId = canUseId.Substring(0, canUseId.Length - 1);
            }
            CanUseIDTextBox.Text = canUseId;
        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void selectCinematicButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, BuffListTextBox, true);
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, CanUseIDTextBox, true);
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
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入物品名称");
                    return;
                }
                if (string.IsNullOrEmpty(PropsTypeComboBox.Text))
                {
                    MessageBox.Show("请输入大分类");
                    return;
                }
                if (string.IsNullOrEmpty(PropsCategoryComboBox.Text))
                {
                    MessageBox.Show("请输入小分类");
                    return;
                }
                if (string.IsNullOrEmpty(PriceNumericUpDown.Text))
                {
                    MessageBox.Show("请输入价格");
                    return;
                }
                if (string.IsNullOrEmpty(UseTimeComboBox.Text))
                {
                    MessageBox.Show("请输入使用时机");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Props_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + ((ComboBoxItem)PropsTypeComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)PropsCategoryComboBox.SelectedItem).key + "\t" + ModelTextBox.Text + "\t" + ((ComboBoxItem)PropsCategoryComboBox.SelectedItem).key + "\t" + PriceNumericUpDown.Text + "\t" + ((ComboBoxItem)UseTimeComboBox.SelectedItem).key + "\t" + CanDealsCheckBox.Checked + "\t" + IsShowCheckBox.Checked + "\t" + BuffListTextBox.Text + "\t";

                if (ConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + ConditionDescriptionTextBox.Text + "\t" + CanUseIDTextBox.Text + "\t";

                string PropsEffect = "";
                if (PropsEffectListView.Items.Count > 0)
                {
                    for (int i = 0; i < PropsEffectListView.Items.Count; i++)
                    {
                        PropsEffect += PropsEffectListView.Items[i].Tag;
                    }
                }
                replacement += PropsEffect + "\t" + PropsEffectDescriptionTextBox.Text;

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

                DataManager.LoadTextfile(typeof(Props), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Props列表
                //获得列表项
                ListViewItem lvi = DataManager.createPropsLvi(idTextBox.Text);


                

                PropsTabControlUserControl PropsTabControlUserControl = (PropsTabControlUserControl)MainForm.userControls["Props"];

                if (DataManager.allPropsLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allPropsLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allPropsLvis.Add(idTextBox.Text, lvi);
                    PropsTabControlUserControl.getPropsListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PropsCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = string.Format("PropsCategory{0:000}", ((ComboBoxItem)PropsCategoryComboBox.SelectedItem).key);
            if (!text.IsNullOrEmpty())
            {
                IconPictureBox.Image = PropsImageList.Images[PropsImageList.Images.IndexOfKey(text)];
            }
            else
            {
                IconPictureBox.Image = null;
            }
        }

        private void AdditionConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(AdditionConditionNodeListView, ConditionTreeView);
        }

        private void AdditionConditionAddNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(AdditionConditionNodeListView, ConditionTreeView);
        }

        private void AdditionConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ConditionTreeView);
        }

        private void AdditionConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ConditionTreeView);
        }

        private void AdditionConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ConditionTreeView);
        }

        private void addRewardButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = "(,,,)";
            PropsInfoEffectForm form = new PropsInfoEffectForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                PropsEffectListView.Items.Add(lvi);
            }
        }

        private void editRewardButton_Click(object sender, EventArgs e)
        {
            if (PropsEffectListView.SelectedItems.Count > 0)
            {
                PropsInfoEffectForm form = new PropsInfoEffectForm(PropsEffectListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteRewardButton_Click(object sender, EventArgs e)
        {
            if (PropsEffectListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PropsEffectListView.Items.Remove(PropsEffectListView.SelectedItems[0]);
                }
            }
        }

        private void PropsTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropsCategoryComboBox.Items.Clear();
            PropsCategoryComboBox.Text = "";
            IconPictureBox.Image = null;
            PropsCategoryComboBox.DisplayMember = "value";
            PropsCategoryComboBox.ValueMember = "key";

            if (PropsTypeComboBox.SelectedIndex != -1)
            {
                foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
                {
                    if (((int)temp).ToString().Substring(0, 1) == ((ComboBoxItem)PropsTypeComboBox.SelectedItem).key)
                    {
                        ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                        PropsCategoryComboBox.Items.Add(cbi);
                    }
                }
            }
        }
    }

}
