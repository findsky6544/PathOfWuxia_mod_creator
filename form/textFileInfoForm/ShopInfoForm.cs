using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Shop = Heluo.Data.Shop;

namespace 侠之道mod制作器
{
    public partial class ShopInfoForm : Form
    {

        public string ShopId;

        public ShopInfoForm()
        {
            InitializeComponent();
        }

        public ShopInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public ShopInfoForm(string ShopId) : this()
        {
            this.ShopId = ShopId;
        }

        public void readShopInfo()
        {
            idTextBox.Text = ShopId;
            idTextBox.Enabled = false;

            Shop Shop = DataManager.getData<Shop>(ShopId);

            if (Shop != null)
            {
                RemarkTextBox.Text = Shop.Remark;
                Utils.initFlowTreeView(Shop.Condition, ConditionTreeView);
                IsRepeatCheckBox.Checked = Shop.IsRepeat;
                PropsIdTextBox.Text = Shop.PropsId;
                if (Shop.ShopPeriods != null)
                {
                    for (int i = 0; i < Shop.ShopPeriods.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = DataManager.getRoundStr(Shop.ShopPeriods[i].OpenRound);
                        lvi.SubItems.Add(DataManager.getRoundStr(Shop.ShopPeriods[i].CloseRound));
                        lvi.Tag = "(" + Shop.ShopPeriods[i].OpenRound + "," + Shop.ShopPeriods[i].CloseRound + ")";
                        ShopPeriodsListView.Items.Add(lvi);
                    }
                }

            }

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
                if (string.IsNullOrEmpty(PropsIdTextBox.Text))
                {
                    MessageBox.Show("请输入物品编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Shop_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + PropsIdTextBox.Text + "\t";

                for (int i = 0; i < ShopPeriodsListView.Items.Count; i++)
                {
                    replacement += ShopPeriodsListView.Items[i].Tag;
                }

                replacement += "\t";

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

                DataManager.LoadTextfile(typeof(Shop), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Shop列表
                //获得列表项
                ListViewItem lvi = DataManager.createShopLvi(idTextBox.Text);


                

                ShopTabControlUserControl ShopTabControlUserControl = (ShopTabControlUserControl)MainForm.userControls["Shop"];

                if (DataManager.allShopLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allShopLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allShopLvis.Add(idTextBox.Text, lvi);
                    ShopTabControlUserControl.getShopListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, PropsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }

        private void ConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ConditionTreeView);
        }

        private void ConditionAddNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionNodeListView, ConditionTreeView);
        }

        private void ConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ConditionNodeListView, ConditionTreeView);
        }

        private void ConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ConditionTreeView);
        }

        private void ConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ConditionTreeView);
        }

        private void addShopPeriodButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.Tag = "(,)";
            ShopPeriodForm form = new ShopPeriodForm(lvi, true, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ShopPeriodsListView.Items.Add(lvi);
            }
        }

        private void editShopPeriodButton_Click(object sender, EventArgs e)
        {
            if (ShopPeriodsListView.SelectedItems.Count > 0)
            {
                ShopPeriodForm form = new ShopPeriodForm(ShopPeriodsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
        }

        private void deleteShopPeriodButton_Click(object sender, EventArgs e)
        {
            if (ShopPeriodsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ShopPeriodsListView.Items.Remove(ShopPeriodsListView.SelectedItems[0]);
                }
            }
        }
    }
}
