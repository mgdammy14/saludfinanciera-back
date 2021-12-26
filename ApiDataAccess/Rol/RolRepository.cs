using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ApiDataAccess.General;
using ApiModel.ResponseDTO.Rol;
using ApiRepositories.Rol;
using Dapper;

namespace ApiDataAccess.Rol
{
    public class RolRepository : Repository<ApiModel.Rol.Rol>, IRolRepository
    {
        public RolRepository(string connectionsString) : base(connectionsString)
        {
        }

        public List<RolResponseDTO> GetRolList()
        {
            var sql = @"SELECT * FROM Rol";

            using (var connection = new SqlConnection(_connectionString))
            {
                return (connection.Query<RolResponseDTO>(
                     sql
                )).ToList();
            }
        }
    }
}
