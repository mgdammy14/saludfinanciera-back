using System;
using System.Collections.Generic;
using System.Transactions;
using ApiBusinessModel.Interfaces.Client;
using ApiModel.ClientModel;
using ApiModel.RequestDTO.Client;
using ApiModel.ResponseDTO.Client;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Client
{
    public class ClientLogic : IClientLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ApiModel.ClientModel.Client> GetList()
        {
            try
            {
                return _unitOfWork.IClient.GetList();
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
                var response = 0;

                using (var transaction = new TransactionScope())
                {

                    ClientLoan obj = new ClientLoan();
                    //Eliminamos el registro segun el idClient
                    _unitOfWork.IClientLoan.DeleteClientLoanRegister(dto.idClient);
                    //Insertamos
                    response = _unitOfWork.IClientLoan.Insert(obj.Mapper(obj, dto));
                    transaction.Complete();

                }

                return response;
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
    }
}
