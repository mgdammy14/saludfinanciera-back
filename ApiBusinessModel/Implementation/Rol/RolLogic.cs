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

        public RolResponseDTO Insert(RolRequestDTO dto)
        {
            try
            {
                RolResponseDTO response = new RolResponseDTO();
                ApiModel.Rol.Rol obj = new ApiModel.Rol.Rol();

                dto.idRol = _unitOfWork.IRol.Insert(obj.Mapper(obj, dto));

                //response.idRol = idCreatedRol;
                //response.rolName = dto.rolName;
                //response.rolDescription = dto.rolDescription;
                response = response.Mapper(response, dto);
                response.permissionList = _unitOfWork.IUrl.GetUrlsByIdRol(dto.idRol);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RolResponseDTO Update(RolRequestDTO dto)
        {
            try
            {
                RolResponseDTO response = new RolResponseDTO();
                ApiModel.Rol.Rol obj = new ApiModel.Rol.Rol();

                _unitOfWork.IRol.Update(obj.Mapper(obj, dto));

                response.idRol = dto.idRol;
                response.rolName = dto.rolName;
                response.rolDescription = dto.rolDescription;
                response.permissionList = _unitOfWork.IUrl.GetUrlsByIdRol(dto.idRol);

                return response;
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

        public RolResponseDTO GetRolWithPermissionsByIdRol(int idRol)
        {
            try
            {
                var rolResponse = _unitOfWork.IRol.GetRolResponseById(idRol);
                rolResponse.permissionList = _unitOfWork.IUrl.GetUrlsByIdRol(idRol);
                return rolResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
