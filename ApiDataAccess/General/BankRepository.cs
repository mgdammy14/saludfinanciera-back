using System;
using ApiModel.General;
using ApiRepositories.General;

namespace ApiDataAccess.General
{
    public class BankRepository : Repository<Bank> , IBankRepository
    {
        public BankRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
