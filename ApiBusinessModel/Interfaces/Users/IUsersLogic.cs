using System;
using System.Collections.Generic;
using ApiModel.RequestDTO;

namespace ApiBusinessModel.Interfaces.Users
{
    public interface IUsersLogic
    {
        public IEnumerable<ApiModel.Users.Users> GetUsers();
        public ApiModel.Users.Users Insert(UsersRequestDTO dto);
        public ApiModel.Users.Users Update(UsersRequestDTO dto);
        public bool Delete(int idUserDeleted);
    }
}
