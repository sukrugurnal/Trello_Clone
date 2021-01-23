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
    public partial class ProjectView : Form
    {
        public ProjectView()
        {
            InitializeComponent();
        }
        public Project Project;
        EventTab eventTab;
        void SortList()
        {
            int startLocationX = 12, startLocationY = 12;
            foreach (EventTab eventTab in Project.eventTabs)
            {
                eventTab.Location = new Point(startLocationX, startLocationY);
                this.Controls.Add(eventTab);
                startLocationX += eventTab.Width + 12;
                btnListAdd.Location = new Point(startLocationX, btnListAdd.Location.Y);
            }
        }
        private void ProjectView_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = new Size(this.Parent.Width-6, this.Parent.Height-6);
            Project.eventTabs = new List<EventTab>();
            eventTab = new EventTab(Project.ID);
            Project.eventTabs = eventTab.GetList();
            SortList();
        }
        private void btnListAdd_Click(object sender, EventArgs e)
        {
            eventTab = new EventTab(Project.ID);
            eventTab.Save();
            Project.eventTabs.Add(eventTab);
            SortList();
        }

        private void ProjectView_ControlAdded(object sender, ControlEventArgs e)
        {
            if (Project.eventTabs.Count == 5)
            {
                btnListAdd.Visible = false;
            }
        }

        private void ProjectView_ControlRemoved(object sender, ControlEventArgs e)
        {
            EventTab _eventTab = (EventTab)e.Control;
            Project.eventTabs.Remove(_eventTab);
            if (Project.eventTabs.Count <= 4)
            {
                btnListAdd.Visible = true;
                btnListAdd.Location = new Point(btnListAdd.Location.X - (btnListAdd.Width + 6), btnListAdd.Location.Y);
            }
            SortList();
        }
        private void ProjectView_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (EventTab eventTab in Project.eventTabs)
            {
                eventTab.eventTabTitleUpdate();
            }
        }
    }
}
