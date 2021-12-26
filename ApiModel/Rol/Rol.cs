using System;
using ApiModel.RequestDTO.Rol;
using Dapper.Contrib.Extensions;

namespace ApiModel.Rol
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        public string rolName { get; set; }
        public string rolDescription { get; set; }

        public Rol Mapper(Rol obj, RolRequestDTO dto)
        {
            obj.idRol = dto.idRol;
            obj.rolName = dto.rolName;
            obj.rolDescription = dto.rolDescription;

            return obj;
        }
    }
}
