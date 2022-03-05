using System;
using ApiModel.Inversiones;
using ApiRepositories.General;

namespace ApiRepositories.Inversiones
{
    public interface IInvestmentRepository : IRepository<Investment>
    {
    }
}
