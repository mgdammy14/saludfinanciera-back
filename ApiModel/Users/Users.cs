using System;
using ApiModel.RequestDTO;
using Dapper.Contrib.Extensions;

namespace ApiModel.Users
{
    public class Users
    {
        [Key]
        public int idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int idRol { get; set; }

        public Users Mapper(Users obj, UsersRequestDTO dto)
        {
            obj.idUser = dto.idUser;
            obj.name = dto.name;
            obj.lastname = dto.lastname;
            obj.username = dto.username;
            obj.password = dto.password;
            obj.idRol = dto.idRol;

            return obj;
        }
    }
}
