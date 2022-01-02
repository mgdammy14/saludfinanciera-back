using System;
using ApiDataAccess.General;
using ApiRepositories.Client;

namespace ApiDataAccess.Client
{
    public class ClientRepository : Repository<ApiModel.ClientModel.Client> , IClientRepository
    {
        public ClientRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
