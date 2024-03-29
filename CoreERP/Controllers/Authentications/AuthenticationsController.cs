﻿using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthenticationsController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser([FromBody]Erpuser erpuser)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;
                    Erpuser user = UserManagmentHelper.ValidateUser(erpuser,out errorMessage);

                    if (user != null)
                    {
                        //var _branch = UserManagmentHelper.GetBranchesByUser(user.SeqId).ToList();
                       // var shiftId = new UserManagmentHelper().GetShiftId(user.SeqId, _branch.FirstOrDefault());
                        dynamic expando = new ExpandoObject();
                        expando.User = user;
                        expando.Token= new BussinessLogic.Authentication.TokenGenerator().GenerateToken(user);
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }
        
       // [Authorize]
        [HttpGet("GetBranchesForUser/{seqid}")]
        public async Task<IActionResult> GetBranchesForUser(string seqid)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(seqid))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Branches = UserManagmentHelper.GetBranchesByUser(Convert.ToDecimal(seqid));
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpGet("getMenu/{roleId}")]
        public async Task<IActionResult> GetMenus(string roleId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var result = UserManagmentHelper.GetMenusForRole(roleId);
                    if (result != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found for user." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        #region Menu Access
        [HttpGet("getMenuList/{roleId}/{parentId}")]
        public async Task<IActionResult> GetMenusList(string roleId,string parentId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var result = new UserManagmentHelper().GetMenus(parentId, roleId);
                    if (result != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found for user." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpPost("GiveAccess/{roleId}")]
        public async Task<IActionResult> GetMenusList(string roleId,[FromBody] List<MenuAccesses> menuAccesses)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                   new UserManagmentHelper().GiveAcces(menuAccesses, roleId);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Menu Access provided sccessfully." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var result = new UserManagmentHelper().GetRoles();
                    if (result != null)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.Roles = result.Select(r => new { ID = r.RoleId, TEXT = r.Role });
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  roles configured." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpGet("getParentMenu")]
        public async Task<IActionResult> GetParentMenu()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var result = new UserManagmentHelper().GetParentMenus();
                    if (result != null)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.ParentMenus = result.Select(r => new { ID = r.OperationCode, TEXT = r.Description }).OrderBy(x=> x.TEXT);
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Parent menu found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }
        #endregion

        [HttpGet("logout/{userId}")]
        public async Task<IActionResult> GetMenuList(string userId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Log out successfully." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        // [Authorize]
        //[HttpGet("ShiftStart/{userId}/{branchCode}")]
        //public async Task<IActionResult> ShiftStart(string userId,string branchCode)
        //{
        //    var result = await Task.Run(() =>
        //    {
        //        try
        //        {
        //            string errorMessage = string.Empty;
        //            var result = new UserManagmentHelper().StartShift(Convert.ToDecimal(userId), branchCode);
        //            if (result != null)
        //            {
        //                dynamic expando = new ExpandoObject();
        //                expando.ShiftId = result.ShiftId;
        //                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //            }

        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Fialed to generate shift id." });
        //        }
        //        catch (Exception ex)
        //        {
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
        //        }
        //    });
        //    return result;
        //}

        // [Authorize]
        //[HttpGet("ShiftTerminate/{shiftId}")]
        //public async Task<IActionResult> ShiftTerminate(string shiftId)
        //{
        //    var result = await Task.Run(() =>
        //    {
        //        try
        //        {
        //            string errorMessage = string.Empty;
        //            var result = new UserManagmentHelper().EndShift(Convert.ToDecimal(shiftId));
        //            if (result)
        //            {
        //                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Shift terminated successfully...." });
        //            }

        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Fialed to terminate the shift." });
        //        }
        //        catch (Exception ex)
        //        {
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
        //        }
        //    });
        //    return result;
        //}

    }
}
       
