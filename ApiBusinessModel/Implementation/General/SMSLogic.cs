using System;
using System.Collections.Generic;
using ApiBusinessModel.Interfaces.General;
using ApiModel.RequestDTO.Mensajes;
using ApiModel.RequestDTO.SMS;
using ApiUnitOfWork.General;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ApiBusinessModel.Implementation.General
{
    public class SMSLogic : ISMSLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        private string accountSid = "AC234f246e4d3d74abd477951243592d8b";
        private string authToken = "4bfa3ee749859bafcdcc65ea9ef0e704";

        public SMSLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool SendNotificationToGroup(SendNotificationToGroupRequestDTO dto)
        {
            try
            {
                var response = false;

                var clientList = _unitOfWork.IPerson.GetClientsByIdLoan(dto.idLoan);


                SMSRequestDTO messageDTO = new SMSRequestDTO();
                messageDTO.message = dto.message;

                switch (dto.idChannel)
                {
                    //SMS
                    case 1:
                        foreach(var item in clientList)
                        {
                            messageDTO.to = "+51" + item.phoneNumber;
                            try
                            {
                                response = SendSMS(messageDTO);
                            }
                            catch(Exception e)
                            {
                                response = false;
                            }
                        }
                        break;
                    //WhatsApp
                    case 2:
                        foreach (var item in clientList)
                        {
                            messageDTO.to = "+51" + item.phoneNumber;
                            try
                            {
                                response = SendWhatsAppSMS(messageDTO);
                            }
                            catch(Exception e)
                            {
                                response = false;
                            }
                        }
                        break;
                    default:
                        break;
                }

                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool SendNotificationIndividual(SendNotificationIndividualRequestDTO dto)
        {
            try
            {
                var response = false;

                SMSRequestDTO messageDTO = new SMSRequestDTO();
                messageDTO.message = dto.message;

                switch (dto.idChannel)
                {
                    //SMS
                    case 1:
                        foreach (var item in dto.clientList)
                        {
                            var client = _unitOfWork.IPerson.GetById(item.idClient);
                            messageDTO.to = "+51" + client.phoneNumber;
                            try
                            {
                                response = SendSMS(messageDTO);
                            }
                            catch (Exception e)
                            {
                                response = false;
                            }
                        }
                        break;
                    //WhatsApp
                    case 2:
                        foreach (var item in dto.clientList)
                        {
                            var client = _unitOfWork.IPerson.GetById(item.idClient);
                            messageDTO.to = "+51" + client.phoneNumber;
                            try
                            {
                                response = SendWhatsAppSMS(messageDTO);
                            }
                            catch(Exception e)
                            {
                                response = false;
                            }
                        }
                        break;
                    default:
                        break;
                }

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool SendSMS(SMSRequestDTO dto)
        {
            try
            {
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

        private bool SendWhatsAppSMS(SMSRequestDTO dto)
        {
            try
            {
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
