﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblAssignmentVoucherSeriestoVoucherType
    {
        public int Code { get; set; }
        public string VoucherType { get; set; }
        public string VoucherSeries { get; set; }
        public string Ext { get; set; }
    }
}