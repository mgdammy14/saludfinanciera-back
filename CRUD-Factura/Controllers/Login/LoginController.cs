using System;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Login
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly ILoginLogic _logic;

        public LoginController(ILoginLogic loginLogic)
        {
            _logic = loginLogic;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Login(dto));
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
