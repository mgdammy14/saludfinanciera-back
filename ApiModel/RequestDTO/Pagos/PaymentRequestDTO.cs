using System;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;

namespace ApiModel.RequestDTO.Pagos
{
    public class PaymentRequestDTO
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
        public IFormFile files { get; set; }
    }
}
