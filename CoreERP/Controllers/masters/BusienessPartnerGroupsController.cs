﻿using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/BusienessPartnerGroups")]
    public class BusienessPartnerGroupsController : ControllerBase
    {
        private readonly IRepository<TblBpgroup> _bpgRepository;
        public BusienessPartnerGroupsController(IRepository<TblBpgroup> bpgRepository)
        {
            _bpgRepository = bpgRepository;
        }

        [HttpPost("RegisterBusienessPartnerGroups")]
        public IActionResult RegisterBusienessPartnerGroups([FromBody]TblBpgroup bpgroup)
        {
            if (bpgroup == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _bpgRepository.Add(bpgroup);
                if (_bpgRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() {status = APIStatus.PASS.ToString(), response = bpgroup};
                else
                    apiResponse = new APIResponse()
                        {status = APIStatus.FAIL.ToString(), response = "Registration Failed."};

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBusienessPartnerGroupsList")]
        public IActionResult GetBusienessPartnerGroupsList()
        {
            try
            {
                var bpgList = CommonHelper.GetBpGroups();
                if (!bpgList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.bpgList = bpgList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBusienessPartnerGroups")]
        public IActionResult UpdateBusienessPartnerGroups([FromBody] TblBpgroup bpgroup)
        {
            if (bpgroup == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(bpgroup)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _bpgRepository.Update(bpgroup);
                if (_bpgRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() {status = APIStatus.PASS.ToString(), response = bpgroup};
                else
                    apiResponse = new APIResponse() {status = APIStatus.FAIL.ToString(), response = "Updation Failed."};

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBusienessPartnerGroups/{code}")]
        public IActionResult DeleteBusienessPartnerGroupsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _bpgRepository.GetSingleOrDefault(x => x.Bpgroup.Equals(code));
                _bpgRepository.Remove(record);
                if (_bpgRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() {status = APIStatus.PASS.ToString(), response = code};
                else
                    apiResponse = new APIResponse() {status = APIStatus.FAIL.ToString(), response = "Deletion Failed."};

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}