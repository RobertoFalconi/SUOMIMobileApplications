using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class GestioneFinnishSaunas
    {
        public static SqlConnection Connetti()
        {
            string connectionString = "Data Source=AC-RFALCONI;Initial Catalog=AndroidSUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static List<String> ReadFinnishSauna()
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM FinnishSaunas";

            List<String> usersEnqueued = new List<String>();

            SqlDataReader reader;
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usersEnqueued.Add(reader["UsersEnqueued"].ToString());
                }
                reader.Close();
                conn.Close();
            }

            return usersEnqueued;
        }
        public static void EnqueueInFinnishSauna(User userDaInserire)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@IdUsersEnqueued", userDaInserire.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", userDaInserire.Nickname);

                command.CommandText = "INSERT INTO FinnishSaunas (IdUsersEnqueued, UsersEnqueued) VALUES (@IdUsersEnqueued, @UsersEnqueued)";
                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void DequeueFromFinnishSauna(User userDaRimuovere)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@IdUsersEnqueued", userDaRimuovere.Id);

                command.CommandText = "DELETE FinnishSaunas WHERE IdUsersEnqueued = @IdUsersEnqueued";

                command.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
