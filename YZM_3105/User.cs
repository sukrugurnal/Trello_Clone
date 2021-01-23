using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace YZM_3105
{
    public class User
    {
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True");
        public int ID;
        public string Name { get; set; }
        public string Mail;
        private int UserIDCreator()
        {
            Random rnd = new Random();
            int tempUserID = rnd.Next(1, 9999) + 10000;
            while (true)
            {
                SqlCommand cmd = new SqlCommand("select COUNT(*) from userTable where userID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", tempUserID);
                connection.Open();
                int userIDCounter = (int)cmd.ExecuteScalar();
                connection.Close();
                if (userIDCounter <= 0)
                {
                    break;
                }
                tempUserID = rnd.Next(1, 99999) + 8000000;
            }
            return tempUserID;
        }
        public bool ConnectionQuery(string userName,string userPassword)
        {
            SqlCommand cmd = new SqlCommand("select * from userTable where userName=@name and userPassword=@pass", connection);
            cmd.Parameters.AddWithValue("@name",userName);
            cmd.Parameters.AddWithValue("@pass",userPassword);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if ((sdr["userName"].ToString() == userName) && (sdr["userPassword"].ToString() == userPassword))
                {
                    ID = (int)sdr["userID"];
                    Name = (string)sdr["userName"];
                    Mail = (string)sdr["userMail"];
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;
        }
        public string NewUserSave(string userName,string userPassword,string userMail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into userTable(userID,userName,userPassword,userMail) values (@ID,@name,@password,@mail)", connection);
                cmd.Parameters.AddWithValue("@ID", UserIDCreator());
                cmd.Parameters.AddWithValue("@name", userName);
                cmd.Parameters.AddWithValue("@password", userPassword);
                cmd.Parameters.AddWithValue("@mail", userMail);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return "Kayıt Başarılı";
            }
            catch (Exception)
            {
                return "Kayıt Başarısız";
                throw;
            }
           

        }
        public int UserMailController(string userMail)
        {
            int userID = 0;
            SqlCommand cmd = new SqlCommand("select userID from userTable where userMail=@mail", connection);
            cmd.Parameters.AddWithValue("@mail", userMail);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (Convert.ToInt32(sdr[0]) > 0)
                {
                    userID = (int)sdr[0];
                }
            }
            connection.Close();
            return userID;
        }
        public bool UserNameController(string userName)
        {
            SqlCommand cmd = new SqlCommand("select * from userTable where userName=@name",connection);
            cmd.Parameters.AddWithValue("@name",userName);
            connection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["userName"].ToString() == userName)
                {
                    connection.Close();
                    return false;
                }
            }
            connection.Close();
            return true;
        }
    }
}
