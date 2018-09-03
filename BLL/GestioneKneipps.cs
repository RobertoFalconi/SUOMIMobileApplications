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

        public void UpdateKneipp(User userToEnqueue)
        {
            DAL.GestioneKneipps.UpdateKneipp(userToEnqueue);
        }
    }
}
