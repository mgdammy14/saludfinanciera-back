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

        public IEnumerable<ApiModel.PermissionModel.Permission> GetList()
        {
            try
            {
                return _unitOfWork.IPermission.GetList();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public int Insert(PermissionRequestDTO dto)
        {
            try
            {
                ApiModel.PermissionModel.Permission obj = new ApiModel.PermissionModel.Permission();
                return _unitOfWork.IPermission.Insert(obj.Mapper(obj, dto));
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool Update(PermissionRequestDTO dto)
        {
            try
            {
                ApiModel.PermissionModel.Permission obj = new ApiModel.PermissionModel.Permission();
                return _unitOfWork.IPermission.Update(obj.Mapper(obj, dto));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Delete(int idPermissionDeleted)
        {
            try
            {
                ApiModel.PermissionModel.Permission obj = new ApiModel.PermissionModel.Permission();
                obj.idPermission = idPermissionDeleted;
                return _unitOfWork.IPermission.Delete(obj);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
