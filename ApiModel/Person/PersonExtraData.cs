using System;
using ApiModel.RequestDTO.Person;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class PersonExtraData
    {
        [Key]
        public int idPersonExtraData { get; set; }
        public int idPerson { get; set; }
        public int? idDegreeOfInstruction { get; set; }
        public int? idLaboralSituation { get; set; }
        public string? otherLaboralSituation { get; set; }
        public string? profession { get; set; }
        public string? occupation { get; set; }
        public int? dependents { get; set; }

        public PersonExtraData Mapper(PersonExtraData obj, PersonExtraDataRequestDTO dto)
        {
            obj.idDegreeOfInstruction = dto.idDegreeOfInstruction;
            obj.idLaboralSituation = dto.idLaboralSituation;
            obj.otherLaboralSituation = dto.otherLaboralSituation;
            obj.profession = dto.profession;
            obj.occupation = dto.occupation;
            obj.dependents = dto.dependents;
            return obj;
        }
    }
}
