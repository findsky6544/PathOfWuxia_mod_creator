
using Heluo.Data;
using Heluo.Flow;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Help = Heluo.Data.Help;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class HelpInfoForm : Form
    {

        public string HelpId;
        public HelpInfoForm()
        {
            InitializeComponent();

            initMainTabComboBox();
        }

        public HelpInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public HelpInfoForm(string HelpId) : this()
        {
            this.HelpId = HelpId;
        }

        public void initMainTabComboBox()
        {
            MainTabComboBox.DisplayMember = "value";
            MainTabComboBox.ValueMember = "key";


            foreach (HelpMainTab temp in Enum.GetValues(typeof(HelpMainTab)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                MainTabComboBox.Items.Add(cbi);
            }
        }

        public void readHelpInfo()
        {
            idTextBox.Text = HelpId;
            idTextBox.Enabled = false;

            Help Help = DataManager.getData<Help>(HelpId);

            for (int i = 0; i < MainTabComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)MainTabComboBox.Items[i]).key == ((int)Help.MainTab).ToString())
                {
                    MainTabComboBox.SelectedIndex = i;
                    break;
                }
            }
            IsMainEntryCheckBox.Checked = Help.IsMainEntry;
            MainEntryIdTextBox.Text = Help.MainEntryId;
            NameTextBox.Text = Help.Name;

            Utils.initFlowTreeView(Help.ShowCondition, ShowConditionTreeView);
            ImageNameTextBox.Text = Help.ImageName;
            ExteriorIdTextBox.Text = Help.ExteriorId;
            string HelpDescriptions = "";
            if (Help.HelpDescriptions != null && Help.HelpDescriptions.Count > 0)
            {
                for (int i = 0; i < Help.HelpDescriptions.Count; i++)
                {
                    HelpDescriptions += Help.HelpDescriptions[i] + ",";
                }
                HelpDescriptions = HelpDescriptions.Substring(0, HelpDescriptions.Length - 1);
            }
            HelpDescriptionsTextBox.Text = HelpDescriptions;
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
                    MessageBox.Show("请输入条目名称");
                    return;
                }
                if (string.IsNullOrEmpty(MainTabComboBox.Text))
                {
                    MessageBox.Show("请输入隶属分页");
                    return;
                }
                if (!IsMainEntryCheckBox.Checked)
                {
                    if (string.IsNullOrEmpty(MainEntryIdTextBox.Text))
                    {
                        MessageBox.Show("请输入对应主条目Id");
                        return;
                    }
                    if (string.IsNullOrEmpty(HelpDescriptionsTextBox.Text))
                    {
                        MessageBox.Show("请输入叙述内容编号");
                        return;
                    }
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Help.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + ((ComboBoxItem)MainTabComboBox.SelectedItem).key + "\t" + IsMainEntryCheckBox.Checked + "\t" + MainEntryIdTextBox.Text + "\t" + NameTextBox.Text + "\t";


                if (ShowConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ShowConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + ImageNameTextBox.Text + "\t" + ExteriorIdTextBox.Text + "\t" + HelpDescriptionsTextBox.Text;


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

                DataManager.LoadTextfile(typeof(Help), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Help列表
                //获得列表项
                ListViewItem lvi = DataManager.createHelpLvi(idTextBox.Text);


                

                HelpTabControlUserControl HelpTabControlUserControl = (HelpTabControlUserControl)MainForm.userControls["Help"];

                if (DataManager.allHelpLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allHelpLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allHelpLvis.Add(idTextBox.Text, lvi);
                    HelpTabControlUserControl.getHelpListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectHelpForm form = new SelectHelpForm(this, MainEntryIdTextBox, false);
            form.ShowDialog();
        }

        private void selectHelpDescriptionsButton_Click(object sender, EventArgs e)
        {
            SelectHelpDescriptionForm form = new SelectHelpDescriptionForm(this, HelpDescriptionsTextBox, true);
            form.ShowDialog();
        }

        private void selectExteriorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, ExteriorIdTextBox, false);
            form.ShowDialog();
        }

        private void addShowConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void ShowConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void showConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ShowConditionTreeView);
        }

        private void showConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ShowConditionTreeView);
        }

        private void showConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ShowConditionTreeView);
        }


        private void IsMainEntryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = !IsMainEntryCheckBox.Checked;
        }
    }

}
