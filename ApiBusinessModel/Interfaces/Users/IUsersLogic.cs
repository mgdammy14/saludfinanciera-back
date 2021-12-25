using System;
using System.Collections.Generic;
using ApiModel.RequestDTO;

namespace ApiBusinessModel.Interfaces.Users
{
    public interface IUsersLogic
    {
        public IEnumerable<ApiModel.Users.Users> GetUsers();
        public int Insert(UsersRequestDTO dto);
        public bool Update(UsersRequestDTO dto);
        public bool Delete(int idUserDeleted);
    }
}
