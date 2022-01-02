using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiBusinessModel.Interfaces.General;
using ApiBusinessModel.Interfaces.Users;
using ApiModel.RequestDTO;
using ApiModel.RequestDTO.SMS;
using ApiModel.ResponseDTO.General;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_Factura.Controllers.Users
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private IUsersLogic _logic;
        private ISMSLogic _smsLogic;

        public UsersController(IUsersLogic logic, ISMSLogic smsLogic)
        {
            _logic = logic;
            _smsLogic = smsLogic;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetUsers());
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert([FromBody] UsersRequestDTO dto)
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

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] UsersRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Update(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }
        [HttpDelete]
        [Route("{idUserDeleted:int}")]
        [Authorize]
        public IActionResult Delete(int idUserDeleted)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Delete(idUserDeleted));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("sendSMS")]
        public IActionResult SendSMS([FromBody] SMSRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _smsLogic.SendSMS(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("sendWhatsAppSMS")]
        public IActionResult SendWhatsAppSMS([FromBody] SMSRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _smsLogic.SendWhatsAppSMS(dto));
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
