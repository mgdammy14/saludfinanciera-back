using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Client
{
    public class ClientRequestDTO
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
    }
}
