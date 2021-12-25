using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_Factura.Controllers.Login
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IEncryptLogic _encryptLogic;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration, IEncryptLogic encryptLogic)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _encryptLogic = encryptLogic;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            try
            {
                string token = "";

                //Validamos si existe el usuario
                var validateUser = _unitOfWork.IUsers.ValidateUsername(dto.username);

                if (validateUser != null)
                {
                    //des encriptamos la contraseña
                    var comparePassword = _encryptLogic.Decrypt(validateUser.password);
                    //Validamos la contraseña
                    if (comparePassword == dto.password)
                    {
                        var secretKey = _configuration.GetValue<string>("SecretKey");
                        var key = Encoding.ASCII.GetBytes(secretKey);

                        var claims = new ClaimsIdentity();
                        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, dto.username));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = claims,
                            Expires = DateTime.UtcNow.AddHours(4),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                        string bearer_token = tokenHandler.WriteToken(createdToken);

                        token = bearer_token;
                    }
                    else
                    {
                        token = "La contraseña es incorrecta";
                    }
                }

                else
                {
                    token = "El usuario no existe";
                }

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
