namespace YZM_3105
{
    partial class MainForm
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
            this.TopMenu = new System.Windows.Forms.Panel();
            this.TabControlPanel = new System.Windows.Forms.Panel();
            this.btnAccount = new DevExpress.XtraEditors.DropDownButton();
            this.AccountMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SignOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProjectView = new System.Windows.Forms.Button();
            this.btnFormMinimized = new System.Windows.Forms.Button();
            this.btnApplicationExit = new System.Windows.Forms.Button();
            this.LeftMenu = new System.Windows.Forms.Panel();
            this.LeftMenuProjects = new System.Windows.Forms.Panel();
            this.btnProjectAdd = new System.Windows.Forms.Button();
            this.timerLeftMenuHide = new System.Windows.Forms.Timer(this.components);
            this.timerLeftMenuUnhide = new System.Windows.Forms.Timer(this.components);
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TopMenu.SuspendLayout();
            this.AccountMenu.SuspendLayout();
            this.LeftMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.TopMenu.Controls.Add(this.TabControlPanel);
            this.TopMenu.Controls.Add(this.btnAccount);
            this.TopMenu.Controls.Add(this.btnProjectView);
            this.TopMenu.Controls.Add(this.btnFormMinimized);
            this.TopMenu.Controls.Add(this.btnApplicationExit);
            this.TopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(778, 32);
            this.TopMenu.TabIndex = 4;
            this.TopMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMenu_MouseDown);
            // 
            // TabControlPanel
            // 
            this.TabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlPanel.Location = new System.Drawing.Point(200, 0);
            this.TabControlPanel.Name = "TabControlPanel";
            this.TabControlPanel.Size = new System.Drawing.Size(354, 32);
            this.TabControlPanel.TabIndex = 10;
            // 
            // btnAccount
            // 
            this.btnAccount.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAccount.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Appearance.Options.UseFont = true;
            this.btnAccount.Appearance.Options.UseForeColor = true;
            this.btnAccount.ContextMenuStrip = this.AccountMenu;
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAccount.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.btnAccount.ImageOptions.Image = global::YZM_3105.Properties.Resources.user_white_32x32;
            this.btnAccount.Location = new System.Drawing.Point(554, 0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAccount.Size = new System.Drawing.Size(160, 32);
            this.btnAccount.TabIndex = 9;
            this.btnAccount.Text = "dropDownButton1";
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // AccountMenu
            // 
            this.AccountMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.AccountMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SignOutToolStripMenuItem});
            this.AccountMenu.Name = "contextMenuStrip1";
            this.AccountMenu.Size = new System.Drawing.Size(162, 26);
            // 
            // SignOutToolStripMenuItem
            // 
            this.SignOutToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateGray;
            this.SignOutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SignOutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SignOutToolStripMenuItem.Name = "SignOutToolStripMenuItem";
            this.SignOutToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SignOutToolStripMenuItem.Text = "Oturumu Kapat";
            this.SignOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // btnProjectView
            // 
            this.btnProjectView.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProjectView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectView.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProjectView.ForeColor = System.Drawing.Color.White;
            this.btnProjectView.Location = new System.Drawing.Point(0, 0);
            this.btnProjectView.Name = "btnProjectView";
            this.btnProjectView.Size = new System.Drawing.Size(200, 32);
            this.btnProjectView.TabIndex = 7;
            this.btnProjectView.TabStop = false;
            this.btnProjectView.Text = "Projeler";
            this.btnProjectView.UseVisualStyleBackColor = false;
            this.btnProjectView.Click += new System.EventHandler(this.btnProjectView_Click);
            // 
            // btnFormMinimized
            // 
            this.btnFormMinimized.BackColor = System.Drawing.Color.Transparent;
            this.btnFormMinimized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFormMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormMinimized.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFormMinimized.ForeColor = System.Drawing.Color.White;
            this.btnFormMinimized.Location = new System.Drawing.Point(714, 0);
            this.btnFormMinimized.Name = "btnFormMinimized";
            this.btnFormMinimized.Size = new System.Drawing.Size(32, 32);
            this.btnFormMinimized.TabIndex = 6;
            this.btnFormMinimized.TabStop = false;
            this.btnFormMinimized.Text = "_";
            this.btnFormMinimized.UseVisualStyleBackColor = false;
            this.btnFormMinimized.Click += new System.EventHandler(this.btnFormMinimized_Click);
            // 
            // btnApplicationExit
            // 
            this.btnApplicationExit.BackColor = System.Drawing.Color.Transparent;
            this.btnApplicationExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicationExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnApplicationExit.ForeColor = System.Drawing.Color.White;
            this.btnApplicationExit.Location = new System.Drawing.Point(746, 0);
            this.btnApplicationExit.Name = "btnApplicationExit";
            this.btnApplicationExit.Size = new System.Drawing.Size(32, 32);
            this.btnApplicationExit.TabIndex = 5;
            this.btnApplicationExit.TabStop = false;
            this.btnApplicationExit.Text = "X";
            this.btnApplicationExit.UseVisualStyleBackColor = false;
            this.btnApplicationExit.Click += new System.EventHandler(this.btnApplicationExit_Click);
            this.btnApplicationExit.MouseEnter += new System.EventHandler(this.btnApplicationExit_MouseEnter);
            this.btnApplicationExit.MouseLeave += new System.EventHandler(this.btnApplicationExit_MouseLeave);
            // 
            // LeftMenu
            // 
            this.LeftMenu.AutoScroll = true;
            this.LeftMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LeftMenu.Controls.Add(this.LeftMenuProjects);
            this.LeftMenu.Controls.Add(this.btnProjectAdd);
            this.LeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMenu.Location = new System.Drawing.Point(0, 32);
            this.LeftMenu.Name = "LeftMenu";
            this.LeftMenu.Size = new System.Drawing.Size(200, 478);
            this.LeftMenu.TabIndex = 5;
            // 
            // LeftMenuProjects
            // 
            this.LeftMenuProjects.AutoScroll = true;
            this.LeftMenuProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftMenuProjects.Location = new System.Drawing.Point(0, 0);
            this.LeftMenuProjects.Name = "LeftMenuProjects";
            this.LeftMenuProjects.Size = new System.Drawing.Size(200, 442);
            this.LeftMenuProjects.TabIndex = 9;
            // 
            // btnProjectAdd
            // 
            this.btnProjectAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProjectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProjectAdd.ForeColor = System.Drawing.Color.White;
            this.btnProjectAdd.Location = new System.Drawing.Point(0, 442);
            this.btnProjectAdd.Name = "btnProjectAdd";
            this.btnProjectAdd.Size = new System.Drawing.Size(200, 36);
            this.btnProjectAdd.TabIndex = 8;
            this.btnProjectAdd.TabStop = false;
            this.btnProjectAdd.Text = "Proje Ekle";
            this.btnProjectAdd.UseVisualStyleBackColor = false;
            this.btnProjectAdd.Click += new System.EventHandler(this.btnProjectAdd_Click);
            // 
            // timerLeftMenuHide
            // 
            this.timerLeftMenuHide.Interval = 10;
            this.timerLeftMenuHide.Tick += new System.EventHandler(this.timerLeftMenuHide_Tick);
            // 
            // timerLeftMenuUnhide
            // 
            this.timerLeftMenuUnhide.Interval = 10;
            this.timerLeftMenuUnhide.Tick += new System.EventHandler(this.timerLeftMenuUnhide_Tick);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(200, 505);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(578, 5);
            this.bottomPanel.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(773, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 473);
            this.panel2.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(778, 510);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.TopMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.TopMenu.ResumeLayout(false);
            this.AccountMenu.ResumeLayout(false);
            this.LeftMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel TopMenu;
        private System.Windows.Forms.Button btnFormMinimized;
        private System.Windows.Forms.Button btnApplicationExit;
        private System.Windows.Forms.Panel LeftMenu;
        private System.Windows.Forms.Button btnProjectView;
        private System.Windows.Forms.Timer timerLeftMenuHide;
        private System.Windows.Forms.Timer timerLeftMenuUnhide;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProjectAdd;
        private DevExpress.XtraEditors.DropDownButton btnAccount;
        private System.Windows.Forms.ContextMenuStrip AccountMenu;
        private System.Windows.Forms.ToolStripMenuItem SignOutToolStripMenuItem;
        private System.Windows.Forms.Panel LeftMenuProjects;
        public System.Windows.Forms.Panel TabControlPanel;
    }
}



