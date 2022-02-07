using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiModel.General;
using ApiRepositories.General;
using Dapper;

namespace ApiDataAccess.General
{
    public class HistoricalSentinelReportRepository : Repository<HistoricalSentinelReport> , IHistoricalSentinelReportRepository
    {
        public HistoricalSentinelReportRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<HistoricalSentinelReport> GetHistoricalSentinelReport(int idClient)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idClient", idClient);
            var sql = @"select * from HistoricalSentinelReport
                        where idClient = @idClient";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<HistoricalSentinelReport>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
