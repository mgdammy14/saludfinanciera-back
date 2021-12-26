using System;
namespace ApiModel.ResponseDTO
{
    public class LoginResponseDTO
    {
        public ApiModel.Users.Users user { get; set; }
        public ApiModel.Rol.Rol rol { get; set; }
        public string Token { get; set; }
    }
}
