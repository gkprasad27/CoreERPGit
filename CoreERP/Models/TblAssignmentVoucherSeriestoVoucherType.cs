﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignmentVoucherSeriestoVoucherType
    {
        public string? Code { get; set; }
        public string? VoucherType { get; set; }
        public string? VoucherSeries { get; set; }
        public int? LastNumber { get; set; }
        public string? Suffix { get; set; }
    }
}
