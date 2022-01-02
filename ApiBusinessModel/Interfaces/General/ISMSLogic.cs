using System;
using ApiModel.RequestDTO.SMS;

namespace ApiBusinessModel.Interfaces.General
{
    public interface ISMSLogic
    {
        public bool SendSMS(SMSRequestDTO dto);
        public bool SendWhatsAppSMS(SMSRequestDTO dto);
    }
}
