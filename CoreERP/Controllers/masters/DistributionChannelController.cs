﻿using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/DistributionChannel")]
    public class DistributionChannelController : ControllerBase
    {
        private readonly IRepository<TblDistributionChannel> _dcRepository;
        public DistributionChannelController(IRepository<TblDistributionChannel> dcRepository)
        {
            _dcRepository = dcRepository;
        }

        [HttpPost("RegisterDistributionChannel")]
        public IActionResult RegisterDistributionChannel([FromBody]TblDistributionChannel dchannel)
        {
            if (dchannel == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (DistributionChannelHelper.GetList(dchannel.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"DistributionChannel Code {nameof(dchannel.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _dcRepository.Add(dchannel);
                if (_dcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dchannel };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDistributionChannelList")]
        public IActionResult GetDistributionChannelList()
        {
            try
            {
                var dchannelList = _dcRepository.GetAll();
                if (dchannelList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.dchannelList = dchannelList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateDistributionChannel")]
        public IActionResult UpdateDistributionChannel([FromBody] TblDistributionChannel dcchannel)
        {
            if (dcchannel == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dcchannel)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _dcRepository.Update(dcchannel);
                if (_dcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dcchannel };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDistributionChannel/{code}")]
        public IActionResult DeleteDistributionChannelByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _dcRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _dcRepository.Remove(record);
                if (_dcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}