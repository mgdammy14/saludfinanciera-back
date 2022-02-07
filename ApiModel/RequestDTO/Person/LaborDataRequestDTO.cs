using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.RequestDTO.Person
{
    public class LaborDataRequestDTO
    {
        [Key]
        public string? RUC { get; set; }
        public string? business { get; set; }
        public string? activity { get; set; }
        public string? businessAddress { get; set; }
        public DateTime? startDate { get; set; }
        public int? idCurrentPosition { get; set; }
        public string? otherCurrentPosition { get; set; }
        public decimal? monthlyGrossIncome { get; set; }
        public decimal? otherIncome { get; set; }
        public string? businessPhone { get; set; }
        public int? idTypeOfRent { get; set; }
    }
}
