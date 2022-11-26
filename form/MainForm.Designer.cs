
namespace 侠之道mod制作器
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigTreeView = new System.Windows.Forms.TreeView();
            this.ConfigPageTabControl = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.closeButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newModToolStripMenuItem,
            this.loadModToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1053, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newModToolStripMenuItem
            // 
            this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
            this.newModToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.newModToolStripMenuItem.Text = "新建mod";
            this.newModToolStripMenuItem.Click += new System.EventHandler(this.newModToolStripMenuItem_Click);
            // 
            // loadModToolStripMenuItem
            // 
            this.loadModToolStripMenuItem.Name = "loadModToolStripMenuItem";
            this.loadModToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.loadModToolStripMenuItem.Text = "载入mod";
            this.loadModToolStripMenuItem.Click += new System.EventHandler(this.loadModToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ConfigTreeView
            // 
            this.ConfigTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigTreeView.HideSelection = false;
            this.ConfigTreeView.Location = new System.Drawing.Point(0, 0);
            this.ConfigTreeView.Name = "ConfigTreeView";
            this.ConfigTreeView.Size = new System.Drawing.Size(265, 555);
            this.ConfigTreeView.TabIndex = 2;
            this.ConfigTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ConfigTreeView_NodeMouseDoubleClick);
            // 
            // ConfigPageTabControl
            // 
            this.ConfigPageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigPageTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.ConfigPageTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigPageTabControl.Name = "ConfigPageTabControl";
            this.ConfigPageTabControl.SelectedIndex = 0;
            this.ConfigPageTabControl.Size = new System.Drawing.Size(784, 555);
            this.ConfigPageTabControl.TabIndex = 4;
            this.ConfigPageTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ConfigPageTabControl_DrawItem);
            this.ConfigPageTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConfigPageTabControl_MouseDown);
            this.ConfigPageTabControl.MouseLeave += new System.EventHandler(this.ConfigPageTabControl_MouseLeave);
            this.ConfigPageTabControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConfigPageTabControl_MouseMove);
            this.ConfigPageTabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ConfigPageTabControl_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ConfigTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ConfigPageTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1053, 555);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 5;
            // 
            // closeButtonImageList
            // 
            this.closeButtonImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.closeButtonImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.closeButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 580);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "侠之道mod制作工具1.0.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.TreeView ConfigTreeView;
        private System.Windows.Forms.TabControl ConfigPageTabControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList closeButtonImageList;
    }
}

