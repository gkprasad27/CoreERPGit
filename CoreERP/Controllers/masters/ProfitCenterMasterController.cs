using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/ProfitCenter")]
    public class ProfitCenterMasterController : ControllerBase
    {
        private readonly IRepository<ProfitCenters> _pcRepository;
        public ProfitCenterMasterController(IRepository<ProfitCenters> pcRepository)
        {
            _pcRepository = pcRepository;
        }

        [HttpGet("GetProfitCenterList")]
        public  IActionResult GetProfitCenterList()
        {
            try
            {
                var profitCenterList = CommonHelper.GetProfitcenters();
                if (profitCenterList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.profitCenterList = profitCenterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception e)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = e.Message });
            }
        }

        [HttpGet("GetProfitCenters")]
        public IActionResult GetProfitCentersList()
        {
            try
            {
                var profitCenterList = CommonHelper.GetProfitcenters().Select(x => new { code = x.Code, name = x.Name, PONumber = x.PONumber, POPrefix = x.POPrefix, SONumber = x.SONumber, SOPrefix = x.SOPrefix }); ;
                if (profitCenterList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.profitCenterList = profitCenterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception e)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = e.Message });
            }
        }

        [HttpPost("RegisterProfitCenters")]
        public  IActionResult RegisterProfitCenters([FromBody] ProfitCenters profitCenter)
        {

            if (profitCenter == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(profitCenter)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _pcRepository.Add(profitCenter);
                if (_pcRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = profitCenter });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateProfitCenters")]
        public  IActionResult UpdateProfitCenters(string code, [FromBody] ProfitCenters profitCenter)
        {
            if (profitCenter == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(profitCenter)} cannot be null" });
            try
            {

                APIResponse apiResponse;
                _pcRepository.Update(profitCenter);
                if (_pcRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = profitCenter });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpDelete("DeleteProfitCenters/{code}")]
        public IActionResult DeleteProfitCenters(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                var record = _pcRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _pcRepository.Remove(record);
                if (_pcRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
