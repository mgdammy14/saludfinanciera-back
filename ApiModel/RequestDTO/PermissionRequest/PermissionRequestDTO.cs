using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.PermissionRequest
{
    public class PermissionRequestDTO
    {
        [Key]
        public int idPermission { get; set; }
        public int idRol { get; set; }
        public int idUrl { get; set; }
    }
}
