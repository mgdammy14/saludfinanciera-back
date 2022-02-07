using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiModel.RequestDTO.Pagos;
using ApiModel.ResponseDTO.Pagos;
using Microsoft.AspNetCore.Http;

namespace ApiBusinessModel.Interfaces.Pagos
{
    public interface IPaymentLogic
    {
        public PaymentResponse Insert(PaymentRequestDTO dto);
        public List<PaymentResponse> GetPaymentsByLoan(int idLoan);
        public PaymentResponse Update(PaymentRequestDTO dto);
    }
}
