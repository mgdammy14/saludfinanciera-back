using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiModel.Prestamos;
using ApiModel.RequestDTO.Prestamos;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Prestamos
{
    public class PaymentScheduleLogic : IPaymentScheduleLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentScheduleLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Insert(PaymentSchedule dto)
        {
            return _unitOfWork.IPaymentSchedule.Insert(dto);
        }

        public IEnumerable<PaymentSchedule> GetList()
        {
            return _unitOfWork.IPaymentSchedule.GetList();
        }



        public List<PaymentSchedule> CreatePaymentSchedule(CreateScheduleRequestDTO dto)
        {
            var response = _unitOfWork.IPaymentSchedule.GetList().ToList();

            PaymentSchedule beforeItem = new PaymentSchedule();

            foreach (var item in response)
            {

                if (item.installmentNumber != 0)
                {
                    item.paymentDate = beforeItem.paymentDate.AddDays(14);
                }
                else
                {
                    item.paymentDate = dto.startPaymentDate;
                }

                beforeItem = item;
            }

            return response;
        }
    }
}
