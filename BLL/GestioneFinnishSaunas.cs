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
        public FinnishSauna ReadFinnishSauna(int id)
        {
            return DAL.GestioneFinnishSaunas.ReadFinnishSauna(id);
        }

        public void UpdateFinnishSauna(FinnishSauna finnishSaunaToUpdate)
        {
            DAL.GestioneFinnishSaunas.UpdateFinnishSauna(finnishSaunaToUpdate);
        }
    }
}
