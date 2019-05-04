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
        IList<Statistic> GetAnalyticsStatistics(GetDateRequest request);

        IList<AnalyticsOverview> GetAnalyticOverviewRequest(GetDateRequest request);

        IList<AnalysisByDay> GetAnalyticsByDayRequest(GetDateRequest request);

        IList<AnalysisByMonth> GetAnalyticsByMonthRequest();

    }
}
