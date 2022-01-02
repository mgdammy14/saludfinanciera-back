using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.PermissionRequest;

namespace ApiBusinessModel.Interfaces.Permission
{
    public interface IPermissionLogic
    {
        public int AddPermissions(List<PermissionRequestDTO> dto);
    }
}
