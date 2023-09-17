﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblSaleOrderMaster
    {
        public int SaleOrderNo { get; set; }
        public string? CustomerCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? PONumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? DateofSupply { get; set; }
        public string? PlaceofSupply { get; set; }
        public string? DocumentURL { get; set; }
        public string? Status { get; set; }
        public string? TaxCode { get; set; }
        public decimal? ICST { get; set; }
        public decimal? UGST { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
