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
            string connectionString = "Data Source=AC-RFALCONI\\SQLEXPRESS;Initial Catalog=AndroidSUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static FinnishSauna ReadFinnishSauna(int id)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM FinnishSaunas WHERE FinnishSaunas.Id = '" + id + "'";

            FinnishSauna finnishSaunaToRead = null;

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

                    finnishSaunaToRead = new FinnishSauna(id_ret, usersEnqueued);
                }
                reader.Close();
                conn.Close();
            }

            return finnishSaunaToRead;
        }

        public static void UpdateFinnishSauna(FinnishSauna finnishSaunaToUpdate)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", finnishSaunaToUpdate.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", finnishSaunaToUpdate.UsersEnqueued);

                command.CommandText = "UPDATE FinnishSaunas SET UsersEnqueued = @UsersEnqueued " +
                                      "WHERE Id = @Id";

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
