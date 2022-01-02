using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.Permission;
using ApiModel.RequestDTO.PermissionRequest;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Permission
{
    public class PermissionLogic : IPermissionLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddPermissions(List<PermissionRequestDTO> dto)
        {
            try
            {
                //Eliminamos todos los permisos
                _unitOfWork.IPermission.DeleteAllPermissionByIdRol(dto[0].idRol);
                foreach (var item in dto)
                {
                    ApiModel.PermissionModel.Permission obj = new ApiModel.PermissionModel.Permission();
                    _unitOfWork.IPermission.Insert(obj.Mapper(obj, item));
                }
                return 1;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
