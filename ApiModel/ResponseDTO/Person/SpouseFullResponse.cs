using System;
using ApiModel.Person;

namespace ApiModel.ResponseDTO.Person
{
    public class SpouseFullResponse
    {
        public Reference spouseData { get; set; }
        public LaborData spouseLaborData { get; set; }
    }
}
