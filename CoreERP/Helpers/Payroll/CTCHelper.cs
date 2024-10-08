﻿using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class CTCHelper
    {
        public static List<Ctcbreakup> GetListOfCTCs()
        {
            try
            {
                //using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //return repo.Ctcbreakup.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();

                return null;
            }
            catch { throw; }
        }

        public static Ctcbreakup GetCTCs(string compCode)
        {
            try
            {
                //                using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //                return repo.Ctcbreakup.AsEnumerable()
                //.Where(x => x.CompanyCode.Equals(compCode))
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }

        public List<TblEmployee> GetEmployeesList(string empCode = null, string companyCode = null)
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();

                // Apply both empCode and companyCode filters
                return repo.TblEmployee
                    .Where(emp => (string.IsNullOrEmpty(empCode) || emp.EmployeeCode.Contains(empCode)) &&
                                  (string.IsNullOrEmpty(companyCode) || emp.CompanyCode == companyCode))
                    .OrderBy(x => x.EmployeeCode)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public List<TblEmployee> GetEmployeesList(string empCode = null)
        //{
        //    try
        //    {
        //        using Repository<TblEmployee> repo = new Repository<TblEmployee>();
        //        return repo.TblEmployee.Where(emp => emp.EmployeeCode.Contains(empCode ?? emp.EmployeeCode)).OrderBy(x => x.EmployeeCode).ToList();

        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public List<StructureComponents> GetStructures(string structure = null,int ctc=0)
        {
            try
            {
                double totalCtc = 0;
                using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                var structurepercentage = repo.StructureComponents.Where(s => s.StructureName.Equals(structure)).ToList();
                foreach (var structurecomponent in structurepercentage)
                {
                    if (structurecomponent.Percentage != null)
                    {
                        totalCtc += (structurecomponent.Percentage.Value / 100) * ctc;
                        structurecomponent.Amount= totalCtc;
                    }
                    else
                    {
                        structurecomponent.Amount = structurecomponent.Amount;
                    }
                }
               return repo.StructureComponents.Where(s => s.StructureName.Equals(structure)).ToList();

            }
            catch (Exception ex) { throw ex; }
        }

        public bool Register(Ctcbreakup structure, List<Ctcbreakup> components)
        {
            using var repo = new Repository<Ctcbreakup>();
            using var context = new ERPContext();

            try
            {
                components.ForEach(x =>
                {
                   x.EffectFrom = structure.EffectFrom;
                    x.EmpCode = structure.EmpCode;
                    x.Active = "Y";
                    x.Ctc = structure.Ctc;
                    x.StructureName = structure.StructureName;
                    x.CompanyCode = structure.CompanyCode;
                });
                
                context.Ctcbreakup.AddRange(components);
                context.SaveChanges();


                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Ctcbreakup structure, List<Ctcbreakup> components)
        {
            {
                using var repo = new Repository<Ctcbreakup>();
                using var context = new ERPContext();

                try
                {
                    if (structure.Id > 0)
                    {
                        components.ForEach(x =>
                        {
                            x.EffectFrom = structure.EffectFrom;
                            x.EmpCode = structure.EmpCode;
                            x.Active = "Y";
                            x.Ctc = structure.Ctc;
                            x.StructureName = structure.StructureName;
                        });
                        context.Ctcbreakup.UpdateRange(components);
                        context.SaveChanges();


                        
                    }
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
                //try
                //{
                //    //using Repository<Ctcbreakup> repo = new Repository<Ctcbreakup>();
                //    //repo.Ctcbreakup.Update(ctcBreakup);
                //    //if (repo.SaveChanges() > 0)
                //    //    return ctcBreakup;

                //    return null;
                //}
                //catch { throw; }
            }
        }


        public static List<ComponentMaster> GetComponentList()
        {
            try
            {
                //using Repository<ComponentMaster> repo = new Repository<ComponentMaster>();
                //return repo.ComponentMaster.AsEnumerable().Where(m => m.Active == "Y").ToList();
                return null;
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<StructureCreation> GetStructureList()
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //return repo.StructureCreation.AsEnumerable().Where(m => m.Active == "Y").ToList();

                return null;
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<PayrollCycle> GetPayrollCycleList()
        {
            try
            {
                //using Repository<PayrollCycle> repo = new Repository<PayrollCycle>();
                //return repo.PayrollCycle.AsEnumerable().Where(m => m.Active == "Y").ToList();

                return null;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
