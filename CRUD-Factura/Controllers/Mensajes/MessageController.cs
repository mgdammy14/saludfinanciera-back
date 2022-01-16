using System;
using ApiBusinessModel.Interfaces.Mensajes;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Mensajes
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IMessageLogic _logic;

        public MessageController(IMessageLogic messageLogic)
        {
            _logic = messageLogic;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert([FromBody] MessageRequestDTO dto)
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
        public IActionResult Update([FromBody] MessageRequestDTO dto)
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
        [Route("{idMessageDeleted:int}")]
        [Authorize]
        public IActionResult Delete(int idMessageDeleted)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Delete(idMessageDeleted));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetRolWithPermissions()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetList());
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
