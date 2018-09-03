using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class GestioneKneipps
    {
        public static SqlConnection Connetti()
        {
            string connectionString = "Data Source=AC-RFALCONI\\SQLEXPRESS;Initial Catalog=AndroidSUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static Kneipp ReadKneipp(int id)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Kneipps WHERE Kneipps.Id = '" + id + "'";

            Kneipp kneippToRead = null;

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
                    List<User> usersEnqueued = (List<User>)reader["UsersEnqueued"];

                    kneippToRead = new Kneipp(id_ret, usersEnqueued);
                }
                reader.Close();
                conn.Close();
            }

            return kneippToRead;
        }

        public static void UpdateKneipp(Kneipp kneippToUpdate)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", kneippToUpdate.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", kneippToUpdate.UsersEnqueued);

                command.CommandText = "UPDATE Kneipps SET UsersEnqueued = @UsersEnqueued " +
                                      "WHERE Id = @Id";

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
