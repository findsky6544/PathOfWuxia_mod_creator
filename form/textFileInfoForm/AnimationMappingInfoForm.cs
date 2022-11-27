using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AnimationMapping = Heluo.Data.AnimationMapping;

namespace 侠之道mod制作器
{
    public partial class AnimationMappingInfoForm : Form
    {

        public string AnimationMappingId;

        public AnimationMappingInfoForm()
        {
            InitializeComponent();
        }

        public AnimationMappingInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public AnimationMappingInfoForm(string AnimationMappingId) : this()
        {
            this.AnimationMappingId = AnimationMappingId;
        }

        public void readAnimationMappingInfo()
        {
            idTextBox.Text = AnimationMappingId;
            idTextBox.Enabled = false;

            AnimationMapping AnimationMapping = DataManager.getData<AnimationMapping>(AnimationMappingId);

            NameTextBox.Text = AnimationMapping.Name;
            DescriptionTextBox.Text = AnimationMapping.Description;
            StandTextBox.Text = AnimationMapping.Stand;
            WalkTextBox.Text = AnimationMapping.Walk;
            BeginWalkTextBox.Text = AnimationMapping.BeginWalk;
            EndWalkTextBox.Text = AnimationMapping.EndWalk;
            RunTextBox.Text = AnimationMapping.Run;
            IdleTextBox.Text = AnimationMapping.Idle;
            MoveTextBox.Text = AnimationMapping.Move;
            HurtTextBox.Text = AnimationMapping.Hurt;
            BigHurtTextBox.Text = AnimationMapping.BigHurt;
            DazeTextBox.Text = AnimationMapping.Daze;
            DodgeTextBox.Text = AnimationMapping.Dodge;
            DieTextBox.Text = AnimationMapping.Die;
            BlockTextBox.Text = AnimationMapping.Block;
            BufferTextBox.Text = AnimationMapping.Buffer;
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
                string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\AnimationMapping_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + DescriptionTextBox.Text + "\t" + StandTextBox.Text + "\t" + WalkTextBox.Text + "\t" + BeginWalkTextBox.Text + "\t" + EndWalkTextBox.Text + "\t" + RunTextBox.Text + "\t" + IdleTextBox.Text + "\t" + MoveTextBox.Text + "\t" + HurtTextBox.Text + "\t" + BigHurtTextBox.Text + "\t" + DazeTextBox.Text + "\t" + DodgeTextBox.Text + "\t" + DieTextBox.Text + "\t" + BlockTextBox.Text + "\t" + BufferTextBox.Text;
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

                DataManager.LoadTextfile(typeof(AnimationMapping), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新AnimationMapping列表
                //获得列表项
                ListViewItem lvi = DataManager.createAnimationMappingLvi(idTextBox.Text);

                

                AnimationMappingTabControlUserControl AnimationMappingTabControlUserControl = (AnimationMappingTabControlUserControl)MainForm.userControls["AnimationMapping"];
                if (DataManager.allAnimationMappingLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allAnimationMappingLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allAnimationMappingLvis.Add(idTextBox.Text, lvi);
                    AnimationMappingTabControlUserControl.getAnimationMappingListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
