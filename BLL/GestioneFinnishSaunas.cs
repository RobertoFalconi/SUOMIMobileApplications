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

        public static void UpdateFinnishSauna(User userToEnqueue)
        {
            DAL.GestioneFinnishSaunas.UpdateFinnishSauna(userToEnqueue);
        }
    }
}
