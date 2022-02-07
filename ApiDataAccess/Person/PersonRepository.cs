using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.Person;
using ApiModel.ResponseDTO.Person;
using ApiRepositories.Person;
using Dapper;

namespace ApiDataAccess.Person
{
    public class PersonRepository : Repository<ApiModel.Person.Person> , IPersonRepository
    {
        public PersonRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<PersonResponse> GetClientList()
        {
            var sql = @"select * from Person
                        where idPersonType = 1";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PersonResponse>(
                     sql
                )).ToList();
            }
        }

        public int ChangePersonState(int idPerson, int idPersonState)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);
            parameters.Add("@idPersonState", idPersonState);
            string sql = @"UPDATE Person
                            SET idPersonState = @idPersonState 
                            WHERE idPerson = @idPerson";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute(
                    sql, parameters
                );
            }
        }

        public PersonResponse CheckPersonByDocumentNumber(string documentNumber)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@documentNumber", documentNumber);
            var sql = @"select * from Person where documentNumber = @documentNumber and idPersonType = 1";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PersonResponse>(
                     sql, parameters
                )).FirstOrDefault();
            }
        }

        public Reference GetReference(int idPerson)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idPerson", idPerson);

            var sql = @"select * from Person
                       where idPerson = @idPerson";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<Reference>(
                     sql, parameters
                )).FirstOrDefault();
            }
        }

        public List<PersonResponse> GetClientsByIdLoan(int idLoan)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idLoan", idLoan);
            var sql = @"select P.*, CL.*, LA.amount from Person P
                        inner join ClientLoan CL ON P.idPerson = CL.idClient
                        inner join LoanAmount LA ON LA.idLoanAmount = CL.idLoanAmount
                        where CL.idLoan = @idLoan";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<PersonResponse>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
