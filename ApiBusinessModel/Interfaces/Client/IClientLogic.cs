using System;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;

namespace ApiBusinessModel.Interfaces.Client
{
    public interface IClientLogic
    {
        public ClientResponseDTO Insert(ClientRequestDTO dto);
    }
}
