//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockMarketManagement.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class EQUITY_L
    {
        public string SYMBOL { get; set; }
        public string NAME_OF_COMPANY { get; set; }
        public string C_SERIES { get; set; }
        public Nullable<int> C_PAID_UP_VALUE { get; set; }
        public Nullable<int> C_MARKET_LOT { get; set; }
        public string C_ISIN_NUMBER { get; set; }
        public Nullable<int> C_FACE_VALUE { get; set; }
    }
}