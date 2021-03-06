﻿using System;
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
            string connectionString = ConnectionString.connectionString;
            return new SqlConnection(connectionString);
        }

        public static List<String> ReadJacuzzi()
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Jacuzzis";

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

        public static void EnqueueInJacuzzi(User userDaInserire)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@IdUsersEnqueued", userDaInserire.Id);
                command.Parameters.AddWithValue("@UsersEnqueued", userDaInserire.Nickname);

                command.CommandText = "INSERT INTO Jacuzzis (IdUsersEnqueued, UsersEnqueued) VALUES (@IdUsersEnqueued, @UsersEnqueued)";
                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static void DequeueFromJacuzzi(User userDaRimuovere)
        {
            SqlConnection conn = Connetti();

            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Parameters.AddWithValue("@IdUsersEnqueued", userDaRimuovere.Id);

                command.CommandText = "DELETE Jacuzzis WHERE IdUsersEnqueued = @IdUsersEnqueued";

                command.ExecuteNonQuery();

                conn.Close();
            }
        }

        public static bool ControllaUtente(User utenteDaRestituire)
        {
            SqlConnection conn = Connetti();

            string query = "SELECT * FROM Jacuzzis WHERE UsersEnqueued = '" + utenteDaRestituire.Nickname + "'";

            bool userDaRestituire = false;

            SqlDataReader reader;
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query);
                command.Connection = conn;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string nickname = reader["UsersEnqueued"]?.ToString();
                    userDaRestituire = true;
                }
                reader.Close();
                conn.Close();
            }

            return userDaRestituire;
        }
    }
}
