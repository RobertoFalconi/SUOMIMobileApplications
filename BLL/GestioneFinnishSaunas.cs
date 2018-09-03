using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestioneFinnishSaunas
    {
        public static List<String> ReadFinnishSauna()
        {
            return DAL.GestioneFinnishSaunas.ReadFinnishSauna();
        }

        public static void EnqueueInFinnishSauna(User userToEnqueue)
        {
            DAL.GestioneFinnishSaunas.EnqueueInFinnishSauna(userToEnqueue);
        }

        public static void DequeueFromFinnishSauna(User userToDequeue)
        {
            DAL.GestioneFinnishSaunas.DequeueFromFinnishSauna(userToDequeue);
        }

    }
}
