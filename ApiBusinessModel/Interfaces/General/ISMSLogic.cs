using System;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.RequestDTO.SMS;

namespace ApiBusinessModel.Interfaces.General
{
    public interface ISMSLogic
    {
        public bool SendNotificationToGroup(SendNotificationToGroupRequestDTO dto);
        public bool SendNotificationIndividual(SendNotificationIndividualRequestDTO dto);
    }
}
