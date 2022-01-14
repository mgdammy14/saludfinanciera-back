using System;
using ApiDataAccess.General;
using ApiModel.Prestamos;
using ApiRepositories.Prestamos;

namespace ApiDataAccess.Prestamos
{
    public class AmortizationRepository : Repository<Amortization> , IAmortizationRepository
    {
        public AmortizationRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
