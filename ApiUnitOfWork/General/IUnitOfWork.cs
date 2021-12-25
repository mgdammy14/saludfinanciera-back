using ApiRepositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUnitOfWork.General
{
    public interface IUnitOfWork
    {
        public IUsersRepository IUsers { get; set; }
    }
}
