using Accounting.Models.Models;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IAnalyticsService
    {
        IList<AnalyticsOverview> GetAnalyticsOverview();

        IList<AnalysisByDay> GetAnalyticsByDay();

        IList<AnalysisByMonth> GetAnalyticsByMonth();

        IList<Statistic> GetStatistics();
    }
}
