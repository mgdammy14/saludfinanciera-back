using System;
using System.Collections.Generic;
using ApiModel.Inversiones;

namespace ApiBusinessModel.Interfaces.Inversiones
{
    public interface IInvestmentLogic
    {
        public List<Investment> GetList();
        public int Insert(Investment obj);
        public bool Update(Investment obj);
        public bool Delete(int idInvestmentDeleted);
    }
}
