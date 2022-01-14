using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiRepositories.Client;
using Dapper;

namespace ApiDataAccess.Client
{
    public class ClientRepository : Repository<ApiModel.ClientModel.Client> , IClientRepository
    {
        public ClientRepository(string connectionsString) : base(connectionsString)
        {
        }

        public int ChangeClientState(int idClient, int idClientState)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idClient", idClient);
            parameters.Add("@idClientState", idClientState);
            string sql = @"UPDATE Client
                            SET idClientState = @idClientState 
                            WHERE idClient = @idClient";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    sql, parameters
                );
            }
        }

        public List<ApiModel.ClientModel.Client> GetClientsByIdLoan(int idLoan)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idLoan", idLoan);
            var sql = @"select C.* from Client C
                        inner join ClientLoan CL ON C.idClient = CL.idClient
                        where CL.idLoan = @idLoan";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<ApiModel.ClientModel.Client>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
