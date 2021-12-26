using System;
using ApiBusinessModel.Interfaces.Url;
using ApiModel.RequestDTO.UrlRequest;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.Url
{
    [Route("api/url")]
    public class UrlController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private IUrlLogic _logic;

        public UrlController(IUrlLogic rolLogic)
        {
            _logic = rolLogic;
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
        public IActionResult Insert([FromBody] UrlRequestDTO dto)
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
        public IActionResult Update([FromBody] UrlRequestDTO dto)
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
        [Route("{idUrlDeleted:int}")]
        [Authorize]
        public IActionResult Delete(int idUrlDeleted)
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Delete(idUrlDeleted));
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
