namespace LeafSoft
{
    partial class yyzq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yyzq));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.udpServerPanel1 = new LeafSoft.PartPanel.UDPServerPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tcpServerPanel1 = new LeafSoft.PartPanel.TCPServerPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comPanel1 = new LeafSoft.PartPanel.ComPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tcpClientPanel1 = new LeafSoft.PartPanel.TCPClientPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.udpClientPanel1 = new LeafSoft.PartPanel.UDPClientPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_Bytes = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_NewRs232 = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_NewTCPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_NewTCPClient = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_NewUDPServer = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_NewUDPClient = new System.Windows.Forms.ToolStripMenuItem();
            this.MS_AboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.udpServerPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(710, 467);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "UDP Server";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // udpServerPanel1
            // 
            this.udpServerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpServerPanel1.Location = new System.Drawing.Point(0, 0);
            this.udpServerPanel1.Name = "udpServerPanel1";
            this.udpServerPanel1.Size = new System.Drawing.Size(710, 467);
            this.udpServerPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tcpServerPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(710, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TCP Server";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tcpServerPanel1
            // 
            this.tcpServerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpServerPanel1.Location = new System.Drawing.Point(3, 3);
            this.tcpServerPanel1.Name = "tcpServerPanel1";
            this.tcpServerPanel1.Size = new System.Drawing.Size(704, 461);
            this.tcpServerPanel1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(710, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comPanel1
            // 
            this.comPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comPanel1.Location = new System.Drawing.Point(3, 3);
            this.comPanel1.Name = "comPanel1";
            this.comPanel1.Size = new System.Drawing.Size(704, 461);
            this.comPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(718, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tcpClientPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(710, 467);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "TCP Client";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tcpClientPanel1
            // 
            this.tcpClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.tcpClientPanel1.Name = "tcpClientPanel1";
            this.tcpClientPanel1.Size = new System.Drawing.Size(710, 467);
            this.tcpClientPanel1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.udpClientPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(710, 467);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "UDP Client";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // udpClientPanel1
            // 
            this.udpClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udpClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.udpClientPanel1.Name = "udpClientPanel1";
            this.udpClientPanel1.Size = new System.Drawing.Size(710, 467);
            this.udpClientPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算器ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.MS_AboutMe});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 计算器ToolStripMenuItem
            // 
            this.计算器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MS_Check,
            this.MS_Bytes});
            this.计算器ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("计算器ToolStripMenuItem.Image")));
            this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
            this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.计算器ToolStripMenuItem.Text = "计算器";
            // 
            // MS_Check
            // 
            this.MS_Check.Image = ((System.Drawing.Image)(resources.GetObject("MS_Check.Image")));
            this.MS_Check.Name = "MS_Check";
            this.MS_Check.Size = new System.Drawing.Size(148, 22);
            this.MS_Check.Text = "校验码计算器";
            this.MS_Check.Click += new System.EventHandler(this.MS_Check_Click);
            // 
            // MS_Bytes
            // 
            this.MS_Bytes.Image = ((System.Drawing.Image)(resources.GetObject("MS_Bytes.Image")));
            this.MS_Bytes.Name = "MS_Bytes";
            this.MS_Bytes.Size = new System.Drawing.Size(148, 22);
            this.MS_Bytes.Text = "数值计算器";
            this.MS_Bytes.Click += new System.EventHandler(this.MS_Bytes_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MS_NewRs232,
            this.MS_NewTCPServer,
            this.MS_NewTCPClient,
            this.MS_NewUDPServer,
            this.MS_NewUDPClient});
            this.关于ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关于ToolStripMenuItem.Image")));
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.关于ToolStripMenuItem.Text = "新的调试";
            // 
            // MS_NewRs232
            // 
            this.MS_NewRs232.Image = ((System.Drawing.Image)(resources.GetObject("MS_NewRs232.Image")));
            this.MS_NewRs232.Name = "MS_NewRs232";
            this.MS_NewRs232.Size = new System.Drawing.Size(142, 22);
            this.MS_NewRs232.Text = "串口";
            this.MS_NewRs232.Click += new System.EventHandler(this.MS_NewRs232_Click);
            // 
            // MS_NewTCPServer
            // 
            this.MS_NewTCPServer.Image = ((System.Drawing.Image)(resources.GetObject("MS_NewTCPServer.Image")));
            this.MS_NewTCPServer.Name = "MS_NewTCPServer";
            this.MS_NewTCPServer.Size = new System.Drawing.Size(142, 22);
            this.MS_NewTCPServer.Text = "TCP Server";
            this.MS_NewTCPServer.Click += new System.EventHandler(this.MS_NewTCPServer_Click);
            // 
            // MS_NewTCPClient
            // 
            this.MS_NewTCPClient.Image = ((System.Drawing.Image)(resources.GetObject("MS_NewTCPClient.Image")));
            this.MS_NewTCPClient.Name = "MS_NewTCPClient";
            this.MS_NewTCPClient.Size = new System.Drawing.Size(142, 22);
            this.MS_NewTCPClient.Text = "TCP Client";
            this.MS_NewTCPClient.Click += new System.EventHandler(this.MS_NewTCPClient_Click);
            // 
            // MS_NewUDPServer
            // 
            this.MS_NewUDPServer.Image = ((System.Drawing.Image)(resources.GetObject("MS_NewUDPServer.Image")));
            this.MS_NewUDPServer.Name = "MS_NewUDPServer";
            this.MS_NewUDPServer.Size = new System.Drawing.Size(142, 22);
            this.MS_NewUDPServer.Text = "UDP Server";
            this.MS_NewUDPServer.Click += new System.EventHandler(this.MS_NewUDPServer_Click);
            // 
            // MS_NewUDPClient
            // 
            this.MS_NewUDPClient.Image = ((System.Drawing.Image)(resources.GetObject("MS_NewUDPClient.Image")));
            this.MS_NewUDPClient.Name = "MS_NewUDPClient";
            this.MS_NewUDPClient.Size = new System.Drawing.Size(142, 22);
            this.MS_NewUDPClient.Text = "UDP Client";
            this.MS_NewUDPClient.Click += new System.EventHandler(this.MS_NewUDPClient_Click);
            // 
            // MS_AboutMe
            // 
            this.MS_AboutMe.Image = ((System.Drawing.Image)(resources.GetObject("MS_AboutMe.Image")));
            this.MS_AboutMe.Name = "MS_AboutMe";
            this.MS_AboutMe.Size = new System.Drawing.Size(60, 21);
            this.MS_AboutMe.Text = "关于";
            this.MS_AboutMe.Click += new System.EventHandler(this.MS_AboutMe_Click);
            // 
            // yyzq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "yyzq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.yyzq_Load);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private PartPanel.ComPanel comPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private PartPanel.UDPServerPanel udpServerPanel1;
        private PartPanel.TCPServerPanel tcpServerPanel1;
        private System.Windows.Forms.TabPage tabPage3;
        private PartPanel.TCPClientPanel tcpClientPanel1;
        private System.Windows.Forms.TabPage tabPage5;
        private PartPanel.UDPClientPanel udpClientPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MS_Check;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MS_NewTCPServer;
        private System.Windows.Forms.ToolStripMenuItem MS_NewTCPClient;
        private System.Windows.Forms.ToolStripMenuItem MS_NewUDPServer;
        private System.Windows.Forms.ToolStripMenuItem MS_NewUDPClient;
        private System.Windows.Forms.ToolStripMenuItem MS_AboutMe;
        private System.Windows.Forms.ToolStripMenuItem MS_NewRs232;
        private System.Windows.Forms.ToolStripMenuItem MS_Bytes;




    }
}

