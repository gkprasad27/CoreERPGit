﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblTdsRates
    {
        public string Code { get; set; }
        public string Desctiption { get; set; }
        public string Tdstype { get; set; }
        public string IncomeType { get; set; }
        public string Status { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public int? BaseAmount { get; set; }
        public int? TdsRate { get; set; }
    }
}
