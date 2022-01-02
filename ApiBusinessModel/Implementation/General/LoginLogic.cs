using System;
using System.Security.Claims;
using System.Text;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO;
using ApiModel.ResponseDTO;
using ApiUnitOfWork.General;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ApiModel.ResponseDTO.General;
using System.Linq;

namespace ApiBusinessModel.Implementation.General
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptLogic _encryptLogic;

        public LoginLogic(IUnitOfWork unitOfWork, IEncryptLogic encryptLogic)
        {
            _unitOfWork = unitOfWork;
            _encryptLogic = encryptLogic;
        }

        public TokenResponseDTO Login(LoginRequestDTO dto)
        {
            try
            {
                TokenResponseDTO response = new TokenResponseDTO();

                //Validamos si existe el usuario
                var validateUser = _unitOfWork.IUsers.ValidateUsername(dto.username);

                if (validateUser != null)
                {
                    //des encriptamos la contraseña
                    var comparePassword = _encryptLogic.Decrypt(validateUser.password);
                    //Validamos la contraseña
                    if (comparePassword == dto.password)
                    {
                        var secretKey = "ga7586mag07g11a9a8g1m6y0s6s9l9c";
                        var key = Encoding.ASCII.GetBytes(secretKey);

                        var claims = new ClaimsIdentity();
                        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, dto.username));

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = claims,
                            Expires = DateTime.UtcNow.AddHours(4),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                            
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                        string bearer_token = tokenHandler.WriteToken(createdToken);

                        response.Token = bearer_token;
                    }
                    else
                    {
                        response.Token = "Contraseña incorrecta";
                    }
                }

                else
                {
                    response.Token = "Usuario invalido";
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public LoginResponseDTO GetToken(string Authorization)
        {
            try
            {
                LoginResponseDTO response = new LoginResponseDTO();
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = Authorization.Split(' ')[1];
                var readJwtToken = tokenHandler.ReadJwtToken(token);
                var username = readJwtToken.Claims.First(claim => claim.Type == "nameid").Value;

                response.user = _unitOfWork.IUsers.ValidateUsername(username);
                response.rol = _unitOfWork.IRol.GetRolResponseById(response.user.idRol);
                response.rol.permissionList = _unitOfWork.IUrl.GetUrlsByIdRol(response.user.idRol);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
