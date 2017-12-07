namespace WindowsFormsApp1
{
    partial class home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.timenow = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.เมนToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.นาฬกานบถอยหลงToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.นาฬกาจบเวลาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ออกจากโปรแกรมToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.เกยวกบโปรแกรมToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add = new System.Windows.Forms.Button();
            this.notifyHome = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripHome = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.เปดแอพToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ออกจากโปรแกรมToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // timenow
            // 
            this.timenow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timenow.AutoSize = true;
            this.timenow.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.timenow.Location = new System.Drawing.Point(79, 87);
            this.timenow.Name = "timenow";
            this.timenow.Size = new System.Drawing.Size(158, 55);
            this.timenow.TabIndex = 0;
            this.timenow.Text = "label1";
            this.timenow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timenow.Click += new System.EventHandler(this.timenow_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.เมนToolStripMenuItem,
            this.เกยวกบโปรแกรมToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // เมนToolStripMenuItem
            // 
            this.เมนToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.นาฬกานบถอยหลงToolStripMenuItem,
            this.นาฬกาจบเวลาToolStripMenuItem,
            this.ออกจากโปรแกรมToolStripMenuItem});
            this.เมนToolStripMenuItem.Name = "เมนToolStripMenuItem";
            this.เมนToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.เมนToolStripMenuItem.Text = "เมนู";
            // 
            // นาฬกานบถอยหลงToolStripMenuItem
            // 
            this.นาฬกานบถอยหลงToolStripMenuItem.Name = "นาฬกานบถอยหลงToolStripMenuItem";
            this.นาฬกานบถอยหลงToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.นาฬกานบถอยหลงToolStripMenuItem.Text = "นาฬิกานับถอยหลัง";
            this.นาฬกานบถอยหลงToolStripMenuItem.Click += new System.EventHandler(this.นาฬกานบถอยหลงToolStripMenuItem_Click);
            // 
            // นาฬกาจบเวลาToolStripMenuItem
            // 
            this.นาฬกาจบเวลาToolStripMenuItem.Name = "นาฬกาจบเวลาToolStripMenuItem";
            this.นาฬกาจบเวลาToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.นาฬกาจบเวลาToolStripMenuItem.Text = "นาฬิกาจับเวลา";
            this.นาฬกาจบเวลาToolStripMenuItem.Click += new System.EventHandler(this.นาฬกาจบเวลาToolStripMenuItem_Click);
            // 
            // ออกจากโปรแกรมToolStripMenuItem
            // 
            this.ออกจากโปรแกรมToolStripMenuItem.Name = "ออกจากโปรแกรมToolStripMenuItem";
            this.ออกจากโปรแกรมToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ออกจากโปรแกรมToolStripMenuItem.Text = "ออกจากโปรแกรม";
            this.ออกจากโปรแกรมToolStripMenuItem.Click += new System.EventHandler(this.ออกจากโปรแกรมToolStripMenuItem_Click);
            // 
            // เกยวกบโปรแกรมToolStripMenuItem
            // 
            this.เกยวกบโปรแกรมToolStripMenuItem.Name = "เกยวกบโปรแกรมToolStripMenuItem";
            this.เกยวกบโปรแกรมToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.เกยวกบโปรแกรมToolStripMenuItem.Text = "เกี่ยวกับโปรแกรม";
            this.เกยวกบโปรแกรมToolStripMenuItem.Click += new System.EventHandler(this.เกยวกบโปรแกรมToolStripMenuItem_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(131, 275);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(115, 34);
            this.add.TabIndex = 2;
            this.add.Text = "เพิ่มการแจ้งเตือน";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // notifyHome
            // 
            this.notifyHome.ContextMenuStrip = this.contextMenuStripHome;
            this.notifyHome.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyHome.Icon")));
            this.notifyHome.Text = "Ok";
            this.notifyHome.Visible = true;
            // 
            // contextMenuStripHome
            // 
            this.contextMenuStripHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.เปดแอพToolStripMenuItem,
            this.ออกจากโปรแกรมToolStripMenuItem1});
            this.contextMenuStripHome.Name = "contextMenuStripHome";
            this.contextMenuStripHome.Size = new System.Drawing.Size(152, 48);
            // 
            // เปดแอพToolStripMenuItem
            // 
            this.เปดแอพToolStripMenuItem.Name = "เปดแอพToolStripMenuItem";
            this.เปดแอพToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.เปดแอพToolStripMenuItem.Text = "เปิดแอพ";
            this.เปดแอพToolStripMenuItem.Click += new System.EventHandler(this.เปดแอพToolStripMenuItem_Click);
            // 
            // ออกจากโปรแกรมToolStripMenuItem1
            // 
            this.ออกจากโปรแกรมToolStripMenuItem1.Name = "ออกจากโปรแกรมToolStripMenuItem1";
            this.ออกจากโปรแกรมToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.ออกจากโปรแกรมToolStripMenuItem1.Text = "ออกจากโปรแกรม";
            this.ออกจากโปรแกรมToolStripMenuItem1.Click += new System.EventHandler(this.ออกจากโปรแกรมToolStripMenuItem1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 377);
            this.Controls.Add(this.add);
            this.Controls.Add(this.timenow);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripHome.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timenow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem เมนToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem นาฬกาจบเวลาToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ออกจากโปรแกรมToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem เกยวกบโปรแกรมToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem นาฬกานบถอยหลงToolStripMenuItem;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.NotifyIcon notifyHome;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHome;
        private System.Windows.Forms.ToolStripMenuItem เปดแอพToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ออกจากโปรแกรมToolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}