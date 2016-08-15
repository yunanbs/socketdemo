namespace SocketDemo
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.socektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getDeviceNoListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendhexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readhexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendappToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.socektToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // socektToolStripMenuItem
            // 
            this.socektToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.ComStripMenuItem1,
            this.exitToolStripMenuItem});
            this.socektToolStripMenuItem.Name = "socektToolStripMenuItem";
            this.socektToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.socektToolStripMenuItem.Text = "Socekt";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // ComStripMenuItem1
            // 
            this.ComStripMenuItem1.Name = "ComStripMenuItem1";
            this.ComStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.ComStripMenuItem1.Text = "Com";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getDeviceNoListToolStripMenuItem,
            this.allStarToolStripMenuItem,
            this.sitesToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // getDeviceNoListToolStripMenuItem
            // 
            this.getDeviceNoListToolStripMenuItem.Name = "getDeviceNoListToolStripMenuItem";
            this.getDeviceNoListToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.getDeviceNoListToolStripMenuItem.Text = "GetDeviceNoList";
            this.getDeviceNoListToolStripMenuItem.Click += new System.EventHandler(this.getDeviceNoListToolStripMenuItem_Click);
            // 
            // allStarToolStripMenuItem
            // 
            this.allStarToolStripMenuItem.Name = "allStarToolStripMenuItem";
            this.allStarToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.allStarToolStripMenuItem.Text = "AllStart";
            this.allStarToolStripMenuItem.Click += new System.EventHandler(this.allStarToolStripMenuItem_Click);
            // 
            // sitesToolStripMenuItem
            // 
            this.sitesToolStripMenuItem.Name = "sitesToolStripMenuItem";
            this.sitesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sitesToolStripMenuItem.Text = "Sites";
            this.sitesToolStripMenuItem.Click += new System.EventHandler(this.sitesToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendhexToolStripMenuItem,
            this.readhexToolStripMenuItem,
            this.allMinToolStripMenuItem,
            this.allMaxToolStripMenuItem,
            this.sendappToolStripMenuItem,
            this.doTestToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // sendhexToolStripMenuItem
            // 
            this.sendhexToolStripMenuItem.Name = "sendhexToolStripMenuItem";
            this.sendhexToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendhexToolStripMenuItem.Text = "sendhex";
            this.sendhexToolStripMenuItem.Click += new System.EventHandler(this.sendhexToolStripMenuItem_Click);
            // 
            // readhexToolStripMenuItem
            // 
            this.readhexToolStripMenuItem.Name = "readhexToolStripMenuItem";
            this.readhexToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.readhexToolStripMenuItem.Text = "readhex";
            // 
            // allMinToolStripMenuItem
            // 
            this.allMinToolStripMenuItem.Name = "allMinToolStripMenuItem";
            this.allMinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allMinToolStripMenuItem.Text = "AllMin";
            this.allMinToolStripMenuItem.Click += new System.EventHandler(this.allMinToolStripMenuItem_Click);
            // 
            // allMaxToolStripMenuItem
            // 
            this.allMaxToolStripMenuItem.Name = "allMaxToolStripMenuItem";
            this.allMaxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allMaxToolStripMenuItem.Text = "AllMax";
            this.allMaxToolStripMenuItem.Click += new System.EventHandler(this.allMaxToolStripMenuItem_Click);
            // 
            // sendappToolStripMenuItem
            // 
            this.sendappToolStripMenuItem.Name = "sendappToolStripMenuItem";
            this.sendappToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendappToolStripMenuItem.Text = "sendapp";
            this.sendappToolStripMenuItem.Click += new System.EventHandler(this.sendappToolStripMenuItem_Click);
            // 
            // doTestToolStripMenuItem
            // 
            this.doTestToolStripMenuItem.Name = "doTestToolStripMenuItem";
            this.doTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.doTestToolStripMenuItem.Text = "DoTest";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "宝山区水质在线监测系统--想打开程序请猛击我！！！";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 773);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "宝山区环保局在线监测";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem socektToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDeviceNoListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allStarToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendhexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readhexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allMinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendappToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}

