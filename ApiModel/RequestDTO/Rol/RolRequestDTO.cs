using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Rol
{
    public class RolRequestDTO
    {
        [Key]
        public int idRol { get; set; }
        public string rolName { get; set; }
        public string rolDescription { get; set; }
    }
}
