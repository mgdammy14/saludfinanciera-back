using System;
using System.IO;
using System.Threading.Tasks;
using ApiBusinessModel.Interfaces.Pagos;
using ApiModel.RequestDTO.Pagos;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace CRUD_Factura.Controllers.Pagos
{
    [Route("api/payment")]
    public class PaymentController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IPaymentLogic _logic;

        public PaymentController(IPaymentLogic paymentLogic)
        {
            _logic = paymentLogic;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert([FromForm] PaymentRequestDTO dto)
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
        [Route("{idLoan:int}")]
        [Authorize]
        public IActionResult GetPaymentByIdLoan(int idLoan)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetPaymentsByLoan(idLoan));
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
