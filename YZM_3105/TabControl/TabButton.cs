using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TabButton : Button
    {
       
        public TabButton(string projectTitle)
        {
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColor = Color.Teal;
            this.ForeColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.Name = "TabButton";
            this.Click += TabButton_Click;
            this.AutoSize = true;
            this.Text = projectTitle;
            HideForms();
        }
        public void showForm()
        {
            HideForms();
            TabControlPanelItem tabControlPanelItem = (TabControlPanelItem)this.Parent;
            tabControlPanelItem.Form.Show();
            tabControlPanelItem.Form.Location = new Point(0, 0);
            tabControlPanelItem.BorderStyle = BorderStyle.Fixed3D;
        }
        private void TabButton_Click(object sender, EventArgs e)
        {
            showForm();
        }
        public void HideForms()
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
            foreach (var Form in mainForm.MdiChildren)
            {
                if (Form.Name == "ProjectView" || Form.Name == "TaskForm")
                {
                    Form.Hide();
                }
            }
            foreach (TabControlPanelItem tabControlPanelItem in mainForm.TabControlPanel.Controls)
            {
                tabControlPanelItem.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
