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

        public static User ReadUser(String nickname, String password)
        {
            return DAL.GestioneUsers.ReadUser(nickname, password);
        }

        public static User ReadFacebookUser(string facebookID)
        {
            return DAL.GestioneUsers.ReadUser(facebookID);
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

        public static void SigninUser(string nickname, string password) 
        {
            User userDaRegistrare = new User(nickname, password);
            User.CurrentUser = userDaRegistrare;
            CreateUser(userDaRegistrare);
        }

        public static User LoginUser(string nickname, string password)
        {
            return ReadUser(nickname, password);
        }

        public static void SigninFacebookUser(string nickname, string password, string facebookID)
        {
            User userDaRegistrare = new User(nickname, password, facebookID);
            User.CurrentUser = userDaRegistrare;
            CreateUser(userDaRegistrare);
        }

        public static User LoginFacebookUser(string facebookID)
        {
            return ReadFacebookUser(facebookID);
        }

        public static void LogoutUser(User userDaSloggare)
        {
            DAL.GestioneUsers.LogOutUser(userDaSloggare);
        }

        public static bool CheckNickname(string nickname)
        {
            return DAL.GestioneUsers.CheckNickname(nickname);
        }

    }
}
