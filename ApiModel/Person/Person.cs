using System;
using ApiModel.RequestDTO.Person;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class Person
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
        public int? idCivilState { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public string? referenceRelation { get; set; }
        public int? idFinancialState { get; set; }
        public int idPersonState { get; set; }

        public Person Mapper(Person obj, PersonRequestDTO dto)
        {
            obj.idDocumentType = dto.idDocumentType;
            obj.documentNumber = dto.documentNumber;
            obj.name = dto.name;
            obj.lastname = dto.lastname;
            obj.dateOfBirth = dto.dateOfBirth;
            obj.gender = dto.gender;
            obj.citizenship = dto.citizenship;
            obj.idCivilState = dto.idCivilState;
            obj.phoneNumber = dto.phoneNumber;
            obj.email = dto.email;
            obj.address = dto.address;
            obj.referenceRelation = dto.referenceRelation;
            obj.idFinancialState = dto.idFinancialState;

            return obj;
        }

        public Person Mapper(Person obj, SpouseRequestDTO dto)
        {
            obj.idDocumentType = dto.idDocumentType;
            obj.documentNumber = dto.documentNumber;
            obj.name = dto.name;
            obj.lastname = dto.lastname;
            obj.dateOfBirth = dto.dateOfBirth;
            obj.gender = dto.gender;
            obj.citizenship = dto.citizenship;
            obj.address = dto.address;
            obj.phoneNumber = dto.phoneNumber;

            return obj;
        }

        public Person Mapper(Person obj, Reference dto)
        {
            obj.idPerson = dto.idPerson;
            obj.idPersonType = dto.idPersonType;
            obj.idDocumentType = dto.idDocumentType;
            obj.documentNumber = dto.documentNumber;
            obj.name = dto.name;
            obj.lastname = dto.lastname;
            obj.dateOfBirth = dto.dateOfBirth;
            obj.gender = dto.gender;
            obj.citizenship = dto.citizenship;
            obj.address = dto.address;
            obj.phoneNumber = dto.phoneNumber;
            obj.referenceRelation = dto.referenceRelation;
            return obj;
        }
    }
}
