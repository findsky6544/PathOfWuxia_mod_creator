using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using RegistrationBonus = Heluo.Data.RegistrationBonus;

namespace 侠之道mod制作器
{
    public partial class RegistrationBonusInfoForm : Form
    {

        public string RegistrationBonusId;
        public RegistrationBonusInfoForm()
        {
            InitializeComponent();
        }

        public RegistrationBonusInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public RegistrationBonusInfoForm(string RegistrationBonusId) : this()
        {
            this.RegistrationBonusId = RegistrationBonusId;
        }

        public void readRegistrationBonusInfo()
        {
            idTextBox.Text = RegistrationBonusId;
            idTextBox.Enabled = false;

            RegistrationBonus RegistrationBonus = DataManager.getData<RegistrationBonus>(RegistrationBonusId);

            DescTextBox.Text = RegistrationBonus.Desc;
            FourAttributesPointNumericUpDown.Value = RegistrationBonus.FourAttributesPoint;
            TraitPointNumericUpDown.Value = RegistrationBonus.TraitPoint;
            string UnLockTraits = "";
            if (RegistrationBonus.UnLockTraits != null && RegistrationBonus.UnLockTraits.Count > 0)
            {
                for (int i = 0; i < RegistrationBonus.UnLockTraits.Count; i++)
                {
                    UnLockTraits += RegistrationBonus.UnLockTraits[i] + ",";
                }
                UnLockTraits = UnLockTraits.Substring(0, UnLockTraits.Length - 1);
            }
            UnLockTraitsTextBox.Text = UnLockTraits;
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
                if (string.IsNullOrEmpty(FourAttributesPointNumericUpDown.Text))
                {
                    MessageBox.Show("请输入增加的四维点");
                    return;
                }
                if (string.IsNullOrEmpty(TraitPointNumericUpDown.Text))
                {
                    MessageBox.Show("请输入增加的特质点");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\RegistrationBonus.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + DescTextBox.Text + "\t" + FourAttributesPointNumericUpDown.Text + "\t" + TraitPointNumericUpDown.Text + "\t" + UnLockTraitsTextBox.Text;


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

                DataManager.LoadTextfile(typeof(RegistrationBonus), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新RegistrationBonus列表
                //获得列表项
                ListViewItem lvi = DataManager.createRegistrationBonusLvi(idTextBox.Text);


                

                RegistrationBonusTabControlUserControl RegistrationBonusTabControlUserControl = (RegistrationBonusTabControlUserControl)MainForm.userControls["RegistrationBonus"];

                if (DataManager.allRegistrationBonusLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allRegistrationBonusLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allRegistrationBonusLvis.Add(idTextBox.Text, lvi);
                    RegistrationBonusTabControlUserControl.getRegistrationBonusListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectBehaviorButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, UnLockTraitsTextBox, true);
            form.ShowDialog();
        }
    }

}
