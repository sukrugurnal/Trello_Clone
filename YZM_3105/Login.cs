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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public User user;
        Register frmRegister;
        bool TextControl(string text)// gelen text sadece boşluktan oluştuğunu kontrol eden method
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
        private void TopNavigatorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();//formu panel yardımıyla hareket ettirme
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void BtnApplicationExit_Click(object sender, EventArgs e)
        {
            this.Close();//uygulamayı kapatma
        }
        private void BtnFormMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//uygulamayı küçültme
        }

        private void Tb_Enter(object sender, EventArgs e)
        {
            //kullanıcı adı alanına girince görselliği ayarlama
            TextBox tb = (TextBox)sender;
            if (tb.Name == "tbUserName") pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_DarkSlateGray_32x32; else pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_darkslategray_32x32;
            if (tb.Name == "tbUserName") panelUserName.BackColor = Color.DarkSlateGray; else panelUserPassword.BackColor = Color.DarkSlateGray;
            if (tb.Text == tb.Tag.ToString())
            {
                tb.Text = null;
                tb.ForeColor = Color.White;
                tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            }
        }
        private void Tb_Leave(object sender, EventArgs e)
        {
            //kullanıcı adı alanından çıkınca görselliği ayarlama
            TextBox tb = (TextBox)sender;
            if (tb.Name == "tbUserName") pbUserName.EditValue = global::YZM_3105.Properties.Resources.user_white_32x32; else pbUserPassword.EditValue = global::YZM_3105.Properties.Resources.lock_white_32x32;
            if (tb.Name == "tbUserName") panelUserName.BackColor = Color.White; else panelUserPassword.BackColor = Color.White;
            if (tb.Text == "" || !TextControl(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gainsboro;
                tb.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                tb.PasswordChar = '\0';
            }
        }

        private void TbUserPassword_TextChanged(object sender, EventArgs e)
        {
            tbUserPassword.PasswordChar = '●';
        }

        private void PbEye_MouseDown(object sender, MouseEventArgs e)
        {
            //şifreyi gösterme
            if (tbUserPassword.Text != tbUserPassword.Tag.ToString())
            {
                tbUserPassword.PasswordChar = '\0';
                pbEye.Image = global::YZM_3105.Properties.Resources.hide_32x32;
            }

        }

        private void PbEye_MouseUp(object sender, MouseEventArgs e)
        {
            //şifreyi gizleme
            if (tbUserPassword.Text != tbUserPassword.Tag.ToString())
            {
                tbUserPassword.PasswordChar = '●';
                pbEye.Image = global::YZM_3105.Properties.Resources.show_32x32;
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            user = new User();
            if (user.ConnectionQuery(tbUserName.Text,tbUserPassword.Text))// girilen kullanıcı adı ve şifre ye ait kullanıcı varmı kontrol 
            {
                //kullanıcı var ise ana formu oluşturup ona kullanıcıyı gönderip gösterme
                MainForm frmMainForm = new MainForm();
                frmMainForm.User = user;
                tbUserName.Text = tbUserName.Tag.ToString();
                tbUserName.ForeColor = Color.Gainsboro;
                tbUserName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                tbUserPassword.Text = tbUserPassword.Tag.ToString();
                tbUserPassword.ForeColor = Color.Gainsboro;
                tbUserPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                tbUserPassword.PasswordChar = '\0';
                lbWrongAccountMessage.Visible = false;
                this.Hide();
                frmMainForm.Show();
            }
            else
            {
                // kullanıcı yok ise hata labelini gösterme
                lbWrongAccountMessage.Visible = true;
            }
        }
        bool isRegisterClicked = false;
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // kayıt ol butonuna tıklandığında login formunu sağ tarafa doğru haraket etmesi
            frmRegister.Left += 15;
            if (frmRegister.Left >= this.Left+this.Width)
            {
                animationTimer.Stop();
                this.TopMost = false;
                frmRegister.TopMost = true;
                animationTimer2.Start();
            }
        }

        private void animationTimer2_Tick(object sender, EventArgs e)
        {
            //login formu sağ gitmesini bitirdiğinde login formu gizleyip register formunu gösterip sol tarafa götürme
            frmRegister.Left -= 15;
            if (frmRegister.Left<=this.Left)
            {
                animationTimer2.Stop();
                btnRegister.Enabled = true;
                this.Hide();
                frmRegister.TopMost = false;
                isRegisterClicked = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            if (!isRegisterClicked)// kayıt ol butonuna 1 kez tıklanması
            {
                isRegisterClicked = true;
                frmRegister = new Register();
                frmRegister.Show();
                frmRegister.Location = new Point(this.Location.X, this.Location.Y);
                animationTimer.Start();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
