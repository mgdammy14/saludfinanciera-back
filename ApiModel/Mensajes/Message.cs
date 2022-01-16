using System;
using ApiModel.RequestDTO.Mensajes;
using Dapper.Contrib.Extensions;

namespace ApiModel.Mensajes
{
    public class Message
    {
        [Key]
        public int idMessage { get; set; }
        public string titleMessage { get; set; }
        public string message { get; set; }

        public Message Mapper(Message obj, MessageRequestDTO dto)
        {
            obj.idMessage = dto.idMessage;
            obj.titleMessage = dto.titleMessage;
            obj.message = dto.message;
            return obj;
        }
    }
}
