using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Prestamos
{
    public class LoanAmount
    {
        [Key]
        public int idLoanAmount { get; set; }
        public decimal amount { get; set; }
        public string descriptionLoanAmount { get; set; }
    }
}
