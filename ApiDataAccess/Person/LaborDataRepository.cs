using System;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiRepositories.Person;
using Dapper;

namespace ApiDataAccess.Person
{
    public class LaborDataRepository : Repository<LaborData> , ILaborDataRepository
    {
        public LaborDataRepository(string connectionsString) : base(connectionsString)
        {
        }

        public LaborData GetLaborDataByIdPerson(int idPerson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);
            var sql = @"select * from LaborData
                        where idPerson = @idPerson";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<LaborData>(
                     sql, parameters
                )).FirstOrDefault();
            }
        }
    }
}
