using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class ShipStatusRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();

       public List<Ttout> GetTtouts()
        {
            return context.Ttouts.ToList();
        }
    }
}
