using System;
using System.Collections.Generic;
using ApiModel.Prestamos;
using ApiModel.RequestDTO.Prestamos;
using ApiModel.ResponseDTO.Prestamos;

namespace ApiBusinessModel.Interfaces.Prestamos
{
    public interface ILoanLogic
    {
        public LoanResponseDTO Insert(LoanRequestDTO dto);
        public LoanResponseDTO Update(LoanRequestDTO dto);
        public IEnumerable<Loan> GetList();
        public FullLoanResponse FullLoanResponse(int idLoan);
    }
}
