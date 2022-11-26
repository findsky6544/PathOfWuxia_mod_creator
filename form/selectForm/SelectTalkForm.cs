using Heluo.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MessageType = Heluo.Data.MessageType;

namespace 侠之道mod制作器
{
    public partial class SelectTalkForm : Form
    {
        public TextBox textBox;
        public TalkType type;

        public bool isMultiSelect = false;
        public SelectTalkForm()
        {
            InitializeComponent();
        }
        public SelectTalkForm(Form owner, TextBox textBox, bool isMultiSelect, TalkType type) : this()
        {
            Owner = owner;

            this.textBox = textBox;
            this.type = type;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;
            if (isMultiSelect)
            {
                talkListView.CheckBoxes = true;
            }

            initTalkListView();
        }

        public void initTalkListView()
        {
            if (DataManager.allTalkLvis.Count == 0)
            {
                DataManager.allTalkLvis = DataManager.createTalkLvis();
            }

            List<ListViewItem> lvis = new List<ListViewItem>();
            foreach (KeyValuePair<string, ListViewItem> kv in DataManager.allTalkLvis)
            {
                string messageType = kv.Value.SubItems[3].Text;
                if ((type == TalkType.Message && (messageType == EnumData.GetDisplayName(MessageType.Dialog) || messageType == EnumData.GetDisplayName(MessageType.Aside))) || type == TalkType.Option && (messageType == EnumData.GetDisplayName(MessageType.OptionOne) || messageType == EnumData.GetDisplayName(MessageType.OptionTwo) || messageType == EnumData.GetDisplayName(MessageType.OptionThree) || messageType == EnumData.GetDisplayName(MessageType.OptionFour)))
                {
                    lvis.Add((ListViewItem)kv.Value.Clone());
                }
                if (type == TalkType.Option)
                {
                    talkListView.CheckBoxes = true;
                    isMultiSelect = true;
                }
            }

            talkListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                bool isFirst = true;
                string[] npcsList = textBox.Text.Trim().Split(',');

                for (int i = 0; i < npcsList.Length; i++)
                {
                    for (int j = 0; j < talkListView.Items.Count; j++)
                    {
                        if (npcsList[i].Trim() == talkListView.Items[j].Text.Trim())
                        {
                            talkListView.Items[j].Checked = true;
                            if (isFirst)
                            {
                                talkListView.Items[j].Selected = true;
                                talkListView.EnsureVisible(j);
                                isFirst = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                searchBuffer(textBox.Text, true, true);
            }

            talkListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                string npcsIds = "";
                for (int i = 0; i < talkListView.Items.Count; i++)
                {
                    if (talkListView.Items[i].Checked)
                    {
                        npcsIds += talkListView.Items[i].SubItems[0].Text + ",";
                    }
                }
                if (npcsIds.Length > 0)
                {
                    npcsIds = npcsIds.Substring(0, npcsIds.Length - 1);
                }
                textBox.Text = npcsIds;
            }
            else
            {
                textBox.Text = talkListView.SelectedItems[0].SubItems[0].Text;
            }
            Close();
        }

        private void bufferListView_DoubleClick(object sender, EventArgs e)
        {
            if (isMultiSelect)
            {
                talkListView.SelectedItems[0].Checked = !talkListView.SelectedItems[0].Checked;
            }
            else
            {
                textBox.Text = talkListView.SelectedItems[0].SubItems[0].Text;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer(searchTextBox.Text, false, false);
        }

        public void searchBuffer(string bufferId, bool isEqual, bool isId)
        {
            if (string.IsNullOrEmpty(bufferId))
            {
                return;
            }
            bool isSearched = false;

            if (talkListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (talkListView.SelectedItems != null && talkListView.SelectedItems.Count != 0)
                {
                    startIndex = talkListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == talkListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = talkListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isId)
                        {
                            if (lvi.Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                talkListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                talkListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                talkListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == talkListView.Items.Count)
                    {
                        index = 0;
                    }
                } while (index != startIndex);
            }
            if (!isSearched)
            {
                MessageBox.Show("未找到该数据");
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchBuffer(searchTextBox.Text, false, false);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            Utils.addToolStripMenuItem("Talk", ":" + talkListView.SelectedItems[0].SubItems[0].Text, contextMenuStrip1);
            if (contextMenuStrip1.Items.Count > 0)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
