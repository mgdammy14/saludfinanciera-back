using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;

namespace ApiBusinessModel.Interfaces.Client
{
    public interface IClientLogic
    {
        public ClientResponseDTO Insert(ClientRequestDTO dto);
        public ClientResponseDTO Update(ClientRequestDTO dto);
        public IEnumerable<ApiModel.ClientModel.Client> GetList();
        public int ChangeClientState(int idClient);
        public int AddToLoan(ClientLoanRequestDTO dto);
        public int AddToLoanList(List<ClientLoanRequestDTO> dtoList);
    }
}
