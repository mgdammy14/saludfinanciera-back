using System;
using System.Collections.Generic;
using ApiModel.Prestamos;

namespace ApiModel.ResponseDTO.Prestamos
{
    public class PaymentScheduleResponse
    {
        public int idLoanAmount { get; set; }
        public List<PaymentSchedule> paymentSchedule { get; set; }
    }
}
