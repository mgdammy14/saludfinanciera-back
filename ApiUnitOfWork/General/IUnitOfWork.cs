using ApiRepositories.Client;
using ApiRepositories.PermissionRepository;
using ApiRepositories.Prestamos;
using ApiRepositories.Rol;
using ApiRepositories.UrlRepository;
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
        public IRolRepository IRol { get; set; }
        public IUrlRepository IUrl { get; set; }
        public IPermissionRepository IPermission { get; set; }
        public IClientRepository IClient { get; set; }
        public ILoanRepository ILoan { get; set; }
        public IAmortizationRepository IAmortization { get; set; }
        public IPaymentScheduleRepository IPaymentSchedule { get; set; }
        public IClientLoanRepository IClientLoan { get; set; }
    }
}
