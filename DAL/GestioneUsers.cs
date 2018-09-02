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
            string connectionString = "Data Source=AC-RFALCONI\\SQLEXPRESS;Initial Catalog=SUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
        public static void InsertUser(User userDaInserire)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Nickname", userDaInserire.Nickname);
                command.Parameters.AddWithValue("@Password", userDaInserire.Password);

                command.CommandText = "INSERT INTO Users (Nickname, Password) VALUES (@Nickname, @Password)";
                command.ExecuteNonQuery();

                conn.Close();
            }
        }
        public static User GetUser(String Nickname)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Users WHERE Users.Nickname = '" + Nickname + "'";

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

            return userDaRestituire;
        }
        public static User GetUser(int id)
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
    }
}
