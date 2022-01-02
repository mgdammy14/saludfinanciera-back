using System;
using ApiModel.RequestDTO;
using ApiModel.ResponseDTO;
using ApiModel.ResponseDTO.General;

namespace ApiBusinessModel.Interfaces.General
{
    public interface ILoginLogic
    {
        public TokenResponseDTO Login(LoginRequestDTO dto);
        public LoginResponseDTO GetToken(string Authorization);
    }
}
