using ApiDataAccess.Users;
using ApiRepositories.Users;
using ApiUnitOfWork.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDataAccess.General
{
    public class UnitOfWork: IUnitOfWork
    {
        public IUsersRepository IUsers { get; set; }

        public UnitOfWork(string connectionString)
        {
            IUsers = new UsersRepository(connectionString);
        }
    }
}
