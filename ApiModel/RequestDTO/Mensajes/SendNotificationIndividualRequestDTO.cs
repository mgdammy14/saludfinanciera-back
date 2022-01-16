using System;
using System.Collections.Generic;

namespace ApiModel.RequestDTO.Mensajes
{
    public class SendNotificationIndividualRequestDTO
    {
        public List<Client> clientList { get; set; }
        public int idChannel { get; set; }
        public string message { get; set; }
    }

    public class Client
    {
        public int idClient { get; set; }
    }
}
