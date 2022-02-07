using System;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiRepositories.Person;
using Dapper;

namespace ApiDataAccess.Person
{
    public class PersonExtraDataRepository : Repository<PersonExtraData> , IPersonExtraDataRepository
    {
        public PersonExtraDataRepository(string connectionsString) : base(connectionsString)
        {
        }

        public PersonExtraData GetPersonExtraDataByIdPerson(int idPerson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);
            var sql = @"select * from PersonExtraData
                        where idPerson = @idPerson";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PersonExtraData>(
                     sql, parameters
                )).FirstOrDefault();
            }
        }
    }
}
