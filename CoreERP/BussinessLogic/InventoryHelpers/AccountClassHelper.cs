﻿using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class AccountClassHelper
    {

        public static AccountingClass RegisterAccountingClass(AccountingClass accountingClass)
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    var record = ((from acc in repo.AccountingClass select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                    if (record != 0)
                    {
                        accountingClass.Code = (record + 1).ToString();
                    }
                    else
                        accountingClass.Code = "1";

                    accountingClass.Active = "Y";
                    repo.AccountingClass.Add(accountingClass);
                    if (repo.SaveChanges() > 0)
                        return accountingClass;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AccountingClass> GetAccountingClassList()
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    return repo.AccountingClass.Select(x => x).ToList();
                }
            }
            catch { throw; }
        }
        public static AccountingClass UpdateAccountingClass(AccountingClass accountingClass)
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    repo.AccountingClass.Update(accountingClass);
                    if (repo.SaveChanges() > 0)
                        return accountingClass;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AccountingClass DeleteAccountingClass(string code)
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    var accountClass = repo.AccountingClass.Where(x => x.Code == code).FirstOrDefault();
                    accountClass.Active = "N";
                    repo.AccountingClass.Update(accountClass);
                    if (repo.SaveChanges() > 0)
                        return accountClass;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}