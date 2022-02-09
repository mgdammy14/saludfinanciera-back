using System;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiModel.RequestDTO.Prestamos;
using ApiModel.ResponseDTO.General;
using ApiModel.ResponseDTO.Prestamos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Prestamos
{
    [Route("api/loan")]
    public class LoanController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private ILoanLogic _logic;

        public LoanController(ILoanLogic loanLogic)
        {
            _logic = loanLogic;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert([FromBody] LoanRequestDTO dto)
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
        public IActionResult Update([FromBody] LoanRequestDTO dto)
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

        [HttpGet]
        [Authorize]
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

        [HttpGet]
        [Route("fullInformation/{idLoan:int}")]
        [Authorize]
        public IActionResult GetFullLoanInfomation(int idLoan)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.FullLoanResponse(idLoan));
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
