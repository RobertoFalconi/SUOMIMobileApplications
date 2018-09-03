using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class GestioneTurkishBaths
    {
        public static SqlConnection Connetti()
        {
            string connectionString = "Data Source=AC-RFALCONI;Initial Catalog=AndroidSUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static List<String> ReadTurkishBath()
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM TurkishBaths";

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

        public static void UpdateTurkishBath(TurkishBath turkishBathToUpdate)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", turkishBathToUpdate.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", turkishBathToUpdate.UsersEnqueued);

                command.CommandText = "UPDATE TurkishBaths SET UsersEnqueued = @UsersEnqueued " +
                                      "WHERE Id = @Id";

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
