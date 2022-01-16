using System;
using ApiModel.RequestDTO.Mensajes;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Mensajes
{
    public class MessageResponse
    {
        [Key]
        public int idMessage { get; set; }
        public string titleMessage { get; set; }
        public string message { get; set; }

        public MessageResponse Mapper(MessageResponse res, MessageRequestDTO dto)
        {
            res.idMessage = dto.idMessage;
            res.titleMessage = dto.titleMessage;
            res.message = dto.message;
            return res;
        }
    }
}
