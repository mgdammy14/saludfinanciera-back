using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiRepositories.UrlRepository;
using Dapper;

namespace ApiDataAccess.Url
{
    public class UrlRepository : Repository<ApiModel.UrlModel.Url>, IUrlRepository
    {
        public UrlRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<ApiModel.UrlModel.Url> GetUrlsByIdRol(int idRol)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@idRol", idRol);
            var sql = @"SELECT U.* FROM Url U
                        INNER JOIN Permission P ON U.idUrl = P.idUrl
                        WHERE P.idRol = @idRol";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<ApiModel.UrlModel.Url>(
                     sql, parameters
                )).ToList();
            }
        }
    }
}
