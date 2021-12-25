using System;
using System.Data.SqlClient;
using ApiDataAccess.General;
using ApiRepositories.Users;
using Dapper;

namespace ApiDataAccess.Users
{
    public class UsersRepository : Repository<ApiModel.Users.Users>, IUsersRepository
    {
        public UsersRepository(string connectionsString) : base(connectionsString)
        {
        }

        public ApiModel.Users.Users ValidateUsername(string username)
        {
            var parameters = new DynamicParameters(new
            {
                p_username = username
            });
            string sql = "SELECT * FROM Users WHERE username = @p_username ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<ApiModel.Users.Users>(
                    sql, parameters);
            }
        }

    }
}
