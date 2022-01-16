using System;
namespace ApiModel.RequestDTO.Mensajes
{
    public class SendNotificationToGroupRequestDTO
    {
        public int idLoan { get; set; }
        public int idChannel { get; set; }
        public string message { get; set; }
    }
}
