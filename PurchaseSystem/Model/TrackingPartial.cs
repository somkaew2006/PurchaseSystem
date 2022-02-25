using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseSystem.Model
{
    class TrackingPartial :Tracking
    {
        public string FirstProduct { get; set; }
        public string FirstBrand { get; set; }
    }
}
