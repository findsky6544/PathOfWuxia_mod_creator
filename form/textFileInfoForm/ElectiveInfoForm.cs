using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Elective = Heluo.Data.Elective;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class ElectiveInfoForm : Form
    {

        public string ElectiveId;

        public string currentCell = "";
        public int selectCellNumber = -1;
        public ElectiveInfoForm()
        {
            InitializeComponent();

            initGradeComboBox();
        }

        public ElectiveInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public ElectiveInfoForm(string ElectiveId) : this()
        {
            this.ElectiveId = ElectiveId;
        }

        public void initGradeComboBox()
        {
            GradeComboBox.DisplayMember = "value";
            GradeComboBox.ValueMember = "key";


            foreach (Grade temp in Enum.GetValues(typeof(Grade)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                GradeComboBox.Items.Add(cbi);
            }
        }

        public void readElectiveInfo()
        {
            idTextBox.Text = ElectiveId;
            idTextBox.Enabled = false;

            Elective Elective = DataManager.getData<Elective>(ElectiveId);

            RemarkTextBox.Text = Elective.Remark;
            NameTextBox.Text = Elective.Name.ToString();
            DescriptionTextBox.Text = Elective.Description.ToString();
            IsRepeatCheckBox.Checked = Elective.IsRepeat;
            ExteriorIdTextBox.Text = Elective.ExteriorId;
            LearnableSkillsIdTextBox.Text = Elective.LearnableSkillsId;
            GradeComboBox.Text = EnumData.GetDisplayName(Elective.Grade);
            ConditionDescriptionTextBox.Text = Elective.ConditionDescription;
            Utils.initFlowTreeView(Elective.Condition, ConditionTreeView);
        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void selectSkillButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, ExteriorIdTextBox, false);
            form.ShowDialog();
        }

        private void selectReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, LearnableSkillsIdTextBox, true, SelectSkillForm.selectSkillType.all);
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
                if (string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    MessageBox.Show("请输入描述");
                    return;
                }
                if (string.IsNullOrEmpty(ExteriorIdTextBox.Text))
                {
                    MessageBox.Show("请输入授课教师编号");
                    return;
                }
                if (string.IsNullOrEmpty(GradeComboBox.Text))
                {
                    MessageBox.Show("请输入阶段");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Elective_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + ExteriorIdTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + ((ComboBoxItem)GradeComboBox.SelectedItem).key + "\t" + LearnableSkillsIdTextBox.Text + "\t" + ConditionDescriptionTextBox.Text + "\t";
                if (ConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + IsRepeatCheckBox.Checked;


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

                DataManager.LoadTextfile(typeof(Elective), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Elective列表
                //获得列表项
                ListViewItem lvi = DataManager.createElectiveLvi(idTextBox.Text);


                

                ElectiveTabControlUserControl ElectiveTabControlUserControl = (ElectiveTabControlUserControl)MainForm.userControls["Elective"];

                if (DataManager.allElectiveLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allElectiveLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allElectiveLvis.Add(idTextBox.Text, lvi);
                    ElectiveTabControlUserControl.getElectiveListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ConditionTreeView);
        }

        private void addReadConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ReadConditionNodeListView, ConditionTreeView);
        }

        private void readConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ConditionTreeView);
        }

        private void readConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ConditionTreeView);
        }
    }

}
