using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class EventTab : FlowLayoutPanel
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public int projectID;
        protected internal int ID;
        private EventTabTopMenu TopPanel = new EventTabTopMenu();
        private TaskAddButton BtnEventAdd = new TaskAddButton();
        private Panel dragPanel;
        public List<TaskClass> tasks;
        private bool dragController = true;
        public EventTab(int projectID)
        {
            this.Name = "eventTab";
            this.Size = new Size(250, 87);
            this.BackColor = Color.DarkSlateGray;
            this.AllowDrop = true;
            this.Controls.Add(TopPanel);
            this.Controls.Add(BtnEventAdd);
            this.AutoScroll = true;
            tasks = new List<TaskClass>();
            this.projectID = projectID;
            this.DragDrop += EventTab_DragDrop;
            this.DragEnter += EventTab_DragEnter;
            this.DragOver += EventTab_DragOver;
            this.DragLeave += EventTab_DragLeave;
            this.ControlRemoved += EventTab_ControlRemoved;
        }
        private void EventTab_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.Height -= 45;
        }
        private void EventTab_DragLeave(object sender, EventArgs e)
        {
            EventTab _destination = (EventTab)sender;
            _destination.Controls.Remove(dragPanel);
            dragController = true;
        }
        private void EventTab_DragOver(object sender, DragEventArgs e)
        {
            EventTab _destination = (EventTab)sender;
            if (dragController)
            {
                _destination.Height += 45;
                dragPanel = new Panel();
                dragPanel.Size = new Size(240,40);
                dragPanel.BackColor = Color.Teal;
                _destination.Controls.Add(dragPanel);
                _destination.Controls.SetChildIndex(dragPanel, _destination.Controls.Count - 2);
                dragController = false;
            }
           
        }
        private void EventTab_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void EventTab_DragDrop(object sender, DragEventArgs e)
        {

            TaskButton selectedButton = (TaskButton)e.Data.GetData(typeof(TaskButton));
            EventTab _destination = (EventTab)sender;
            EventTab _source = (EventTab)selectedButton.Parent;
            if (_source != _destination)
            {
                _destination.Controls.Add(selectedButton);
                _destination.tasks.Add(selectedButton.Task);
                _destination.Height += 45;
                int index = _destination.Controls.Count;
                _destination.Controls.SetChildIndex(selectedButton, index - 2);
                _destination.Invalidate();
                _source.Invalidate();
                dragController = true;
            }
            else
            {
                dragController = true;
            }
            _destination.Controls.Remove(dragPanel);
        }
        private int EventTabIDCreator()
        {
            Random rnd = new Random();
            int tempEventTabID = rnd.Next(1, 999) + 5000;
            while (true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from eventTab where eventTabID=@eventTabID", connection);
                cmd.Parameters.AddWithValue("@eventTabID", tempEventTabID);
                connection.Open();
                int eventTabIDCounter = (int)cmd.ExecuteScalar();
                connection.Close();
                if (eventTabIDCounter <= 0)
                {
                    break;
                }
                tempEventTabID = rnd.Next(1, 999) + 5000;
            }
            return tempEventTabID;
        }
        public void Save()
        {
            this.ID = EventTabIDCreator();
            SqlCommand cmd = new SqlCommand("insert into eventTab(eventTabID,eventTabTitle,projectID) values (@eventTabID,@eventTabTitle,@projectID)",connection);
            cmd.Parameters.AddWithValue("@eventTabID", this.ID);
            cmd.Parameters.AddWithValue("@eventTabTitle", this.TopPanel.TbTitle.Text);
            cmd.Parameters.AddWithValue("@projectID", this.projectID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public List<EventTab> GetList()
        {
            List<EventTab> eventTabs = new List<EventTab>();
            TaskClass task = new TaskClass();
            SqlCommand cmd = new SqlCommand("select * from eventTab where projectID=@projectID ORDER BY evenTabTableAddDate ASC", connection);
            cmd.Parameters.AddWithValue("@projectID", projectID);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                EventTab eventTab = new EventTab(this.projectID);
                eventTab.ID = (int)sdr["eventTabID"];
                eventTab.tasks = task.Get(eventTab.ID);
                foreach (TaskClass item in eventTab.tasks)
                {
                    eventTab.Controls.Add(item.TaskButton);
                    eventTab.Controls.SetChildIndex(eventTab.BtnEventAdd, eventTab.Controls.Count);
                    eventTab.Height += item.TaskButton.Height+6;
                }
                eventTab.TopPanel.TbTitle.Text = sdr["eventTabTitle"].ToString();
                eventTabs.Add(eventTab);
            }
            connection.Close();
            return eventTabs;
        }
        public void eventTabTitleUpdate()
        {
            SqlCommand cmd = new SqlCommand("update eventTab set eventTabTitle=@title where eventTabID=@ID",connection);
            cmd.Parameters.AddWithValue("@title", this.TopPanel.TbTitle.Text);
            cmd.Parameters.AddWithValue("@ID", this.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}
