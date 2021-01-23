using Microsoft.VisualBasic;
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
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public User User;
        public List<Project> Projects;
        Project Project = new Project();
        void ListProject()
        {
            if (Projects.Count>0)
            {
                LeftMenuProjects.Controls.Clear();
                for (int i = Projects.Count-1; i >= 0; i--)
                {
                    ProjectForm projectForm = new ProjectForm();
                    projectForm.TopLevel = false;
                    projectForm.Dock = DockStyle.Top;
                    projectForm.Project = Projects[i];
                    LeftMenuProjects.Controls.Add(projectForm);
                    projectForm.Show();
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            btnFormMinimized.FlatAppearance.BorderSize = 0;
            btnApplicationExit.FlatAppearance.BorderSize = 0;
            //FORM PROPERTIES
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height-40);
            this.Location = new Point(0, 0);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Teal;
            //USER NAME 
            btnAccount.Text = User.Name;
            //GET - LİST PROJECT
            Projects = Project.GetProjectID(User.ID);
            ListProject();
        }
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
        bool isProjectViewClicked = false;
        private void btnProjectView_Click(object sender, EventArgs e)
        {
            if (!isProjectViewClicked)
            {
                if (LeftMenu.Width > 0)
                {
                    isProjectViewClicked = true;
                    timerLeftMenuHide.Start();
                }
                else
                {
                    isProjectViewClicked = true;
                    timerLeftMenuUnhide.Start();
                }
            }
        }
        private void btnApplicationExit_Click(object sender, EventArgs e)
        {
            Form[] Forms = this.MdiChildren;
            for (int i = 0; i < Forms.Length; i++)
                Forms[i].Close();
            Login frmLogin = Application.OpenForms["Login"] as Login;
            frmLogin.Close();
        }

        private void btnFormMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timerLeftMenuHide_Tick(object sender, EventArgs e)
        {
            LeftMenu.Width -= 20;
            if (LeftMenu.Width <= 0)
            {
                timerLeftMenuHide.Stop();
                isProjectViewClicked = false;
            }
        }
        private void timerLeftMenuUnhide_Tick(object sender, EventArgs e)
        {
            LeftMenu.Width += 20;
            if (LeftMenu.Width >= 200)
            {
                timerLeftMenuUnhide.Stop();
                isProjectViewClicked = false;
            }
        }

        private void TopMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
             string projectTitle = Interaction.InputBox("Proje Başlığını Giriniz.", "Proje Başlığı", "", -1, -1);
             if (projectTitle != "" && TextControl(projectTitle))
             {
                if (projectTitle.Length <= 25)
                {
                    Projects.Add(Project.ProjectAdd(User.ID, projectTitle));
                    ListProject();
                }
                else
                {
                    MessageBox.Show("Proje başlığı en fazla 25 karakter olabilir.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
             }
        }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frmLogin = (Login)Application.OpenForms["Login"];
            frmLogin.user = new User();
            this.Close();
            frmLogin.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            AccountMenu.Show(btnAccount, new Point(0, btnAccount.Height));
        }

        private void btnApplicationExit_MouseEnter(object sender, EventArgs e)
        {
            btnApplicationExit.BackColor = Color.Red;
        }

        private void btnApplicationExit_MouseLeave(object sender, EventArgs e)
        {
            btnApplicationExit.BackColor = Color.Transparent;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                foreach (Form form in this.MdiChildren)
                {
                    form.Close();
                }
                Login frmLogin = Application.OpenForms["Login"] as Login;
                frmLogin.Close();
            }
        }
    }
}
