using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Client;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Client;
using ApiModel.ResponseDTO.Person;

namespace ApiBusinessModel.Interfaces.Client
{
    public interface IClientLogic
    {
        public List<ClientToInsert> ListToInsert();
    }
}
