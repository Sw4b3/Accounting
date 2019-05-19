using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Accounting.Repository.Interface
{
    public interface IExpenditureRepository 
    {
        IList<Expenditure> GetExpenditureByDateRequest(GetDateRequest request);

        IList<ExpenditureType> GetExpenditureTypes();

        IList<ExpenditureType> GetExpenditureRules();

        IList<ExpenditureOverview> GetExpenditureOverview();

        IList<ExpenditureOverview> GetExpenditureRuleOverview();

        void SaveExpenditureRule(SaveExpenditureTypeRequest request);

        void ImportExpenditure(GetDateRequest request);

        void UpdateExpenditure(UpdateExpenditureRequest request);

        void UpdateExpenditureType(UpdateExpenditureTypeRequest request);

        void Delete();
        
    }
}
