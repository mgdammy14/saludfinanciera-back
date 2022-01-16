using System;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Mensajes
{
    [Route("api/SMS")]
    public class SMSController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly ISMSLogic _logic;

        public SMSController(ISMSLogic SMSLogic)
        {
            _logic = SMSLogic;
        }

        [HttpPost]
        [Route("sendNotificationToGroup")]
        [Authorize]
        public IActionResult SendNotificationToGroup([FromBody] SendNotificationToGroupRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.SendNotificationToGroup(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("sendNotificationIndividual")]
        [Authorize]
        public IActionResult SendNotificationIndividual([FromBody] SendNotificationIndividualRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.SendNotificationIndividual(dto));
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
