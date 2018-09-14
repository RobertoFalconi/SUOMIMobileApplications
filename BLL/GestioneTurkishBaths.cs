using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestioneTurkishBaths
    {
        public static List<String> ReadTurkishBath()
        {
            return DAL.GestioneTurkishBaths.ReadTurkishBath();
        }

        public static void EnqueueInTurkishBath(User userToEnqueue)
        {
            DAL.GestioneTurkishBaths.EnqueueInTurkishBath(userToEnqueue);
        }

        public static void DequeueFromTurkishBath(User userToDequeue)
        {
            DAL.GestioneTurkishBaths.DequeueFromTurkishBath(userToDequeue);
        }

        public static bool ControllaUtente(User utenteDaRestituire)
        {
            return DAL.GestioneTurkishBaths.ControllaUtente(utenteDaRestituire);
        }
    }
}
