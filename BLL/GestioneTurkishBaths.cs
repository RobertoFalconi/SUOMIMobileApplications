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
        public TurkishBath ReadTurkishBath(int id)
        {
            return DAL.GestioneTurkishBaths.ReadTurkishBath(id);
        }

        public void UpdateTurkishBath(TurkishBath turkishBathToUpdate)
        {
            DAL.GestioneTurkishBaths.UpdateTurkishBath(turkishBathToUpdate);
        }
    }
}
