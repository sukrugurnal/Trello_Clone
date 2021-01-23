using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Login frmLogin;
        User user = new User();
        bool isFormCloseButtonClicked = false;
        bool TextControl(string text)
        {
            foreach (char chr in text)
            {
                if (chr != ' ')
                {
                    return true;
                }
            }
            return false;
        }
        void inTbUserName()
        {
            if (panelUserName.BackColor != Color.Red)
            {
                panelUserName.BackColor = Color.DarkSlateGray;
                pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_DarkSlateGray_32x32;
            }
        }
        void outTbUserName()
        {
            if (panelUserName.BackColor != Color.Red)
            {
                panelUserName.BackColor = Color.White;
                pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_white_32x32;
            }
           
        }
        void inTbUserPassword()
        {
            if (panelUserPassword.BackColor != Color.Red)
            {
                panelUserPassword.BackColor = Color.DarkSlateGray;
                pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_darkslategray_32x32;
            }
        }
        void outTbUserPassword()
        {
            if (panelUserPassword.BackColor != Color.Red)
            {
                panelUserPassword.BackColor = Color.White;
                pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_white_32x32;
            }
        }
        void inTbUserPasswordAgain()
        {
            if (panelUserPasswordAgain.BackColor != Color.Red)
            {
                panelUserPasswordAgain.BackColor = Color.DarkSlateGray;
                pbUserPasswordAgain.EditValue = global::YZM_3105.Properties.Resources.lock_darkslategray_32x32;
            }
        }
        void outTbUserPasswordAgain()
        {
            if (panelUserPasswordAgain.BackColor != Color.Red)
            {
                panelUserPasswordAgain.BackColor = Color.White;
                pbUserPasswordAgain.EditValue = global::YZM_3105.Properties.Resources.lock_white_32x32;
            }
        }
        void inTbUserMail()
        {
            if (panelUserMail.BackColor != Color.Red)
            {
                panelUserMail.BackColor = Color.DarkSlateGray;
                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_darkslateGray_32x32;
            }
        }
        void outTbUserMail()
        {
            if (panelUserMail.BackColor != Color.Red)
            {
                panelUserMail.BackColor = Color.White;
                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_white_32x32;
            }
        }
        void closeRegisterForm()
        {
            if (!isFormCloseButtonClicked)
            {
                frmLogin = (Login)Application.OpenForms["Login"];
                frmLogin.Show();
                frmLogin.Location = new Point(this.Location.X, this.Location.Y);
                animationTimer.Start();
            }
        }
        private void Tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == "tbUserName") inTbUserName(); else if (tb.Name == "tbUserPassword") inTbUserPassword(); else if (tb.Name == "tbUserPasswordAgain") inTbUserPasswordAgain(); else inTbUserMail();
            string tbTag = tb.Tag.ToString();
            if (tb.Text == tbTag)
            {
                tb.Text = null;
                tb.ForeColor = Color.White;
                tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            }
        }
        private void Tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == "tbUserName") outTbUserName(); else if (tb.Name == "tbUserPassword") outTbUserPassword(); else if (tb.Name == "tbUserPasswordAgain") outTbUserPasswordAgain(); else outTbUserMail();
            string tbTag = tb.Tag.ToString();
            if (tb.Text == "" || !TextControl(tb.Text))
            {
                tb.Text = tbTag;
                tb.ForeColor = Color.Gainsboro;
                tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                tb.PasswordChar = '\0';
            }
        }

        private void topNavigatorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            frmLogin.Left += 15;
            if (frmLogin.Left >= this.Left + this.Width)
            {
                animationTimer.Stop();
                this.TopMost = false;
                frmLogin.TopMost = true;
                animationTimer2.Start();
            }
        }

        private void animationTimer2_Tick_1(object sender, EventArgs e)
        {
            frmLogin.Left -= 15;
            if (frmLogin.Left <= this.Left)
            {
                animationTimer2.Stop();
                frmLogin.TopMost = false;

                this.Close();
            }
        }

        private void btnApplicationExit_Click(object sender, EventArgs e)
        {
            closeRegisterForm();
        }
    
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length >= 4 && tbUserName.Text.Length <= 25)
            {
                if (user.UserNameController(tbUserName.Text))
                {
                    if (tbUserPassword.Text.Length >= 8 && tbUserPassword.Text.Length <= 25)
                    {
                        if (tbUserPasswordAgain.Text == tbUserPassword.Text)
                        {
                            if (user.UserMailController(tbUserMail.Text) <= 0)
                            {
                                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_darkslateGray_32x32;
                                panelUserMail.BackColor = Color.DarkSlateGray;
                                lbUserMailEror.Visible = false;
                                user.NewUserSave(tbUserName.Text, tbUserPassword.Text, tbUserMail.Text);
                                closeRegisterForm();
                            }
                            else
                            {
                                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_red_32x32;
                                panelUserMail.BackColor = Color.Red;
                                lbUserMailEror.Text = "Girdiğiniz e - postaya ait hesap bulunmaktadır.";
                                lbUserMailEror.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_red_32x32;
                    panelUserName.BackColor = Color.Red;
                    lbUserNameEror.Text = "Kullanıcı adı kullanılamaz.";
                    lbUserNameEror.Visible = true;
                }
            }
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length >= 4 && tbUserName.Text.Length <= 25)
            {
                pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_DarkSlateGray_32x32;
                panelUserName.BackColor = Color.DarkSlateGray;
                lbUserNameEror.Visible = false;
            }
            else
            {
                pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_red_32x32;
                panelUserName.BackColor = Color.Red;
                lbUserNameEror.Text = "Kullanıcı adı 4 ila 25 karakter arasında olmalıdır.";
                lbUserNameEror.Visible = true;
            }
        }
        private void tbUserPassword_TextChanged(object sender, EventArgs e)
        {
            tbUserPassword.PasswordChar = '●';
            if (tbUserPassword.Text.Length >= 8 && tbUserPassword.Text.Length <= 25)
            {
                pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_darkslategray_32x32;
                panelUserPassword.BackColor = Color.DarkSlateGray;
                lbUserPasswordEror.Visible = false;
            }
            else
            {
                pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_red_32x32;
                panelUserPassword.BackColor = Color.Red;
                lbUserPasswordEror.Visible = true;
            }
        }
        private void tbUserPasswordAgain_TextChanged(object sender, EventArgs e)
        {
            tbUserPasswordAgain.PasswordChar = '●';
            if (tbUserPasswordAgain.Text == tbUserPassword.Text)
            {
                pbUserPasswordAgain.EditValue = global::YZM_3105.Properties.Resources.lock_darkslategray_32x32;
                panelUserPasswordAgain.BackColor = Color.DarkSlateGray;
                lbUserPasswordAgainEror.Visible = false;
            }
            else
            {
                pbUserPasswordAgain.EditValue = global::YZM_3105.Properties.Resources.lock_red_32x32;
                panelUserPasswordAgain.BackColor = Color.Red;
                lbUserPasswordAgainEror.Visible = true;
            }
        }
        private void tbUserMail_TextChanged(object sender, EventArgs e)
        {
            if (tbUserMail.Text.IndexOf("@") > 0 && tbUserMail.Text.IndexOf(".") > 0)
            {
                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_darkslateGray_32x32;
                panelUserMail.BackColor = Color.DarkSlateGray;
                lbUserMailEror.Visible = false;
            }
            else
            {
                pbUserMail.EditValue = global::YZM_3105.Properties.Resources.mail_red_32x32;
                panelUserMail.BackColor = Color.Red;
                lbUserMailEror.Text = "Lütfen geçerli bir e - posta girin.";
                lbUserMailEror.Visible = true;
            }
        }

        private void btnFormMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
