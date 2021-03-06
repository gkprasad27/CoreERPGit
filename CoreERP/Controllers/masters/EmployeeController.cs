﻿using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("GetEmployeeList")]
        public IActionResult GetEmployeeList()
        {
            try
            {
                var employeesList = EmployeeHelper.GetEmployes();
                if (employeesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.employeesList = employeesList;
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


        //[HttpPost("RegisterEmployee")]
        //public IActionResult RegisterEmployee([FromBody]TblEmployee employee)
        //{
        //    if (employee == null)
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(employee)} cannot be null" });

        //    try
        //    {
        //        if (EmployeeHelper.GetEmployesByID(employee.EmployeeCode).Count() > 0)
        //            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"Code {employee.EmployeeCode} is already exists ,please use different code" });

        //        var result = EmployeeHelper.Register(employee);
        //        APIResponse apiResponse;
        //        if (result != null)
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
        //        }
        //        else
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
        //        }

        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}



        //[HttpPut("UpdateEmployee")]
        //public IActionResult UpdateEmployee([FromBody] TblEmployee employee)
        //{
        //    try
        //    {
        //        if (employee == null)
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(employee)} cannot be null" });

        //        var result = EmployeeHelper.Update(employee);
        //        APIResponse apiResponse;
        //        if (result != null)
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
        //        }
        //        else
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
        //        }
        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}


        //// Delete Branch
        //[HttpDelete("DeleteEmployee/{code}")]
        //public IActionResult DeleteEmployee(string code)
        //{
        //    if (code == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });
        //    try
        //    {
        //        var result = EmployeeHelper.Delete(code);
        //        APIResponse apiResponse;
        //        if (result != null)
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
        //        }
        //        else
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
        //        }
        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}