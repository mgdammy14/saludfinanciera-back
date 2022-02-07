using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Client;
using ApiModel.ResponseDTO.Person;
using ApiRepositories.Client;
using Dapper;

namespace ApiDataAccess.Client
{
    public class ClientRepository : Repository<ApiModel.ClientModel.Client> , IClientRepository
    {
        public ClientRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<ClientToInsert> GetClientToInsert()
        {
            var sql = @"select idClient, idDocumentType, documentNumber, clientName as name, 
                        clientLastname as lastname, clientDateOfBirth as dateOfBirth, clientPhoneNumber as phoneNumber, 
                        clientAddress as address, idFinancialState from Client";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<ClientToInsert>(
                     sql
                )).ToList();
            }
        }
    }
}
