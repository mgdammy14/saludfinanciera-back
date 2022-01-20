using System;
using System.Collections.Generic;
using ApiModel.Prestamos;
using ApiRepositories.General;

namespace ApiRepositories.Prestamos
{
    public interface IPaymentScheduleRepository : IRepository<PaymentSchedule>
    {
        public List<PaymentSchedule> GetScheduleByIdLoanAmount(int idLoanAmount);
    }
}
