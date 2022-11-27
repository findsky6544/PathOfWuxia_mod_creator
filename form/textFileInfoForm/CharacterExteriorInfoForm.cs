
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using CharacterExterior = Heluo.Data.CharacterExterior;
using Control = System.Windows.Forms.Control;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TextBox = System.Windows.Forms.TextBox;

namespace 侠之道mod制作器
{
    public partial class CharacterExteriorInfoForm : Form
    {

        public string CharacterExteriorId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public CharacterExteriorInfoForm()
        {
            InitializeComponent();

            initGenderComboBox();
            initSizeComboBox();
            initAgeGroupComboBox();
            initProtraitComboBox();

            initButtons();
        }

        public CharacterExteriorInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public CharacterExteriorInfoForm(string CharacterExteriorId) : this()
        {
            this.CharacterExteriorId = CharacterExteriorId;
        }

        public void initGenderComboBox()
        {
            GenderComboBox.DisplayMember = "value";
            GenderComboBox.ValueMember = "key";


            foreach (Gender temp in Enum.GetValues(typeof(Gender)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                GenderComboBox.Items.Add(cbi);
            }
        }

        public void initSizeComboBox()
        {
            SizeComboBox.DisplayMember = "value";
            SizeComboBox.ValueMember = "key";


            foreach (Size temp in Enum.GetValues(typeof(Size)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                SizeComboBox.Items.Add(cbi);
            }
        }

        public void initAgeGroupComboBox()
        {
            AgeGroupComboBox.DisplayMember = "value";
            AgeGroupComboBox.ValueMember = "key";


            foreach (AgeGroup temp in Enum.GetValues(typeof(AgeGroup)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                AgeGroupComboBox.Items.Add(cbi);
            }
        }

        public void initProtraitComboBox()
        {
            for (int i = 0; i < protraitImageList.Images.Count; i++)
            {
                string imageName = protraitImageList.Images.Keys[i];
                imageName = imageName.Substring(0, imageName.LastIndexOf('_'));
                if (!ProtraitComboBox.Items.Contains(imageName))
                {
                    ProtraitComboBox.Items.Add(imageName);
                }
            }
        }
        public void initButtons()
        {
            foreach (Control button in flowLayoutPanel1.Controls)
            {
                if (button is Button)
                {
                    button.Click += (s, e) =>
                    {
                        setText(button.Text, DescriptionTextBox);
                    };

                    if (!button.Name.Contains("Appellation"))
                    {
                        continue;
                    }
                    else
                    {
                        string stringTableName = button.Name.Replace("button", "");
                        button.Text = "{" + DataManager.getStringTableTextRemark(stringTableName) + "}";
                    }
                }
            }
        }

        public void setText(string text, TextBox textBox)
        {
            if (text == "文字变红")
            {
                textBox.SelectedText = "<color=#FF0000>" + textBox.SelectedText + "</color>";
            }
            else
            {
                int index = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(index, text);
                textBox.SelectionStart = index + text.Length;
            }
            textBox.Focus();
        }

        public void readCharacterExteriorInfo()
        {
            idTextBox.Text = CharacterExteriorId;
            idTextBox.Enabled = false;

            CharacterExterior CharacterExterior = DataManager.getData<CharacterExterior>(CharacterExteriorId);

            RemarkTextBox.Text = CharacterExterior.Remark;
            SurNameTextBox.Text = CharacterExterior.SurName.ToString();
            NameTextBox.Text = CharacterExterior.Name.ToString();
            NickNameTextBox.Text = CharacterExterior.Nickname;
            ProtraitComboBox.Text = CharacterExterior.Protrait;
            DescriptionTextBox.Text = Utils.replaceRichTextReadIn(CharacterExterior.Description, flowLayoutPanel1);
            for (int i = 0; i < GenderComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)GenderComboBox.Items[i]).key == ((int)CharacterExterior.Gender).ToString())
                {
                    GenderComboBox.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < SizeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)SizeComboBox.Items[i]).key == ((int)CharacterExterior.Size).ToString())
                {
                    SizeComboBox.SelectedIndex = i;
                    break;
                }
            }
            ModelTextBox.Text = CharacterExterior.Model;
            AnimMapIdTextBox.Text = CharacterExterior.AnimMapId;
            HeightNumericUpDown.Text = CharacterExterior.Height.ToString();
            string PreferenceType = "";
            if (CharacterExterior.PreferenceType != null && CharacterExterior.PreferenceType.Count > 0)
            {
                for (int i = 0; i < CharacterExterior.PreferenceType.Count; i++)
                {
                    PreferenceType += (int)CharacterExterior.PreferenceType[i] + ",";
                }
                PreferenceType = PreferenceType.Substring(0, PreferenceType.Length - 1);
            }
            PreferenceTypeTextBox.Text = PreferenceType;
            IsShowProtraitCheckBox.Checked = CharacterExterior.IsShowProtrait;
            InfoIdTextBox.Text = CharacterExterior.InfoId;
            for (int i = 0; i < AgeGroupComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)AgeGroupComboBox.Items[i]).key == ((int)CharacterExterior.AgeGroup).ToString())
                {
                    AgeGroupComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void selectReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, AnimMapIdTextBox, false);
            form.ShowDialog();
        }

        private void selectAnimationMappingButton_Click(object sender, EventArgs e)
        {
            SelectAnimationMappingForm form = new SelectAnimationMappingForm(this, AnimMapIdTextBox, false);
            form.ShowDialog();
        }

        private void selectPreferenceTypeButton_Click(object sender, EventArgs e)
        {
            SelectPropsCategoryForm form = new SelectPropsCategoryForm(this, PreferenceTypeTextBox, true);
            form.ShowDialog();
        }

        private void selectInfoButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, InfoIdTextBox, false);
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
                if (string.IsNullOrEmpty(SurNameTextBox.Text))
                {
                    MessageBox.Show("请输入姓");
                    return;
                }
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入名");
                    return;
                }
                if (string.IsNullOrEmpty(GenderComboBox.Text))
                {
                    MessageBox.Show("请输入性别");
                    return;
                }
                if (string.IsNullOrEmpty(SizeComboBox.Text))
                {
                    MessageBox.Show("请输入体型");
                    return;
                }
                if (string.IsNullOrEmpty(HeightNumericUpDown.Text))
                {
                    MessageBox.Show("请输入身高");
                    return;
                }
                if (string.IsNullOrEmpty(AgeGroupComboBox.Text))
                {
                    MessageBox.Show("请输入年龄层");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\CharacterExterior_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + SurNameTextBox.Text + "\t" + NameTextBox.Text + "\t" + NickNameTextBox.Text + "\t" + ProtraitComboBox.Text + "\t" + Utils.replaceRichTextWriteOut(DescriptionTextBox.Text, flowLayoutPanel1) + "\t" + ((ComboBoxItem)GenderComboBox.SelectedItem).key + "\t" + ((ComboBoxItem)SizeComboBox.SelectedItem).key + "\t" + ModelTextBox.Text + "\t" + AnimMapIdTextBox.Text + "\t" + HeightNumericUpDown.Text + "\t" + PreferenceTypeTextBox.Text + "\t" + IsShowProtraitCheckBox.Checked + "\t" + InfoIdTextBox.Text + "\t" + ((ComboBoxItem)AgeGroupComboBox.SelectedItem).key;


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

                DataManager.LoadTextfile(typeof(CharacterExterior), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新CharacterExterior列表
                //获得列表项
                ListViewItem lvi = DataManager.createCharacterExteriorLvi(idTextBox.Text);


                

                CharacterExteriorTabControlUserControl CharacterExteriorTabControlUserControl = (CharacterExteriorTabControlUserControl)MainForm.userControls["CharacterExterior"];

                if (DataManager.allCharacterExteriorLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allCharacterExteriorLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allCharacterExteriorLvis.Add(idTextBox.Text, lvi);
                    CharacterExteriorTabControlUserControl.getCharacterExteriorListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProtraitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = ProtraitComboBox.Text + "_General";
            ProtraitPictureBox.Image = protraitImageList.Images[protraitImageList.Images.IndexOfKey(text)];
        }
    }

}
