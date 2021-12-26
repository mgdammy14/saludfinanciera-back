using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.PermissionRequest;

namespace ApiBusinessModel.Interfaces.Permission
{
    public interface IPermissionLogic
    {
        public IEnumerable<ApiModel.PermissionModel.Permission> GetList();
        public int Insert(PermissionRequestDTO dto);
        public bool Update(PermissionRequestDTO dto);
        public bool Delete(int idPermissionDeleted);
    }
}
