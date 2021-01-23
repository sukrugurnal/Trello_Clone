namespace YZM_3105
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.topNavigatorPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFormMinimized = new System.Windows.Forms.Button();
            this.btnApplicationExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.panelUserName = new System.Windows.Forms.Panel();
            this.panelUserPassword = new System.Windows.Forms.Panel();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.animationTimer2 = new System.Windows.Forms.Timer(this.components);
            this.pbUserPassword = new DevExpress.XtraEditors.PictureEdit();
            this.pbUserName = new DevExpress.XtraEditors.PictureEdit();
            this.pbEye = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbWrongAccountMessage = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.topNavigatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.Color.Teal;
            this.tbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbUserName.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbUserName.Location = new System.Drawing.Point(86, 245);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(2);
            this.tbUserName.Multiline = true;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(212, 29);
            this.tbUserName.TabIndex = 0;
            this.tbUserName.Tag = "Kullanıcı Adı";
            this.tbUserName.Text = "Kullanıcı Adı";
            this.tbUserName.Enter += new System.EventHandler(this.Tb_Enter);
            this.tbUserName.Leave += new System.EventHandler(this.Tb_Leave);
            // 
            // topNavigatorPanel
            // 
            this.topNavigatorPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.topNavigatorPanel.Controls.Add(this.label1);
            this.topNavigatorPanel.Controls.Add(this.pictureBox1);
            this.topNavigatorPanel.Controls.Add(this.btnFormMinimized);
            this.topNavigatorPanel.Controls.Add(this.btnApplicationExit);
            this.topNavigatorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topNavigatorPanel.Location = new System.Drawing.Point(0, 0);
            this.topNavigatorPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topNavigatorPanel.Name = "topNavigatorPanel";
            this.topNavigatorPanel.Size = new System.Drawing.Size(355, 40);
            this.topNavigatorPanel.TabIndex = 1;
            this.topNavigatorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopNavigatorPanel_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Todorello";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnFormMinimized
            // 
            this.btnFormMinimized.BackColor = System.Drawing.Color.Transparent;
            this.btnFormMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormMinimized.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFormMinimized.ForeColor = System.Drawing.Color.White;
            this.btnFormMinimized.Location = new System.Drawing.Point(281, 4);
            this.btnFormMinimized.Name = "btnFormMinimized";
            this.btnFormMinimized.Size = new System.Drawing.Size(32, 32);
            this.btnFormMinimized.TabIndex = 3;
            this.btnFormMinimized.TabStop = false;
            this.btnFormMinimized.Text = "_";
            this.btnFormMinimized.UseVisualStyleBackColor = false;
            this.btnFormMinimized.Click += new System.EventHandler(this.BtnFormMinimized_Click);
            // 
            // btnApplicationExit
            // 
            this.btnApplicationExit.BackColor = System.Drawing.Color.Transparent;
            this.btnApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicationExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnApplicationExit.ForeColor = System.Drawing.Color.White;
            this.btnApplicationExit.Location = new System.Drawing.Point(319, 4);
            this.btnApplicationExit.Name = "btnApplicationExit";
            this.btnApplicationExit.Size = new System.Drawing.Size(32, 32);
            this.btnApplicationExit.TabIndex = 2;
            this.btnApplicationExit.TabStop = false;
            this.btnApplicationExit.Text = "X";
            this.btnApplicationExit.UseVisualStyleBackColor = false;
            this.btnApplicationExit.Click += new System.EventHandler(this.BtnApplicationExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Giriş Yap";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(44, 354);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(258, 32);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 8;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // panelUserName
            // 
            this.panelUserName.BackColor = System.Drawing.Color.White;
            this.panelUserName.Location = new System.Drawing.Point(52, 275);
            this.panelUserName.Name = "panelUserName";
            this.panelUserName.Size = new System.Drawing.Size(250, 1);
            this.panelUserName.TabIndex = 11;
            // 
            // panelUserPassword
            // 
            this.panelUserPassword.BackColor = System.Drawing.Color.White;
            this.panelUserPassword.Location = new System.Drawing.Point(52, 321);
            this.panelUserPassword.Name = "panelUserPassword";
            this.panelUserPassword.Size = new System.Drawing.Size(250, 1);
            this.panelUserPassword.TabIndex = 14;
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.BackColor = System.Drawing.Color.Teal;
            this.tbUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUserPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbUserPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.tbUserPassword.Location = new System.Drawing.Point(86, 291);
            this.tbUserPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbUserPassword.Multiline = true;
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.Size = new System.Drawing.Size(179, 29);
            this.tbUserPassword.TabIndex = 1;
            this.tbUserPassword.Tag = "Şifre";
            this.tbUserPassword.Text = "Şifre";
            this.tbUserPassword.TextChanged += new System.EventHandler(this.TbUserPassword_TextChanged);
            this.tbUserPassword.Enter += new System.EventHandler(this.Tb_Enter);
            this.tbUserPassword.Leave += new System.EventHandler(this.Tb_Leave);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(44, 392);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(258, 32);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Kayıt Ol";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // animationTimer2
            // 
            this.animationTimer2.Interval = 8;
            this.animationTimer2.Tick += new System.EventHandler(this.animationTimer2_Tick);
            // 
            // pbUserPassword
            // 
            this.pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_white_32x32;
            this.pbUserPassword.Location = new System.Drawing.Point(52, 286);
            this.pbUserPassword.Name = "pbUserPassword";
            this.pbUserPassword.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbUserPassword.Properties.Appearance.Options.UseBackColor = true;
            this.pbUserPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbUserPassword.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbUserPassword.Size = new System.Drawing.Size(32, 32);
            this.pbUserPassword.TabIndex = 15;
            // 
            // pbUserName
            // 
            this.pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_white_32x32;
            this.pbUserName.Location = new System.Drawing.Point(52, 241);
            this.pbUserName.Name = "pbUserName";
            this.pbUserName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pbUserName.Properties.Appearance.Options.UseBackColor = true;
            this.pbUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbUserName.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pbUserName.Size = new System.Drawing.Size(32, 32);
            this.pbUserName.TabIndex = 12;
            // 
            // pbEye
            // 
            this.pbEye.Image = global::YZM_3105.Properties.Resources.show_32x32;
            this.pbEye.Location = new System.Drawing.Point(270, 291);
            this.pbEye.Name = "pbEye";
            this.pbEye.Size = new System.Drawing.Size(32, 23);
            this.pbEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEye.TabIndex = 9;
            this.pbEye.TabStop = false;
            this.pbEye.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbEye_MouseDown);
            this.pbEye.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbEye_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(116, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // lbWrongAccountMessage
            // 
            this.lbWrongAccountMessage.AutoSize = true;
            this.lbWrongAccountMessage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbWrongAccountMessage.ForeColor = System.Drawing.Color.Red;
            this.lbWrongAccountMessage.Location = new System.Drawing.Point(51, 439);
            this.lbWrongAccountMessage.Name = "lbWrongAccountMessage";
            this.lbWrongAccountMessage.Size = new System.Drawing.Size(252, 23);
            this.lbWrongAccountMessage.TabIndex = 16;
            this.lbWrongAccountMessage.Text = "Kullanıcı Adı veya Şifre Yanlış";
            this.lbWrongAccountMessage.Visible = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(350, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(5, 440);
            this.panelRight.TabIndex = 17;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 475);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(350, 5);
            this.panelBottom.TabIndex = 18;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(5, 435);
            this.panelLeft.TabIndex = 19;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(355, 480);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.lbWrongAccountMessage);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.pbUserPassword);
            this.Controls.Add(this.panelUserPassword);
            this.Controls.Add(this.tbUserPassword);
            this.Controls.Add(this.pbUserName);
            this.Controls.Add(this.panelUserName);
            this.Controls.Add(this.pbEye);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.topNavigatorPanel);
            this.Controls.Add(this.tbUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.topNavigatorPanel.ResumeLayout(false);
            this.topNavigatorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel topNavigatorPanel;
        private System.Windows.Forms.Button btnApplicationExit;
        private System.Windows.Forms.Button btnFormMinimized;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pbEye;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Panel panelUserName;
        private DevExpress.XtraEditors.PictureEdit pbUserName;
        private DevExpress.XtraEditors.PictureEdit pbUserPassword;
        private System.Windows.Forms.Panel panelUserPassword;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer animationTimer2;
        public System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbWrongAccountMessage;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeft;
    }
}