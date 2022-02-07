using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class Reference
    {
        [Key]
        public int idPerson { get; set; }
        public int idPersonType { get; set; }
        public int? idDocumentType { get; set; }
        public string? documentNumber { get; set; }
        public string? name { get; set; }
        public string? lastname { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string? gender { get; set; }
        public string? citizenship { get; set; }
        public string? address { get; set; }
        public string? phoneNumber { get; set; }
        public string? referenceRelation { get; set; }
    }
}
