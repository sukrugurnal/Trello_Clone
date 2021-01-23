using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TaskAddButton : Button
    {

        public TaskAddButton()
        {
            this.Name = "addTaskButton";
            this.Text = "Task Ekle";
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Teal;
            this.ForeColor = Color.White;
            this.Click += TaskAddButton_Click;
            this.Size = new System.Drawing.Size(240, 40);
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
        }

        private void TaskAddButton_Click(object sender, EventArgs e)
        {
            EventTab eventTab = (EventTab)this.Parent;
            TaskClass task = new TaskClass();
            task.EventTabID = eventTab.ID;
            task.Add();
            eventTab.tasks.Add(task);
            eventTab.Controls.Add(task.TaskButton);
            eventTab.Controls.SetChildIndex(this, eventTab.tasks.Count + 1);

            if ((eventTab.Height + task.TaskButton.Height + 6 + this.Height) < eventTab.Parent.Height)
            {
                eventTab.Size = new Size(eventTab.Width, eventTab.Height + task.TaskButton.Height + 6);
            }
        }
    }
}
