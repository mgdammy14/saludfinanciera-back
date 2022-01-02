using System;
using ApiModel.RequestDTO.Client;
using Dapper.Contrib.Extensions;

namespace ApiModel.ClientModel
{
    public class Client
    {
        [Key]
        public int idClient { get; set; }
        public string documentNumber { get; set; }
        public int idDocumentType { get; set; }
        public string clientName { get; set; }
        public string clientLastname { get; set; }
        public string clientAddress { get; set; }
        public string clientPhoneNumber { get; set; }
        public DateTime clientDateOfBirth { get; set; }
        public int idFinancialState { get; set; }
        public int idClientState { get; set; }

        public Client Mapper(Client obj, ClientRequestDTO dto)
        {
            obj.idClient = dto.idClient;
            obj.documentNumber = dto.documentNumber;
            obj.idDocumentType = dto.idDocumentType;
            obj.clientName = dto.clientName;
            obj.clientLastname = dto.clientLastname;
            obj.clientAddress = dto.clientAddress;
            obj.clientPhoneNumber = dto.clientPhoneNumber;
            obj.clientDateOfBirth = dto.clientDateOfBirth;
            obj.idFinancialState = dto.idFinancialState;
            obj.idClientState = dto.idClientState;

            return obj;
        }
    }
}
