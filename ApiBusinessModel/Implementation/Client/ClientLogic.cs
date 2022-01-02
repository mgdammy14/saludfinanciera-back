using System;
using ApiBusinessModel.Interfaces.Client;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Client
{
    public class ClientLogic : IClientLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ClientResponseDTO Insert(ClientRequestDTO dto)
        {
            try
            {

                ClientResponseDTO response = new ClientResponseDTO();
                ApiModel.ClientModel.Client obj = new ApiModel.ClientModel.Client();
                dto.idClient = _unitOfWork.IClient.Insert(obj.Mapper(obj, dto));
                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
