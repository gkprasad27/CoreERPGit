﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class States
    {
        //public States()
        //{
        //    ProfitCenters = new HashSet<ProfitCenters>();
        //    SalesDepartment = new HashSet<SalesDepartment>();
        //    TblBranch = new HashSet<TblBranch>();
        //    TblPlant = new HashSet<TblPlant>();
        //    TblSalesOffice = new HashSet<TblSalesOffice>();
        //}

        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CountryCode { get; set; }
        public string Language { get; set; }

        //public virtual Countries CountryCodeNavigation { get; set; }
        //public virtual TblLanguage LanguageNavigation { get; set; }
        //public virtual ICollection<ProfitCenters> ProfitCenters { get; set; }
        //public virtual ICollection<SalesDepartment> SalesDepartment { get; set; }
        //public virtual ICollection<TblBranch> TblBranch { get; set; }
        //public virtual ICollection<TblPlant> TblPlant { get; set; }
        //public virtual ICollection<TblSalesOffice> TblSalesOffice { get; set; }
    }
}
