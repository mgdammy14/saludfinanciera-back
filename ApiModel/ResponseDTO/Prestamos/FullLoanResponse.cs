using System;
using System.Collections.Generic;
using ApiModel.Prestamos;

namespace ApiModel.ResponseDTO.Prestamos
{
    public class FullLoanResponse
    {
        public List<ApiModel.ClientModel.Client> clientList { get; set; }
        public Amortization amortization { get; set; }
        public List<PaymentSchedule>? paymentSchedule { get; set; }
    }
}
