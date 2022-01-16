using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Pagos;
using ApiModel.ResponseDTO.Pagos;
using ApiRepositories.Pagos;
using Dapper;

namespace ApiDataAccess.Pagos
{
    public class PaymentRepository : Repository<Payment> , IPaymentRepository
    {
        public PaymentRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<PaymentResponse> GetPaymentsByIdLoan(int idLoan)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idLoan", idLoan);
            var sql = @"select * from Payment where idLoan = @idLoan";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PaymentResponse>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
