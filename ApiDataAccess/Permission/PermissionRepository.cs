using System;
using System.Data;
using System.Data.SqlClient;
using ApiDataAccess.General;
using ApiRepositories.PermissionRepository;
using Dapper;

namespace ApiDataAccess.Permission
{
    public class PermissionRepository : Repository<ApiModel.PermissionModel.Permission> , IPermissionRepository
    {
        public PermissionRepository(string connectionsString) : base(connectionsString)
        {
        }

        public int DeleteAllPermissionByIdRol(int idRol)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string sql = "DELETE FROM Permission WHERE idRol = @idRol";

                var parameters = new DynamicParameters();
                parameters.Add("@idRol", idRol, DbType.Int32);

                return connection.Execute(
                       sql, param: parameters, commandType: CommandType.Text);
            }
        }
    }
}
