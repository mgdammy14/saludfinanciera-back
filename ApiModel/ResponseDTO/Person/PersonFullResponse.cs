using System;
using System.Collections.Generic;
using ApiModel.Person;

namespace ApiModel.ResponseDTO.Person
{
    public class PersonFullResponse
    {
        public ApiModel.Person.Person client { get; set; }
        public PersonExtraData extraClientData { get; set; }
        public LaborData laborData { get; set; }
        public SpouseFullResponse spouse { get; set; }
        public List<Reference> referenceList { get; set; }
    }
}
