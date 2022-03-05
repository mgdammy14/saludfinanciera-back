using System;
using ApiBusinessModel.Interfaces.General;
using ApiModel.ResponseDTO.General;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Factura.Controllers.General
{
    [Route("api/dashboard")]
    public class DashboardController : Controller
    {
        private ResponseDTO _responseDTO = null;
        private readonly IDashboardLogic _logic;

        public DashboardController(IDashboardLogic dashboardLogic)
        {
            _logic = dashboardLogic;
        }

        [HttpGet]
        public IActionResult GetDashboard()
        {
            _responseDTO = new ResponseDTO();
            try
            {
                var response = _responseDTO.Success(_responseDTO, _logic.Dashboard());
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
