using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiModel.Prestamos;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Prestamos
{
    public class LoanAmountLogic : ILoanAmountLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoanAmountLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<LoanAmount> GetList()
        {
            try
            {
                return _unitOfWork.ILoanAmount.GetList().ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Insert(LoanAmount dto)
        {
            try
            {
                return _unitOfWork.ILoanAmount.Insert(dto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(LoanAmount dto)
        {
            try
            {
                return _unitOfWork.ILoanAmount.Update(dto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
