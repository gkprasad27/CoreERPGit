﻿using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/OpenLedger")]
    public class OpenLedgerController : ControllerBase
    {
        private readonly IRepository<TblOpenLedger> _olRepository;
        public OpenLedgerController(IRepository<TblOpenLedger> olRepository)
        {
            _olRepository = olRepository;
        }

        [HttpPost("RegisterOpenLedger")]
        public IActionResult RegisterOpenLedger([FromBody] TblOpenLedger opnldgr)
        {
            if (opnldgr == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                //if (GLHelper.GetList(opnldgr.LedgerKey).Count > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Ledger Code ={opnldgr.LedgerKey} alredy exists." });

                APIResponse apiResponse;
                _olRepository.Add(opnldgr);
                if (_olRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = opnldgr });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetOpenLedgerList")]
        public IActionResult GetOpenLedgerList()
        {
            try
            {
                var openledgerList = CommonHelper.GetOpenLedger();
                if (openledgerList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.OpenLedgerList = openledgerList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateOpenLedgerList")]
        public IActionResult UpdateOpenLedgerList([FromBody] TblOpenLedger ledger)
        {
            if (ledger == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(ledger)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _olRepository.Update(ledger);
                if (_olRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = ledger });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteOpenLedgerList/{code}")]
        public IActionResult DeleteOpenLedgerList(int code)
        {
            //if (string.IsNullOrWhiteSpace(code))
            //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                var record = _olRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _olRepository.Remove(record);
                if (_olRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}