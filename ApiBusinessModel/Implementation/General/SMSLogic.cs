using System;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO.SMS;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ApiBusinessModel.Implementation.General
{
    public class SMSLogic : ISMSLogic
    {
        public SMSLogic()
        {
        }

        public bool SendSMS(SMSRequestDTO dto)
        {
            try
            {
                string accountSid = "AC234f246e4d3d74abd477951243592d8b";
                string authToken = "98192382945ac864063537921f22ca94";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: dto.message,
                    from: new Twilio.Types.PhoneNumber("+17242008493"),
                    to: new Twilio.Types.PhoneNumber(dto.to)
                );


                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool SendWhatsAppSMS(SMSRequestDTO dto)
        {
            try
            {
                string accountSid = "AC234f246e4d3d74abd477951243592d8b";
                string authToken = "98192382945ac864063537921f22ca94";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: dto.message,
                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                    to: new Twilio.Types.PhoneNumber("whatsapp:"+ dto.to)
                );

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
