using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.ResponseDTO.Person
{
    public class PersonResponse
    {
        [Key]
        public int idPerson { get; set; }
        public int idPersonType { get; set; }
        public int? idDocumentType { get; set; }
        public string? documentNumber { get; set; }
        public string? name { get; set; }
        public string? lastname { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? citizenship { get; set; }
        public int? idCivilState { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? referenceRelation { get; set; }
        public int? idFinancialState { get; set; }
        public int idPersonState { get; set; }
        public int idLoanAmount { get; set; }
        public decimal amount { get; set; }
    }
}
