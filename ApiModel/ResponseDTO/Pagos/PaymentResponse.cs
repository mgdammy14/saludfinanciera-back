using System;
using ApiModel.RequestDTO.Pagos;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Pagos
{
    public class PaymentResponse
    {
        [Key]
        public int idPayment { get; set; }
        public int idLoan { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal grupalFee { get; set; }
        public int paymentState { get; set; }
        public string operationNumber { get; set; }
        public string depositor { get; set; }
        public int canal { get; set; }
        public string payConstancy { get; set; }
        public string paymentObservation { get; set; }

        public PaymentResponse Mapper(PaymentResponse res, PaymentRequestDTO dto)
        {
            res.idPayment = dto.idPayment;
            res.idLoan = dto.idLoan;
            res.paymentDate = dto.paymentDate;
            res.grupalFee = dto.grupalFee;
            res.paymentState = dto.paymentState;
            res.operationNumber = dto.operationNumber;
            res.depositor = dto.depositor;
            res.canal = dto.canal;
            res.payConstancy = dto.payConstancy;
            res.paymentObservation = dto.paymentObservation;
            return res;
        }
    }
}
