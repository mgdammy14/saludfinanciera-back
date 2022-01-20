using System;
using ApiDataAccess.General;
using ApiModel.Prestamos;
using ApiRepositories.Prestamos;

namespace ApiDataAccess.Prestamos
{
    public class LoanAmountRepository : Repository<LoanAmount> , ILoanAmountRepository
    {
        public LoanAmountRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
