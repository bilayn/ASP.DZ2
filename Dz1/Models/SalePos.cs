//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dz1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalePos
    {
        public int SalePosId { get; set; }
        public int SaleId { get; set; }
        public int GoodId { get; set; }
        public int CountGood { get; set; }
        public decimal Summa { get; set; }
    
        public virtual Good Good { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
