﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class CardType
    {
        public string Code { get; set; }
        public string CardName { get; set; }
        public string CardType1 { get; set; }
        public string Ext1 { get; set; }
        public string Ext2 { get; set; }
        public string Glaccount { get; set; }
        public string Type { get; set; }
        public string Active { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
