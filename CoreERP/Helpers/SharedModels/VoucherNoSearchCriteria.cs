﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Helpers.SharedModels
{
    public class VoucherNoSearchCriteria
    {
        private DateTime? _fromDate;
        private DateTime? _toDate;
        public DateTime? FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                if (value == null)
                    _fromDate = DateTime.Now;

                _fromDate = value;
            }
        }
        public DateTime? ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                if (value == null)
                    _toDate = DateTime.Now;

                _toDate = value;
            }
        }
        public string VoucherNo { get; set; }
        public string StockExcessNo { get; set; }
        public string OilConversionVchNo { get; set; }
        public string issueNo { get; set; }
        public string StockshortNo { get; set; }
        public string receiptNo { get; set; }
        public int Role { get; set; }
    }
}
