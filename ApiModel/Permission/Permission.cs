using System;
using ApiModel.RequestDTO.PermissionRequest;
using Dapper.Contrib.Extensions;

namespace ApiModel.PermissionModel
{
    public class Permission
    {
        [Key]
        public int idPermission { get; set; }
        public int idRol { get; set; }
        public int idUrl { get; set; }

        public Permission Mapper(Permission obj, PermissionRequestDTO dto)
        {
            obj.idPermission = dto.idPermission;
            obj.idRol = dto.idRol;
            obj.idUrl = dto.idUrl;
            return obj;
        }
    }
}
