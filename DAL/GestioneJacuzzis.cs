using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;

namespace DAL
{
    public class GestioneJacuzzis
    {
        public static SqlConnection Connetti()
        {
            string connectionString = "Data Source=AC-RFALCONI\\SQLEXPRESS;Initial Catalog=AndroidSUOMI;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static Jacuzzi ReadJacuzzi(int id)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Jacuzzis WHERE Jacuzzis.Id = '" + id + "'";

            Jacuzzi jacuzziToRead = null;

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

                    jacuzziToRead = new Jacuzzi(id_ret, usersEnqueued);
                }
                reader.Close();
                conn.Close();
            }

            return jacuzziToRead;
        }

        public static void UpdateJacuzzi(Jacuzzi jacuzziToUpdate)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@Id", jacuzziToUpdate.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", jacuzziToUpdate.UsersEnqueued);

                command.CommandText = "UPDATE Jacuzzis SET UsersEnqueued = @UsersEnqueued " +
                                      "WHERE Id = @Id";

                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
