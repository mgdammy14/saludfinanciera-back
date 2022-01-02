using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.Permission;
using ApiModel.RequestDTO.PermissionRequest;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Permission
{
    [Route("api/permission")]
    public class PermissionController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IPermissionLogic _logic;

        public PermissionController(IPermissionLogic permissionLogic)
        {
            _logic = permissionLogic;
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] List<PermissionRequestDTO> dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.AddPermissions(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }
    }
}
