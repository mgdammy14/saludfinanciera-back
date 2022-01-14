using System;
using ApiDataAccess.General;
using ApiModel.Prestamos;
using ApiRepositories.Prestamos;

namespace ApiDataAccess.Prestamos
{
    public class PaymentScheduleRepository : Repository<PaymentSchedule> , IPaymentScheduleRepository
    {
        public PaymentScheduleRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
