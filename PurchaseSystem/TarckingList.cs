//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PurchaseSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class TarckingList
    {
        public int KeyGen { get; set; }
        public string ID { get; set; }
        public string Ta { get; set; }
        public string Tb { get; set; }
        public string Tc { get; set; }
        public string Td { get; set; }
        public string Te { get; set; }
        public string Tf { get; set; }
    
        public virtual Tracking Tracking { get; set; }
    }
}
