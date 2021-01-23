using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace YZM_3105
{
    public class WorkFollow
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public TextBox ID = new TextBox() { ForeColor = Color.DarkSlateGray, Enabled = false };
        public TextBox Date = new TextBox() { ForeColor = Color.DarkSlateGray, MaxLength = 100 };
        public TextBox Status = new TextBox() { ForeColor = Color.DarkSlateGray, MaxLength = 100 };
        public TextBox Work = new TextBox() { ForeColor = Color.DarkSlateGray, MaxLength = 100 };
        public TextBox Comment = new TextBox() { ForeColor = Color.DarkSlateGray, MaxLength = 100 };
        public Button WorkFollowDeleteButton = new Button() { Text = "X", ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Width = 25, Height = 25, TextAlign = ContentAlignment.MiddleCenter };
        private int workFollowIDCreator()
        {
            Random rnd = new Random();
            int tempWorkFolloID = rnd.Next(1, 9999) + 10000;
            while (true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from workFollow where workFollowID=@workFollowID", connection);
                cmd.Parameters.AddWithValue("@workFollowID", tempWorkFolloID);
                connection.Open();
                int workFollowIDCounter = (int)cmd.ExecuteScalar();
                connection.Close();
                if (workFollowIDCounter <= 0)
                {
                    break;
                }
                tempWorkFolloID = rnd.Next(1, 9999) + 10000;
            }
            return tempWorkFolloID;
        }
        public WorkFollow()
        {
            WorkFollowDeleteButton.Click += WorkFollowDeleteButton_Click;
        }

        private void WorkFollowDeleteButton_Click(object sender, EventArgs e)
        {
            Delete(Convert.ToInt32(this.ID.Text));
            TaskForm taskForm = this.WorkFollowDeleteButton.Parent.Parent.Parent as TaskForm;
            taskForm.tableWorkFollow.Controls.Remove(this.ID);
            taskForm.tableWorkFollow.Controls.Remove(this.Date);
            taskForm.tableWorkFollow.Controls.Remove(this.Status);
            taskForm.tableWorkFollow.Controls.Remove(this.Work);
            taskForm.tableWorkFollow.Controls.Remove(this.Comment); 
            taskForm.tableWorkFollow.Controls.Remove(this.WorkFollowDeleteButton);
            taskForm.task.workFollows.Remove(this);
            taskForm.workFollowTableRowSort();
            System.Threading.Thread.Sleep(1000);
        }

        public WorkFollow Create(int taskID)
        {
            this.ID.Text = workFollowIDCreator().ToString();
            SqlCommand cmd = new SqlCommand("insert into workFollow(workFollowID,taskID,Date,Status,Work,Comment) values (@workFollowID,@taskID,@Date,@Status,@Work,@Comment)",connection);
            cmd.Parameters.AddWithValue("@WorkFollowID", Convert.ToInt32(this.ID.Text));
            cmd.Parameters.AddWithValue("@taskID", taskID);
            cmd.Parameters.AddWithValue("@Date",Date.Text);
            cmd.Parameters.AddWithValue("@Status",Status.Text);
            cmd.Parameters.AddWithValue("@Work",Work.Text);
            cmd.Parameters.AddWithValue("@Comment",Comment.Text);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return this;
        }
        public List<WorkFollow> Get(int taskID)
        {
            List<WorkFollow> workFollows = new List<WorkFollow>();
            SqlCommand cmd = new SqlCommand("select * from workFollow where taskID=@taskID",connection);
            cmd.Parameters.AddWithValue("@taskID",taskID);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                WorkFollow workFollow = new WorkFollow();
                workFollow.ID.Text = sdr["workFollowID"].ToString();
                workFollow.Date.Text = (string)sdr["Date"];
                workFollow.Status.Text = (string)sdr["Status"];
                workFollow.Work.Text = (string)sdr["Work"];
                workFollow.Comment.Text = (string)sdr["Comment"];
                workFollows.Add(workFollow);
            }
            connection.Close();
            return workFollows;
        }
        public void Delete(int workFollowID)
        {
            SqlCommand cmd = new SqlCommand("delete from workFollow where workFollowID=@ID",connection);
            cmd.Parameters.AddWithValue("@ID",workFollowID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void AllWorkFollowDelete(int taskID)
        {
            SqlCommand cmd = new SqlCommand("delete from workFollow where taskID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", taskID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
