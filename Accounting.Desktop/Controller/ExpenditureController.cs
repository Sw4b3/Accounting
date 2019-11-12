using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace Accounting.Desktop.Controller
{
    public class ExpenditureController
    {
        private readonly IExpenditureService _expenditureService;

        public ExpenditureController()
        {
            _expenditureService = new ExpenditureService();

        }

        public List<ExpenditureViewModel> GetExpenditure(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            })
            .Where(x => x.ExpenditureRuleId == 0)
            .Select(x => new ExpenditureViewModel
            {
                ExpenditureId = x.ExpenditureId,
                TransactionId = x.TransactionId,
                Description = x.Description,
                Amount = x.Amount,
                TransactionTimestamp = x.TransactionTimestamp,

            }).ToList();

            return res;
        }

        public IList<ExpenditureOverview> GetExpenditureOverview()
        {
            var res = _expenditureService.GetExpenditureOverview();
            return res;
        }


        public List<ExpenditureRuleItem> GetExpenditureRulesList()
        {
            var res = _expenditureService.GetExpenditureRules()
                .Select(x => new ExpenditureRuleItem { ExpenditureDesc = x.ExpenditureDesc, ExpenditureRuleId = x.ExpenditureRuleId }).ToList();

            return res;
        }

        public List<ExpenditureBreakdownViewModel> FilterExpenditureBreakdownByDate(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var res = _expenditureService.GetExpenditureRuleOverview(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            }).Select(x => new ExpenditureBreakdownViewModel
            {
                ExpenditureDesc = x.ExpenditureDesc,
                ExpenditureLimit = x.ExpenditureLimit,
                ExpenditureTotal = x.ExpenditureTotal,
                Difference = x.ExpenditureLimit - x.ExpenditureTotal
            }).ToList();

            return res;
        }

        public List<ExpenditureViewModel> FilterExpenditure(string value, DateTime date)
        {

            if (value == "Unmapped")
            {
                var startDate = new DateTime(date.Year, date.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate
                }).Where(x => x.ExpenditureRuleId == 0)
               .Select(x => new ExpenditureViewModel
               {
                   ExpenditureId = x.ExpenditureId,
                   TransactionId = x.TransactionId,
                   Description = x.Description,
                   Amount = x.Amount,
                   TransactionTimestamp = x.TransactionTimestamp,

               }).ToList();

                return res;
            }
            else
            {
                var startDate = new DateTime(date.Year, date.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var res = _expenditureService.GetExpenditureByDateRequest(new DateRequest()
                {
                    StartDate = startDate,
                    EndDate = endDate
                }).Where(x => x.ExpenditureRuleId != 0)
                .Select(x => new ExpenditureViewModel
                {
                    ExpenditureId = x.ExpenditureId,
                    TransactionId = x.TransactionId,
                    Description = x.Description,
                    Amount = x.Amount,
                    TransactionTimestamp = x.TransactionTimestamp,

                }).ToList();

                return res;
            }

        }

        public List<ExpenditureTypeItem> GetExpenditureTypes()
        {
            var res = _expenditureService.GetExpenditureTypes().Select(x => new ExpenditureTypeItem
            {
                ExpenditureTypeId = x.ExpenditureTypeId,
                ExpenditureDesc = x.ExpenditureDesc
            }).ToList();
            return res;
        }

        public List<ExpenditureRule> GetExpenditureRules()
        {
            var res = _expenditureService.GetExpenditureRules().ToList();
            return res;
        }

        public List<ExpenditureOverview> GetExpenditureRuleOverview()
        {
            var res = _expenditureService.GetExpenditureRuleOverview().ToList();
            return res;
        }

        public List<ExpenditureBreakdownViewModel> GetExpenditureBreakdown()
        {
            var res = _expenditureService.GetExpenditureRuleOverview().
                Select(x => new ExpenditureBreakdownViewModel
                {
                    ExpenditureDesc = x.ExpenditureDesc,
                    ExpenditureLimit = x.ExpenditureLimit,
                    ExpenditureTotal = x.ExpenditureTotal,
                    Difference = x.ExpenditureLimit - x.ExpenditureTotal
                }).ToList();
            return res;
        }

        public void ImportExpenditure(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            _expenditureService.ImportExpenditure(new DateRequest()
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }

        public void SaveExpenditureRules(SaveExpenditureTypeRequest expenditureRequest)
        {
            _expenditureService.SaveExpenditureRule(expenditureRequest);
        }

        public void UpdateExpenditure(UpdateExpenditureRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditure(expenditureRequest);
        }

        public void UpdateExpenditureRule(UpdateExpenditureRuleRequest expenditureRequest)
        {
            _expenditureService.UpdateExpenditureRule(expenditureRequest);
        }

        public void DeleteExpenditureRule(int expenditureRuleId)
        {
            _expenditureService.DeleteExpenditureRule(new DeleteExpenditureRuleRequest
            {
                ExpenditureRuleId = expenditureRuleId,
                IsArchived = true,
                ArchivedDate = DateTime.Now
            });
        }
    }
}
