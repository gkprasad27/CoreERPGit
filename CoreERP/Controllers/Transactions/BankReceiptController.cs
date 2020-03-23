﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Models;
using Newtonsoft.Json.Linq;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/BankReceipt")]
    public class BankReceiptController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new BankReceiptHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBankReceiptList")]
        public async Task<IActionResult> GetBankReceiptList()
        {
            try
            {
                var bankReceiptList = BankReceiptHelper.GetBankReceipts();
                if (bankReceiptList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BankReceiptList = bankReceiptList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherNo/{branchCode}")]
        public async Task<IActionResult> GetVoucherNo(string branchCode)
        {
            if (string.IsNullOrEmpty(branchCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new BankReceiptHelper().GetVoucherNo(branchCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountLedgerList")]
        public async Task<IActionResult> GetAccountLedgerList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxcodesList = BankReceiptHelper.GetAccountLedgers().Select(x => new { ID = x.LedgerCode, TEXT = x.LedgerName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpPost("RegisterBankReceipt")]
        public async Task<IActionResult> RegisterBankReceipt([FromBody]JObject objData)
        {

            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _bankreceiptHdr = objData["BankreceiptHdr"].ToObject<TblBankReceiptMaster>();
                var _bankreceiptDtl = objData["BankreceiptDetail"].ToObject<TblBankReceiptDetails[]>();

                var result = new BankReceiptHelper().RegisterBankReceipt(_bankreceiptHdr, _bankreceiptDtl.ToList());
                if (result)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = _bankreceiptHdr });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("GetBankreceiptList/{branchCode}")]
        public async Task<IActionResult> GetBankreceiptList(string branchCode, [FromBody]SearchCriteria searchCriteria)
        {

            if (searchCriteria == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var bankReceiptMasterList = new BankReceiptHelper().GetBankReceiptMasters(searchCriteria);
                if (bankReceiptMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BankReceiptList = bankReceiptMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Billing record found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}