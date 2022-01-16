using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.General;
using ApiModel.General;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.General
{
    public class BankLogic : IBankLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Insert(Bank obj)
        {
            try
            {
                return _unitOfWork.IBank.Insert(obj);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Bank> GetList()
        {
            try
            {
                return _unitOfWork.IBank.GetList().ToList();            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
