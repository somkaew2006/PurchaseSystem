using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Repository
{
    class PaymentRepo
    {
        Fairtech_DataEntities context = new Fairtech_DataEntities();

        public List<Tbank> GetTbanks()
        {
            return context.Tbanks.ToList();
        }
    }
}
