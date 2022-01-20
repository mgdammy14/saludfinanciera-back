using System;
using System.Collections.Generic;
using ApiModel.ResponseDTO.Client;
using ApiRepositories.General;

namespace ApiRepositories.Client
{
    public interface IClientRepository : IRepository<ApiModel.ClientModel.Client>
    {
        public int ChangeClientState(int idClient, int idClientState);
        public List<ApiModel.ClientModel.Client> GetClientsByIdLoan(int idLoan);
        public List<ClientResponseDTO> GetClientList();
        public ApiModel.ClientModel.Client CheckClientByDocumentNumber(string documentNumber);
    }
}
