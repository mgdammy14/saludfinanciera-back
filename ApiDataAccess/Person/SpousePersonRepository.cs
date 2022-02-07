using System;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiRepositories.Person;
using Dapper;

namespace ApiDataAccess.Person
{
    public class SpousePersonRepository : Repository<SpousePerson> , ISpousePersonRepository
    {
        public SpousePersonRepository(string connectionsString) : base(connectionsString)
        {
        }

        public SpousePerson GetSpousePerson(int idPerson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);
            var sql = @"select * from SpousePerson
                        where idClient = @idPerson";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<SpousePerson>(
                     sql, parameters
                )).FirstOrDefault();
            }
        }
    }
}
