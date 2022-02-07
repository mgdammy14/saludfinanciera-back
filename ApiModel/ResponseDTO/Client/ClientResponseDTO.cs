using System;
using ApiModel.RequestDTO.Client;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Client
{
    public class ClientResponseDTO
    {
        [Key]
        public int idClient { get; set; }
        public string documentNumber { get; set; }
        public int idDocumentType { get; set; }
        public string clientName { get; set; }
        public string clientLastname { get; set; }
        public string clientAddress { get; set; }
        public string clientGender { get; set; }
        public string clientCitizenship { get; set; }
        public int idCivilState { get; set; }
        public string clientEmail { get; set; }
        public string clientPhoneNumber { get; set; }
        public DateTime clientDateOfBirth { get; set; }
        public int age { get; set; }
        public int idFinancialState { get; set; }
        public int idClientState { get; set; }

        public ClientResponseDTO Mapper(ClientResponseDTO obj, ClientRequestDTO dto)
        {
            obj.idClient = dto.idClient;
            obj.documentNumber = dto.documentNumber;
            obj.idDocumentType = dto.idDocumentType;
            obj.clientName = dto.clientName;
            obj.clientLastname = dto.clientLastname;
            obj.clientAddress = dto.clientAddress;
            obj.clientGender = dto.clientGender;
            obj.clientCitizenship = dto.clientCitizenship;
            obj.idCivilState = dto.idCivilState;
            obj.clientEmail = dto.clientEmail;
            obj.clientPhoneNumber = dto.clientPhoneNumber;
            obj.clientDateOfBirth = dto.clientDateOfBirth;
            obj.idFinancialState = dto.idFinancialState;
            obj.idClientState = dto.idClientState;
            return obj;
        }
    }
}
