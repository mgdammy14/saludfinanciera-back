using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Prestamos;
using ApiRepositories.Prestamos;
using Dapper;

namespace ApiDataAccess.Prestamos
{
    public class PaymentScheduleRepository : Repository<PaymentSchedule> , IPaymentScheduleRepository
    {
        public PaymentScheduleRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<PaymentSchedule> GetScheduleByIdLoanAmount(int idLoanAmount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idLoanAmount", idLoanAmount);
            var sql = @"select * from PaymentSchedule
                        where idLoanAmount = @idLoanAmount
                        order by idPaymentSchedule ASC";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PaymentSchedule>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
