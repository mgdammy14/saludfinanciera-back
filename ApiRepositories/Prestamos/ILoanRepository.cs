﻿using System;
using ApiModel.Prestamos;
using ApiRepositories.General;

namespace ApiRepositories.Prestamos
{
    public interface ILoanRepository : IRepository<Loan>
    {
    }
}