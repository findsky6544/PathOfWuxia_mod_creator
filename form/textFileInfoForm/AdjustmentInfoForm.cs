using Heluo.Data;
using Heluo.Flow;
using Heluo.Utility;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Adjustment = Heluo.Data.Adjustment;

namespace 侠之道mod制作器
{
    public partial class AdjustmentInfoForm : Form
    {

        public string AdjustmentId;

        public AdjustmentInfoForm()
        {
            InitializeComponent();

            initElementComboBox();
        }

        public AdjustmentInfoForm(string AdjustmentId,bool canEdit) : this()
        {
            this.AdjustmentId = AdjustmentId;

            if (!canEdit)
            {
                saveButton.Visible = false;

                foreach(Control control in panel1.Controls)
                {
                    if(control is TextBox || control is ComboBox || control is NumericUpDown)
                    {
                        control.Enabled = false;
                    }
                }
                selectMustMemberButton.Enabled = false;
                selectProhibitMemberButton.Enabled = false;

                selectCinematicButton.Text = "查看演出";
                selectCinematicButton.Click -= selectCinematicButton_Click;
                selectCinematicButton.Click += readCinematicToolStripMenuItem_Click;
            }

            if (!AdjustmentId.IsNullOrEmpty())
            {
                readAdjustmentInfo();
            }
        }
        private void readCinematicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CinematicInfoForm form = new CinematicInfoForm(CinematicIdTextBox.Text, false);

            form.Show();
        }

        public void initElementComboBox()
        {
            RecommendationElementComboBox.DisplayMember = "value";
            RecommendationElementComboBox.ValueMember = "key";
            OpposeElementComboBox.DisplayMember = "value";
            OpposeElementComboBox.ValueMember = "key";
            foreach (Element temp in Enum.GetValues(typeof(Element)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                RecommendationElementComboBox.Items.Add(cbi);
                OpposeElementComboBox.Items.Add(cbi);
            }
        }

        public void readAdjustmentInfo()
        {
            idTextBox.Text = AdjustmentId;
            idTextBox.Enabled = false;

            Adjustment Adjustment = DataManager.getData<Adjustment>(AdjustmentId);

            NameTextBox.Text = string.IsNullOrEmpty(Adjustment.Name) ? "" : Adjustment.Name;
            RemarkTextBox.Text = string.IsNullOrEmpty(Adjustment.Remark) ? "" : Adjustment.Remark;
            DescriptionTextBox.Text = string.IsNullOrEmpty(Adjustment.Description) ? "" : Adjustment.Description;

            for (int i = 0; i < RecommendationElementComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)RecommendationElementComboBox.Items[i]).key == ((int)Adjustment.RecommendationElement).ToString())
                {
                    RecommendationElementComboBox.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < OpposeElementComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)OpposeElementComboBox.Items[i]).key == ((int)Adjustment.OpposeElement).ToString())
                {
                    OpposeElementComboBox.SelectedIndex = i;
                    break;
                }
            }
            MinPartyCountNumericUpDown.Value = Adjustment.MinPartyCount;
            MaxPartyCountNumericUpDown.Value = Adjustment.MaxPartyCount;
            string mustMember = "";
            if (Adjustment.MustMember != null && Adjustment.MustMember.Count > 0)
            {
                for (int i = 0; i < Adjustment.MustMember.Count; i++)
                {
                    mustMember += Adjustment.MustMember[i] + ",";
                }
                mustMember = mustMember.Substring(0, mustMember.Length - 1);
            }
            MustMemberTextBox.Text = mustMember;
            string ProhibitMember = "";
            if (Adjustment.ProhibitMember != null && Adjustment.ProhibitMember.Count > 0)
            {
                for (int i = 0; i < Adjustment.ProhibitMember.Count; i++)
                {
                    ProhibitMember += Adjustment.ProhibitMember[i] + ",";
                }
                ProhibitMember = ProhibitMember.Substring(0, ProhibitMember.Length - 1);
            }
            ProhibitMemberTextBox.Text = ProhibitMember;
            CinematicIdTextBox.Text = Adjustment.CinematicId;
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
                if (string.IsNullOrEmpty(RecommendationElementComboBox.Text))
                {
                    MessageBox.Show("请选择建议功体");
                    return;
                }
                if (string.IsNullOrEmpty(OpposeElementComboBox.Text))
                {
                    MessageBox.Show("请选择不建议功体");
                    return;
                }
                if (string.IsNullOrEmpty(CinematicIdTextBox.Text))
                {
                    MessageBox.Show("请输入接续演出编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\Adjustment_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + ((ComboBoxItem)RecommendationElementComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)OpposeElementComboBox.SelectedItem).key + "\t" + MinPartyCountNumericUpDown.Text + "\t" + MaxPartyCountNumericUpDown.Text + "\t" + MustMemberTextBox.Text + "\t" + ProhibitMemberTextBox.Text + "\t" + CinematicIdTextBox.Text;
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

                DataManager.LoadTextfile(typeof(Adjustment), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新adjustment列表
                //获得列表项
                ListViewItem lvi = DataManager.createAdjustmentLvi(idTextBox.Text);

                

                AdjustmentTabControlUserControl adjustmentTabControlUserControl = (AdjustmentTabControlUserControl)MainForm.userControls["Adjustment"];
                if (DataManager.allAdjustmentLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allAdjustmentLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allAdjustmentLvis.Add(idTextBox.Text, lvi);
                    adjustmentTabControlUserControl.getAdjustmentListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectMustMemberButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm selectNpcForm = new SelectNpcForm(this, MustMemberTextBox, true);
            selectNpcForm.ShowDialog();
        }

        private void selectProhibitMemberButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm selectNpcForm = new SelectNpcForm(this, ProhibitMemberTextBox, true);
            selectNpcForm.ShowDialog();
        }

        private void selectCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm selectCinematicForm = new SelectCinematicForm(this, CinematicIdTextBox, false);
            selectCinematicForm.ShowDialog();
        }
    }

}
