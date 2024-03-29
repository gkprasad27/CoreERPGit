﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/EmployeeInBranch")]
    public class EmployeeInBranchController : ControllerBase
    {

        [HttpGet("GetAllEmployeesInBranch/{BranchCode}")]
        public IActionResult GetAllEmployeesInBranch(string BranchCode)
        {
            try
            {
                var empinbrList = EmployeeHelper.GetEmployeeInBranches(null, BranchCode);
                if (empinbrList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.empinbrList = empinbrList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


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


        [HttpGet("GetBranchesList")]
        public IActionResult GetBranchesList()
        {
            try
            {
                var branchesList = CommonHelper.GetBranches();
                if (branchesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.branchesList = branchesList;
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


        [HttpPost("RegisterEmployeeInBranch")]
        public IActionResult RegisterEmployeeInBranch([FromBody]EmployeeInBranches employeeInBranch)
        {
            if (employeeInBranch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(employeeInBranch)} cannot be null" });
            try
            {
                var result = EmployeeHelper.RegisterEmployeeInBranch(employeeInBranch);
                APIResponse apiResponse;
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPut("UpdateEmployeeInBranch")]
        public IActionResult UpdateEmployeeInBranch([FromBody] EmployeeInBranches employeeInBranch)
        {
            if (employeeInBranch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(employeeInBranch)} cannot be null." });

            try
            {
                var result = EmployeeHelper.UpdateEmployeeInBranches(employeeInBranch);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        // Delete Branch
        [HttpDelete("DeleteEmployeeInBranch/{code}")]
        public IActionResult DeleteEmployeeInBranch(string code)
        {
            if (code == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = EmployeeHelper.DeleteEmployeeInBranches(code);
                APIResponse apiResponse;
                if (result != null)
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