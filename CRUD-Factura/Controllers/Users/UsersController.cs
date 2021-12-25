using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiBusinessModel.Interfaces.Users;
using ApiModel.RequestDTO;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_Factura.Controllers.Users
{
    [Route("api/users")]

    public class UsersController : Controller
    {
        private IUsersLogic _logic;

        public UsersController(IUsersLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            try
            {
                return Ok(_logic.GetUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert([FromBody] UsersRequestDTO dto)
        {
            try
            {
                return Ok(_logic.Insert(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] UsersRequestDTO dto)
        {
            try
            {
                return Ok(_logic.Update(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete]
        [Route("{idUserDeleted:int}")]
        //[Authorize]
        public IActionResult Delete(int idUserDeleted)
        {
            try
            {
                return Ok(_logic.Delete(idUserDeleted));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
