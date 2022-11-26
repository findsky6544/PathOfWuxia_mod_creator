using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Npc = Heluo.Data.Npc;

namespace 侠之道mod制作器
{
    public partial class NpcInfoForm : Form
    {

        public string NpcId;
        public NpcInfoForm()
        {
            InitializeComponent();
        }

        public NpcInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public NpcInfoForm(string NpcId) : this()
        {
            this.NpcId = NpcId;
        }

        public void readNpcInfo()
        {
            idTextBox.Text = NpcId;
            idTextBox.Enabled = false;

            Npc Npc = DataManager.getData<Npc>(NpcId);

            NameTextBox.Text = Npc.Name;
            RemarkTextBox.Text = Npc.Remark;
            CharacterInfoIdTextBox.Text = Npc.CharacterInfoId;
            ExteriorIdTextBox.Text = Npc.ExteriorId;
            IsTriggerCheckBox.Checked = Npc.IsTrigger;
            string BehaviourId = "";
            if (Npc.BehaviourId != null && Npc.BehaviourId.Count > 0)
            {
                for (int i = 0; i < Npc.BehaviourId.Count; i++)
                {
                    BehaviourId += Npc.BehaviourId[i] + ",";
                }
                BehaviourId = BehaviourId.Substring(0, BehaviourId.Length - 1);
            }
            BehaviourIdTextBox.Text = BehaviourId;
            InteractiveHeightNumericUpDown.Text = Npc.InteractiveHeight.ToString();
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
                if (string.IsNullOrEmpty(InteractiveHeightNumericUpDown.Text))
                {
                    MessageBox.Show("请输入互动界面出现高度");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Npc.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + CharacterInfoIdTextBox.Text + "\t" + ExteriorIdTextBox.Text + "\t" + IsTriggerCheckBox.Checked + "\t" + BehaviourIdTextBox.Text + "\t" + InteractiveHeightNumericUpDown.Text;


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

                DataManager.LoadTextfile(typeof(Npc), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Npc列表
                //获得列表项
                ListViewItem lvi = DataManager.createNpcLvi(idTextBox.Text);


                

                NpcTabControlUserControl NpcTabControlUserControl = (NpcTabControlUserControl)MainForm.userControls["Npc"];

                if (DataManager.allNpcLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allNpcLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allNpcLvis.Add(idTextBox.Text, lvi);
                    NpcTabControlUserControl.getNpcListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectCharacaterInfoButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, CharacterInfoIdTextBox, false);
            form.ShowDialog();
        }

        private void selectExteriorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, ExteriorIdTextBox, false);
            form.ShowDialog();
        }

        private void selectBehaviorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterBehaviourForm form = new SelectCharacterBehaviourForm(this, BehaviourIdTextBox, true);
            form.ShowDialog();
        }
    }

}
