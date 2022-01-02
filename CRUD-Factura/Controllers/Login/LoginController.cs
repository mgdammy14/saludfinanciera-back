using System;
using System.Net;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Login
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly ILoginLogic _logic;
        private readonly IHttpContextAccessor _context;

        public LoginController(ILoginLogic loginLogic, IHttpContextAccessor httpContextAccessor)
        {
            _logic = loginLogic;
            _context = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var transaction = _logic.Login(dto);
                var response = new ResponseDTO();

                if(transaction.Token == "Usuario invalido")
                {
                    response = _responseDTO.WrongUser(_responseDTO, transaction);
                }
                else
                {
                    if(transaction.Token == "Contraseña incorrecta")
                    {
                        response = _responseDTO.WrongPassword(_responseDTO, transaction);
                    }
                    else
                    {
                        response = _responseDTO.Success(_responseDTO, transaction);
                    }
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("me")]
        [Authorize]
        public IActionResult Me()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var token = _context.HttpContext.Request.Headers["Authorization"].ToString();
                var response = _responseDTO.Success(_responseDTO, _logic.GetToken(token));
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
