using System;
using System.Collections.Generic;
using ApiModel.General;

namespace ApiRepositories.General
{
    public interface IHistoricalSentinelReportRepository : IRepository<HistoricalSentinelReport>
    {
        public List<HistoricalSentinelReport> GetHistoricalSentinelReport(int idClient);
    }
}
