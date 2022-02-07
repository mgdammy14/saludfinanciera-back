using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Client;
using ApiModel.ResponseDTO.Person;
using ApiRepositories.General;

namespace ApiRepositories.Client
{
    public interface IClientRepository : IRepository<ApiModel.ClientModel.Client>
    {
        public List<ClientToInsert> GetClientToInsert();
    }
}
