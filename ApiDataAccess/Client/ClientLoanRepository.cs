using System;
using System.Data.SqlClient;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiRepositories.Client;
using Dapper;

namespace ApiDataAccess.Client
{
    public class ClientLoanRepository : Repository<ClientLoan> , IClientLoanRepository
    {
        public ClientLoanRepository(string connectionsString) : base(connectionsString)
        {
        }

        public int DeleteClientLoanRegister(int idClient, int idLoan)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idClient", idClient);
            parameters.Add("@idLoan", idLoan);
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
