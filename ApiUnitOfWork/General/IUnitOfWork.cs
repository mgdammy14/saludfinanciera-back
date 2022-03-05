using ApiRepositories.Client;
using ApiRepositories.General;
using ApiRepositories.Inversiones;
using ApiRepositories.Mensajes;
using ApiRepositories.Pagos;
using ApiRepositories.PermissionRepository;
using ApiRepositories.Person;
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
        public ILoanRepository ILoan { get; set; }
        public IAmortizationRepository IAmortization { get; set; }
        public IPaymentScheduleRepository IPaymentSchedule { get; set; }
        public IClientLoanRepository IClientLoan { get; set; }
        public IPaymentRepository IPayment { get; set; }
        public IMessageRepository IMessage { get; set; }
        public IHistoricalSentinelReportRepository IHistoricalSentinelReport { get; set; }
        public IBankRepository IBank { get; set; }
        public ILoanAmountRepository ILoanAmount { get; set; }
        public IPersonRepository IPerson { get; set; }
        public IPersonExtraDataRepository IPersonExtraData { get; set; }
        public ILaborDataRepository ILaborData { get; set; }
        public ISpousePersonRepository ISpousePerson { get; set; }
        public IPersonReferenceRepository IPersonReference { get; set; }
        public IInvestmentRepository IInvestment { get; set; }
    }
}
