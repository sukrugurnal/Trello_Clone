using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TaskClass
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public int ID { get; private set; }
        public int EventTabID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int GuessTime { get; set; }
        public int RealTime { get; set; }
        public int TechnicalPersonID { get; set; }
        public string WorkComment { get; set; }
        public string Note { get; set; }
        public Boolean taskFinish;
        public List<WorkFollow> workFollows = new List<WorkFollow>();
        public BindingList<User> technicalPersons = new BindingList<User>();
        public TaskButton TaskButton;
        public TaskClass()
        {
            if (TaskButton == null)
            {
                TaskButton = new TaskButton(this);
            }
            
        }
        int TaskIDCreator()
        {
            Random rnd = new Random();
            int tempTaskID = rnd.Next(1, 999) + 1000;
            while (true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from task where taskID=@taskID", connection);
                cmd.Parameters.AddWithValue("@taskID", tempTaskID);
                connection.Open();
                int taskIDCounter = (int)cmd.ExecuteScalar();
                connection.Close();
                if (taskIDCounter <= 0)
                {
                    break;
                }
                tempTaskID = rnd.Next(1, 999) + 1000;
            }
            return tempTaskID;
        }
        public void Add()
        {
            this.ID = TaskIDCreator();
            this.Date = DateTime.Today;
            SqlCommand cmd = new SqlCommand("insert into task(taskID,eventTabID,taskTitle,taskDate) values (@ID,@eventTabID,@taskTitle,@date)", connection);
            cmd.Parameters.AddWithValue("@ID", this.ID);
            cmd.Parameters.AddWithValue("@eventTabID", this.EventTabID);
            cmd.Parameters.AddWithValue("@taskTitle", this.ID.ToString() + " - Task");
            cmd.Parameters.AddWithValue("@date", this.Date);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            this.TaskButton.Text = this.ID + " - Task";
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand("delete from task where taskID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", this.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand("update task set taskTitle=@title,taskGuessTime=@guessTime,taskRealTime=@realTime,taskTechnicalPerson=@technicalPerson,taskWorkComment=@comment,taskNotes=@note  where taskID=@ID", connection);
            cmd.Parameters.AddWithValue("@title",this.Title);
            cmd.Parameters.AddWithValue("@guessTime",this.GuessTime);
            cmd.Parameters.AddWithValue("@realTime",this.RealTime);
            cmd.Parameters.AddWithValue("@technicalPerson",this.TechnicalPersonID);
            cmd.Parameters.AddWithValue("@comment",this.WorkComment);
            cmd.Parameters.AddWithValue("@note",this.Note);
            cmd.Parameters.AddWithValue("@ID",this.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            foreach (WorkFollow workFollow in this.workFollows)
            {
                SqlCommand cmdWorkFollow = new SqlCommand("update workFollow set Date=@date,Status=@status,Work=@work,Comment=@comment where workFollowID=@ID", connection);
                cmdWorkFollow.Parameters.AddWithValue("@date",workFollow.Date.Text);
                cmdWorkFollow.Parameters.AddWithValue("@status",workFollow.Status.Text);
                cmdWorkFollow.Parameters.AddWithValue("@work",workFollow.Work.Text);
                cmdWorkFollow.Parameters.AddWithValue("@comment",workFollow.Comment.Text);
                cmdWorkFollow.Parameters.AddWithValue("@ID",workFollow.ID.Text);
                connection.Open();
                cmdWorkFollow.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateParent()
        {
            SqlCommand cmd = new SqlCommand("update Task set eventTabID=@eventTabID,taskTableAddDate=@date where taskID=@taskID",connection);
            cmd.Parameters.AddWithValue("@eventTabID", this.EventTabID);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@taskID", this.ID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    
        public List<TaskClass> Get(int eventTabID)
        {
            List<TaskClass> tasks = new List<TaskClass>();
            SqlCommand cmd = new SqlCommand("select * from Task where eventTabID=@eventTabID ORDER BY taskTableAddDate ASC", connection);
            cmd.Parameters.AddWithValue("@eventTabID", eventTabID);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TaskClass task = new TaskClass();
                task.ID = (int)sdr["taskID"];
                task.EventTabID = (int)sdr["eventTabID"];
                task.Title = (string)sdr["taskTitle"];
                task.Date = (DateTime)sdr["taskDate"];
                task.GuessTime = (int)sdr["taskGuessTime"];
                task.RealTime = (int)sdr["taskRealTime"];
                task.TechnicalPersonID = (int)sdr["taskTechnicalPerson"];
                task.WorkComment = (string)sdr["taskWorkComment"];
                task.Note = (string)sdr["taskNotes"];
                task.TaskButton.Text = task.Title;
                task.taskFinish = (Boolean)sdr["taskFinish"];
                WorkFollow workFollow = new WorkFollow();
                task.workFollows = workFollow.Get(task.ID);
                tasks.Add(task);
            }
            connection.Close();
            return tasks;
        }
        public void GetTechnicalPerson(int projectID)
        {
            SqlCommand cmd = new SqlCommand("select U.userID, U.userName,U.userMail from userTable U inner join UserConnectionProject P on U.userID = P.userID where P.projectID=@ID",connection);
            cmd.Parameters.AddWithValue("ID",projectID);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                User technicalPerson = new User();
                technicalPerson.ID = (int)sdr["userID"];
                technicalPerson.Name = (string)sdr["userName"];
                technicalPerson.Mail = (string)sdr["userMail"];
                technicalPersons.Add(technicalPerson);
            }
            connection.Close();
        }
        public void Finish(int commentLength,int noteLenght)
        {
            SqlCommand cmd = new SqlCommand("insert into FinishTime(userID,taskFinishTime,taskCommentLength,taskNoteLength,taskWorkFollowRowCount) values (@ID,@finishTime,@commentLength,@noteLength,@workFollowRowCount)",connection);
            cmd.Parameters.AddWithValue("@ID",this.TechnicalPersonID);
            cmd.Parameters.AddWithValue("@finishTime",this.RealTime);
            cmd.Parameters.AddWithValue("@commentLength",commentLength);
            cmd.Parameters.AddWithValue("@noteLength", noteLenght);
            cmd.Parameters.AddWithValue("@workFollowRowCount",workFollows.Count);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            SqlCommand cmdFinishTask = new SqlCommand("update task set taskFinish='true',taskRealTime=@time,taskTitle=@title where taskID=@ID",connection);
            cmdFinishTask.Parameters.AddWithValue("@ID",this.ID);
            cmdFinishTask.Parameters.AddWithValue("@title", this.Title);
            cmdFinishTask.Parameters.AddWithValue("@time", this.RealTime);
            connection.Open();
            cmdFinishTask.ExecuteNonQuery();
            connection.Close();

        }
    }
}


