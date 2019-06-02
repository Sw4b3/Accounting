using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IAnalyticsRepository
    {
        IList<Statistic> GetAnalyticsStatistics(DateRequest request);

        IList<AnalyticsOverview> GetAnalyticOverviewRequest(DateRequest request);

        IList<AnalysisByDay> GetAnalyticsByDayRequest(DateRequest request);

        IList<AnalysisByMonth> GetAnalyticsByMonthRequest();

    }
}
