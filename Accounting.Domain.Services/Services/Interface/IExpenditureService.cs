using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IExpenditureService
    {
        IList<Expenditure> GetExpenditureByDateRequest(DateRequest dateRequest);

        IList<ExpenditureType> GetExpenditureTypes();

        IList<ExpenditureRule> GetExpenditureRules();

        IList<ExpenditureOverview> GetExpenditureOverview();

        IList<ExpenditureOverview> GetExpenditureRuleOverview();

        IList<ExpenditureOverview> GetExpenditureRuleOverview(DateRequest dateRequest);

        void ImportExpenditure(DateRequest dateRequest);

        void SaveExpenditureRule(SaveExpenditureTypeRequest request);

        void UpdateExpenditure(UpdateExpenditureRequest expenditureRequest);

        void UpdateExpenditureRule(UpdateExpenditureRuleRequest expenditureRequest);

        void DeleteExpenditureRule(DeleteExpenditureRuleRequest expenditureRequest);

        void AutoResolveMappings(DateRequest request);
    }
}
