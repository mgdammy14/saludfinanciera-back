using System;
using ApiDataAccess.General;
using ApiModel.Prestamos;
using ApiRepositories.Prestamos;

namespace ApiDataAccess.Prestamos
{
    public class LoanRepository : Repository<Loan> , ILoanRepository
    {
        public LoanRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
