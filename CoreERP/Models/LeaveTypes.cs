﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class LeaveTypes
    {
        public string? LeaveCode { get; set; }
        public string? LeaveName { get; set; }
        public string? CompanyCode { get; set; }
        public string? LeaveMinLimit { get; set; }
        public string? LeaveMaxLimit { get; set; }
        
    }
}
