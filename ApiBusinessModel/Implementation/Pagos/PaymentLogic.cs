using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBusinessModel.Interfaces.General;
using ApiBusinessModel.Interfaces.Pagos;
using ApiModel.Pagos;
using ApiModel.RequestDTO.Pagos;
using ApiModel.ResponseDTO.Pagos;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace ApiBusinessModel.Implementation.Pagos
{
    public class PaymentLogic : IPaymentLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadFileLogic _uploadFileLogic;

        public PaymentLogic(IUnitOfWork unitOfWork, IUploadFileLogic uploadFileLogic)
        {
            _unitOfWork = unitOfWork;
            _uploadFileLogic = uploadFileLogic;
        }

        public PaymentResponse Insert(PaymentRequestDTO dto)
        {
            try
            {
                PaymentResponse response = new PaymentResponse();
                Payment obj = new Payment();
                var Loan = _unitOfWork.ILoan.GetById(dto.idLoan);

                var payDay = dto.paymentDate.Day;
                var payMonth = dto.paymentDate.Month;
                var payYear = dto.paymentDate.Year;

                string[] valores = dto.files.ContentType.Split("/");

                var extension = valores[1];

                var fileName = Loan.loanName + payDay + "-" + payMonth + "-" + payYear + "." + extension ;

                dto.payConstancy = _uploadFileLogic.UploadImgToAzure(dto.files, fileName);

                dto.idPayment = _unitOfWork.IPayment.Insert(obj.Mapper(obj, dto));

                response = response.Mapper(response, dto);

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public PaymentResponse Update(PaymentRequestDTO dto)
        {
            try
            {
                PaymentResponse response = new PaymentResponse();
                Payment obj = new Payment();
                if (dto.files == null)
                {
                    _unitOfWork.IPayment.Update(obj.Mapper(obj, dto));
                }
                else
                {
                    var Loan = _unitOfWork.ILoan.GetById(dto.idLoan);

                    var payDay = dto.paymentDate.Day;
                    var payMonth = dto.paymentDate.Month;
                    var payYear = dto.paymentDate.Year;

                    string[] valores = dto.files.ContentType.Split("/");

                    var extension = valores[1];

                    var fileName = Loan.loanName + payDay + "-" + payMonth + "-" + payYear + "." + extension;

                    dto.payConstancy = _uploadFileLogic.UploadImgToAzure(dto.files, fileName);

                    _unitOfWork.IPayment.Update(obj.Mapper(obj, dto));
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<PaymentResponse> GetPaymentsByLoan(int idLoan)
        {
            try
            {
                List<PaymentResponse> response = new List<PaymentResponse>();
                response = _unitOfWork.IPayment.GetPaymentsByIdLoan(idLoan);
                foreach(var item in response)
                {
                    var client = _unitOfWork.IPerson.CheckPersonByDocumentNumber(item.depositor);
                    if(client != null)
                    {
                        item.depositorFullName = client.name + " " + client.lastname;
                    }
                    else
                    {
                        item.depositorFullName = "Persona externa";
                    }
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
