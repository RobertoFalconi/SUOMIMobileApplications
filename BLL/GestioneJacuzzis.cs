using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class GestioneJacuzzis
    {
        public static List<String> ReadJacuzzi()
        {
            return DAL.GestioneJacuzzis.ReadJacuzzi();
        }

        public void UpdateJacuzzi(User userToEnqueue)
        {
            DAL.GestioneJacuzzis.UpdateJacuzzi(userToEnqueue);
        }
    }
}
