using System;
using ApiModel.RequestDTO;
using ApiModel.ResponseDTO;

namespace ApiBusinessModel.Interfaces.General
{
    public interface ILoginLogic
    {
        public LoginResponseDTO Login(LoginRequestDTO dto);
    }
}
