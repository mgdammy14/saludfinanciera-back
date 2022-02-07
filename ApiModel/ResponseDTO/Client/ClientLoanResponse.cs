using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Client
{
    public class ClientLoanResponse
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
        public int age { get; set; }
        public int idFinancialState { get; set; }
        public int idClientState { get; set; }
        public int idLoanAmount { get; set; }
        public int amount { get; set; }
    }
}
