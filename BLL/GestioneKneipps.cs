using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestioneKneipps
    {
        public static List<String> ReadKneipp()
        {
            return DAL.GestioneKneipps.ReadKneipp();
        }

        public static void EnqueueInKneipp(User userToEnqueue)
        {
            DAL.GestioneKneipps.EnqueueInKneipp(userToEnqueue);
        }

        public static void DequeueFromKneipp(User userToDequeue)
        {
            DAL.GestioneKneipps.DequeueFromKneipp(userToDequeue);
        }

        public static bool ControllaUtente(User utenteDaRestituire)
        {
            return DAL.GestioneKneipps.ControllaUtente(utenteDaRestituire);
        }
    }
}
