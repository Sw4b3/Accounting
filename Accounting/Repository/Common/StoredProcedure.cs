using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Common
{
    public static class SQLStoredProcedures
    {
        public const string getGetTransactionByDate = "spGetTransactionsByDate";
        public const string searchTransactionByDate = "spSearchTransactionsByDate";
        public const string saveTransaction = "spSaveTransaction";
        public const string saveTransactionStaging = "spSaveTransactionStaging";
        public const string updateTransaction = "spUpdateTransaction";
        public const string getGetAccounts = "spGetAccounts";
        public const string saveAccount = "spSaveAccount";
        public const string getAnalyticsOverview = "spGetAnalyticsOverview";
        public const string getAnalyticsByDay = "spGetAnalyticsByDay";
        public const string getAnalyticsByMonth = "spGetAnalyticsByMonth";
        public const string getAnalyticsStatistics = "spGetAnalyticsStatistics";
        public const string getMappings = "spGetMappings";
        public const string deleteTransaction= "spDeleteTransactionStaging";
        public const string getExpendituresByDate = "spGetExpendituresByDate";
        public const string saveExpenditure = "spSaveExpenditure";
    }
}
