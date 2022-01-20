using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ApiBusinessModel.Interfaces.Client;
using ApiBusinessModel.Interfaces.General;
using ApiModel.ClientModel;
using ApiModel.General;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Client
{
    public class ClientLogic : IClientLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadFileLogic _uploadFileLogic;

        public ClientLogic(IUnitOfWork unitOfWork, IUploadFileLogic uploadFileLogic)
        {
            _unitOfWork = unitOfWork;
            _uploadFileLogic = uploadFileLogic;
        }

        public List<ClientResponseDTO> GetList()
        {
            try
            {
                List<ClientResponseDTO> response = new List<ClientResponseDTO>();

                response = _unitOfWork.IClient.GetClientList();

                foreach(var item in response)
                {

                    int Years(DateTime start, DateTime end)
                    {
                        return (end.Year - start.Year - 1) +
                            (((end.Month > start.Month) ||
                            ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
                    }

                    item.age = Years(item.clientDateOfBirth, DateTime.Now);
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ClientResponseDTO Insert(ClientRequestDTO dto)
        {
            try
            {

                ClientResponseDTO response = new ClientResponseDTO();
                ApiModel.ClientModel.Client obj = new ApiModel.ClientModel.Client();
                dto.idClient = _unitOfWork.IClient.Insert(obj.Mapper(obj, dto));
                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ClientResponseDTO Update(ClientRequestDTO dto)
        {
            try
            {
                ClientResponseDTO response = new ClientResponseDTO();
                ApiModel.ClientModel.Client obj = new ApiModel.ClientModel.Client();
                _unitOfWork.IClient.Update(obj.Mapper(obj, dto));
                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int ChangeClientState(int idClient)
        {
            try
            {
                var Client = _unitOfWork.IClient.GetById(idClient);
                int idClientState = 0;
                //validamos su estado actual
                if(Client.idClientState == 1)
                {
                    idClientState = 2;
                    _unitOfWork.IClient.ChangeClientState(idClient, idClientState);
                }
                else
                {
                    idClientState = 1;
                    _unitOfWork.IClient.ChangeClientState(idClient, idClientState);
                }

                return idClientState;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int AddToLoan(ClientLoanRequestDTO dto)
        {
            try
            {
                ClientLoan obj = new ClientLoan();
                obj.clientLoan = dto.idClient.ToString() + dto.idLoan.ToString();
                _unitOfWork.IClientLoan.Insert(obj.Mapper(obj, dto));
                return 1;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int AddToLoanList(List<ClientLoanRequestDTO> dtoList)
        {
            try
            {
                var response = 0;
                foreach(var item in dtoList)
                {
                    response = AddToLoan(item);
                }
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int DeleteClientFromLoan(int idClient)
        {
            try
            {
                return _unitOfWork.IClientLoan.DeleteClientLoanRegister(idClient);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<ApiModel.ClientModel.Client> GetClientByIdLoan(int idLoan)
        {
            try
            {
                return _unitOfWork.IClient.GetClientsByIdLoan(idLoan);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public string UploadSentinelPdf(UploadPdfRequestDTO dto)
        {
            try
            {
                var user = _unitOfWork.IUsers.GetById(dto.idClient);
                string nameFile = user.lastname + user.name + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                var response =  _uploadFileLogic.UploadPdfToAzure(dto.files, nameFile);
                HistoricalSentinelReport sentinelReport = new HistoricalSentinelReport();
                sentinelReport.idClient = dto.idClient;
                sentinelReport.uploadDate = DateTime.Now;
                sentinelReport.filePDF = response;
                _unitOfWork.IHistoricalSentinelReport.Insert(sentinelReport);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int CheckClientByDocumentNumber(string documentNumber)
        {
            try
            {
                var response = 0;

                var checkClient = _unitOfWork.IClient.CheckClientByDocumentNumber(documentNumber);

                if (checkClient != null)
                {
                    response = 1;
                }
                else
                {
                    response = 2;
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
