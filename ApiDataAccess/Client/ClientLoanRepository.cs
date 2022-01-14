using System;
using System.Data.SqlClient;
using ApiDataAccess.General;
using ApiModel.ClientModel;
using ApiRepositories.Client;
using Dapper;

namespace ApiDataAccess.Client
{
    public class ClientLoanRepository : Repository<ClientLoan> , IClientLoanRepository
    {
        public ClientLoanRepository(string connectionsString) : base(connectionsString)
        {
        }

        public int DeleteClientLoanRegister(int idClient)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idClient", idClient);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    "DeleteClientLoanRegister", parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }
    }
}
