using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiRepositories.Person;
using Dapper;

namespace ApiDataAccess.Person
{
    public class PersonReferenceRepository : Repository<PersonReference> , IPersonReferenceRepository
    {
        public PersonReferenceRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<PersonReference> GetPersonReference(int idPerson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);
            var sql = @"select * from PersonReference
                        where idClient = @idPerson";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PersonReference>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
