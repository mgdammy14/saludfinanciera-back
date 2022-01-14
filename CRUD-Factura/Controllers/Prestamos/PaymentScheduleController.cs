using System;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiModel.Prestamos;
using ApiModel.RequestDTO.Prestamos;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Prestamos
{
    [Route("api/paymentSchedule")]
    public class PaymentScheduleController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private IPaymentScheduleLogic _logic;

        public PaymentScheduleController(IPaymentScheduleLogic paymentScheduleLogic)
        {
            _logic = paymentScheduleLogic;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Insert([FromBody] PaymentSchedule dto)
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

        [HttpGet]
        //[Authorize]
        public IActionResult GetList()
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



        [HttpPost]
        [Route("schedule")]
        public IActionResult CrearCronogramaTest([FromBody] CreateScheduleRequestDTO firsPaymentDate)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.CreatePaymentSchedule(firsPaymentDate));
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
