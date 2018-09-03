using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;

namespace ConsoleApplications
{
    class Program
    {
        static void Main(string[] args)
        {

            // SIGN IN (CREATE TEST)
            User nuovoUser = new User("Topolino", "123");
            GestioneUsers.CreateUser(nuovoUser);

            // LOGIN (READ TEST)
            User utenteCorrente = GestioneUsers.ReadUser(nuovoUser.Nickname);
            Console.WriteLine(utenteCorrente.Id + utenteCorrente.Nickname + utenteCorrente.Password);

            // PROFILE EDIT (UPDATE TEST)
            GestioneUsers.UpdateUser(utenteCorrente, "Paperino", "123");
            utenteCorrente = GestioneUsers.ReadUser(utenteCorrente.Id);
            Console.WriteLine(utenteCorrente.Id + utenteCorrente.Nickname + utenteCorrente.Password);

            // ACCOUNT DELETION (DELETE TEST)
            GestioneUsers.DeleteUser(utenteCorrente);

            // READ FINNISHSAUNA (READ TEST)
            List<String> utentiFS = GestioneFinnishSaunas.ReadFinnishSauna();
            Console.WriteLine("Utenti in sauna: " + utentiFS[1]);

            // READ JACUZZI (READ TEST)
            List<String> utentiJ = GestioneJacuzzis.ReadJacuzzi();
            Console.WriteLine("Utenti in jacuzzi: " + utentiJ[0]);

            // READ KNEIPP (READ TEST)
            List<String> utentiK = GestioneKneipps.ReadKneipp();
            Console.WriteLine("Utenti in kneipp: " + utentiK[0]);

            // READ TURKISH BATH (READ TEST)
            List<String> utentiTB = GestioneTurkishBaths.ReadTurkishBath();
            Console.WriteLine("Utenti in bagno turco: " + utentiTB[0]);

            //ENQUEUE IN FINNISH SAUNA (CREATE TEST)
            User supersaunista = new User("SuperSauna", "ilovesauna");
            GestioneUsers.CreateUser(supersaunista);
            GestioneFinnishSaunas.UpdateFinnishSauna(supersaunista);

        }
    }
}
