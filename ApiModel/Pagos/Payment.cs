using System;
using ApiModel.RequestDTO.Pagos;
using Dapper.Contrib.Extensions;

namespace ApiModel.Pagos
{
    public class Payment
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

        public Payment Mapper(Payment obj, PaymentRequestDTO dto)
        {
            obj.idPayment = dto.idPayment;
            obj.idLoan = dto.idLoan;
            obj.paymentDate = dto.paymentDate;
            obj.grupalFee = dto.grupalFee;
            obj.paymentState = dto.paymentState;
            obj.operationNumber = dto.operationNumber;
            obj.depositor = dto.depositor;
            obj.canal = dto.canal;
            obj.payConstancy = dto.payConstancy;
            obj.paymentObservation = dto.paymentObservation;
            return obj;
        }
    }
}
