using System;
using ApiModel.ResponseDTO.Rol;

namespace ApiModel.ResponseDTO
{
    public class LoginResponseDTO
    {
        public ApiModel.Users.Users user { get; set; }
        public RolResponseDTO rol { get; set; }
    }
}
