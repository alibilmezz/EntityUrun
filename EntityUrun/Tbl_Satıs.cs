//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityUrun
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Satıs
    {
        public int SatısID { get; set; }
        public Nullable<int> SatısUrun { get; set; }
        public Nullable<int> SatısMusteri { get; set; }
        public Nullable<decimal> SatısFiyat { get; set; }
        public Nullable<System.DateTime> SatısTarih { get; set; }
    
        public virtual Tbl_Musteri Tbl_Musteri { get; set; }
        public virtual Tbl_Urun Tbl_Urun { get; set; }
    }
}
