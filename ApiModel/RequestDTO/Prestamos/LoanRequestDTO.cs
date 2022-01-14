using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Prestamos
{
    public class LoanRequestDTO
    {
        [Key]
        public int idLoan { get; set; }
        public string loanName { get; set; }
        public decimal capital { get; set; }
        public int idAmortization { get; set; }
        public decimal percentage { get; set; }
        public decimal guaranteeAmount { get; set; }
        public int idGuaranteeState { get; set; }
        public int idLoanState { get; set; }
        public DateTime startpaymentDate { get; set; }
    }
}
