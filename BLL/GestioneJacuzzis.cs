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
        public Jacuzzi ReadJacuzzi(int id)
        {
            return DAL.GestioneJacuzzis.ReadJacuzzi(id);
        }

        public void UpdateJacuzzi(Jacuzzi jacuzziToUpdate)
        {
            DAL.GestioneJacuzzis.UpdateJacuzzi(jacuzziToUpdate);
        }
    }
}
