﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTdsRates
    {
        public string? Code { get; set; }
        public string? Desctiption { get; set; }
        public string? Tdstype { get; set; }
        public string? IncomeType { get; set; }
        public string? Status { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public decimal? BaseAmount { get; set; }
        public decimal? TdsRate { get; set; }
    }
}
