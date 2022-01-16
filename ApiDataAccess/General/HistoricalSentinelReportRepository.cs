using System;
using ApiModel.General;
using ApiRepositories.General;

namespace ApiDataAccess.General
{
    public class HistoricalSentinelReportRepository : Repository<HistoricalSentinelReport> , IHistoricalSentinelReportRepository
    {
        public HistoricalSentinelReportRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
