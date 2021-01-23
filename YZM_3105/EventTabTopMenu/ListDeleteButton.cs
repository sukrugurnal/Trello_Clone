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
    public class ListDeleteButton : Button
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public ListDeleteButton()
        {
            this.Dock = System.Windows.Forms.DockStyle.Right;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColor = Color.Teal;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "button1";
            this.Click += ListDeleteButton_Click; ;
            this.Size = new System.Drawing.Size(60, 30);
            this.TabIndex = 4;
            this.Text = "Listeyi Sil";
        }

        private void ListDeleteButton_Click(object sender, EventArgs e)
        {
            EventTab eventTab = (EventTab)this.Parent.Parent;
            SqlCommand cmd = new SqlCommand("delete from eventTab where eventTabID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", eventTab.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            cmd = new SqlCommand("delete from task where eventTabID=@ID",connection);
            cmd.Parameters.AddWithValue("@ID", eventTab.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            eventTab.Parent.Controls.Remove(eventTab);

            MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
            foreach(TaskClass task in eventTab.tasks)
            {
                foreach(TabControlPanelItem item in mainForm.TabControlPanel.Controls)
                {
                    if (item.Form.Name == task.ID.ToString())
                    {
                        item.CloseButton.close();
                    }
                }
               
            }

        }
    }
}
