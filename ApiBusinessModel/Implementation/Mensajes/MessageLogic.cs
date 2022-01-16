using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessModel.Interfaces.Mensajes;
using ApiModel.Mensajes;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.ResponseDTO.Mensajes;
using ApiUnitOfWork.General;

namespace ApiBusinessModel.Implementation.Mensajes
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MessageResponse Insert(MessageRequestDTO dto)
        {
            try
            {
                MessageResponse response = new MessageResponse();
                Message obj = new Message();

                dto.idMessage = _unitOfWork.IMessage.Insert(obj.Mapper(obj, dto));

                response = response.Mapper(response, dto);

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public MessageResponse Update(MessageRequestDTO dto)
        {
            try
            {
                MessageResponse response = new MessageResponse();
                Message obj = new Message();
                _unitOfWork.IMessage.Update(obj.Mapper(obj, dto));

                response = response.Mapper(response, dto);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int idMessageDeleted)
        {
            try
            {
                Message obj = new Message();
                obj.idMessage = idMessageDeleted;
                return _unitOfWork.IMessage.Delete(obj);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Message> GetList()
        {
            try
            {
                var response = _unitOfWork.IMessage.GetList();
                return response.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
