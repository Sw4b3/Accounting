using Accounting.Domain.Services.Utillies;
using Accounting.Models.Models;
using Accounting.Repository;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service
{
    public class AnalyticsService
    {
        private readonly UnitOfWork uow;

        public AnalyticsService()
        {
            uow = new UnitOfWork();
        }

        public IList<Statistic> GetStatistics()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AnalyticsRepository.GetAnalyticsStatistics(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<AnalyticsOverview> GetAnalysicOverview()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AnalyticsRepository.GetAnalyticOverviewRequest(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<AnalysisByDay> GetAnalyticsByDay()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AnalyticsRepository.GetAnalyticsByDayRequest(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<AnalysisByMonth> GetAnalyticsByMonth()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AnalyticsRepository.GetAnalyticsByMonthRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<AnalysisBySavings> GetAnalyticsSavings()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.AnalyticsRepository.GetAnalyticsSavings();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
