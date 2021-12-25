using System;
using ApiRepositories.General;

namespace ApiRepositories.Users
{
    public interface IUsersRepository : IRepository<ApiModel.Users.Users>
    {
        public ApiModel.Users.Users ValidateUsername(string username);
    }
}
