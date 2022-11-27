
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Trait = Heluo.Data.Trait;

namespace 侠之道mod制作器
{
    public partial class TraitInfoForm : Form
    {

        public string TraitId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public TraitInfoForm()
        {
            InitializeComponent();
        }

        public TraitInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public TraitInfoForm(string TraitId) : this()
        {
            this.TraitId = TraitId;
        }

        public void readTraitInfo()
        {
            idTextBox.Text = TraitId;
            idTextBox.Enabled = false;

            Trait Trait = DataManager.getData<Trait>(TraitId);


            NameTextBox.Text = Trait.Name;
            DescriptionTextBox.Text = Trait.Description;
            RemarkTextBox.Text = Trait.Remark;
            IsInitialCheckBox.Checked = Trait.IsInitial;
            PointNumericUpDown.Value = Trait.Point;
            CheckChainTraitListTextBox.Text = Utils.stringListToString(Trait.CheckChainTraitList);
            AddChainTraitListTextBox.Text = Utils.stringListToString(Trait.AddChainTraitList);
            InitialRewardsTextBox.Text = Utils.stringListToString(Trait.InitialRewards);
            if (Trait.TraitEffects != null)
            {
                for (int i = 0; i < Trait.TraitEffects.Count; i++)
                {
                    TraitEffect TraitEffect = Trait.TraitEffects[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = EnumData.GetDisplayName(TraitEffect.Type);
                    lvi.SubItems.Add(EnumData.GetDisplayName(TraitEffect.Property));
                    lvi.SubItems.Add(TraitEffect.Value.ToString());
                    if (TraitEffect.Type == TraitEffectType.SelfBuffer)
                    {
                        lvi.SubItems.Add(DataManager.getBuffersName(TraitEffect.Id));
                    }
                    else if (TraitEffect.Type == TraitEffectType.SkillQuicken)
                    {
                        lvi.SubItems.Add(EnumData.GetDisplayName((PropsCategory)Enum.Parse(typeof(PropsCategory), TraitEffect.Id)));
                    }
                    else
                    {
                        lvi.SubItems.Add("");
                    }
                    lvi.Tag = "(" + TraitEffect.Type + "," + TraitEffect.Property + "," + TraitEffect.Value + "," + TraitEffect.Id + ")";
                    TraitEffectsListView.Items.Add(lvi);
                }
            }
        }

        private void selectCheckChainTraitButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, CheckChainTraitListTextBox, true);
            form.ShowDialog();
        }

        private void selectAddChainTraitButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, AddChainTraitListTextBox, true);
            form.ShowDialog();
        }

        private void selectRewardButton_Click(object sender, EventArgs e)
        {
            SelectRewardForm form = new SelectRewardForm(this, InitialRewardsTextBox, true);
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
                    MessageBox.Show("请输入等级");
                    return;
                }
                if (string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    MessageBox.Show("请输入描述");
                    return;
                }
                if (string.IsNullOrEmpty(PointNumericUpDown.Text))
                {
                    MessageBox.Show("请输入点数消耗");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Trait_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + IsInitialCheckBox.Checked + "\t" + PointNumericUpDown.Text + "\t" + CheckChainTraitListTextBox.Text + "\t" + AddChainTraitListTextBox.Text + "\t";
                if (TraitEffectsListView.Items.Count > 0)
                {
                    for (int i = 0; i < TraitEffectsListView.Items.Count; i++)
                    {
                        replacement += TraitEffectsListView.Items[i].Tag.ToString();
                    }
                }
                replacement += "\t";
                replacement += InitialRewardsTextBox.Text;


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

                DataManager.LoadTextfile(typeof(Trait), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Trait列表
                //获得列表项
                ListViewItem lvi = DataManager.createTraitLvi(idTextBox.Text);


                

                TraitTabControlUserControl TraitTabControlUserControl = (TraitTabControlUserControl)MainForm.userControls["Trait"];

                if (DataManager.allTraitLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allTraitLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allTraitLvis.Add(idTextBox.Text, lvi);
                    TraitTabControlUserControl.getTraitListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addSkillButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Tag = "(,0,0,)";
            TraitEffectTypeForm form = new TraitEffectTypeForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TraitEffectsListView.Items.Add(lvi);
            }
        }

        private void editSkillButton_Click(object sender, EventArgs e)
        {
            if (TraitEffectsListView.SelectedItems.Count > 0)
            {
                TraitEffectTypeForm form = new TraitEffectTypeForm(TraitEffectsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteSkillButton_Click(object sender, EventArgs e)
        {
            if (TraitEffectsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    TraitEffectsListView.Items.Remove(TraitEffectsListView.SelectedItems[0]);
                }
            }
        }
    }

}
