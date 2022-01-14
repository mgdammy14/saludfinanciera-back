using System;
using System.Collections.Generic;
using ApiModel.Prestamos;
using ApiModel.RequestDTO.Prestamos;

namespace ApiBusinessModel.Interfaces.Prestamos
{
    public interface IPaymentScheduleLogic
    {
        public int Insert(PaymentSchedule dto);
        public IEnumerable<PaymentSchedule> GetList();
        public List<PaymentSchedule> CreatePaymentSchedule(CreateScheduleRequestDTO dto);
    }
}
