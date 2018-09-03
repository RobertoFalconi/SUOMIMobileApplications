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

        public void UpdateTurkishBath(User userToEnqueue)
        {
            DAL.GestioneTurkishBaths.UpdateTurkishBath(userToEnqueue);
        }
    }
}
