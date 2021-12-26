using System;
using System.Collections.Generic;
using ApiModel.UrlModel;

namespace ApiModel.ResponseDTO.Rol
{
    public class RolResponseDTO
    {
        public int idRol { get; set; }
        public string rolName { get; set; }
        public string rolDescription { get; set; }

        public List<Url> permissionList { get; set; }
    }
}
