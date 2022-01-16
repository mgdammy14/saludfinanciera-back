using System;
using ApiBusinessModel.Interfaces.General;
using ApiModel.General;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.General
{
    [Route("api/bank")]
    public class BankController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IBankLogic _logic;

        public BankController(IBankLogic bankLogic)
        {
            _logic = bankLogic;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Bank dto)
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
    }
}
