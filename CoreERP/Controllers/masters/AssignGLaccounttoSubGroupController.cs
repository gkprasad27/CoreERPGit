﻿using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AssignGLaccounttoSubGroup")]

    public class AssignGLaccounttoSubGroupController : ControllerBase
    {
        private readonly IRepository<TblAccountGroup> _glaugRepository;
        private readonly IRepository<AssignmentSubaccounttoGl> _assignmentSubaccounttoGLRepository;
        public AssignGLaccounttoSubGroupController(IRepository<TblAccountGroup> glaugRepository,
            IRepository<AssignmentSubaccounttoGl> assignmentSubaccounttoGLRepository)
        {
            _glaugRepository = glaugRepository;
            _assignmentSubaccounttoGLRepository = assignmentSubaccounttoGLRepository;
        }
        [HttpGet("GetAssignGLaccounttoSubGroupList")]
        public async Task<IActionResult> GetAssignGLaccounttoSubGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var assignacckeyList = _assignmentSubaccounttoGLRepository.GetAll();
                    if (assignacckeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.assignacckeyList = assignacckeyList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for assignacckeyList." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterAssignGLaccounttoSubGroup")]
        public async Task<IActionResult> RegisterAssignGLaccounttoSubGroup([FromBody]AssignmentSubaccounttoGl assnacckey)
        {
            APIResponse apiResponse;
            if (assnacckey == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(assnacckey)} cannot be null" });
            else
            {
                try
                {
                    _assignmentSubaccounttoGLRepository.Add(assnacckey);
                    if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };
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

        [HttpPut("UpdateAssignGLaccounttoSubGroup")]
        public async Task<IActionResult> UpdateAssignGLaccounttoSubGroup([FromBody] AssignmentSubaccounttoGl assnacckey)
        {
            APIResponse apiResponse = null;
            if (assnacckey == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assignmentSubaccounttoGLRepository.Update(assnacckey);
                if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignGLaccounttoSubGroup/{code}")]
        public async Task<IActionResult> DeleteAssignGLaccounttoSubGroup(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assignmentSubaccounttoGLRepository.GetSingleOrDefault(x => x.Glgroup.Equals(code));
                _assignmentSubaccounttoGLRepository.Remove(record);
                if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
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


        [HttpGet("GetGLUnderSubGroupList/{undersubgroup}")]
        public IActionResult GetGLUnderSubGroupList(string undersubgroup)
        {
            try
            {
                try
                {
                    var GetAccountNamelist = _glaugRepository.Where(x => x.Nature == undersubgroup&&x.IsDefault==1);
                    if (GetAccountNamelist.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.GetAccountNamelist = GetAccountNamelist;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for SubGroupList." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}