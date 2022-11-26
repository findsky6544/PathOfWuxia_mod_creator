
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Evaluation = Heluo.Data.Evaluation;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class EvaluationInfoForm : Form
    {

        public string EvaluationId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public EvaluationInfoForm()
        {
            InitializeComponent();
            initListView();
        }

        public EvaluationInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public EvaluationInfoForm(string EvaluationId) : this()
        {
            this.EvaluationId = EvaluationId;
        }

        public void initListView()
        {
            foreach (EvaluationPoint temp in Enum.GetValues(typeof(EvaluationPoint)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string Description = "";
                int value = 0;
                lvi.Tag = "[" + (int)temp + ",(" + Description + "," + value + ")]";
                lvi.SubItems.Add(Description);
                lvi.SubItems.Add(value.ToString());
                EvaluationPointInfoListView.Items.Add(lvi);
            }
            foreach (EvaluationLevel temp in Enum.GetValues(typeof(EvaluationLevel)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string propsId = "";
                int count = 0;
                lvi.Tag = "[" + (int)temp + ",(" + propsId + "," + count + ")]";
                lvi.SubItems.Add(DataManager.getPropssName(propsId));
                lvi.SubItems.Add(count.ToString());
                EvaluationRewardListView.Items.Add(lvi);
            }
        }

        public void readEvaluationInfo()
        {
            idTextBox.Text = EvaluationId;
            idTextBox.Enabled = false;

            Evaluation Evaluation = DataManager.getData<Evaluation>(EvaluationId);

            NameTextBox.Text = Evaluation.Name;
            RemarkTextBox.Text = Evaluation.Remark;
            DescriptionTextBox.Text = Evaluation.Description;
            EvaluationPointInfoListView.Items.Clear();
            foreach (EvaluationPoint temp in Enum.GetValues(typeof(EvaluationPoint)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string Description = "";
                int value = 0;
                if (Evaluation.EvaluationPointInfo != null && Evaluation.EvaluationPointInfo[temp] != null)
                {
                    Description = Evaluation.EvaluationPointInfo[temp].Description;
                    value = Evaluation.EvaluationPointInfo[temp].Value;
                }
                lvi.Tag = "[" + (int)temp + ",(" + Description + "," + value + ")]";
                lvi.SubItems.Add(Description);
                lvi.SubItems.Add(value.ToString());
                EvaluationPointInfoListView.Items.Add(lvi);
            }
            EvaluationRewardListView.Items.Clear();
            foreach (EvaluationLevel temp in Enum.GetValues(typeof(EvaluationLevel)))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = EnumData.GetDisplayName(temp);
                string propsId = "";
                int count = 0;
                if (Evaluation.EvaluationReward != null && Evaluation.EvaluationReward[temp] != null)
                {
                    propsId = Evaluation.EvaluationReward[temp].Id;
                    count = Evaluation.EvaluationReward[temp].Count;
                }
                lvi.Tag = "[" + (int)temp + ",(" + propsId + "," + count + ")]";
                lvi.SubItems.Add(DataManager.getPropssName(propsId));
                lvi.SubItems.Add(count.ToString());
                EvaluationRewardListView.Items.Add(lvi);
            }
        }

        private void selectTalentsButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, NameTextBox, true);
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
                    MessageBox.Show("请输入名称");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Evaluation.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + DescriptionTextBox.Text + "\t";

                if (EvaluationPointInfoListView.Items.Count > 0)
                {
                    for (int i = 0; i < EvaluationPointInfoListView.Items.Count; i++)
                    {
                        if (EvaluationPointInfoListView.Items[i].SubItems[1].Text != "")
                        {
                            replacement += EvaluationPointInfoListView.Items[i].Tag.ToString();
                        }
                    }
                }
                replacement += "\t";
                if (EvaluationRewardListView.Items.Count > 0)
                {
                    for (int i = 0; i < EvaluationRewardListView.Items.Count; i++)
                    {
                        if (EvaluationRewardListView.Items[i].SubItems[1].Text != "(空)")
                        {
                            replacement += EvaluationRewardListView.Items[i].Tag.ToString();
                        }
                    }
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

                DataManager.LoadTextfile(typeof(Evaluation), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Evaluation列表
                //获得列表项
                ListViewItem lvi = DataManager.createEvaluationLvi(idTextBox.Text);


                

                EvaluationTabControlUserControl EvaluationTabControlUserControl = (EvaluationTabControlUserControl)MainForm.userControls["Evaluation"];

                if (DataManager.allEvaluationLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allEvaluationLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allEvaluationLvis.Add(idTextBox.Text, lvi);
                    EvaluationTabControlUserControl.getEvaluationListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editEquipButton_Click(object sender, EventArgs e)
        {
            if (EvaluationPointInfoListView.SelectedItems.Count > 0)
            {
                EvaluationPointForm form = new EvaluationPointForm(EvaluationPointInfoListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void editPropertyButton_Click(object sender, EventArgs e)
        {
            if (EvaluationRewardListView.SelectedItems.Count > 0)
            {
                EvaluationLevelForm form = new EvaluationLevelForm(EvaluationRewardListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }
    }

}
