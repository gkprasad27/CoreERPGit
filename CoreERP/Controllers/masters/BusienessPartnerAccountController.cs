﻿using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/BusienessPartnerAccount")]
    public class BusienessPartnerAccountController : ControllerBase
    {
        private readonly IRepository<TblAssignment> _assignmentrepository;
        private readonly IRepository<TblBpgroup> _bpgrouprepository;
        private readonly IRepository<TblNumberRange> _numberRangerepository;
        private readonly IRepository<TblBusinessPartnerAccount> _businessPartnerAccountRepository;
        public BusienessPartnerAccountController(IRepository<TblBusinessPartnerAccount> businessPartnerAccountRepository,
          IRepository<TblAssignment> assignmentepository, IRepository<TblBpgroup> bpgrouprepository,
          IRepository<TblNumberRange> numberRangerepository)
        {
            _businessPartnerAccountRepository = businessPartnerAccountRepository;
            _assignmentrepository = assignmentepository;
            _numberRangerepository = numberRangerepository;
            _bpgrouprepository = bpgrouprepository;
        }
        [HttpGet("GetBusienessPartnerAccountList/{CompanyCode}")]
        public async Task<IActionResult> GetBusienessPartnerAccountList(string CompanyCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var bpaList = CommonHelper.GetBusinessPartner().Where(c => c.Company.Contains(CompanyCode)); 
                    if (bpaList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.bpaList = bpaList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for BusienessPartnerAccount." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterBusienessPartnerAccount")]
        public async Task<IActionResult> RegisterBusienessPartnerAccount([FromBody] TblBusinessPartnerAccount bpa)
        {
            APIResponse apiResponse;
            if (bpa == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(bpa)} cannot be null" });
            else
            {
                try
                {
                    _businessPartnerAccountRepository.Add(bpa);
                    TblBpgroup BGG = new TblBpgroup();
                    BGG.Ext1 = int.Parse(bpa.Bpnumber);
                    BGG.Bpgroup = bpa.Bpgroup;
                    BGG.Bptype = bpa.Bptype;
                    BGG.Description = bpa.Ext;
                    _bpgrouprepository.Update(BGG);
                    _bpgrouprepository.SaveChanges();
                    if (_businessPartnerAccountRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bpa };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateBusienessPartnerAccount")]
        public async Task<IActionResult> UpdateBusienessPartnerAccount([FromBody] TblBusinessPartnerAccount bpa)
        {
            APIResponse apiResponse = null;
            if (bpa == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _businessPartnerAccountRepository.Update(bpa);
                if (_businessPartnerAccountRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bpa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBusienessPartnerAccount/{code}")]
        public async Task<IActionResult> DeleteBusienessPartnerAccount(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _businessPartnerAccountRepository.GetSingleOrDefault(x => x.Bpnumber.Equals(code));
                _businessPartnerAccountRepository.Remove(record);
                if (_businessPartnerAccountRepository.SaveChanges() > 0)
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

        [HttpGet("GetBusienessPartnerAccount/{code}")]
        public async Task<IActionResult> GetBusienessPartnerAccount(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var bpaList = _businessPartnerAccountRepository.GetSingleOrDefault(x => x.Bpnumber.Equals(code));
                if (bpaList != null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpaList = bpaList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for BusienessPartnerAccount." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBPtNumberList/{code}/{code1}")]
        public IActionResult GetBPtNumberList(string code, int code1)
        {
            try
            {
                var Getaccnolist = _assignmentrepository.Where(x => x.Bpgroup == code).FirstOrDefault();
                var numrnglist = _numberRangerepository.Where(x => x.Code == Getaccnolist.NumberRangeKey.ToString()).FirstOrDefault();
                if (Enumerable.Range(Convert.ToInt32(numrnglist.RangeFrom), Convert.ToInt32(numrnglist.RangeTo)).Contains(code1))
                {
                    if (code1 >= Convert.ToInt32(numrnglist.RangeFrom) && code1 <= Convert.ToInt32(numrnglist.RangeTo))
                    {
                        return Ok();
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBPtNumber/{code}")]
        public IActionResult GetBPtNumber(string code)
        {
            try
            {
                int i = Convert.ToInt32(_bpgrouprepository.Where(x => x.Bpgroup == code).SingleOrDefault()?.Ext1);
                var Getaccnolist = _assignmentrepository.Where(x => x.Bpgroup == code).FirstOrDefault();
                if (Getaccnolist != null)
                {
                    var numrnglist = _numberRangerepository.Where(x => x.Code == Getaccnolist.NumberRangeKey.ToString()).FirstOrDefault();
                    if (i == 0 && Getaccnolist.Bpgroup == code)
                    {
                        var x = numrnglist.RangeFrom;

                        if (Enumerable.Range(Convert.ToInt32(numrnglist.RangeFrom), Convert.ToInt32(numrnglist.RangeTo)).Contains(Convert.ToInt32(x)))
                        {
                            if (x >= Convert.ToInt32(numrnglist.RangeFrom) && x <= Convert.ToInt32(numrnglist.RangeTo))
                            {
                                var bpnum = x + 1;
                                if (bpnum != null)
                                {
                                    dynamic expdoObj = new ExpandoObject();
                                    expdoObj.bpaNum = bpnum;
                                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                                }
                            }
                            else
                                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                        }
                    }
                    else
                    {
                        if (Enumerable.Range(Convert.ToInt32(numrnglist.RangeFrom), Convert.ToInt32(numrnglist.RangeTo)).Contains(i))
                        {
                            if (i >= Convert.ToInt32(numrnglist.RangeFrom) && i <= Convert.ToInt32(numrnglist.RangeTo))
                            {
                                var bpnum = i + 1;
                                if (bpnum != null)
                                {
                                    dynamic expdoObj = new ExpandoObject();
                                    expdoObj.bpaNum = bpnum;
                                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                                }
                            }
                            else
                                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                        }
                    }
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data.." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            return Ok();

        }

        [HttpGet("GetBPtName/{code}")]
        public IActionResult GetBPtNumberList(string code)
        {
            try
            {
                var bpname = _bpgrouprepository.Where(x => x.Bpgroup == code).SingleOrDefault()?.Description;
                //var bpname = _bpgrouprepository.Where(x => x.Bpgroup == code).FirstOrDefault();
                if (bpname != null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpname = bpname;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for BusienessPartnerAccount." });
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}