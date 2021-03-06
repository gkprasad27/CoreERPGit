﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblGoodsReceiptDetails
    {
        public int Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public int? Poqty { get; set; }
        public int? ReceivedQty { get; set; }
        public string Plant { get; set; }
        public string StorageLocation { get; set; }
        public string ProfitCenter { get; set; }
        public string Project { get; set; }
        public string Branch { get; set; }
        public string MovementType { get; set; }
        public string LotNo { get; set; }
        public DateTime? LotDate { get; set; }
    }
}
