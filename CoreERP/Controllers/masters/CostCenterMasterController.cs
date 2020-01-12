using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;
using System;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/CostCenter")]
    public class CostCenterMasterController : ControllerBase
    {


        [HttpGet("GetCostCenterList")]
        public async Task<IActionResult> GetCostCenterList()
        {
            try
            {
                var costcenterList = CostCenterHelper.GetCostCenterList();
                if (costcenterList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costcenterList = costcenterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterCostCenter")]
        public async Task<IActionResult> RegisterCostCenter([FromBody]CostCenters costCenter)
        {
            APIResponse apiResponse = null;
            if (costCenter == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costCenter)} cannot be null" });
            try
            {
                if(CostCenterHelper.IsCodeExists(costCenter.Code))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"Code ={costCenter.Code} Already Exists." });

                var result = CostCenterHelper.RegisterCostCenter(costCenter);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPut("UpdateCostCenter")]
        public async Task<IActionResult> UpdateCostCenter([FromBody] CostCenters costCenter)
        {
            APIResponse apiResponse = null;
            if (costCenter == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costCenter)} cannot be null" });
            try
            {

                var rs = CostCenterHelper.UpdateCostCenter(costCenter);
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCostCenter/{code}")]
        public async Task<IActionResult> DeleteCostCenter(string code)
        {
            APIResponse apiResponse = null;
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null"});
            try
            {
                var result = CostCenterHelper.DeleteCostCenter(code);
                if (result !=null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
