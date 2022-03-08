using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiBusinessModel.Interfaces.General;
using ApiModel.ResponseDTO.General;
using ApiUnitOfWork.General;
using static ApiModel.ResponseDTO.General.DashboardResponse;

namespace ApiBusinessModel.Implementation.General
{
    public class DashboardLogic : IDashboardLogic
    {
        private IUnitOfWork _unitOfWork;

        public DashboardLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DashboardResponse Dashboard()
        {
            try
            {
                DashboardResponse response = new DashboardResponse();

                var userActiveRes = _unitOfWork.IPerson.GetClientList();
                var clientInLoanRes = _unitOfWork.IClientLoan.GetList().ToList();
                var userInactiveRes = _unitOfWork.IPerson.GetClientInactiveList();
                var loanRes = _unitOfWork.ILoan.GetList().ToList();
                decimal suma = loanRes.Sum(item => item.capital);

                List<UserSummary> userSumary = new List<UserSummary>();

                DateTimeFormatInfo formatoFecha = CultureInfo.CreateSpecificCulture("es-ES").DateTimeFormat;

                for (var i = 1; i <= 12; i++ )
                {
                    UserSummary userSumaryToAdd = new UserSummary();
                    userSumaryToAdd.idMonth = i;
                    userSumaryToAdd.month = formatoFecha.GetMonthName(i);
                    userSumary.Add(userSumaryToAdd);
                }

                var currentYear = DateTime.Now.Year;
                foreach(var item in userSumary)
                {
                    item.quantity = _unitOfWork.IPerson.GetClientListByMonthAndYear(item.idMonth, currentYear).Count;
                }

                response.userActive = userActiveRes.Count;
                response.userInLoans = clientInLoanRes.Count;
                response.userOutLoans = response.userActive - response.userInLoans;
                response.userInactive = userInactiveRes.Count;
                response.userSummaries = userSumary;

                response.amountDisbursed = suma;


                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
