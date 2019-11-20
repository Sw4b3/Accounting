using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Repository.Interface
{
    public interface IExpenditureRepository
    {
        IList<Expenditure> GetExpenditureByDateRequest(DateRequest request);

        IList<ExpenditureType> GetExpenditureTypes();

        IList<ExpenditureRule> GetExpenditureRules();

        IList<ExpenditureOverview> GetExpenditureOverview(DateRequest request);

        IList<ExpenditureOverview> GetExpenditureRuleOverview(DateRequest request);

        void SaveExpenditureRule(SaveExpenditureTypeRequest request);

        void ImportExpenditure(DateRequest request);

        void UpdateExpenditure(UpdateExpenditureRequest request);

        void UpdateExpenditureRule(UpdateExpenditureRuleRequest request);

        void DeleteExpenditureRule(DeleteExpenditureRuleRequest expenditureRequest);

        void AutoResolveMappings(DateRequest request);
    }
}
