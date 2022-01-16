using System;
using System.Collections.Generic;
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

        [HttpPost]
        [Authorize]
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

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] ClientRequestDTO dto)
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

        [HttpPut]
        [Route("changeClientState/{idClient:int}")]
        [Authorize]
        public IActionResult DesactivateClient(int idClient)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.ChangeClientState(idClient));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("addToLoan")]
        [Authorize]
        public IActionResult AddToLoan([FromBody] ClientLoanRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.AddToLoan(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("addToLoanList")]
        [Authorize]
        public IActionResult AddToLoanList([FromBody] List<ClientLoanRequestDTO> dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.AddToLoanList(dto));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("byIdLoan/{idLoan:int}")]
        [Authorize]
        public IActionResult GetClientByIdLoan(int idLoan)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetClientByIdLoan(idLoan));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("uploadSentinelPdf")]
        //[Authorize]
        public IActionResult UploadSentinelPdf([FromForm] UploadPdfRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.UploadSentinelPdf(dto));
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
