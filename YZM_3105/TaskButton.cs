using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TaskButton : Button
    {
        public TaskClass Task;
        private bool isMouseDown = false;
        private int mouseDownX = 0;
        private int mouseDownY = 0;
        public TaskButton(TaskClass task)
        {
            Task = task;
            this.Name = "addEventButton";
            this.Size = new System.Drawing.Size(240, 40);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.BackColor = Color.Teal;
            this.ForeColor = Color.White;
            this.MouseDown += TaskButton_MouseDown;
            this.MouseMove += TaskButton_MouseMove;
            this.MouseUp += TaskButton_MouseUp;
            this.Click += TaskButton_Click;
            this.ParentChanged += TaskButton_ParentChanged;
        }

        private void TaskButton_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                EventTab eventTab = this.Parent as EventTab;
                if (eventTab.ID != Task.EventTabID)
                {
                    Task.EventTabID = eventTab.ID;
                    Task.UpdateParent();
                }
            }
        }

        private void TaskButton_Click(object sender, EventArgs e)
        {
            bool activeForm = false;
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
            foreach (TabControlPanelItem tabControlPanelItem in mainForm.TabControlPanel.Controls)
            {
                if (tabControlPanelItem.TabButton.Text == this.Text)
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
                EventTab eventTab = this.Parent as EventTab;
                TaskForm TaskForm = new TaskForm();
                TaskForm.task = this.Task;
                TaskForm.projectID = eventTab.projectID;
                TaskForm.MdiParent = mainForm;
                TabControlPanelItem tabControlPanelItem = new TabControlPanelItem(this.Text);
                tabControlPanelItem.Form = TaskForm;
                mainForm.TabControlPanel.Controls.Add(tabControlPanelItem);
                mainForm.TabControlPanel.Controls.SetChildIndex(tabControlPanelItem, 0);
                TaskForm.Show();
            }
        }

        private void TaskButton_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void TaskButton_MouseMove(object sender, MouseEventArgs e)
        {
            ProjectView projectView = this.Parent.Parent as ProjectView;
            if (isMouseDown)
            {
                if (Math.Abs(mouseDownX - e.X) > 10 || Math.Abs(mouseDownY - e.Y) > 10)
                {
                    Button selectedButton = (Button)sender;
                    selectedButton.DoDragDrop(selectedButton, DragDropEffects.All);
                    isMouseDown = false;
                }
                
            }
        }
        private void TaskButton_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownX = e.X;
            mouseDownY = e.Y;
            isMouseDown = true;
        }
    }
}
