using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.Inversiones;
using ApiModel.Inversiones;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Inversiones
{
    public class InvestmentLogic : IInvestmentLogic
    {
        private IUnitOfWork _unitOfWork;

        public InvestmentLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Investment> GetList()
        {
            try
            {
                return _unitOfWork.IInvestment.GetList().ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Insert(Investment obj)
        {
            try
            {
                return _unitOfWork.IInvestment.Insert(obj);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(Investment obj)
        {
            try
            {
                return _unitOfWork.IInvestment.Update(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int idInvestmentDeleted)
        {
            try
            {
                Investment obj = new Investment();
                obj.idInvestment = idInvestmentDeleted;
                return _unitOfWork.IInvestment.Delete(obj);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
