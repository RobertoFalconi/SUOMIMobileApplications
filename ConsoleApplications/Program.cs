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
            Console.WriteLine("Utenti in sauna: " + utentiFS[0]);

            // READ JACUZZI (READ TEST)
            List<String> utentiJ = GestioneJacuzzis.ReadJacuzzi();
            Console.WriteLine("Utenti in jacuzzi: " + utentiJ[0]);

            // READ KNEIPP (READ TEST)
            List<String> utentiK = GestioneKneipps.ReadKneipp();
            Console.WriteLine("Utenti in kneipp: " + utentiK[0]);

            // READ TURKISH BATH (READ TEST)
            List<String> utentiTB = GestioneTurkishBaths.ReadTurkishBath();
            Console.WriteLine("Utenti in bagno turco: " + utentiTB[0]);

            // SIGN IN AND ENQUEUE IN FINNISH SAUNA (CREATE TEST)
            User supersaunista = new User("SuperSauna", "ilovesauna");
            GestioneUsers.CreateUser(supersaunista);
            GestioneFinnishSaunas.UpdateFinnishSauna(supersaunista);

            // SIGN IN AND ENQUEUE IN TURKISH BATH (CREATE TEST)
            User utenteasciutto = new User("SonoAsciutto", "ilovetb");
            GestioneUsers.CreateUser(utenteasciutto);
            GestioneTurkishBaths.UpdateTurkishBath(utenteasciutto);

            // SIGN IN AND ENQUEUE IN JACUZZI (CREATE TEST)
            User utentepigro = new User("SonoPigro", "ilovehydro");
            GestioneUsers.CreateUser(utentepigro);
            GestioneJacuzzis.UpdateJacuzzi(utentepigro);

            // SIGN IN AND ENQUEUE IN KNEIPP (CREATE TEST)
            User utenteconcattivacircolazione = new User("HoUnaCattivaCircolazione", "ilovekneipp");
            GestioneUsers.CreateUser(utenteconcattivacircolazione);
            GestioneKneipps.UpdateKneipp(utenteconcattivacircolazione);

            // LOGIN AND ENQUEUE IN FINNISH SAUNA (CREATE TEST)
            User supersaunista2 = GestioneUsers.ReadUser("SuperSauna");
            GestioneFinnishSaunas.UpdateFinnishSauna(supersaunista2);

            // LOGIN AND ENQUEUE IN TURKISH BATH (CREATE TEST)
            User utenteasciutto2 = GestioneUsers.ReadUser("SonoAsciutto");
            GestioneTurkishBaths.UpdateTurkishBath(utenteasciutto2);

            // LOGIN AND ENQUEUE IN JACUZZI (CREATE TEST)
            User utentepigro2 = GestioneUsers.ReadUser("SonoPigro");
            GestioneJacuzzis.UpdateJacuzzi(utentepigro2);

            // LOGIN AND ENQUEUE IN KNEIPP (CREATE TEST)
            User utenteconcattivacircolazione2 = GestioneUsers.ReadUser("HoUnaCattivaCircolazione");
            GestioneKneipps.UpdateKneipp(utenteconcattivacircolazione2);

        }
    }
}
