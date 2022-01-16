using System;
using Dapper.Contrib.Extensions;

namespace ApiModel.General
{
    public class HistoricalSentinelReport
    {
        [Key]
        public int idHistorical { get; set; }
        public int idClient { get; set; }
        public DateTime uploadDate { get; set; }
        public string filePDF { get; set; }
    }
}
