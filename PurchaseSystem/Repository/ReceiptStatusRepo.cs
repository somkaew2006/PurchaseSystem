using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class ReceiptStatusRepo
    {

        Fairtech_DataEntities context = new Fairtech_DataEntities();

        public List<Tin> GetTins()
        {
            return context.Tins.ToList();
        }
    }
}
