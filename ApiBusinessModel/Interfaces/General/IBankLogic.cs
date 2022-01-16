using System;
using System.Collections.Generic;
using ApiModel.General;

namespace ApiBusinessModel.Interfaces.General
{
    public interface IBankLogic
    {
        public int Insert(Bank obj);
        public List<Bank> GetList();
    }
}
