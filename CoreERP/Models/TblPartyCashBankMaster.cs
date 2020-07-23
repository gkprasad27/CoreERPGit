﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblPartyCashBankMaster
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Branch { get; set; }
        public string VoucherClass { get; set; }
        public string VoucherType { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? Period { get; set; }
        public string VoucherNumber { get; set; }
        public string TransactionType { get; set; }
        public string NatureofTransaction { get; set; }
        public string Account { get; set; }
        public string AccountingIndicator { get; set; }
        public decimal? Amount { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public string ProfitCenter { get; set; }
        public string Segment { get; set; }
        public string Bpcategory { get; set; }
        public string PartyAccount { get; set; }
        public string Narration { get; set; }
        public string Ext { get; set; }
        public string Ext1 { get; set; }
    }
}
