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
        public Kneipp ReadKneipp(int id)
        {
            return DAL.GestioneKneipps.ReadKneipp(id);
        }

        public void UpdateKneipp(Kneipp kneippToUpdate)
        {
            DAL.GestioneKneipps.UpdateKneipp(kneippToUpdate);
        }
    }
}
