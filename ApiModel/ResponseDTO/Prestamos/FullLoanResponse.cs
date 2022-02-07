using System;
using System.Collections.Generic;
using ApiModel.Prestamos;
using ApiModel.ResponseDTO.Client;
using ApiModel.ResponseDTO.Person;

namespace ApiModel.ResponseDTO.Prestamos
{
    public class FullLoanResponse
    {
        public List<PersonResponse> clientList { get; set; }
        public Amortization amortization { get; set; }
        public List<PaymentSchedule>? paymentSchedule { get; set; }
    }
}
