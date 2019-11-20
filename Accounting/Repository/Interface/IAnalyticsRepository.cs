using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Repository.Interface
{
    public interface IAnalyticsRepository
    {
        IList<Statistic> GetAnalyticsStatistics(DateRequest request);

        IList<AnalyticsOverview> GetAnalyticOverviewRequest(DateRequest request);

        IList<AnalysisByDay> GetAnalyticsByDayRequest(DateRequest request);

        IList<AnalysisByMonth> GetAnalyticsByMonthRequest();

        IList<AnalysisBySavings> GetAnalyticsSavings();
    }
}
