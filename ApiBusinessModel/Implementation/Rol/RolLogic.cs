using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.Rol;
using ApiModel.RequestDTO.Rol;
using ApiModel.ResponseDTO.Rol;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Rol
{
    public class RolLogic : IRolLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Insert(RolRequestDTO dto)
        {
            try
            {
                ApiModel.Rol.Rol obj = new ApiModel.Rol.Rol();
                return _unitOfWork.IRol.Insert(obj.Mapper(obj, dto));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(RolRequestDTO dto)
        {
            try
            {
                ApiModel.Rol.Rol obj = new ApiModel.Rol.Rol();
                return _unitOfWork.IRol.Update(obj.Mapper(obj, dto));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int idRolRequest)
        {
            try
            {
                ApiModel.Rol.Rol obj = new ApiModel.Rol.Rol();
                obj.idRol = idRolRequest;
                return _unitOfWork.IRol.Delete(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<RolResponseDTO> GetRolWithPermissions()
        {
            try
            {
                var rolList = _unitOfWork.IRol.GetRolList();
                foreach(var item in rolList)
                {
                    item.permissionList = _unitOfWork.IUrl.GetUrlsByIdRol(item.idRol);
                }
                return rolList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
