using System;
using ApiDataAccess.General;
using ApiRepositories.PermissionRepository;

namespace ApiDataAccess.Permission
{
    public class PermissionRepository : Repository<ApiModel.PermissionModel.Permission> , IPermissionRepository
    {
        public PermissionRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
