using System;
using System.Collections.Generic;
using ApiRepositories.General;

namespace ApiRepositories.Client
{
    public interface IClientRepository : IRepository<ApiModel.ClientModel.Client>
    {
        public int ChangeClientState(int idClient, int idClientState);
        public List<ApiModel.ClientModel.Client> GetClientsByIdLoan(int idLoan);
    }
}
