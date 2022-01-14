using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Prestamos
{
    public class PaymentSchedule
    {
        [Key]
        public int idPaymentSchedule { get; set; }
        public int idGroupPayment { get; set; }
        public int installmentNumber { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal fee { get; set; }
        public decimal capitalRepayment { get; set; }
        public decimal creditLifeInsurance { get; set; }
        public decimal ITF { get; set; }
        public decimal interest { get; set; }
        public decimal principalBalance { get; set; }
    }
}
