using System;
using ApiModel.RequestDTO.Person;
using Dapper.Contrib.Extensions;

namespace ApiModel.Person
{
    public class LaborData
    {
        [Key]
        public int idLaborData { get; set; }
        public int idPerson { get; set; }
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

        public LaborData Mapper(LaborData obj, LaborDataRequestDTO dto)
        {
            obj.RUC = dto.RUC;
            obj.business = dto.business;
            obj.activity = dto.activity;
            obj.businessAddress = dto.businessAddress;
            obj.startDate = dto.startDate;
            obj.idCurrentPosition = dto.idCurrentPosition;
            obj.otherCurrentPosition = dto.otherCurrentPosition;
            obj.monthlyGrossIncome = dto.monthlyGrossIncome;
            obj.otherIncome = dto.otherIncome;
            obj.businessPhone = dto.businessPhone;
            obj.idTypeOfRent = dto.idTypeOfRent;
            
            return obj;
        }
    }
}
