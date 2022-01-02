using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Rol;
using ApiModel.UrlModel;

namespace ApiModel.ResponseDTO.Rol
{
    public class RolResponseDTO
    {
        public int idRol { get; set; }
        public string rolName { get; set; }
        public string rolDescription { get; set; }

        public List<Url> permissionList { get; set; }

        public RolResponseDTO Mapper(RolResponseDTO obj , RolRequestDTO dto)
        {
            obj.idRol = dto.idRol;
            obj.rolName = dto.rolName;
            obj.rolDescription = dto.rolDescription;

            return obj;
        }
    }
}
