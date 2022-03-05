using System;
using ApiDataAccess.General;
using ApiModel.Inversiones;
using ApiRepositories.Inversiones;

namespace ApiDataAccess.Inversiones
{
    public class InvestmentRepository : Repository<Investment>, IInvestmentRepository
    {
        public InvestmentRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
