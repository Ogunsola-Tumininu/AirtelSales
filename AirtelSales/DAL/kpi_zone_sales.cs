//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirtelSales.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class kpi_zone_sales
    {
        public int Id { get; set; }
        public string ref_period { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string RegionCode { get; set; }
        public long target_activation { get; set; }
        public long target_activebase { get; set; }
        public long target_recharge { get; set; }
        public decimal target_usage { get; set; }
        public Nullable<decimal> distribution_pct { get; set; }
        public Nullable<long> actual_activation { get; set; }
        public Nullable<long> actual_activebase { get; set; }
        public Nullable<long> actual_recharge { get; set; }
        public Nullable<decimal> actual_usage { get; set; }
        public Nullable<long> orsc_comm { get; set; }
        public Nullable<long> bts_comm { get; set; }
    }
}
