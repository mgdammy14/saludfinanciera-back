using ApiDataAccess.Client;
using ApiDataAccess.Permission;
using ApiDataAccess.Prestamos;
using ApiDataAccess.Rol;
using ApiDataAccess.Url;
using ApiDataAccess.Users;
using ApiRepositories.Client;
using ApiRepositories.PermissionRepository;
using ApiRepositories.Prestamos;
using ApiRepositories.Rol;
using ApiRepositories.UrlRepository;
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
        public IRolRepository IRol { get; set; }
        public IUrlRepository IUrl { get; set; }
        public IPermissionRepository IPermission { get; set; }
        public IClientRepository IClient { get; set; }
        public ILoanRepository ILoan { get; set; }
        public IAmortizationRepository IAmortization { get; set; }
        public IPaymentScheduleRepository IPaymentSchedule { get; set; }
        public IClientLoanRepository IClientLoan { get; set; }

        public UnitOfWork(string connectionString)
        {
            IUsers = new UsersRepository(connectionString);
            IRol = new RolRepository(connectionString);
            IUrl = new UrlRepository(connectionString);
            IPermission = new PermissionRepository(connectionString);
            IClient = new ClientRepository(connectionString);
            ILoan = new LoanRepository(connectionString);
            IAmortization = new AmortizationRepository(connectionString);
            IPaymentSchedule = new PaymentScheduleRepository(connectionString);
            IClientLoan = new ClientLoanRepository(connectionString);
        }
    }
}
