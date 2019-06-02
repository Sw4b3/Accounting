﻿using Accounting.Models.Models;
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

        IList<ExpenditureRule> GetExpenditureRules();

        IList<ExpenditureOverview> GetExpenditureOverview(GetDateRequest request);

        IList<ExpenditureOverview> GetExpenditureRuleOverview(GetDateRequest request);

        void SaveExpenditureRule(SaveExpenditureTypeRequest request);

        void ImportExpenditure(GetDateRequest request);

        void UpdateExpenditure(UpdateExpenditureRequest request);

        void UpdateExpenditureRule(UpdateExpenditureRuleRequest request);

        void Delete();
        
    }
}
