using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZM_3105
{
    public class Project
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public int ID { get; set; }
        public string Title { get; set; }
        public List<EventTab> eventTabs;
        private int ProjectIDCreator()
        {
            Random rnd = new Random();
            int tempProjectID = rnd.Next(1, 9999) + 10000;
            while (true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from projectTable where projectID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", tempProjectID);
                connection.Open();
                int projectIDCounter = (int)cmd.ExecuteScalar();
                connection.Close();
                if (projectIDCounter <= 0)
                {
                    break;
                }
                tempProjectID = rnd.Next(1, 99999) + 7000000;
            }
            return tempProjectID;
        }
        private bool UserConnectionProjectTableIsThereAnything(int userID)
        {
            SqlCommand cmd = new SqlCommand("select COUNT(*) from UserConnectionProject where userID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", userID);
            connection.Open();
            int projectCounter = (int)cmd.ExecuteScalar();
            connection.Close();
            if (projectCounter > 0) return true; else return false;
        }
        public List<Project> GetProjectID(int userID)
        {
            if (UserConnectionProjectTableIsThereAnything(userID))
            {
                List<Project> Projects = new List<Project>();
                SqlCommand cmd = new SqlCommand("select * from UserConnectionProject where userID=@ID  ORDER BY addDate ASC", connection);
                cmd.Parameters.AddWithValue("@ID", userID);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Projects.Add(new Project { ID = (int)sdr["projectID"] });
                }
                connection.Close();
                return GetProject(Projects);
            }
            return new List<Project>();
        }
        private List<Project> GetProject(List<Project> Projects)
        {
            foreach (var project in Projects)
            {
                SqlCommand cmd = new SqlCommand("select * from projectTable where projectID=@ID",connection);
                cmd.Parameters.AddWithValue("@ID",project.ID);
                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                project.Title = (string)sdr["projectTitle"];
                connection.Close();
            }
            return Projects;
        }
        public Project ProjectAdd(int userID, string title)
        {
            int projectID = ProjectIDCreator();
            SqlCommand cmd = new SqlCommand("insert into projectTable(projectID,projectTitle) values (@ID,@title)", connection);
            cmd.Parameters.AddWithValue("@ID", projectID);
            cmd.Parameters.AddWithValue("@title", title);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            ProjectUserConnectionAdd(userID, projectID);
            Project project = new Project();
            project.ID = projectID;
            project.Title = title;
            return project;

        }
        public void ProjectUserConnectionAdd(int userID, int projectID)
        {
            SqlCommand cmd = new SqlCommand("insert into UserConnectionProject(projectID,userID) values (@projectID,@userID)", connection);
            cmd.Parameters.AddWithValue("@projectID", projectID);
            cmd.Parameters.AddWithValue("@userID", userID);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private bool ProjectUserConnectionController(int userID)
        {
            SqlCommand cmd = new SqlCommand("Select COUNT(*) from UserConnectionProject where userID=@userID and projectID=@projectID",connection);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@projectID", this.ID);
            connection.Open();
            int userCounter = (int)cmd.ExecuteScalar();
            connection.Close();
            if (userCounter > 0) return true; else return false;
        }
        public string AddUserProject(string userMail)
        {
            User user = new User();
            int userID = user.UserMailController(userMail);
            if (ProjectUserConnectionController(userID))
            {
                return "Kullanıcı zaten projede";
                
            }
            else if (userID > 0)
            {
                ProjectUserConnectionAdd(userID, this.ID);
                return "Kullanıcı projeye eklendi";
            }
            else
            {
                return "Kullanıcı bulunamadı";
            }
        }
        public void Delete()
        {
            string[] sqlTableNames = { "ProjectTable", "UserConnectionProject" };
            foreach (string sqlTableName in sqlTableNames)
            {
                SqlCommand cmd = new SqlCommand("delete from "+sqlTableName+" where projectID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}
