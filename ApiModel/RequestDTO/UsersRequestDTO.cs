using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO
{
    public class UsersRequestDTO
    {
        [Key]
        public int idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int idRol { get; set; }
    }
}
