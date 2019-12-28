﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase")]
    public class PurchaseController : ControllerBase
    {
        #region Purchase 

        [HttpGet("mpurchase")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(
                new {
                //companys = _unitOfWork.Companys.GetAll(),
                //branches = _unitOfWork.Branches.GetAll(),
                purchase = PurchasesHelper.GetPurchaseList(),
               // accounts = _unitOfWork.GLAccounts.GetAll() ,  
               // materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
               //                    where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASE.ToString()
               //                    select mattran),
               //materialGroup = (from mattran in _unitOfWork.MaterialGroup.GetAll()
               //                 select mattran),
               // accToAccClass =(from acctoacc in _unitOfWork.AsignmentAcctoAccClass.GetAll()
               //                 select acctoacc),
               // taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
               //                  //join taxi in _unitOfWork.TaxIntegration.GetAll()
               //                  //on taxm.Code equals taxi.TaxCode
               //                  where taxm.TaxType == "INPUT"
               //                  select taxm),
               // taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
               // models = (from md in _unitOfWork.BrandModel.GetAll()
               //          // join itmmst in _unitOfWork.ItemMaster.GetAll()
               //         //  on md.Code equals itmmst.Model
               //           select md),
               // itemmaster = _unitOfWork.ItemMaster.GetAll(),
               // partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
               //                    join partcr in _unitOfWork.PartnerCreation.GetAll()
               //                    on parttyp.Code equals partcr.Partnertype
               //                    where parttyp.AccountType == NatureOfAccounts.TRADEVENDORS.ToString()
               //                    select partcr),
               // brandList = (from br in _unitOfWork.Brand.GetAll()
               //              select br),
               // purchaseReturnsList = _unitOfWork.PurchaseReturns.GetAll().Where(x=>x.GoodsReceiptDate != null),
               // accIntegrationList =_unitOfWork.Interpretation.GetAll(),
               // materialGroupList =_unitOfWork.MaterialGroup.GetAll()
            });

        }

        [HttpPost("mpurchase/register")]
        public async Task<IActionResult> RegisterPurchase([FromBody]Purchase[] purchase)
        {
            if (purchase == null)
                return BadRequest($"{nameof(purchase)} cannot be null");
            try
            {
                int result = PurchasesHelper.RegisterPurchase(purchase);
                if(result > 0)
                return Ok(purchase);

            }
            catch{}

            return BadRequest("Registration Failed");
        }


        [HttpPut("mpurchase/updatePurchase")]
        public async Task<IActionResult> UpdatePurchase(string code, [FromBody] Purchase purchase)
        {
            if (purchase == null)
                return BadRequest($"{nameof(purchase)} cannot be null");

            try
            {
                int result = PurchasesHelper.UpdatePurchase(purchase);
                if (result > 0)
                    return Ok(purchase);
            }
            catch{}

            return BadRequest("Updation Failed");
        }


        [HttpDelete("mpurchase/deletePurchase/{code}")]
        public async Task<IActionResult> DeletePurchase(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                int result = PurchasesHelper.DeletePurchase(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");
        }


        [HttpGet("mpurchase/getPurchaseMaterialGrp")]
        public async Task<IActionResult> GetPurchaseMaterialGrp()
        {

            return Ok(
                new
                {
                    // accounts = _unitOfWork.GLAccounts.GetAll() ,  
                    // materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                    //                    where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASE.ToString()
                    //                    select mattran),
                    //materialGroup = (from mattran in _unitOfWork.MaterialGroup.GetAll()
                    //                 select mattran),
                    // accToAccClass =(from acctoacc in _unitOfWork.AsignmentAcctoAccClass.GetAll()
                    //                 select acctoacc),
                    // taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
                    //                  //join taxi in _unitOfWork.TaxIntegration.GetAll()
                    //                  //on taxm.Code equals taxi.TaxCode
                    //                  where taxm.TaxType == "INPUT"
                    //                  select taxm),
                    // taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
                    // models = (from md in _unitOfWork.BrandModel.GetAll()
                    //          // join itmmst in _unitOfWork.ItemMaster.GetAll()
                    //         //  on md.Code equals itmmst.Model
                    //           select md),
                    // itemmaster = _unitOfWork.ItemMaster.GetAll(),
                    // partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
                    //                    join partcr in _unitOfWork.PartnerCreation.GetAll()
                    //                    on parttyp.Code equals partcr.Partnertype
                    //                    where parttyp.AccountType == NatureOfAccounts.TRADEVENDORS.ToString()
                    //                    select partcr),
                    // brandList = (from br in _unitOfWork.Brand.GetAll()
                    //              select br),
                    // purchaseReturnsList = _unitOfWork.PurchaseReturns.GetAll().Where(x=>x.GoodsReceiptDate != null),
                    // accIntegrationList =_unitOfWork.Interpretation.GetAll(),
                    // materialGroupList =_unitOfWork.MaterialGroup.GetAll()
                });

        }

        #endregion

        //[HttpGet("mpurchase/gstr1")]
        //public async Task<IActionResult> GetAllDataForGSTR1()
        //{

        //    var sss = _unitOfWork.Interpretation.GetAll().ToArray();

        //    return Json(new
        //    {
        //        companys = _unitOfWork.Companys.GetAll(),
        //        branches = _unitOfWork.Branches.GetAll(),
        //        taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
        //                         join taxi in _unitOfWork.TaxIntegration.GetAll()
        //                         on taxm.Code equals taxi.TaxCode
        //                         where taxm.TaxType == "INPUT"
        //                         select taxm),               
        //        itemmaster = _unitOfWork.ItemMaster.GetAll(),
        //        partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
        //                           join partcr in _unitOfWork.PartnerCreation.GetAll()
        //                           on parttyp.Code equals partcr.Partnertype
        //                           where parttyp.AccountType == "TRADEVENDORS"
        //                           select partcr)
        //       });

        //}


        //[HttpPost("mpurchase/gstr1/records")]
        //public async Task<IActionResult> GetPurchaseRecordsByParams([FromBody] ReportSearchCriteria reportSearchCriteria)
        //{


        //    if (reportSearchCriteria != null)
        //    {
        //        try
        //        {

        //           var result = (new Reports.ReportSaerchHelper(_unitOfWork)).searchPurchase(reportSearchCriteria.FromDate, reportSearchCriteria.ToDate, reportSearchCriteria.Branch, reportSearchCriteria.Company, reportSearchCriteria.Taxcode);

        //            if (result != null)
        //            {
        //                result = (from r in result orderby r.GoodsReceiptDate ascending select r).ToArray();
        //                return Ok(result);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex);
        //        }

        //    }
        //    return BadRequest();
        //}



        #region Purchase Reutrn
        //[HttpGet("mpurchasereturn")]
        //public async Task<IActionResult> GetAllData()
        //{
        //    //var result1 = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
        //    //               where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASERETURN.ToString()
        //    //               select mattran).FirstOrDefault();
        //    //var result2 = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
        //    //               where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASEDEFECTIVE.ToString()
        //    //               select mattran).FirstOrDefault();

        //    // || mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASEDEFECTIVE.ToString()
        //    return Json(new
        //    {
        //        companys = _unitOfWork.Companys.GetAll(),
        //        branches = _unitOfWork.Branches.GetAll(),
        //        purchase = _unitOfWork.Purchase.GetAll().ToArray(),
        //        accounts = _unitOfWork.GLAccounts.GetAll(),
        //        materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
        //                           where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASERETURN.ToString()
        //                             || mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASEDEFECTIVE.ToString()
        //                           select mattran),
        //        materialGroup = (from mattran in _unitOfWork.MaterialGroup.GetAll()
        //                         select mattran),
        //        accToAccClass = _unitOfWork.AsignmentAcctoAccClass.GetAll(),
        //        taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
        //                         where taxm.TaxType == "INPUT"
        //                         select taxm),
        //        taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
        //        models = _unitOfWork.BrandModel.GetAll(),
        //        itemmaster = _unitOfWork.ItemMaster.GetAll(),
        //        partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
        //                           join partcr in _unitOfWork.PartnerCreation.GetAll()
        //                           on parttyp.Code equals partcr.Partnertype
        //                           where parttyp.AccountType == NatureOfAccounts.TRADEVENDORS.ToString() //"TRADEVENDORS"
        //                           select partcr),
        //        brandList = _unitOfWork.Brand.GetAll(),
        //        // purchaseReturnsList = _unitOfWork.PurchaseReturns.GetAll().Where(x => x.GoodsReceiptDate != null),
        //        accIntegrationList = _unitOfWork.Interpretation.GetAll()
        //    });

        //}


        //[HttpPost("mpurchase/purchasereturns/register")]
        //public async Task<IActionResult> RegisterPurchaseReturn([FromBody]PurchaseReturns[] purchaseReturns)
        //{
        //    if (purchaseReturns == null)
        //        return BadRequest($"{nameof(purchaseReturns)} cannot be null");
        //    try
        //    {
        //       for(int i=0;i< purchaseReturns.Count(); i++)
        //        {
        //            purchaseReturns[i].AddDate = DateTime.Now;
        //            purchaseReturns[i].EditDate = DateTime.Now;
        //        }

        //        _unitOfWork.PurchaseReturns.AddRange(purchaseReturns);
        //        if (_unitOfWork.SaveChanges() > 0)
        //            return Ok(purchaseReturns);
        //        else
        //            return BadRequest($"{nameof(purchaseReturns)} Registration Failed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{nameof(purchaseReturns)} Registration Failed");
        //    }
        //}


        //[HttpGet("mpurchasereturn/{grn}")]
        //public async Task<IActionResult> GetAllDataForGSTR1(string grn)
        //{
        //    var prRCD = _unitOfWork.PurchaseReturns.GetAll().Where(x=> x.GoodsReceiptNo==grn).FirstOrDefault();
        //    if (prRCD != null)
        //        return BadRequest("GRN  "+grn+"  Already Return !!!!!!!!!");

        //    return Json(new
        //    {
        //        purchaseList = _unitOfWork.Purchase.GetAll().Where(x=> x.GoodsReceiptNo == grn).ToArray(),
        //    });

        //}


        //[HttpPost("mpurchasereturn/search")]
        //public async Task<IActionResult> SearchPurchaseReturn([FromBody]ReportSearchCriteria reportSearchCriteria)
        //{
        //    IList<PurchaseReturns> _purchaseReturns = null;

        //    if(reportSearchCriteria != null)
        //    {


        //        if (reportSearchCriteria.FromDate != null && reportSearchCriteria.ToDate != null)
        //        {
        //            _purchaseReturns = (from pur in _unitOfWork.PurchaseReturns.GetAll()
        //                                where Convert.ToDateTime(pur.AddDate.ToShortDateString()) >= Convert.ToDateTime(reportSearchCriteria.FromDate.ToShortDateString())
        //                                   && Convert.ToDateTime(pur.AddDate.ToShortDateString()) <= Convert.ToDateTime(reportSearchCriteria.ToDate.ToShortDateString())
        //                                select pur).ToArray();
        //        }
        //        else
        //        {
        //            if(reportSearchCriteria.FromDate != null)
        //            {
        //                _purchaseReturns = (from pur in _unitOfWork.PurchaseReturns.GetAll()
        //                                    where Convert.ToDateTime(pur.AddDate.ToShortDateString()) >= Convert.ToDateTime(reportSearchCriteria.FromDate.ToShortDateString())
        //                                    select pur).ToArray();
        //            }
        //            if (reportSearchCriteria.ToDate != null)
        //            {
        //                _purchaseReturns = (from pur in _unitOfWork.PurchaseReturns.GetAll()
        //                                    where Convert.ToDateTime(pur.AddDate.ToShortDateString()) <= Convert.ToDateTime(reportSearchCriteria.ToDate.ToShortDateString())
        //                                    select pur).ToArray();
        //            }
        //        }
        //        return Ok(_purchaseReturns);
        //    }

        //    return NoContent();
        //}

        #endregion


        //[HttpGet("mpurchase/gstNo/{companyCode}/{stateName}")]
        //[Produces(typeof(string))]
        //public async Task<IActionResult> GetCompanyGSTNumber(string companyCode, string stateName)
        //{
        //    if (stateName == null)
        //        return BadRequest($"stateName cannot be null");
        //    if (companyCode == null)
        //        return BadRequest($"companyCode cannot be null");

        //    return Json(new { gstNo = CompanyHelper.GetCompanyGSTNo(this._unitOfWork, companyCode, stateName) });

        //}

        //[HttpGet("mpurchase/acctoaccclassAccounts/{materialgroupCode}/{type}")]
        //public  async Task<IActionResult> GetPurchaseAccounts(string materialgroupCode,string type)
        //{
        //    if (materialgroupCode == null)
        //        return BadRequest("materialgroupCode cannot be null");

        //    var rs = (from gl in _unitOfWork.GLAccounts.GetAll()
        //              where gl.GLCode == ((from mat in _unitOfWork.MaterialGroup.GetAll()
        //                                   join acctoacc in _unitOfWork.AsignmentAcctoAccClass.GetAll() on mat.Ext1 equals acctoacc.AccClass
        //                                   join mtran in (_unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.Type != null))
        //                                   on acctoacc.TransactionType equals mtran.Code
        //                                   where mat.Code == materialgroupCode
        //                                      && mtran.TransactionType.ToUpper().Trim() == type.ToUpper().Trim()
        //                                   select acctoacc).FirstOrDefault().PurchaseAcc)
        //              select gl).FirstOrDefault();

        //    return Json(new { accToaccPurchaseAccounts = (from gl in _unitOfWork.GLAccounts.GetAll()
        //                                                  where gl.GLCode == ((from mat in _unitOfWork.MaterialGroup.GetAll()
        //                                                                       join acctoacc in _unitOfWork.AsignmentAcctoAccClass.GetAll() on mat.Ext1 equals acctoacc.AccClass
        //                                                                       join mtran in (_unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.Type != null))
        //                                                                       on acctoacc.TransactionType equals mtran.Code
        //                                                                       where mat.Code == materialgroupCode
        //                                                                          && mtran.TransactionType.ToUpper().Trim() == type.ToUpper().Trim()
        //                                                                       select acctoacc).FirstOrDefault().PurchaseAcc)
        //                                                  select gl).FirstOrDefault() });
        //}


        ////check DC No Is Present or not
        //[HttpGet("mpurchase/checkdocumnetno/{docNum}")]
        //[Produces(typeof(string))]
        //public async Task<IActionResult> ChekDocumentNumber(string docNum)
        //{
        //    if (docNum == null)
        //        return BadRequest("");
        //   // return Ok(_unitOfWork.Purchase.GetAll().Where(p => p.DeliveryNoteNo == docNum).Count() != 0);
        //    var result = _unitOfWork.Purchase.GetAll().Where(p => p.DeliveryNoteNo == docNum).Count() != 0;
        //    return Ok(result);
        //   // return Json(new { status =  });

        //}

        ////check DC No Is Present or not
        //[HttpGet("mpurchase/chkInviceNo/{invNo}")]
        //[Produces(typeof(string))]
        //public async Task<IActionResult> ChekchkInviceNumber(string invNo)
        //{
        //    if (invNo == null)
        //        return BadRequest("");

        //   // return Json(new { status = _unitOfWork.Purchase.GetAll().Where(p => p.InvoiceNo == invNo).Count() != 0 });
        //    return Ok(_unitOfWork.Purchase.GetAll().Where(p => p.InvoiceNo == invNo).Count() != 0);
        //}

    }
}