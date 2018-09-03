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
        public static void CreateUser(User userDaInserire)
        {
            DAL.GestioneUsers.CreateUser(userDaInserire);
        }

        public static User ReadUser(String nickname)
        {
            return DAL.GestioneUsers.ReadUser(nickname);
        }

        public static User ReadUser(int id)
        {
            return DAL.GestioneUsers.ReadUser(id);
        }

        public static void UpdateUser(User userDaAggiornare, String nuovoNickname, String nuovaPassword)
        {
            DAL.GestioneUsers.UpdateUser(userDaAggiornare, nuovoNickname, nuovaPassword);
        }

        public static void DeleteUser(User userDaRimuovere)
        {
            DAL.GestioneUsers.DeleteUser(userDaRimuovere);
        }

    }
}
