using System;
using ApiModel.PermissionModel;
using ApiRepositories.General;

namespace ApiRepositories.PermissionRepository
{
    public interface IPermissionRepository : IRepository<Permission>
    {
    }
}
