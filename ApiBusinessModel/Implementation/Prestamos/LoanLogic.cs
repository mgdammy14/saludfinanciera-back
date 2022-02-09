using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiModel.Prestamos;
using ApiModel.RequestDTO.Prestamos;
using ApiModel.ResponseDTO.Prestamos;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Prestamos
{
    public class LoanLogic : ILoanLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentScheduleLogic _paymentScheduleLogic;

        public LoanLogic(IUnitOfWork unitOfWork, IPaymentScheduleLogic paymentScheduleLogic)
        {
            _unitOfWork = unitOfWork;
            _paymentScheduleLogic = paymentScheduleLogic;
        }

        public LoanResponseDTO Insert(LoanRequestDTO dto)
        {
            try
            {
                LoanResponseDTO response = new LoanResponseDTO();
                Loan obj = new Loan();
                dto.idLoan = _unitOfWork.ILoan.Insert(obj.Mapper(obj, dto));
                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public LoanResponseDTO Update(LoanRequestDTO dto)
        {
            try
            {
                LoanResponseDTO response = new LoanResponseDTO();
                Loan obj = new Loan();
                _unitOfWork.ILoan.Update(obj.Mapper(obj, dto));
                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Loan> GetList()
        {
            try
            {
                return _unitOfWork.ILoan.GetList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public FullLoanResponse FullLoanResponse(int idLoan)
        {
            try
            {
                FullLoanResponse response = new FullLoanResponse();

                //Seteamos la amortizacion
                Amortization amortizationResponse = new Amortization();
                amortizationResponse.tea = "137.52%";
                amortizationResponse.tem = "7.48%";
                amortizationResponse.teq = "3.42%";

                response.amortization = amortizationResponse;

                //Traemos a todos los clientes
                var clientListResponse = _unitOfWork.IPerson.GetClientsByIdLoan(idLoan);

                foreach (var item in clientListResponse)
                {

                    int Years(DateTime start, DateTime end)
                    {
                        return (end.Year - start.Year - 1) +
                            (((end.Month > start.Month) ||
                            ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
                    }

                    item.age = Years((DateTime)item.dateOfBirth, DateTime.Now);
                }

                response.clientList = clientListResponse;

                //Mostramos el cronograma de pagos
                var loan = _unitOfWork.ILoan.GetById(idLoan);
                List<PaymentScheduleResponse> paymentScheduleResponse = new List<PaymentScheduleResponse>();
                if (loan.startpaymentDate != null)
                {
                    paymentScheduleResponse = _unitOfWork.IPaymentSchedule.GetIdLoanAmountByIdLoan(idLoan);
                    foreach(var item in paymentScheduleResponse)
                    {
                        CreateScheduleRequestDTO createScheduleRequest = new CreateScheduleRequestDTO();
                        createScheduleRequest.idLoanAmount = item.idLoanAmount;
                        createScheduleRequest.startPaymentDate = (DateTime)loan.startpaymentDate;
                        item.paymentSchedule = _paymentScheduleLogic.CreatePaymentSchedule(createScheduleRequest);
                    }
                    response.paymentScheduleList = paymentScheduleResponse;
                }
                else
                {
                    response.paymentScheduleList = null;
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
