using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Person
{
    public class PersonExtraDataRequestDTO
    {
        [Key]
        public int? idDegreeOfInstruction { get; set; }
        public int? idLaboralSituation { get; set; }
        public string? otherLaboralSituation { get; set; }
        public string? profession { get; set; }
        public string? occupation { get; set; }
        public int? dependents { get; set; }
    }
}
