using System;
using System.Collections.Generic;
using ApiModel.ResponseDTO.Rol;
using ApiRepositories.General;

namespace ApiRepositories.Rol
{
    public interface IRolRepository : IRepository<ApiModel.Rol.Rol>
    {
        public List<RolResponseDTO> GetRolList();
        public RolResponseDTO GetRolResponseById(int idRol);
    }
}
