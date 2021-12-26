using System;
using System.Collections.Generic;
using ApiModel.RequestDTO.Rol;
using ApiModel.ResponseDTO.Rol;

namespace ApiBusinessModel.Interfaces.Rol
{
    public interface IRolLogic
    {
        public int Insert(RolRequestDTO dto);
        public bool Update(RolRequestDTO dto);
        public bool Delete(int idRolRequest);
        public List<RolResponseDTO> GetRolWithPermissions();
    }
}
