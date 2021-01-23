using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }
        public Project Project;
        MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
        private void Project_Load(object sender, EventArgs e)
        {
            lbProjectTitle.Text = Project.Title;
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
        private void btnInvite_Click(object sender, EventArgs e)
        {
            string projectTitle = Interaction.InputBox("Projeye eklenecek kişinin e-postasını giriniz", "Projeye Ekle.", "", -1, -1);
            if (projectTitle != "" && TextControl(projectTitle))
            {
               MessageBox.Show(Project.AddUserProject(projectTitle));
            }
        }

        private void btnProjectView_Click(object sender, EventArgs e)
        {
            bool activeForm = false;
            foreach (TabControlPanelItem tabControlPanelItem in mainForm.TabControlPanel.Controls)
            {
                if (tabControlPanelItem.TabButton.Text == Project.Title)
                {
                    tabControlPanelItem.TabButton.HideForms();
                    tabControlPanelItem.BorderStyle = BorderStyle.Fixed3D;
                    tabControlPanelItem.Form.Show();
                    tabControlPanelItem.Form.Location = new Point(0, 0);
                    activeForm = true;
                    break;
                }
            }
            if (!activeForm)
            {
                ProjectView projectView = new ProjectView();
                projectView.Project = this.Project;
                TabControlPanelItem tabControlPanelItem = new TabControlPanelItem(Project.Title);
                tabControlPanelItem.Form = projectView;
                mainForm.TabControlPanel.Controls.Add(tabControlPanelItem);
                mainForm.TabControlPanel.Controls.SetChildIndex(tabControlPanelItem,0);
                projectView.MdiParent = mainForm;
                projectView.Show();
            }
         
        }

        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lbProjectTitle.Text+" adlı projeyi silmek istediğinizden emin misiniz ?","QUESTİON",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Project.Delete();
                mainForm.Projects.Remove(Project);
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
