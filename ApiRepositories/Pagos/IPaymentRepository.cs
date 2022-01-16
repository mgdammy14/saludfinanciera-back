using System;
using System.Collections.Generic;
using ApiModel.Pagos;
using ApiModel.ResponseDTO.Pagos;
using ApiRepositories.General;

namespace ApiRepositories.Pagos
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        public List<PaymentResponse> GetPaymentsByIdLoan(int idLoan);
    }
}
