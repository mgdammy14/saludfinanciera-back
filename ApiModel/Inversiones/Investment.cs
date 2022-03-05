using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.Inversiones
{
    public class Investment
    {
        [Key]
        public int idInvestment { get; set; }
        public string investmentFullName { get; set; }
        public decimal investmentAmount { get; set; }
        public string operationNumber { get; set; }
        public string investmentMode { get; set; }
        public string interestByPeriod { get; set; }
        public int numberOfPeriod { get; set; }
        public int timeOfPeriod { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
    }
}
