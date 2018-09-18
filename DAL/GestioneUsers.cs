using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class GestioneUsers
    {
        public static SqlConnection Connetti()
        {
            string connectionString = ConnectionString.connectionString;
            return new SqlConnection(connectionString);
        }
        public static void CreateUser(User userDaInserire)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Nickname", userDaInserire.Nickname);
                command.Parameters.AddWithValue("@Password", userDaInserire.Password);
                if (!String.IsNullOrEmpty(userDaInserire.FacebookID))
                {
                    command.Parameters.AddWithValue("@FacebookID", userDaInserire.FacebookID);
                    command.CommandText = "INSERT INTO Users (Nickname, Password, FacebookID) VALUES (@Nickname, @Password, @FacebookID)";
                } else
                {
                    command.CommandText = "INSERT INTO Users (Nickname, Password) VALUES (@Nickname, @Password)";
                }

                command.ExecuteNonQuery();

                conn.Close();
            }

            string query = "SELECT Id FROM Users WHERE Users.Nickname = '" + userDaInserire.Nickname + "'";
            SqlConnection conn2 = Connetti();
            SqlDataReader reader;
            using (conn2)
            {
                conn2.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn2;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    userDaInserire.Id = id;
                }

            }
        }

        public static User ReadUser(String Nickname, String Password)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Users WHERE Users.Nickname = '" + Nickname + "' AND Users.Password = '" + Password + "'";

            User userDaRestituire = null;

            SqlDataReader reader;
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string nickname = reader["Nickname"]?.ToString();
                    string password = reader["Password"]?.ToString();

                    userDaRestituire = new User(id, nickname, password);
                }
                reader.Close();
                conn.Close();
            }
            BE.User.CurrentUser = userDaRestituire;
            return userDaRestituire;
        }
        public static User ReadUser(int id)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Users WHERE Users.Id = '" + id + "'";

            User userDaRestituire = null;

            SqlDataReader reader;
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id_ret = (int)reader["Id"];
                    string nickname = reader["Nickname"]?.ToString();
                    string password = reader["Password"]?.ToString();

                    userDaRestituire = new User(id_ret, nickname, password);
                }
                reader.Close();
                conn.Close();
            }

            return userDaRestituire;
        }

        public static User ReadUser(string facebookID)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Users WHERE Users.FacebookID = '" + facebookID + "'";

            User userDaRestituire = null;

            SqlDataReader reader;
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id_ret = (int)reader["Id"];
                    string nickname = reader["Nickname"]?.ToString();
                    string password = reader["Password"]?.ToString();

                    userDaRestituire = new User(id_ret, nickname, password, facebookID);
                }
                reader.Close();
                conn.Close();
            }
            BE.User.CurrentUser = userDaRestituire;
            return userDaRestituire;
        }


        public static void UpdateUser(User userDaAggiornare, String nuovoNickname, String nuovaPassword)
        {
            SqlConnection conn = Connetti();
            
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", userDaAggiornare.Id);
                command.Parameters.AddWithValue("@Nickname", nuovoNickname);
                command.Parameters.AddWithValue("@Password", nuovaPassword);

                command.CommandText = "UPDATE Users SET Nickname = @Nickname, Password = @Password " +
                                      "WHERE Id = @Id";
                
                command.ExecuteNonQuery();
                conn.Close();
            }

            BE.User.CurrentUser.Nickname = nuovoNickname;
            BE.User.CurrentUser.Password = nuovaPassword;
        }


        public static void DeleteUser(User userDaRimuovere)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", userDaRimuovere.Id);

                command.CommandText = "DELETE Users WHERE Id = @Id";

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void LogOutUser(User userDaSloggare)
        {
            User.CurrentUser = null;
            userDaSloggare.Id = 0;
            userDaSloggare.Nickname = null;
            userDaSloggare.Password = null;
            userDaSloggare.FacebookID = null;
        }

        public static bool CheckNickname(string nickname)
        {
            SqlConnection conn = Connetti();

            bool result = false;

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Nickname", nickname);

                command.CommandText = "SELECT * FROM Users WHERE Nickname = @Nickname";

                result = command.ExecuteReader().HasRows;

                conn.Close();
            }

            return result;
        }

    }
}
