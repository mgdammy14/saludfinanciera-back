using System;
using ApiModel.Person;
using ApiRepositories.General;

namespace ApiRepositories.Client
{
    public interface IClientLoanRepository : IRepository<ClientLoan>
    {
        public int DeleteClientLoanRegister(int idClient, int idLoan);
    }
}
