using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Rol;
using ApiModel.ResponseDTO.Rol;

namespace ApiBusinessModel.Interfaces.Rol
{
    public interface IRolLogic
    {
        public RolResponseDTO Insert(RolRequestDTO dto);
        public RolResponseDTO Update(RolRequestDTO dto);
        public bool Delete(int idRolRequest);
        public List<RolResponseDTO> GetRolWithPermissions();
        public RolResponseDTO GetRolWithPermissionsByIdRol(int idRol);
    }
}
