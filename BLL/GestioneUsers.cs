using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestioneUsers
    {
        public static void InsertUser(User userDaInserire)
        {
            DAL.GestioneUsers.InsertUser(userDaInserire);
        }
        public static User GetUser(String nickname)
        {
            return DAL.GestioneUsers.GetUser(nickname);
        }
        public static User GetUser(int id)
        {
            return DAL.GestioneUsers.GetUser(id);
        }
    }
}
