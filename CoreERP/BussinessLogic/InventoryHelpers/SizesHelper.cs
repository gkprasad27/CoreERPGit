﻿using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class SizesHelper
    {
        public static Sizes RegisterSizes(Sizes sizes)
        {
            try
            {
                using (Repository<Sizes> repo = new Repository<Sizes>())
                {
                    var record = ((from acc in repo.Sizes select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                    if (record != 0)
                    {
                        sizes.Code = (record + 1).ToString();
                    }
                    else
                        sizes.Code = "1";

                    sizes.Active = "Y";
                    repo.Sizes.Add(sizes);
                    if (repo.SaveChanges() > 0)
                        return sizes;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Sizes> GetSizesList()
        {
            try
            {
                using (Repository<Sizes> repo = new Repository<Sizes>())
                {
                    return repo.Sizes.Select(x => x).ToList();
                }
            }
            catch { throw; }
        }
        public static Sizes UpdateSizes(Sizes sizes)
        {
            try
            {
                using (Repository<Sizes> repo = new Repository<Sizes>())
                {
                    repo.Sizes.Update(sizes);
                    if (repo.SaveChanges() > 0)
                        return sizes;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Sizes DeleteSizes(string code)
        {
            try
            {
                using (Repository<Sizes> repo = new Repository<Sizes>())
                {
                    var accountClass = repo.Sizes.Where(x => x.Code == code).FirstOrDefault();
                    accountClass.Active = "N";
                    repo.Sizes.Update(accountClass);
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