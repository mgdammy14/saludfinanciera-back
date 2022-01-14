using System;
using System.Collections.Generic;
using ApiModel.Prestamos;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Prestamos
{
    public class LoanResponseDTO
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

        public LoanResponseDTO Mapper(LoanResponseDTO obj, LoanRequestDTO dto)
        {
            obj.idLoan = dto.idLoan;
            obj.loanName = dto.loanName;
            obj.capital = dto.capital;
            obj.idAmortization = dto.idAmortization;
            obj.percentage = dto.percentage;
            obj.guaranteeAmount = dto.guaranteeAmount;
            obj.idGuaranteeState = dto.idGuaranteeState;
            obj.idLoanState = dto.idLoanState;
            obj.startpaymentDate = dto.startpaymentDate;
            return obj;
        }
    }
}
