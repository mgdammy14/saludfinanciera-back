using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.Person;
using ApiModel.RequestDTO.Client;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Person
{
    [Route("api/person")]
    public class PersonController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IPersonLogic _logic;

        public PersonController(IPersonLogic personLogic)
        {
            _logic = personLogic;
        }

        [HttpGet]
        [Route("clientList")]
        [Authorize]
        public IActionResult GetClientList()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetClientList());
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
        public IActionResult Insert([FromBody] PersonFullRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.InsertPerson(dto));
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
        public IActionResult Update([FromBody] UpdatePersonFullRequestDTO dto)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.UpdatePerson(dto));
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
        //[Authorize]
        public IActionResult AddToLoan([FromBody] List<ClientLoanRequestDTO> dto)
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

        [HttpDelete]
        [Route("fromLoan/{idClient:int}/{idLoan:int}")]
        [Authorize]
        public IActionResult AddToLoan(int idClient, int idLoan)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.DeleteClientFromLoan(idClient, idLoan));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("check/{documentNumber:int}")]
        [Authorize]
        public IActionResult CheckClientByDocumentNumber(int documentNumber)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.CheckClientByDocumentNumber(documentNumber.ToString()));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("fullInformation/{idPerson:int}")]
        [Authorize]
        public IActionResult GetFullInformation(int idPerson)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetFullInformation(idPerson));
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
        [Authorize]
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

        [HttpGet]
        [Route("historicalSentinelReport/{idPerson:int}")]
        [Authorize]
        public IActionResult GetHistoricalSentinelReportByIdPerson(int idPerson)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.GetHistoricalSentinelReportByIdPerson(idPerson));
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
                var response = _responseDTO.Success(_responseDTO, _logic.ChangePersonState(idClient));
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("deleteSentinelReport/{idReport:int}")]
        [Authorize]
        public IActionResult DeleteSentinelReport(int idReport)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.DeleteSentinelReport(idReport));
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
