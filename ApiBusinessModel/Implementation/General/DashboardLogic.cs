using System;
using System.Linq;
using ApiBusinessModel.Interfaces.General;
using ApiModel.ResponseDTO.General;
using ApiUnitOfWork.General;

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

                response.userActive = userActiveRes.Count;
                response.userInLoans = clientInLoanRes.Count;
                response.userOutLoans = response.userActive - response.userInLoans;
                response.userInactive = userInactiveRes.Count;

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
