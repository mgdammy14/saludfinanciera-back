using System;
using System.Collections.Generic;
using ApiModel.Prestamos;

namespace ApiBusinessModel.Interfaces.Prestamos
{
    public interface ILoanAmountLogic
    {
        public List<LoanAmount> GetList();
        public int Insert(LoanAmount dto);
        public bool Update(LoanAmount dto);
    }
}
