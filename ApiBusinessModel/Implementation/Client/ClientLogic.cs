using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ApiBusinessModel.Interfaces.Client;
using ApiBusinessModel.Interfaces.General;
using ApiModel.ClientModel;
using ApiModel.General;
using ApiModel.RequestDTO.Client;
using ApiModel.RequestDTO.Person;
using ApiModel.ResponseDTO.Client;
using ApiModel.ResponseDTO.Person;
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

        public List<ClientToInsert> ListToInsert()
        {
            return _unitOfWork.IClient.GetClientToInsert();
        }
    }
}
