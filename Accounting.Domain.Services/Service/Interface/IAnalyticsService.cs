using Accounting.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
