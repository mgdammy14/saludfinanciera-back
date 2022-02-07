using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Person
{
    public class PersonFullRequestDTO
    {
        public PersonRequestDTO client { get; set; }
        public PersonExtraDataRequestDTO extraClientData { get; set; }
        public LaborDataRequestDTO laborData { get; set; }
        public SpouseFullRequestDTO spouse { get; set; }
        public List<SpouseRequestDTO> referenceList { get; set; }
    }
}
