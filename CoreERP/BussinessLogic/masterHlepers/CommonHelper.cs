﻿using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP
{
    public class CommonHelper
    {
        public static List<Countries> GetCountries()
        {
            using var repo = new Repository<Countries>();
            var languages = repo.TblLanguage.ToList();
            var currencies = repo.TblCurrency.ToList();
            repo.Countries.ToList()
                .ForEach(c =>
                {
                    c.LangName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                    c.CurrName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                });
            return repo.Countries.ToList();
        }

        public static IEnumerable<TblRegion> GetRegions()
        {
            using var repo = new Repository<TblRegion>();
            var countries = repo.Countries.ToList();
            var resul = repo.TblRegion.ToList();

            resul.ForEach(c =>
            {
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
            });
            return resul;
        }

        public static IEnumerable<States> GetStates()
        {
            using var repo = new Repository<States>();
            var languages = repo.TblLanguage.ToList();
            var countries = repo.Countries.ToList();
            var result = repo.States.ToList();

            result.ForEach(c =>
            {
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.CountryCode)?.CountryName;
                c.LangName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
            });
            return result;
        }

        public static IEnumerable<TblCompany> GetCompanies()
        {
            using var repo = new Repository<TblCompany>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var result = repo.TblCompany.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
            });
            return result;
        }

        public static IEnumerable<ProfitCenters> GetProfitcenters()
        {
            using var repo = new Repository<ProfitCenters>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var result = repo.ProfitCenters.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblBranch> GetBranches()
        {
            using var repo = new Repository<TblBranch>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.TblBranch.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<CostCenters> GetCostcenters()
        {
            using var repo = new Repository<CostCenters>();
            var states = repo.States.ToList();
            var employees = repo.TblEmployee.ToList();
            var companies = repo.TblCompany.ToList();
            var result = repo.CostCenters.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompCode)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<TblFunctionalDepartment> GetFunctionalDepts()
        {
            using var repo = new Repository<TblFunctionalDepartment>();
            var employees = repo.TblEmployee.ToList();

            var result = repo.TblFunctionalDepartment.ToList();

            result.ForEach(c =>
            {
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<Divisions> GetDivisions()
        {
            using var repo = new Repository<Divisions>();
            var employees = repo.TblEmployee.ToList();

            var result = repo.Divisions.ToList();

            result.ForEach(c =>
            {
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblPlant> GetPlants()
        {
            using var repo = new Repository<TblPlant>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();
            var locations = repo.TblLocation.ToList();

            var result = repo.TblPlant.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
                c.LocationName = locations.FirstOrDefault(l => l.LocationId == c.Location)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblLocation> Getlocations()
        {
            using var repo = new Repository<TblLocation>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblLocation.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<SalesDepartment> GetSalesDepartments()
        {
            using var repo = new Repository<SalesDepartment>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();

            var result = repo.SalesDepartment.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblSalesOffice> GetSalesOffice()
        {
            using var repo = new Repository<TblSalesOffice>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();
            var languages = repo.TblLanguage.ToList();
            var employees = repo.TblEmployee.ToList();

            var result = repo.TblSalesOffice.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.LanguageName = languages.FirstOrDefault(l => l.LanguageCode == c.Language)?.LanguageName;
                c.ResponsibleName = employees.FirstOrDefault(l => l.EmployeeCode == c.ResponsiblePerson)?.EmployeeName;
            });
            return result;
        }

        public static IEnumerable<TblMaintenancearea> GetMaintenance()
        {
            using var repo = new Repository<TblMaintenancearea>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblMaintenancearea.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<TblStorageLocation> GetStorageLocation()
        {
            using Repository<TblStorageLocation> repo = new Repository<TblStorageLocation>();
            var plants = repo.TblPlant.ToList();

            var result = repo.TblStorageLocation.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(l => l.PlantCode == c.Plant)?.Plantname;
            });
            return result;
        }

        public static IEnumerable<TblOpenLedger> GetOpenLedger()
        {
            using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
            var ledgers = repo.Ledger.ToList();

            var result = repo.TblOpenLedger.ToList();

            result.ForEach(c =>
            {
                c.LedgerName = ledgers.FirstOrDefault(l => l.Code == c.LedgerKey)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblVoucherType> GetVoucherType()
        {
            using var repo = new Repository<TblVoucherType>();
            var voucherclasses = repo.TblVoucherclass.ToList();

            var result = repo.TblVoucherType.ToList();

            result.ForEach(c =>
            {
                c.VoucherClassName = voucherclasses.FirstOrDefault(l => l.VoucherKey == c.VoucherClass)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblVoucherSeries> GetVoucherseries()
        {
            using var repo = new Repository<TblVoucherSeries>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();

            var result = repo.TblVoucherSeries.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
            });
            return result;
        }

        public static IEnumerable<TblAssignmentVoucherSeriestoVoucherType> GetAssignVoucherseriesVoucherType()
        {
            using var repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
            var tblVoucherTypes = repo.TblVoucherType.ToList();

            var result = repo.TblAssignmentVoucherSeriestoVoucherType.ToList();

            result.ForEach(c =>
            {
                c.VoucherTypeName = tblVoucherTypes.FirstOrDefault(l => l.VoucherTypeId == c.VoucherType)?.VoucherTypeName;
            });
            return result;
        }

        public static IEnumerable<TblTaxtransactions> GetTaxTransactions()
        {
            using Repository<TblTaxtransactions> repo = new Repository<TblTaxtransactions>();
            var tblTaxtypes = repo.TblTaxtypes.ToList();

            var result = repo.TblTaxtransactions.ToList();

            result.ForEach(c =>
            {
                c.TaxTypeName = tblTaxtypes.FirstOrDefault(l => l.TaxKey == c.TaxType)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblTaxRates> GetTaxRates()
        {
            using Repository<TblTaxRates> repo = new Repository<TblTaxRates>();
            var tblTaxtransactions = repo.TblTaxtransactions.ToList();

            var result = repo.TblTaxRates.ToList();

            result.ForEach(c =>
            {
                c.TaxTransactionName = tblTaxtransactions.FirstOrDefault(l => l.Code == c.TaxTransaction)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignTaxacctoTaxcode> GetTaxaccountsTaxcodes()
        {
            using var repo = new Repository<TblAssignTaxacctoTaxcode>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAssignTaxacctoTaxcode.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.CGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Cgstgl)?.GlaccountName;
                c.SGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Sgstgl)?.GlaccountName;
                c.IGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Igstgl)?.GlaccountName;
                c.UGSTName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Ugstgl)?.GlaccountName;
                c.CompositeAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.CompositeAccount)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblTdsRates> GetTdsRates()
        {
            using var repo = new Repository<TblTdsRates>();
            var tdstypes = repo.TblTdstypes.ToList();
            var incomeTypes = repo.TblIncomeTypes.ToList();

            var result = repo.TblTdsRates.ToList();

            result.ForEach(c =>
            {
                c.TdsTypeName = tdstypes.FirstOrDefault(l => l.TdsCode == c.Tdstype)?.Desctiption;
                c.IncomeTypeName = incomeTypes.FirstOrDefault(l => l.Code == c.IncomeType)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblPosting> GetPosting()
        {
            using var repo = new Repository<TblPosting>();
            var plants = repo.TblPlant.ToList();
            var branches = repo.TblBranch.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();
            var tdsRates = repo.TblTdsRates.ToList();

            var result = repo.TblPosting.ToList();

            result.ForEach(c =>
            {
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.BranchName = branches.FirstOrDefault(l => l.BranchCode == c.Branch)?.BranchName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.GLAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Glaccount)?.GlaccountName;
                c.TdsRatetName = tdsRates.FirstOrDefault(l => l.Code == c.Tdsrate)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAssignchartaccttoCompanycode> GetChartofAccounttoCompany()
        {
            using var repo = new Repository<TblAssignchartaccttoCompanycode>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();

            var result = repo.TblAssignchartaccttoCompanycode.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.OchartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.OperationCoa)?.Desctiption;
                c.GchartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.GroupCoa)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAccountGroup> GetAccountGroups()
        {
            using var repo = new Repository<TblAccountGroup>();
            var result = repo.TblAccountGroup.ToList();

            result.ForEach(c =>
            {
                c.UnderAccountName = result.FirstOrDefault(l => l.AccountGroupId == c.GroupUnder)?.AccountGroupName;

            });
            return result.OrderBy(x => x.Sequence);
        }

        public static IEnumerable<AssignmentSubaccounttoGl> GetAssignmentsubaccounttoGl()
        {
            using var repo = new Repository<AssignmentSubaccounttoGl>();
            var tblAccountGroups = repo.TblAccountGroup.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.AssignmentSubaccounttoGl.ToList();

            result.ForEach(c =>
            {
                c.UnderAccountName = tblAccountGroups.FirstOrDefault(l => l.AccountGroupId == c.SubAccount)?.AccountGroupName;
                c.GlAccountName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.FromGl)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBpgroup> GetBpGroups()
        {
            using Repository<TblBpgroup> repo = new Repository<TblBpgroup>();
            var partnertypes = repo.PartnerType.ToList();

            var result = repo.TblBpgroup.ToList();

            result.ForEach(c =>
            {
                c.PartnerTypeName = partnertypes.FirstOrDefault(l => l.Code == c.Bptype)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignment> GetAssignments()
        {
            using var repo = new Repository<TblAssignment>();
            var tblBpgroups = repo.TblBpgroup.ToList();

            var result = repo.TblAssignment.ToList();

            result.ForEach(c =>
            {
                c.BpGroupName = tblBpgroups.FirstOrDefault(l => l.Bpgroup == c.Bpgroup)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAlternateControlAccTrans> GetAlternateControlAccounts()
        {
            using var repo = new Repository<TblAlternateControlAccTrans>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAlternateControlAccTrans.ToList();

            result.ForEach(c =>
            {
                c.NcName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.NormalControlAccount)?.GlaccountName;
                c.AcName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AlternativeControlAccount)?.GlaccountName;
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblAssetBlock> GetAssetBlock()
        {
            using var repo = new Repository<TblAssetBlock>();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblAssetBlock.ToList();

            result.ForEach(c =>
            {
                c.DepreciationName = tblDepreciationAreas.FirstOrDefault(l => l.Code == c.DepreciationKey)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignAssetClasstoBlockAsset> GetAssetClassBlock()
        {
            using Repository<TblAssignAssetClasstoBlockAsset> repo = new Repository<TblAssignAssetClasstoBlockAsset>();
            var tblAssetBlocks = repo.TblAssetBlock.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();

            var result = repo.TblAssignAssetClasstoBlockAsset.ToList();

            result.ForEach(c =>
            {
                c.AssetBlockName = tblAssetBlocks.FirstOrDefault(l => l.Code == c.AssetBlock)?.Description;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.AssetClass)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssignAccountkeytoAsset> GetAssetAccountkeytoasset()
        {
            using Repository<TblAssignAccountkeytoAsset> repo = new Repository<TblAssignAccountkeytoAsset>();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();

            var result = repo.TblAssignAccountkeytoAsset.ToList();

            result.ForEach(c =>
            {
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(l => l.Code == c.AccountKey)?.Description;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.AssetClass)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblAssetAccountkey> GetAssetAccountKey()
        {
            using Repository<TblAssetAccountkey> repo = new Repository<TblAssetAccountkey>();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var glaccounts = repo.Glaccounts.ToList();

            var result = repo.TblAssetAccountkey.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.CompanyCode)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartofAccount)?.Desctiption;
                c.AcquisationName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AcquisitionsGl)?.GlaccountName;
                c.AccumulatedName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.AccumulatedGl)?.GlaccountName;
                c.AucName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.Auggl)?.GlaccountName;
                c.SalesRevenueName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.SalesRevenueGl)?.GlaccountName;
                c.LossonSalesName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.LossOnSaleGl)?.GlaccountName;
                c.GainonSalesName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.GainOnSaleGl)?.GlaccountName;
                c.ScrapGLName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.ScrappingGl)?.GlaccountName;
                c.DepreciationGLName = glaccounts.FirstOrDefault(l => l.AccountNumber == c.DepreciationGl)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBankMaster> GetBankMaster()
        {
            using Repository<TblBankMaster> repo = new Repository<TblBankMaster>();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var currencies = repo.TblCurrency.ToList();

            var result = repo.TblBankMaster.ToList();

            result.ForEach(c =>
            {
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
            });
            return result;
        }

        public static IEnumerable<Glaccounts> GetGlAccounts()
        {
            using var repo = new Repository<Glaccounts>();
            var currencies = repo.TblCurrency.ToList();
            var companies = repo.TblCompany.ToList();
            var chartAccounts = repo.TblChartAccount.ToList();
            var gLAccGroups = repo.GlaccGroup.ToList();
            var tblBankMasters = repo.TblBankMaster.ToList();

            var result = repo.Glaccounts.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.ChartAccountName = chartAccounts.FirstOrDefault(l => l.Code == c.ChartAccount)?.Desctiption;
                c.CurrencyName = currencies.FirstOrDefault(cur => cur.CurrencySymbol == c.Currency)?.CurrencyName;
                c.AccGroupName = gLAccGroups.FirstOrDefault(cur => cur.GroupCode == c.AccGroup)?.GroupName;
                c.BankName = tblBankMasters.FirstOrDefault(cur => cur.BankCode == c.BankKey)?.BankName;
            });
            return result;
        }

        public static IEnumerable<TblGlsubAccount> GetGlSubAccounts()
        {
            using var repo = new Repository<TblGlsubAccount>();
            var gLAccGroups = repo.Glaccounts.ToList();

            var result = repo.TblGlsubAccount.ToList();

            result.ForEach(c =>
            {

                c.AccGroupName = gLAccGroups.FirstOrDefault(cur => cur.AccountNumber == c.Glaccount)?.GlaccountName;
            });
            return result;
        }

        public static IEnumerable<TblBusinessPartnerAccount> GetBusinessPartner()
        {
            using var repo = new Repository<TblBusinessPartnerAccount>();
            var companies = repo.TblCompany.ToList();
            var partnerTypes = repo.PartnerType.ToList();
            var tblBpgroups = repo.TblBpgroup.ToList();
            var states = repo.States.ToList();
            var regions = repo.TblRegion.ToList();
            var countries = repo.Countries.ToList();
            var gLAccGroups = repo.Glaccounts.ToList();
            var tblPaymentTerms = repo.TblPaymentTerms.ToList();
            var tblTdstypes = repo.TblTdstypes.ToList();
            var tblTdsRates = repo.TblTdsRates.ToList();

            var result = repo.TblBusinessPartnerAccount.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.BpTypeName = partnerTypes.FirstOrDefault(l => l.Code == c.Bptype)?.Description;
                c.BpGroupName = tblBpgroups.FirstOrDefault(cur => cur.Bpgroup == c.Bpgroup)?.Description;
                c.StateName = states.FirstOrDefault(cur => cur.StateCode == c.State)?.StateName;
                c.RegionName = regions.FirstOrDefault(cur => cur.RegionCode == c.Region)?.RegionName;
                c.CountryName = countries.FirstOrDefault(cur => cur.CountryCode == c.Country)?.CountryName;
                c.ControlAccountName = gLAccGroups.FirstOrDefault(cur => cur.AccountNumber == c.ControlAccount)?.GlaccountName;
                c.PaymentTermsName = tblPaymentTerms.FirstOrDefault(cur => cur.Code == c.PaymentTerms)?.Description;
                c.TdsTypeName = tblTdstypes.FirstOrDefault(cur => cur.TdsCode == c.Tdstype)?.Desctiption;
                c.TdsStateName = tblTdsRates.FirstOrDefault(cur => cur.Code == c.Tdsrate)?.Desctiption;
            });
            return result;
        }

        public static IEnumerable<TblMainAssetMaster> GetMainAssetMaster()
        {
            using var repo = new Repository<TblMainAssetMaster>();
            var companies = repo.TblCompany.ToList();
            var tblAssetClasses = repo.TblAssetClass.ToList();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var branches = repo.TblBranch.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var segments = repo.Segment.ToList();
            var divisions = repo.Divisions.ToList();
            var plants = repo.TblPlant.ToList();
            var tblLocations = repo.TblLocation.ToList();
            var tblDepreciations = repo.TblDepreciation.ToList();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblMainAssetMaster.ToList();

            result.ForEach(c =>
            {
                c.CompanyName = companies.FirstOrDefault(l => l.CompanyCode == c.Company)?.CompanyName;
                c.AssetClassName = tblAssetClasses.FirstOrDefault(l => l.Code == c.Assetclass)?.Description;
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(cur => cur.Code == c.AccountKey)?.Description;
                c.BranchName = branches.FirstOrDefault(cur => cur.BranchCode == c.Branch)?.BranchName;
                c.ProfitCenterName = profitCenters.FirstOrDefault(cur => cur.Code == c.ProfitCenter)?.Description;
                c.SegmentName = segments.FirstOrDefault(cur => cur.Id == c.Segment)?.Name;
                c.DivisionName = divisions.FirstOrDefault(cur => cur.Code == c.Division)?.Description;
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.LocationName = tblLocations.FirstOrDefault(cur => cur.LocationId == c.Location)?.Description;
                c.DepreciationDataName = tblDepreciations.FirstOrDefault(cur => cur.Code == c.DepreciationData)?.Description;
                c.DepreciationAreaName = tblDepreciationAreas.FirstOrDefault(cur => cur.Code == c.DepreciationArea)?.Description;
            });
            return result;
        }

        public static IEnumerable<TblSubAssetMaster> GetSubAssetMaster()
        {
            using var repo = new Repository<TblSubAssetMaster>();
            var tblMainAssetMasters = repo.TblMainAssetMaster.ToList();
            var tblAssetAccountkeys = repo.TblAssetAccountkey.ToList();
            var branches = repo.TblBranch.ToList();
            var profitCenters = repo.ProfitCenters.ToList();
            var segments = repo.Segment.ToList();
            var divisions = repo.Divisions.ToList();
            var plants = repo.TblPlant.ToList();
            var tblLocations = repo.TblLocation.ToList();
            var tblDepreciations = repo.TblDepreciation.ToList();
            var tblDepreciationAreas = repo.TblDepreciationAreas.ToList();

            var result = repo.TblSubAssetMaster.ToList();

            result.ForEach(c =>
            {
                c.MainAssetName = tblMainAssetMasters.FirstOrDefault(l => l.AssetNumber == c.MainAssetNo)?.Name;
                c.AccountKeyName = tblAssetAccountkeys.FirstOrDefault(cur => cur.Code == c.AccountKey)?.Description;
                c.BranchName = branches.FirstOrDefault(cur => cur.BranchCode == c.Branch)?.BranchName;
                c.ProfitCenterName = profitCenters.FirstOrDefault(cur => cur.Code == c.ProfitCenter)?.Description;
                c.SegmentName = segments.FirstOrDefault(cur => cur.Id == c.Segment)?.Name;
                c.DivisionName = divisions.FirstOrDefault(cur => cur.Code == c.Division)?.Description;
                c.PlantName = plants.FirstOrDefault(cur => cur.PlantCode == c.Plant)?.Plantname;
                c.LocationName = tblLocations.FirstOrDefault(cur => cur.LocationId == c.Location)?.Description;
                c.DepreciationDataName = tblDepreciations.FirstOrDefault(cur => cur.Code == c.DepreciationData)?.Description;
                c.DepreciationAreaName = tblDepreciationAreas.FirstOrDefault(cur => cur.Code == c.DepreciationArea)?.Description;
            });
            return result;
        }

        public static TblAssignmentVoucherSeriestoVoucherType GetVoucherNo(string voucherTypeId, out int startNumber, out int endNumber)
        {
            startNumber = 0;
            endNumber = 0;
            using var repo = new ERPContext();
            var voucherSeries = (from avsvt in repo.TblAssignmentVoucherSeriestoVoucherType
                                 join vs in repo.TblVoucherSeries on avsvt.VoucherSeries equals vs.VoucherSeriesKey
                                 where avsvt.VoucherType == voucherTypeId
                                 select vs).FirstOrDefault();

            startNumber = Convert.ToInt32(voucherSeries?.FromInterval ?? "0");
            endNumber = Convert.ToInt32(voucherSeries?.ToInterval ?? "0");

            return repo.TblAssignmentVoucherSeriestoVoucherType.FirstOrDefault(t => t.VoucherType == voucherTypeId);
        }
    }
}
