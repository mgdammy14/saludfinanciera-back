using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Mensajes
{
    public class MessageRequestDTO
    {
        [Key]
        public int idMessage { get; set; }
        public string titleMessage { get; set; }
        public string message { get; set; }
    }
}
