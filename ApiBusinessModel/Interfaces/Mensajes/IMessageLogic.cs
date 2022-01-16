using System;
using System.Collections.Generic;
using ApiModel.Mensajes;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.ResponseDTO.Mensajes;

namespace ApiBusinessModel.Interfaces.Mensajes
{
    public interface IMessageLogic
    {
        public MessageResponse Insert(MessageRequestDTO dto);
        public MessageResponse Update(MessageRequestDTO dto);
        public bool Delete(int idMessageDeleted);
        public List<Message> GetList();
    }
}
