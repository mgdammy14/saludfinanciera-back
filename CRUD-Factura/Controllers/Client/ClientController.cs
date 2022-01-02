using System;
using ApiBusinessModel.Interfaces.Client;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Client
{
    [Route("api/client")]
    public class ClientController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IClientLogic _logic;

        public ClientController(IClientLogic clientLogic)
        {
            _logic = clientLogic;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Insert([FromBody] ClientRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Insert(dto));
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
