using System;
namespace ApiModel.RequestDTO.Person
{
    public class SpouseFullRequestDTO
    {
        public SpouseRequestDTO spouseData { get; set; }
        public LaborDataRequestDTO spouseLaborData { get; set; }
    }
}
